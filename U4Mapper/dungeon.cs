using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace U4Mapper
{
    internal class dungeon
    {
        public string name = "";
        public List<level> levels = new List<level>();
        public List<room> rooms = new List<room>();

        public dungeon(string file_path, bool is_normal_layout)
        {
            name = Path.GetFileNameWithoutExtension(file_path);

            BinaryReader bReader = new BinaryReader(new FileStream(file_path, FileMode.Open));

            //levels
            for (int i = 0; i < 8; i++)
            {
                levels.Add(new level(i, bReader.ReadBytes(8 * 8), is_normal_layout));
            }

            //rooms
            try {
                for (int i = 0; i < 16; i++) {
                    rooms.Add(new room(i, bReader.ReadBytes(256)));
                }
                if (name.ToUpper() == "ABYSS")
                {
                    for (int i = 16; i < 64; i++)
                    {
                        rooms.Add(new room(i, bReader.ReadBytes(256)));
                    }
                }
            }
            catch (Exception ex){
                
            }

            //room tiles


            bReader.Close();

        }

        public List<List<byte>> GetLevelByIndex(int index, bool is_normal_layout)
        {
            levels[index].DrawLevel(is_normal_layout);
            return levels[index].resultingMap;
        }
        public level GetLevel(int index, bool is_normal_layout)
        {
            levels[index].DrawLevel(is_normal_layout);
            return levels[index];
        }
    }
}
