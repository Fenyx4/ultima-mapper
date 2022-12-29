using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Windows.Interop;
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

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
        private Image img_room_tiles;
        dungeon dungeon;

        public Form1()
        {
            InitializeComponent();

            LoadTiles();
            img_room_tiles = new Bitmap("Tiles\\tiles.png");
            Bitmap image = new Bitmap((int)(8.0f * tile_size * tile_scale), (int)(8.0f * tile_size * tile_scale));
            pictureBox1.Image = image;
            LoadDungeonFiles();
            DrawLevel(1);
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

            if (str != null)
            {
                str.AddTile(tileNum, x_offset, y_offset);
            }

            if (tileNum >= 0xD0 && tileNum <= 0xDF)
            {
                g.DrawString((tileNum - 0xD0).ToString(), this.Font, Brushes.Black, x_offset, y_offset);
            }
        }

        private void DrawLevel(int level_num) {
            level l = dungeon.GetLevel(level_num - 1, drawStyle);
            List<List<byte>> level_data = l.resultingMap;

            Bitmap image = new Bitmap((int)(level_data.Count * tile_size * tile_scale), (int)(level_data[0].Count * tile_size * tile_scale));
            imgMapper = new Imagemapper();
            imgMapper.Init(dungeon.name, level_num);

            List<int> roomlist = new List<int>();

            for (int i = 0; i < level_data.Count; i++)
            {
                for( int j = 0; j < level_data[i].Count; j++)
                {
                    byte tile = level_data[i][j];
                    DrawTile(image, i, j, tile, imgMapper);
                    if (tile >= 0xD0 && tile <= 0xDF)
                    {
                        roomlist.Add(tile - 0xD0);
                    }
                }
            }
            roomlist.Sort();
            lstRooms.Items.Clear();
            roomlist.ForEach(e => lstRooms.Items.Add("Room " + e));
            if (lstRooms.Items.Count > 0)
            {
                lstRooms.SelectedIndex = 0;
            }

            pictureBox1.Image = image;

            imgMapper.Footer();

            textBox1.Text = imgMapper.Export();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFile = cmbDungeons.Text.ToUpper() + ".DNG";
            dungeon = new dungeon("Maps\\" + currentFile, drawStyle);

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
                str.Append(dungeon.name);
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
            //BinaryReader worldMap = new BinaryReader(new FileStream("Maps\\CHARSET.EGA", FileMode.Open));
            BinaryReader worldMap = new BinaryReader(new FileStream("Maps\\SHAPES.EGA", FileMode.Open));

            byte[] charset = worldMap.ReadBytes(size);

            worldMap.Close();

            Bitmap image = new Bitmap(8, 8*(122+32));
            //Bitmap image = new Bitmap(8 * 16, 8 * 16);

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
                //image.SetPixel((i * 2+1) % 8, (i * 2+1) / 8, pixel);
                image.SetPixel((i * 2 + 1) % 8, (i * 2 + 1) / 8, pixel);
            }

            pictureBox1.Image = image;
            BitmapSource bSource = Imagemapper.BitmapToSource(image);
            FileStream stream = new FileStream("layer0.png", FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();

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

        private void lstRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(11 * 16 * 2, 11 * 16 * 2);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            picRoom.Image = image;
            byte b;

            if (lstRooms.Items.Count > 0)
            {
                int room_id = int.Parse(lstRooms.SelectedItem.ToString().Replace("Room ", ""));

                for(int y = 0; y < 11; y ++)
                {
                    for (int x = 0; x < 11; x ++) {
                        b = dungeon.rooms[room_id].room_tiles[x, y];
                        DrawRoomTile(image, x, y, b);
                    }
                }
                picRoom.Image = image;
            }
        }
        private void DrawRoomTile(Bitmap image, int x, int y, int tileNum)
        {
            int x_offset = (int)(x * tile_size * tile_scale);
            int y_offset = (int)(y * tile_size * tile_scale);

            int cx = tileNum % 16;
            int cy = tileNum / 16;
            
            Rectangle cloneRect = new Rectangle(cx * 16, cy * 16, 15, 15);
            Image tile = new Bitmap(32, 32);
            Graphics t = Graphics.FromImage(tile);
            t.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            t.DrawImage(img_room_tiles, 0, 0, cloneRect, GraphicsUnit.Pixel);
                       
            Graphics g = Graphics.FromImage(image);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.DrawImage(tile, x_offset, y_offset, 26 * tile_scale, 26 * tile_scale);

        }
    }
}
