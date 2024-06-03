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
            CommandAction(Phase.g_cmd);
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
                    Console.WriteLine($"[{1}] 덱 확인");
                    Console.WriteLine($"[{2}] 맵 확인");
                    break;
           }
        }

        public int CommandAction(int iCmd)
        {
            int iResult = 1;

            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

           
            //if (iCmd == 0)
            switch (key.Key)
            {
                // 조작
                case ConsoleKey.UpArrow:
                    //iResult = _Limit.Limit_PlayerPosition_CMD(Phase.player.x, Phase.player.y - 1);
                    break;

                case ConsoleKey.DownArrow:
                    //iResult = _Limit.Limit_PlayerPosition_CMD(Phase.player.x, Phase.player.y + 1);
                    break;

                case ConsoleKey.LeftArrow:
                    //iResult = _Limit.Limit_PlayerPosition_CMD(Phase.player.x - 1, Phase.player.y);
                    break;

                case ConsoleKey.RightArrow:
                    //iResult = _Limit.Limit_PlayerPosition_CMD(Phase.player.x + 1, Phase.player.y);
                    break;

                // 
                case ConsoleKey.NumPad1:
                    Phase.g_cmd = 1;
                    //Phase.player.targetdeck.ShowDeck();
                    break;

                case ConsoleKey.NumPad2:
                    Phase.g_cmd = 1;
                    Phase.currentmap.CheckMap();
                    break;

                default:
                    Console.WriteLine($"{key.Key}");
                    break;
            }

            return iResult;
        }
    }
}