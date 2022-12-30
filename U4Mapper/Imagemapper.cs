using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace U4Mapper
{
    internal class Imagemapper
    {

        private StringBuilder str;
        private string dungeon_name;
        private int level_num;

        public void Init(string DungeonName, int LevelNum)
        {
            str = new StringBuilder();
            dungeon_name = DungeonName;
            level_num = LevelNum;

            Header();
        }

        public void Header()
        {
            str.AppendLine("<imagemap>");
            str.Append("Image:U4-");
            str.Append(dungeon_name);
            str.Append("-L");
            str.Append(level_num);
            str.Append(".png|thumb|center|555px|alt=");
            str.Append(dungeon_name);
            str.Append(" Level ");
            str.Append(level_num);
            str.Append("|");
            str.Append(dungeon_name);
            str.Append(" Level ");
            str.Append(level_num);
            str.AppendLine(" - Click locations on the map for more details");
            str.AppendLine("");
        }
        public void Footer()
        {
            str.AppendLine("");
            str.AppendLine("desc bottom-left");
            str.AppendLine("</imagemap>");
        }

        public void AddTile(int tileNum, int x_offset, int y_offset)
        {
            switch (tileNum)
            {
                case 0x10: // Ladder Up
                    if (level_num != 1)
                    {
                        writeRect(str, x_offset, y_offset);
                        str.Append("[[");
                        str.Append(dungeon_name);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(dungeon_name);
                        str.Append("-L");
                        str.Append((level_num - 1).ToString());
                        str.AppendLine("]]");
                    }
                    else
                    {
                        writeRect(str, x_offset, y_offset);
                        str.Append("[[");
                        str.Append(dungeon_name);
                        str.AppendLine(" (Ultima IV)|Exit]]");
                    }
                    break;
                case 0x20: //Ladder Down
                    writeRect(str, x_offset, y_offset);
                    str.Append("[[");
                    str.Append(dungeon_name);
                    str.Append(" (Ultima IV)|U4-");
                    str.Append(dungeon_name);
                    str.Append("-L");
                    str.Append((level_num + 1).ToString());
                    str.AppendLine("]]");
                    break;
                case 0x30: //Up & Down ladder
                    if (level_num == 1)
                    {
                        writeRect(str, x_offset, y_offset);
                        str.Append("[[");
                        str.Append(dungeon_name);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(dungeon_name);
                        str.Append("-L");
                        str.Append((level_num + 1).ToString());
                        str.AppendLine("]]");
                    }
                    else
                    {
                        writeRect(str, x_offset + 8, y_offset + 8, x_offset + 16, y_offset + 16);
                        str.Append("[[");
                        str.Append(dungeon_name);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(dungeon_name);
                        str.Append("-L");
                        str.Append((level_num + 1).ToString());
                        str.AppendLine("]]");

                        writeRect(str, x_offset, y_offset, x_offset + 8, y_offset + 8);
                        str.Append("[[");
                        str.Append(dungeon_name);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(dungeon_name);
                        str.Append("-L");
                        str.Append((level_num - 1).ToString());
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
                    if (dungeon_name.ToUpper() != "ABYSS")
                    {
                        writeRect(str, x_offset, y_offset);
                        str.AppendLine("[[Virtue Stones]]");
                    }
                    else if (level_num != 8)
                    {
                        writeRect(str, x_offset, y_offset);
                        str.Append("[[");
                        str.Append(dungeon_name);
                        str.Append(" (Ultima IV)|U4-");
                        str.Append(dungeon_name);
                        str.Append("-L");
                        str.Append((level_num + 1).ToString());
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
                    str.Append(dungeon_name);
                    str.Append("-L");
                    str.Append(level_num);
                    str.Append("-");
                    str.Append("Room-");
                    str.Append((tileNum - 0xD0).ToString());
                    str.AppendLine("]]");
                    break;
            }
        }

        public string Export()
        {
            return str.ToString();
        }

        public void Export(StreamWriter allFormat, Image dungeon_image, ref TextBox output_text)
        {
            StringBuilder str = new StringBuilder();
            str.Append("U4-");
            str.Append(dungeon_name);
            str.Append("-L");
            str.Append(level_num);
            //str.Append(".png");

            Bitmap blah = (Bitmap)dungeon_image;
            BitmapSource image = BitmapToSource(blah);
            FileStream stream = new FileStream(str.ToString() + ".png", FileMode.Create);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            //TextBlock myTextBlock = new TextBlock();
            //myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Interlace = PngInterlaceOption.On;
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
            stream.Close();

            FileStream fs = new FileStream(str.ToString() + ".txt", FileMode.Create, FileAccess.Write, FileShare.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(output_text.Text);
            if (allFormat != null)
            {
                //{| style="display:inline"
                //|
                allFormat.WriteLine("{| style=\"display:inline\"");
                allFormat.Write("| ");
                allFormat.WriteLine(output_text.Text);
                allFormat.WriteLine("|}");
            }
            sw.Close();
            fs.Close();


        }
        public static BitmapSource BitmapToSource(System.Drawing.Bitmap bitmap)
        {
            BitmapSource destination;
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();
            destination = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, sizeOptions);
            destination.Freeze();
            return destination;
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


    }
}
