using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4Mapper
{
    internal class room_monster
    {
        public TileEnum monster_type_id;
        public Point start_pos;

        public room_monster(byte[] monster_data, int offset)
        {
            monster_type_id = (TileEnum)Enum.Parse(typeof(TileEnum), monster_data[0 + offset].ToString());
            start_pos = new Point(monster_data[16 + offset], monster_data[32 + offset]);
        }
    }
}
