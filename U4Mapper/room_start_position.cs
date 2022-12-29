using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4Mapper
{
    internal class room_start_position
    {
        public int party_member_id;
        public DirectionEnum direction;
        public Point start_pos;

        public room_start_position(int id, DirectionEnum dir, byte[] position_data, int offset)
        {
            party_member_id = id;
            direction = dir;
            start_pos = new Point(position_data[0 + offset], position_data[8 + offset]);

            //Debug.WriteLine(dir.ToString() + " " + start_pos.ToString());
        }
    }
}
