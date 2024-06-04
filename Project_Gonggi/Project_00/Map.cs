using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Map
    {
        int[,] map = new int[_Limit.g_Limit_Position, _Limit.g_Limit_Position];


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
                    //Console.Write($"【{j},{i}】 ");
                    DrawTile(map[j,i]);
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

            // Enemy
            if (i >= 100)
            {
                _Set.SetTextColor("Enemy");
                s = "●";
            }
            // Player
            else if (i == 1)
            {
                _Set.SetTextColor("Player");
                s = "▲";
            }
            else
            {
                ;
            }
            Console.Write($"{s}");
            Console.ResetColor();
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
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = _Check.Check_TargetOnMap(i,j);
                }
            }
        }
    }
}
