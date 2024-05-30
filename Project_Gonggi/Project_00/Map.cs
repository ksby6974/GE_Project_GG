using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Map
    {
        int[,] map = new int [20,20];


        public Map()
        {
            InitMap();
        }

        // 맵 그리기
        public void DrawMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                map[i, 0] = i;

                for (int j = 0; j < map.GetLength(1); j++)
                {
                    DrawTile(map[i,j]);
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
    }
}
