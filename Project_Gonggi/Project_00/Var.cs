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
            int iBlank = _Limit.g_Limit_Blank;
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

            // 적의 상태창
            if (iWho == 2)
            {
                for (int i = 0; i < iBlank; i++)
                {
                    Console.WriteLine();
                }

            }
            for (int i = 0; i < _Limit.g_Limit_WindowWidth; i++)
            {
                int iTemp;

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
                            iTemp = _Check.Check_SearchPlayer();
                            DrawLine_Player(Phase.aTargets[iTemp].x, Phase.aTargets[iTemp].y);
                            break;

                        case 2:
                            iTemp = _Check.Check_SearchEnemy_First();
                            DrawLine_Enemy(Phase.aTargets[iTemp].x, Phase.aTargets[iTemp].y);
                            break;

                        default:
                            break;
                    }
                }

                Console.Write($"{s}");
            }

            Console.WriteLine();

            // 자신의 상태창
            if (iWho == 1)
            {
                // 플레이어 현재 패 보여주기
                int iPlayer = _Check.Check_SearchPlayer();
                Phase.aTargets[iPlayer].targetdeck.Shuffle_Draw();

                Phase.aTargets[iPlayer].targetdeck.Show_Hand();

                for (int i = 0; i < iBlank; i++) 
                {
                    Console.WriteLine();
                }
            }
        }

        static public void DrawLine_Player(int x, int y)
        {
            _Set.SetTextColor("Player");
            Console.Write($"【 Player : {x},{y}】");
            Console.ResetColor();
        }

        static public void DrawLine_Enemy(int x, int y)
        {
            _Set.SetTextColor("Enemy");
            Console.Write($"【 Enemy : {x},{y}】");
            Console.ResetColor();
        }

        static public void DrawLine_Turn(int i)
        {
            string sShow;

            switch (Phase.g_cmd)
            {
                case -1:
                    sShow = "명령 재시도 부여";

                    break;
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

            Console.Write($"【{sShow}:{Phase.g_cmd}】『Turn : {i}』");
        }

        static public void DrawLine_Cmd()
        {
            Console.Write($"【 Cmd 】");
        }
    }
}
