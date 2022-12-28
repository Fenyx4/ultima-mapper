using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace U4Mapper
{
    public partial class Form1 : Form
    {
        private const float tile_size = 16.0f;
        private float tile_scale = 1.0f;
        private Dictionary<int,Bitmap> tiles;
        private String currentFile = "";
        private string maps_path = "Maps\\";
        private bool drawStyle = false;
        private int level = 1;
        private Imagemapper imgMapper = new Imagemapper();

        public Form1()
        {
            InitializeComponent();

            LoadTiles();
            Bitmap image = new Bitmap((int)(8.0f * tile_size * tile_scale), (int)(8.0f * tile_size * tile_scale));
            pictureBox1.Image = image;
            LoadDungeonFiles();
            DrawLevel(1);
            //LoadWorldMap();
            //DrawCharset();
        }

        private void LoadDungeons()
        {
            cmbDungeons.Items.Add("Abyss");
            cmbDungeons.Items.Add("Covetous");
            cmbDungeons.Items.Add("Deceit");
            cmbDungeons.Items.Add("Despise");
            cmbDungeons.Items.Add("Destard");
            cmbDungeons.Items.Add("Hythloth");
            cmbDungeons.Items.Add("Shame");
            cmbDungeons.Items.Add("Wrong");

            cmbDungeons.SelectedIndex = 0;

            currentFile = "ABYSS.DNG";
        }

        private void LoadTiles()
        {
            tiles = new Dictionary<int, Bitmap>();
            Bitmap tile = new Bitmap("Tiles\\wall.bmp");
            tiles.Add(0xF0, tile);
            tile = new Bitmap("Tiles\\ladderup.bmp");
            tiles.Add(0x10, tile);
            tile = new Bitmap("Tiles\\corridor.bmp");
            tiles.Add(0x00, tile);
            tile = new Bitmap("Tiles\\ladderdown.bmp");
            tiles.Add(0x20, tile);
            tile = new Bitmap("Tiles\\updown.bmp");
            tiles.Add(0x30, tile);
            tile = new Bitmap("Tiles\\chest.bmp");
            tiles.Add(0x40, tile);
            tile = new Bitmap("Tiles\\orb.bmp");
            tiles.Add(0x70, tile);
            tile = new Bitmap("Tiles\\winds.bmp");
            tiles.Add(0x80, tile);
            tile = new Bitmap("Tiles\\rock.bmp");
            tiles.Add(0x81, tile);
            tile = new Bitmap("Tiles\\pit.bmp");
            tiles.Add(0x8E, tile);
            tile = new Bitmap("Tiles\\plainFo.bmp");
            tiles.Add(0x90, tile);
            tile = new Bitmap("Tiles\\healFo.bmp");
            tiles.Add(0x91, tile);
            tile = new Bitmap("Tiles\\acidFo.bmp");
            tiles.Add(0x92, tile);
            tile = new Bitmap("Tiles\\cureFo.bmp");
            tiles.Add(0x93, tile);
            tile = new Bitmap("Tiles\\poisonFo.bmp");
            tiles.Add(0x94, tile);
            tile = new Bitmap("Tiles\\poisonFi.bmp");
            tiles.Add(0xA0, tile);
            tile = new Bitmap("Tiles\\lightningFi.bmp");
            tiles.Add(0xA1, tile);
            tile = new Bitmap("Tiles\\fireFi.bmp");
            tiles.Add(0xA2, tile);
            tile = new Bitmap("Tiles\\sleepFi.bmp");
            tiles.Add(0xA3, tile);
            tile = new Bitmap("Tiles\\altar.bmp");
            tiles.Add(0xB0, tile);
            tile = new Bitmap("Tiles\\door.bmp");
            tiles.Add(0xC0, tile);
            tile = new Bitmap("Tiles\\room.bmp");
            tiles.Add(0xD0, tile);
            tiles.Add(0xD1, tile);
            tiles.Add(0xD2, tile);
            tiles.Add(0xD3, tile);
            tiles.Add(0xD4, tile);
            tiles.Add(0xD5, tile);
            tiles.Add(0xD6, tile);
            tiles.Add(0xD7, tile);
            tiles.Add(0xD8, tile);
            tiles.Add(0xD9, tile);
            tiles.Add(0xDA, tile);
            tiles.Add(0xDB, tile);
            tiles.Add(0xDC, tile);
            tiles.Add(0xDD, tile);
            tiles.Add(0xDE, tile);
            tiles.Add(0xDF, tile);
            tile = new Bitmap("Tiles\\secretdoor.bmp");
            tiles.Add(0xE0, tile);
            tile = new Bitmap("Tiles\\error.bmp");
            tiles.Add(0xFF, tile);
        }

        private void DrawTile(Bitmap image, int x, int y, int tileNum, Imagemapper str)
        {
            int x_offset = (int)(x * tile_size * tile_scale);
            int y_offset = (int)(y * tile_size * tile_scale);

            Bitmap tile = tiles[0xFF];
            if (tiles.ContainsKey(tileNum))
            {
                tile = tiles[tileNum];
            }

            Graphics g = Graphics.FromImage(image);
            g.DrawImage(tile, x_offset, y_offset, tile_size * tile_scale, tile_size * tile_scale);

            str.AddTile(tileNum, x_offset, y_offset);

            if (tileNum >= 0xD0 && tileNum <= 0xDF)
            {
                //g.DrawImage(tile, x_offset, y_offset, tile_size * tile_scale, tile_size * tile_scale);
                g.DrawString((tileNum - 0xD0).ToString(), this.Font, Brushes.Black, x_offset, y_offset);

                lstRooms.Items.Add("Room " + (tileNum - 0xD0));
            }
        }

        public List<List<byte>> LoadLevel(int level)
        {
            level = level - 1;

            BinaryReader bReader = new BinaryReader(new FileStream("Maps\\" + currentFile, FileMode.Open));

            bReader.ReadBytes(8 * 8 * level);

            byte[] levelArr = bReader.ReadBytes(8 * 8);

            bReader.Close();
            bool[] levelDrawn = new bool[8 * 8];
            for (int i= 0; i < levelDrawn.Length; i++)
            {
                levelDrawn[i] = false;
            }

            List<List<byte>> resultingMap = new List<List<byte>>();

            if (drawStyle)
            {
                for (int i = 0; i < 8; i++)
                {
                    resultingMap.Add(new List<byte>());
                    for (int j = 0; j < 8; j++)
                    {
                        resultingMap[i].Add(0x00);
                    }
                }
                for (int i = 0; i < levelArr.Length; i++)
                {
                    resultingMap[i % 8][i / 8] = levelArr[i];
                }
            }
            else
            {

                Point startPt = new Point(0, 0);
                Point? adjustPt = null;
                // find an undrawn non-wall
                for (int i = 0; i < levelDrawn.Length; i++)
                {
                    if (!levelDrawn[i] && levelArr[i] != 0xF0)
                    {
                        adjustPt = FollowCorridor(i, levelDrawn, levelArr, resultingMap, startPt);
                        startPt.Offset(adjustPt.Value);
                    }

                    // If we've found something need to start moving the startPt
                    if (adjustPt != null)
                    {
                        if ((i + 1) % 8 == 0)
                        {
                            startPt.X -= 7;
                            startPt.Y += 1;
                        }
                        else
                        {
                            startPt.X += 1;
                        }

                        // try to keep it nestled
                        //startPt.Y = startPt.Y % 8;
                        //startPt.X = startPt.X % 8;
                    }
                }
            }
            return resultingMap;
        }

        private Point FollowCorridor(int startingPoint, bool[] levelDrawn, byte[] levelArr, List<List<byte>> resultingMap, Point startPt)
        {
            //If it is already drawn then bail
            if (levelDrawn[startingPoint])
            {
                return new Point(0,0);
            }

            Point adjust = new Point(0,0);
            while (startPt.X < 0)
            {
                int lengthy = 0;
                if (resultingMap.Count != 0)
                {
                    lengthy = resultingMap[0].Count;
                }
                resultingMap.Insert(0,new List<byte>());
                adjust.X += 1;
                startPt.X += 1;
                
                for (int i = 0; i < lengthy; i++)
                {
                    resultingMap[0].Add(0x00);
                }
            }
            while (startPt.X >= resultingMap.Count)
            {
                int lengthy = 0;
                if (resultingMap.Count != 0)
                {
                    lengthy = resultingMap[0].Count;
                }
                resultingMap.Add(new List<byte>());

                for (int i = 0; i < lengthy; i++)
                {
                    resultingMap[resultingMap.Count-1].Add(0x00);
                }
            }

            while (startPt.Y < 0)
            {
                foreach (List<byte> ys in resultingMap)
                {
                    ys.Insert(0, 0x00);
                }
                adjust.Y += 1;
                startPt.Y += 1;
            }
            while (startPt.Y >= resultingMap[0].Count)
            {
                foreach (List<byte> ys in resultingMap)
                {
                    ys.Add(0x00);
                }
            }

            //startPt.Offset(adjust);

            //I've now shifted everything so I can fit
            //Add the tile I'm here to add
            resultingMap[startPt.X][startPt.Y] = levelArr[startingPoint];

            //If it isn't a wall then we keep recursing
            if (levelArr[startingPoint] != 0xF0)
            {
                levelDrawn[startingPoint] = true;

                Point subAdjust = new Point(0, 0);
                if (startingPoint % 8 - 4 > 0)
                {
                    subAdjust = FollowCorridor(West(startingPoint), levelDrawn, levelArr, resultingMap, new Point(startPt.X - 1, startPt.Y));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                    subAdjust = FollowCorridor(East(startingPoint), levelDrawn, levelArr, resultingMap, new Point(startPt.X + 1, startPt.Y));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                }
                else
                {
                    subAdjust = FollowCorridor(East(startingPoint), levelDrawn, levelArr, resultingMap, new Point(startPt.X + 1, startPt.Y));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                    subAdjust = FollowCorridor(West(startingPoint), levelDrawn, levelArr, resultingMap, new Point(startPt.X - 1, startPt.Y));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                }
                if (startingPoint / 8 - 4 > 0)
                {
                    subAdjust = FollowCorridor(South(startingPoint), levelDrawn, levelArr, resultingMap, new Point(startPt.X, startPt.Y + 1));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                    subAdjust = FollowCorridor(North(startingPoint), levelDrawn, levelArr, resultingMap, new Point(startPt.X, startPt.Y - 1));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                }
                else
                {
                    subAdjust = FollowCorridor(South(startingPoint), levelDrawn, levelArr, resultingMap, new Point(startPt.X, startPt.Y + 1));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                    subAdjust = FollowCorridor(North(startingPoint), levelDrawn, levelArr, resultingMap, new Point(startPt.X, startPt.Y - 1));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                }
                if (levelArr[South(East(startingPoint))] == 0xF0)
                {
                    subAdjust = FollowCorridor(South(East(startingPoint)), levelDrawn, levelArr, resultingMap, new Point(startPt.X + 1, startPt.Y + 1));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                }
                if (levelArr[North(East(startingPoint))] == 0xF0)
                {
                    subAdjust = FollowCorridor(North(East(startingPoint)), levelDrawn, levelArr, resultingMap, new Point(startPt.X + 1, startPt.Y - 1));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                }
                if (levelArr[South(West(startingPoint))] == 0xF0)
                {
                    subAdjust = FollowCorridor(South(West(startingPoint)), levelDrawn, levelArr, resultingMap, new Point(startPt.X - 1, startPt.Y+1));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                }
                if (levelArr[North(West(startingPoint))] == 0xF0)
                {
                    subAdjust = FollowCorridor(North(West(startingPoint)), levelDrawn, levelArr, resultingMap, new Point(startPt.X - 1, startPt.Y - 1));
                    adjust.Offset(subAdjust);
                    startPt.Offset(subAdjust);
                }
            }
            return adjust;
        }

        private int East(int startingPoint)
        {
            int y = startingPoint / 8;
            int x = (startingPoint + 1) % 8;

            return y * 8 + x;
        }

        private int West(int startingPoint)
        {
            int y = startingPoint / 8;
            int x = (startingPoint + 7) % 8;

            return y * 8 + x;
        }

        private int South(int startingPoint)
        {
            int ret = (startingPoint + 8)%64;

            return ret;
        }

        private int North(int startingPoint)
        {
            int ret = startingPoint - 8;
            if (ret < 0)
            {
                ret += 64;
            }

            return ret;
        }

        private void DrawLevel(int level)
        {
            lstRooms.Items.Clear();
            DrawLevel(level, LoadLevel(level));
        }
        private void DrawLevel(int levelNum, List<List<byte>> level)
        {
            if(level.Count == 0 || level[0].Count == 0)
            {
                //Nothing to draw
                return;
            }
            Bitmap image = new Bitmap((int)(level.Count * tile_size * tile_scale), (int)(level[0].Count * tile_size * tile_scale));
            imgMapper = new Imagemapper();
            imgMapper.Init(cmbDungeons.Text, levelNum);
            
            for (int i = 0; i < level.Count; i++)
            {
                for( int j = 0; j < level[i].Count; j++)
                {
                    byte tile = level[i][j];
                    DrawTile(image, i, j, tile, imgMapper);
                }
            }
            
            pictureBox1.Image = image;

            imgMapper.Footer();

            textBox1.Text = imgMapper.Export();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFile = cmbDungeons.Text.ToUpper() + ".DNG";
            level = 1;
            DrawLevel(level);
            lstLevels.SetSelected(0, true);
        }
                
        private void button3_Click(object sender, EventArgs e)
        {
            drawStyle = !drawStyle;
            DrawLevel(level);
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cmbDungeons.Items.Count; i++)
            {
                cmbDungeons.SelectedIndex = i;
                StringBuilder str = new StringBuilder();
                str.Append("U4-");
                str.Append(cmbDungeons.Text);
                str.Append("-L");
                str.Append(level.ToString());
                str.Append("-All.txt");
                FileStream fs = new FileStream(str.ToString(), FileMode.Create, FileAccess.Write, FileShare.Write);
                StreamWriter sw = new StreamWriter(fs);
                for (int j = 1; j <= 8; j++)
                {
                    level = j;
                    DrawLevel(level);
                    imgMapper.Export(null, pictureBox1.Image, ref textBox1);
                }
                sw.Close();
                fs.Close();
            }
            
        }

        private void Export()
        {
            imgMapper.Export();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void DrawCharset()
        {
            int size = (8/2)*(8/2)*(122+32);
            System.IO.BinaryReader worldMap = new System.IO.BinaryReader(new System.IO.FileStream("Maps\\CHARSET.EGA", System.IO.FileMode.Open));

            byte[] charset = worldMap.ReadBytes(size);

            worldMap.Close();

            Bitmap image = new Bitmap(8, 8*(122+32));

            int nibble;
            Color pixel;
            for( int i = 0; i < size; i++)
            {
                nibble = charset[i];
                nibble = nibble >> 4;
                pixel = CharsetColor(nibble);
                 
                //pixel = Color.FromArgb((nibble & 0x20) << 2, (nibble & 0x40) << 1, (nibble & 0x80));
                //pixel = Color.FromArgb(nibble);
                image.SetPixel((i*2) % 8, (i*2) / 8,pixel);
                nibble = charset[i] & 0x0F;
                //pixel = Color.FromArgb((nibble & 0x2) << 6, (nibble & 0x4) << 5, (nibble & 0x8) << 4);
                pixel = CharsetColor(nibble);
                image.SetPixel((i * 2+1) % 8, (i * 2+1) / 8, pixel);
            }

            pictureBox1.Image = image;
            BitmapSource bSource = Imagemapper.BitmapToSource(image);
            FileStream stream = new FileStream("layer0.png", FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //TextBlock myTextBlock = new TextBlock();
            //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Frames.Add(BitmapFrame.Create(bSource));
            encoder.Save(stream);
            stream.Close();
        }

        private Color CharsetColor(int nibble)
        {
            Color pixel;
            if (nibble == 0)
            {
                pixel = Color.FromArgb(0, 0, 0);
            }
            // Red
            else if (nibble == 4)
            {
                pixel = Color.FromArgb(170, 0, 0);
            }
            // Grey
            else if (nibble == 7)
            {
                pixel = Color.FromArgb(170, 170, 170);
            }
            else if (nibble == 9)
            {
                // Blue
                pixel = Color.FromArgb(85, 85, 255);
            }
            else
            {
                pixel = Color.FromArgb(170, 170, 170);
            }

            return pixel;
        }

        private byte[][] LoadWorldMap()
        {
    	    byte[][] world = new byte[256][];

            for (int i = 0; i < 256; i++)
            {
                world[i] = new byte[256];
            }
    	
    	    try {
    		    int chunkwidth = 32;
    		    int chunkSize = chunkwidth*chunkwidth;
    		    byte[] chunk; // = new byte[chunkSize];
                BinaryReader worldMap = new BinaryReader(new FileStream("Maps\\WORLD.MAP", FileMode.Open));
    			
			    for(int chunkCount = 0; chunkCount < 64; chunkCount++)
			    {
                    chunk = worldMap.ReadBytes(chunkSize);
    			
				    // Copy the chunk over
				    for(int i = 0; i < chunkSize; i++)
				    {
					    world[i%chunkwidth + chunkCount%8*chunkwidth][i/chunkwidth + chunkCount/8*chunkwidth]=chunk[i];
				    }
			    }
    			
			    worldMap.Close();					
		    } catch (IOException e) {
			    // TODO Auto-generated catch block
			    //e.printStackTrace();
		    }

            //Set up our levels
            Dictionary<int, Color> levels = new Dictionary<int, Color>();

            int water = 14*3*4-28-14-14;
            int level = 3;
            int diff = 0;
            /*
             * Water
             */
            // Deep water
            levels.Add(0, Color.FromArgb(water, water, water));
            // Normal water
            levels.Add(1, Color.FromArgb(water, water, water));
            // Shallow water
            levels.Add(2, Color.FromArgb(water, water, water));
            /*
             * Land
             */
            // Swamp
            diff = level * 6;
            levels.Add(3, Color.FromArgb(water + diff, water + diff, water + diff));
            // Grass
            levels.Add(4, Color.FromArgb(water + diff, water + diff, water + diff));
            // Shrub
            levels.Add(5, Color.FromArgb(water + diff, water + diff, water + diff));
            // Forest
            levels.Add(6, Color.FromArgb(water + diff, water + diff, water + diff));

            // Hill
            diff = diff + level * 5;
            levels.Add(7, Color.FromArgb(water + diff, water + diff, water + diff));

            // Mountain
            levels.Add(8, Color.FromArgb(water + diff, water + diff, water + diff));

            Bitmap image = new Bitmap(256,256);

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    Color pixel = Color.White;
                    // Grass
                    if (levels.ContainsKey(world[x][y]))
                    {
                        pixel = levels[world[x][y]];
                    }
                    //Color.FromArgb(world[x][y],0,0);
                    image.SetPixel(x, y, pixel);
                }
            }

            pictureBox1.Image = image;
            BitmapSource bSource = Imagemapper.BitmapToSource(image);
            FileStream stream = new FileStream( "layer0.png", FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //TextBlock myTextBlock = new TextBlock();
            //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Frames.Add(BitmapFrame.Create(bSource));
            encoder.Save(stream);
            stream.Close();

		    return world;
    }

        private void showWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadWorldMap();
        }

        private void LoadDungeonFiles()
        {
            foreach (string f in Directory.EnumerateFiles(maps_path, "*.dng"))
            {
                cmbDungeons.Items.Add(Path.GetFileNameWithoutExtension(f));

                if (currentFile == "") { 
                    currentFile = Path.GetFileName(f);
                    cmbDungeons.SelectedIndex = 0;
                }
            }
        }

        private void lstLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            level = lstLevels.SelectedIndex + 1;
            DrawLevel(level);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tile_scale = 1+(trackBar1.Value/4.0f);
            DrawLevel(level);
        }
    }
}
