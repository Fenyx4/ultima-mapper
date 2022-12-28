using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media.Imaging;

namespace U4Mapper
{
    public partial class Form1 : Form
    {
        private const float tile_size = 16.0f;
        private float tile_scale = 1.0f;
        private Dictionary<int,Bitmap> tiles;
        private String currentFile;

        public Form1()
        {
            InitializeComponent();

            LoadTiles();
            Bitmap image = new Bitmap((int)(8.0f * tile_size * tile_scale), (int)(8.0f * tile_size * tile_scale));
            pictureBox1.Image = image;
            LoadDungeons();
            DrawLevel(1);

            //LoadWorldMap();
            //DrawCharset();
        }

        private void LoadDungeons()
        {
            comboBox1.Items.Add("Abyss");
            comboBox1.Items.Add("Covetous");
            comboBox1.Items.Add("Deceit");
            comboBox1.Items.Add("Despise");
            comboBox1.Items.Add("Destard");
            comboBox1.Items.Add("Hythloth");
            comboBox1.Items.Add("Shame");
            comboBox1.Items.Add("Wrong");

            comboBox1.SelectedIndex = 0;

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

        private void DrawTile(Bitmap image, int x, int y, int tileNum, StringBuilder str)
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

            switch (tileNum)
            {
                case 0x10: // Ladder Up
                    if (level != 1)
                    {
                        writeRect(str, x_offset, y_offset);
                        str.Append("[[");
                        str.Append(comboBox1.Text);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(comboBox1.Text);
                        str.Append("-L");
                        str.Append((level - 1).ToString());
                        str.AppendLine("]]");
                    }
                    else
                    {
                        writeRect(str, x_offset, y_offset);
                        str.Append("[[");
                        str.Append(comboBox1.Text);
                        str.AppendLine(" (Ultima IV)|Exit]]");
                    }
                    break;
                case 0x20: //Ladder Down
                    writeRect(str, x_offset, y_offset);
                    str.Append("[[");
                    str.Append(comboBox1.Text);
                    str.Append(" (Ultima IV)|U4-");
                    str.Append(comboBox1.Text);
                    str.Append("-L");
                    str.Append((level + 1).ToString());
                    str.AppendLine("]]");
                    break;
                case 0x30: //Up & Down ladder
                    if (level == 1)
                    {
                        writeRect(str, x_offset, y_offset);
                        str.Append("[[");
                        str.Append(comboBox1.Text);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(comboBox1.Text);
                        str.Append("-L");
                        str.Append((level + 1).ToString());
                        str.AppendLine("]]");
                    }
                    else
                    {
                        writeRect(str, x_offset+8, y_offset+8, x_offset+16, y_offset+16);
                        str.Append("[[");
                        str.Append(comboBox1.Text);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(comboBox1.Text);
                        str.Append("-L");
                        str.Append((level + 1).ToString());
                        str.AppendLine("]]");

                        writeRect(str, x_offset, y_offset, x_offset + 8, y_offset + 8);
                        str.Append("[[");
                        str.Append(comboBox1.Text);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(comboBox1.Text);
                        str.Append("-L");
                        str.Append((level - 1).ToString());
                        str.AppendLine("]]");
                    }
                    break;
                //case 0x40: Treasure Chest
                case 0x70: //Magic Orb
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Magic Orbs]]");
                    break;
                case 0x80: // Wind Trap
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Wind Trap]]");
                    break;
                case 0x81: // Pit Trap
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Pit Trap]]");
                    break;
                case 0x90: // Plain Fountain
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Fountain|Plain Fountain]]");
                    break;
                case 0x91: // Healing Fountain
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Fountain|Healing Fountain]]");
                    break;
                case 0x92: // Acid Fountain
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Fountain|Acid Fountain]]");
                    break;
                case 0x93: // Cure Fountain
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Fountain|Cure Fountain]]");
                    break;
                case 0x94: // Poison Fountain
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Fountain|Poison Fountain]]");
                    break;
                case 0xA0: // Poison Field
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Poison Field]]");
                    break;
                case 0xA1: // Energy Field
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Lightning Field]]");
                    break;
                case 0xA2: // Fire Field
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Fire Field]]");
                    break;
                case 0xA3: // Sleep Field
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Sleep Field]]");
                    break;
                case 0xB0: // Altar/Stone
                    if(currentFile != "ABYSS.DNG")
                    {
                        writeRect(str, x_offset, y_offset);
                        str.AppendLine("[[Virtue Stones]]");
                    }
                    else if( level != 8)
                    {
                        writeRect(str, x_offset, y_offset);
                        str.Append("[[");
                        str.Append(comboBox1.Text);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(comboBox1.Text);
                        str.Append("-L");
                        str.Append((level + 1).ToString());
                        str.AppendLine("]]");
                    }
                    break;
                case 0xE0: // Secret Door
                    writeRect(str, x_offset, y_offset);
                    str.AppendLine("[[Secret Door]]");
                    break;
                case 0xD0:
                case 0xD1:
                case 0xD2:
                case 0xD3:
                case 0xD4:
                case 0xD5:
                case 0xD6:
                case 0xD7:
                case 0xD8:
                case 0xD9:
                case 0xDA:
                case 0xDB:
                case 0xDC:
                case 0xDD:
                case 0xDE:
                case 0xDF:
                    writeRect(str, x_offset, y_offset);
                    str.Append("[[U4-");
                    str.Append(comboBox1.Text);
                    str.Append("-L");
                    str.Append(level.ToString());
                    str.Append("-");
                    str.Append("Room-");
                    str.Append((tileNum-0xD0).ToString());
                    str.AppendLine("]]");

                    //g.DrawImage(tile, x_offset, y_offset, tile_size * tile_scale, tile_size * tile_scale);
                    g.DrawString((tileNum - 0xD0).ToString(), this.Font, Brushes.Black, x_offset, y_offset);
                    break;
            }
        }

        private void writeRect(StringBuilder str, int x, int y)
        {
            writeRect(str, x, y, x + 16, y + 16);
        }
        private void writeRect(StringBuilder str, int x, int y, int x2, int y2)
        {
            str.Append("rect ");
            str.Append(x.ToString());
            str.Append(" ");
            str.Append(y.ToString());
            str.Append(" ");
            str.Append((x2).ToString());
            str.Append(" ");
            str.Append((y2).ToString());
            str.Append(" ");
        }

        public List<List<byte>> LoadLevel(int level)
        {
            level = level-1;
            //byte[] levelArr = new byte[8 * 8];

            System.IO.BinaryReader bReader = new System.IO.BinaryReader(new System.IO.FileStream("Maps\\"+ currentFile,System.IO.FileMode.Open));

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

        int _level = 1;
        private int level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
                label1.Text = _level.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            level = level % 8 +1;
            DrawLevel(level);
        }

        private void DrawLevel(int level)
        {
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
            StringBuilder str = new StringBuilder();
            str.AppendLine("<imagemap>");
            str.Append("Image:U4-");
            str.Append(comboBox1.Text);
            str.Append("-L");
            str.Append(levelNum.ToString());
            str.Append(".png|thumb|center|555px|alt=");
            str.Append(comboBox1.Text);
            str.Append(" Level ");
            str.Append(levelNum.ToString());
            str.Append("|");
            str.Append(comboBox1.Text);
            str.Append(" Level ");
            str.Append(levelNum.ToString());
            str.AppendLine(" - Click locations on the map for more details");
            str.AppendLine("");

            for (int i = 0; i < level.Count; i++)
            {
                for( int j = 0; j < level[i].Count; j++)
                {
                    byte tile = level[i][j];
                    DrawTile(image, i, j, tile, str);
                }
            }
            
            pictureBox1.Image = image;

            str.AppendLine("");
            str.AppendLine("desc bottom-left");
            str.AppendLine("</imagemap>");

            textBox1.Text = str.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFile = comboBox1.Text.ToUpper() + ".DNG";
            level = 1;
            DrawLevel(level);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            level = level - 1 % 8;
            if (level == 0)
            {
                level = 8;
            }
            DrawLevel(level);
        }

        private bool drawStyle = false;
        private void button3_Click(object sender, EventArgs e)
        {
            drawStyle = !drawStyle;
            DrawLevel(level);
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                comboBox1.SelectedIndex = i;
                StringBuilder str = new StringBuilder();
                str.Append("U4-");
                str.Append(comboBox1.Text);
                str.Append("-L");
                str.Append(level.ToString());
                str.Append("-All.txt");
                FileStream fs = new FileStream(str.ToString(), FileMode.Create, FileAccess.Write, FileShare.Write);
                StreamWriter sw = new StreamWriter(fs);
                for (int j = 1; j <= 8; j++)
                {
                    level = j;
                    DrawLevel(level);
                    Export(sw);
                }
                sw.Close();
                fs.Close();
            }
            
        }

        private void Export()
        {
            Export(null);
        }

        private void Export(StreamWriter allFormat)
        {
            StringBuilder str = new StringBuilder();
            str.Append("U4-");
            str.Append(comboBox1.Text);
            str.Append("-L");
            str.Append(level.ToString());
            //str.Append(".png");

            Bitmap blah = (Bitmap)pictureBox1.Image;
            BitmapSource image = _bitmapToSource(blah);
            FileStream stream = new FileStream(str.ToString() +".png", FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //TextBlock myTextBlock = new TextBlock();
            //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
            stream.Close();

            FileStream fs = new FileStream(str.ToString() + ".txt", FileMode.Create, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(textBox1.Text);
            if (allFormat != null)
            {
                //{| style="display:inline"
                //|
                allFormat.WriteLine("{| style=\"display:inline\"");
                allFormat.Write("| ");
                allFormat.WriteLine(textBox1.Text);
                allFormat.WriteLine("|}");
            }
            sw.Close();
            fs.Close();


        }

        private BitmapSource _bitmapToSource(System.Drawing.Bitmap bitmap)
        {
            BitmapSource destination;
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();
            destination = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, sizeOptions);
            destination.Freeze();
            return destination;
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
            BitmapSource bSource = _bitmapToSource(image);
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
                System.IO.BinaryReader worldMap = new System.IO.BinaryReader(new System.IO.FileStream("Maps\\WORLD.MAP", System.IO.FileMode.Open));
    			
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
            BitmapSource bSource = _bitmapToSource(image);
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

        private void numTileScale_ValueChanged(object sender, EventArgs e)
        {
            tile_scale = (float)numTileScale.Value;
            DrawLevel(level);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
