using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace U4Mapper
{
    internal class Room
    {
        public int index;
        public int room_num;
        public List<RoomTrigger> triggers;
        public byte[,] room_tiles;
        public List<RoomMonster> monsters;
        public List<RoomStartPosition> start_positions;

        public Room(int room_index, byte[] room_data)
        {
            int bSize = 0;
            int bPos = 0;
            RoomMonster m;
            RoomTrigger _t;

            index = room_index;
            room_num = room_index % 16;

            triggers = new List<RoomTrigger>();
            monsters= new List<RoomMonster>();
            room_tiles = new byte[11, 11];
            start_positions = new List<RoomStartPosition>();

            //read triggers
            bSize = 4;
            Debug.WriteLine("Room id: " + index);
            for (int i = 0; i < 4; i++)
            {
                _t = new RoomTrigger(room_data, bPos + (bSize * i));
                if (_t.tile_num > 0) { triggers.Add(_t); }
            }
            bPos = bSize * 4;

            //read monsters
            bSize = 1;
            for (int i = 0; i < 16; i++)
            {
                m = new RoomMonster(room_data, bPos + (bSize * i));
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
                start_positions.Add(new RoomStartPosition(i, DirectionEnum.north, room_data, bPos + i + (bSize * 0)));
            }
            for (int i = 0; i < 8; i++)
            {
                start_positions.Add(new RoomStartPosition(i, DirectionEnum.east, room_data, bPos + i + (bSize * 1)));
            }
            for (int i = 0; i < 8; i++)
            {
                start_positions.Add(new RoomStartPosition(i, DirectionEnum.south, room_data, bPos + i + (bSize * 2)));
            }
            for (int i = 0; i < 8; i++)
            {
                start_positions.Add(new RoomStartPosition(i, DirectionEnum.west, room_data, bPos + i + (bSize * 3)));
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

        public bool hasMonsters()
        {
            return monsters.Count > 0;
        }
        public bool hasTrigger1() { return triggers.Count > 0; }
        public bool hasTrigger2() { return triggers.Count > 1; }
        public bool hasTrigger3() { return triggers.Count > 2; }
        public bool hasTrigger4() { return triggers.Count > 3; }

        public List<RoomStartPosition> GetStartPositionsByDirection(DirectionEnum dir)
        {
            return start_positions.FindAll(e => e.direction == dir);
        }
    }
}
