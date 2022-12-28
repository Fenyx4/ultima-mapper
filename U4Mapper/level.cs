using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U4Mapper
{
    internal class level
    {
        private bool[] levelDrawn = new bool[8 * 8];
        private byte[] _level_data;
        private int _level_num;

        public List<List<byte>> resultingMap = new List<List<byte>>();

        public level(int level_num, byte[] level_data, bool is_normal_layout)
        {
            _level_data = level_data;
            _level_num = level_num;

            DrawLevel(is_normal_layout);
        }
        public int LevelNum()
        {
            return _level_num;
        }
        public void DrawLevel(bool is_normal_layout)
        {
            levelDrawn = new bool[8 * 8];
            resultingMap = new List<List<byte>>();

            if (is_normal_layout)
            {
                for (int i = 0; i < 8; i++)
                {
                    resultingMap.Add(new List<byte>());
                    for (int j = 0; j < 8; j++)
                    {
                        resultingMap[i].Add(0x00);
                    }
                }
                for (int i = 0; i < _level_data.Length; i++)
                {
                    resultingMap[i % 8][i / 8] = _level_data[i];
                }
            }
            else
            {

                Point startPt = new Point(0, 0);
                Point? adjustPt = null;
                // find an undrawn non-wall
                for (int i = 0; i < levelDrawn.Length; i++)
                {
                    if (!levelDrawn[i] && _level_data[i] != 0xF0)
                    {
                        adjustPt = FollowCorridor(i, levelDrawn, _level_data, resultingMap, startPt);
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
        }

        private Point FollowCorridor(int startingPoint, bool[] levelDrawn, byte[] levelArr, List<List<byte>> resultingMap, Point startPt)
        {
            //If it is already drawn then bail
            if (levelDrawn[startingPoint])
            {
                return new Point(0, 0);
            }

            Point adjust = new Point(0, 0);
            while (startPt.X < 0)
            {
                int lengthy = 0;
                if (resultingMap.Count != 0)
                {
                    lengthy = resultingMap[0].Count;
                }
                resultingMap.Insert(0, new List<byte>());
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
                    resultingMap[resultingMap.Count - 1].Add(0x00);
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
                    subAdjust = FollowCorridor(South(West(startingPoint)), levelDrawn, levelArr, resultingMap, new Point(startPt.X - 1, startPt.Y + 1));
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
            int ret = (startingPoint + 8) % 64;

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
    }
}
