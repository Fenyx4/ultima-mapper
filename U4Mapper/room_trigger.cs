using System;
using System.Diagnostics;
using System.Drawing;

namespace U4Mapper
{
    internal class room_trigger
    {
        public TileEnum tile_num;
        public Point trigger_pos;
        public Point tile_1_pos;
        public Point tile_2_pos;

        public room_trigger(byte[] trigger_data, int offset)
        {
            tile_num = (TileEnum)trigger_data[0 + offset];
            if (tile_num > 0)
            {
                Debug.WriteLine(tile_num);
                if (tile_num == TileEnum.Daemon_1)
                {

                }
            }
            trigger_pos = PointFromHex(trigger_data[1 + offset]);
            tile_1_pos = PointFromHex(trigger_data[2 + offset]);
            tile_2_pos = PointFromHex(trigger_data[3 + offset]);
        }

        private Point PointFromHex(byte b)
        {
            if (b == 0) { return Point.Empty; }
            try
            {
                return new Point(HexToInt(b.ToString("X2")[0]), HexToInt(b.ToString("X2")[1]));
            }
            catch (Exception err)
            {

            }
            return Point.Empty;
        }

        private int HexToInt(char h)
        {
            if (Convert.ToInt32(h.ToString(), 16) > 7)
            {

            }
            return Convert.ToInt32(h.ToString(), 16);
        }
    }
}
