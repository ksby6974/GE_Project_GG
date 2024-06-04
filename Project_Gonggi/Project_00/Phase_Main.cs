using Project_GG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Phase_Main
    {
        public void Update(int iStart)
        {
            // 선제 출력
            QuickDraw.DrawLine("Turn", 0, Phase.g_iTurn);
            QuickDraw.DrawLine("Enemy", 1);
            Phase.currentmap.DrawMap();
            QuickDraw.DrawLine("Player", 1);

            // 명령 입력 UI
            CommandPhase(Phase.g_cmd);

            // 플레이어 입력
            Phase.g_cmd = CommandAction(Phase.g_cmd);
        }

        static public void CommandPhase(int iCmd)
        {
            switch (iCmd)
            {
                // 덱 확인
                case 1:
                    break;

                default:
                    //int iResult = 0;

                    QuickDraw.DrawLine("Cmd", 2);
                    Console.WriteLine($"[D] 덱 확인");
                    Console.WriteLine($"[{2}] 맵 확인");
                    Console.WriteLine($"[{3}] 대상 확인");
                    break;
           }
        }

        public int CommandAction(int iCmd)
        {
            int iResult = 1;
            int iPlayer = _Check.Check_SearchPlayer();
            int iPx = Phase.aTargets[iPlayer].x;
            int iPy = Phase.aTargets[iPlayer].y;

            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

           
            //if (iCmd == 0)
            switch (key.Key)
            {

                // 조작
                case ConsoleKey.UpArrow:
                    iResult = _Limit.Limit_PlayerPosition_CMD(iPx, iPy - 1);
                    break;

                case ConsoleKey.DownArrow:
                    iResult = _Limit.Limit_PlayerPosition_CMD(iPx, iPy + 1);
                    break;

                case ConsoleKey.LeftArrow:
                    iResult = _Limit.Limit_PlayerPosition_CMD(iPx - 1, iPy);
                    break;

                case ConsoleKey.RightArrow:
                    iResult = _Limit.Limit_PlayerPosition_CMD(iPx + 1, iPy);
                    break;

                // 
                case ConsoleKey.D:
                    Phase.g_cmd = 1;
                    Phase.aTargets[iPlayer].targetdeck.Show_Deck();
                    iResult = -1;
                    break;

                default:
                    Console.WriteLine($"{key.Key}");
                    iResult = -1;
                    break;
            }

            Console.WriteLine($"명령 반환:{iResult}, {key.Key}");
            return iResult;
        }
    }
}