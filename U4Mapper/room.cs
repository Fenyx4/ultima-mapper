using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4Mapper
{
    internal class room
    {
        public int index;
        public int room_num;
        public List<room_trigger> triggers;
        public byte[,] room_tiles;
        public List<room_monster> monsters;
        public List<room_start_position> start_positions;

        public room(int room_index, byte[] room_data)
        {
            int bSize = 0;
            int bPos = 0;
            room_monster m;
            room_trigger _t;

            index = room_index;
            room_num = room_index % 16;

            triggers = new List<room_trigger>();
            monsters= new List<room_monster>();
            room_tiles = new byte[11, 11];
            start_positions = new List<room_start_position>();

            //read triggers
            bSize = 4;
            for (int i = 0; i < 4; i++)
            {
                _t = new room_trigger(room_data, bPos + (bSize * i));
                if (_t.tile_num > 0) { triggers.Add(_t); }
            }
            bPos = bSize * 4;

            //read monsters
            bSize = 1;
            for (int i = 0; i < 16; i++)
            {
                m = new room_monster(room_data, bPos + (bSize * i));
                if (m.monster_type_id > 0)
                {
                    monsters.Add(m);
                }
            }
            bPos += 16 * 3;

            //party starting positions
            bSize = 16;
            for (int i = 0; i < 8; i++)
            {
                start_positions.Add(new room_start_position(i, DirectionEnum.north, room_data, bPos + i + (bSize * 0)));
            }
            for (int i = 0; i < 8; i++)
            {
                start_positions.Add(new room_start_position(i, DirectionEnum.east, room_data, bPos + i + (bSize * 1)));
            }
            for (int i = 0; i < 8; i++)
            {
                start_positions.Add(new room_start_position(i, DirectionEnum.south, room_data, bPos + i + (bSize * 2)));
            }
            for (int i = 0; i < 8; i++)
            {
                start_positions.Add(new room_start_position(i, DirectionEnum.west, room_data, bPos + i + (bSize * 3)));
            }
            bPos += 8 * 8;

            //room tiles
            for (int x = 0; x < 11; x++)
            {
                for(int y= 0; y < 11; y ++)
                {
                    try
                    {
                        room_tiles[x, y] = room_data[bPos + x + (y * 11)];
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

        }
    }
}
