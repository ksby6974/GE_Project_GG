using Project_GG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    static class QuickDraw
    {
        static public void DrawLine(string sValue = "default", int iValue = 0, int iTurn = 0)
        {
            int iWho = 0;
            switch (sValue)
            {
                case "Cmd":
                    iWho = -2;

                    break;
                case "Turn":
                    iWho = -1;
                    break;

                case "Player":
                    iWho = 1;
                    break;

                case "Enemy":
                    iWho = 2;
                    break;

                default:
                    break;
            }

            //
            int iResult = iValue;
            string s = "─";

            switch (iValue)
            {
                case 1:
                    s = "━";
                    break;

                case 2:
                    s = ":";
                    break;

                default:
                    s = "─";
                    break;
            }

            if (iWho == 2)
            {
                for (int i = 0; i < _Limit.g_Limit_Blank; i++)
                {
                    Console.WriteLine();
                }

            }
            for (int i = 0; i < _Limit.g_Limit_WindowWidth; i++)
            {
                if (i == 3)
                {
                    switch (iWho)
                    {
                        case -2:
                            DrawLine_Cmd();
                            break;

                        case -1:
                            DrawLine_Turn(iTurn);
                            break;

                        case 1:
                            //DrawLine_Player(Phase.player.x, Phase.player.y);
                            break;

                        case 2:
                            DrawLine_Enemy();
                            break;

                        default:
                            break;
                    }
                }

                Console.Write($"{s}");
            }

            Console.WriteLine();

            if (iWho == 1)
            {
                for (int i = 0; i < _Limit.g_Limit_Blank; i++) 
                {
                    Console.WriteLine();
                }
            }
        }

        static public void DrawLine_Player(int x, int y)
        {
            Console.Write($"【 Player : {x},{y}】");
        }

        static public void DrawLine_Enemy()
        {
            Console.Write($"【 Enemy 】");
        }

        static public void DrawLine_Turn(int i)
        {
            string sShow;

            switch (Phase.g_cmd)
            {
                case 0:
                    sShow = "플레이어 명령 대기중";
                    break;

                case 1:
                    sShow = "플레이어 덱 확인중";
                    break;

                default:
                    sShow = "default";
                    break;
            }

            Console.Write($"【{sShow}】『Turn : {i}』");
        }

        static public void DrawLine_Cmd()
        {
            Console.Write($"【 Cmd 】");
        }
    }
}
