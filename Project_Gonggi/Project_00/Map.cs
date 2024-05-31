using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Map
    {
        int[,] map = new int[12, 12];


        public Map()
        {
            InitMap();
        }

        public void CheckMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.WriteLine($"【{i},{j}】 : {map[i, j]}");
                }
            }
        }

        // 맵 그리기
        public void DrawMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {


                for (int j = 0; j < map.GetLength(1); j++)
                {
                    DrawTile(map[i, j]);
                }


                switch (i)
                {
                    case 4:
                        Console.Write($"\t [↑] 이동");
                        break;

                    case 5:
                        Console.Write($"\t [→] 이동");
                        break;

                    case 6:
                        Console.Write($"\t [←] 이동");
                        break;

                    case 7:
                        Console.Write($"\t [↓] 이동");
                        break;

                    default:
                        break;
                }
                Console.WriteLine($"");
            }
        }

        // 그리기
        public void DrawTile(int i)
        {
            string s = "·";

            switch (i)
            {
                // Player
                case 1:
                    s = "▲";
                    break;

                // None
                default:
                    break;
            }
            Console.Write($"{s}");
        }

        public void InitMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = -1;
                }
            }
        }

        public void Update()
        {
            int iPx = Phase.player.x;
            int iPy = Phase.player.y;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (iPx == i && iPy == j)
                    {
                        map[i, j] = 1;
                    }

                    else
                    {
                        map[i, j] = -1;
                    }
                }
            }
        }
    }
}
