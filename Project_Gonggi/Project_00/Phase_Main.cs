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

            //


            // 명령 입력 UI
            CommandPhase(Phase.g_cmd);

            // 플레이어 입력
            int CorrectInput = CommandInput();

            // 플레이어 명령수행
            Phase.g_cmd = CommandAction(CorrectInput);
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
                    Console.WriteLine($"[D] 현재 덱 확인");
                    Console.WriteLine($"[Q] 뽑을 카드 뭉치 확인");
                    Console.WriteLine($"[W] 버린 카드 뭉치 확인");
                    Console.WriteLine($"[Space] 패를 버리고 카드를 새로 뽑습니다.");
                    break;
           }
        }

        static public int CommandInput()
        {
            //정수값만 받도록
            int iResult = -1;
            int iPlayer = _Check.Check_SearchPlayer();
            int i = 0;
            string? s = Console.ReadLine();

            if (s == "d" || s == "D")
            {
                Phase.aTargets[iPlayer].targetdeck.Show_Deck();
            }
            else if (s == "Q" || s == "q")
            {
                Phase.aTargets[iPlayer].targetdeck.Show_Draw();
            }
            else if (s == "W" || s == "w")
            {
                Phase.aTargets[iPlayer].targetdeck.Show_Discard();
            }
            else
            {

                bool bResult = int.TryParse(s, out i);

                if (bResult)
                {
                    //Console.WriteLine($"입력된 명령:{s}　결과:{bResult}　값:{int.Parse(s)}");
                    iResult = int.Parse(s);
                }
                else
                {
                    //Console.WriteLine($"{s}");
                }
            }

            return iResult;
        }

        public int CommandAction(int input)
        {
            Console.WriteLine($"input:{input}　g_cmd:{Phase.g_cmd}");

            int iResult = input;
            int iDrawOn = _Check.Check_CMD_CardUse(input); 

            //명령 수행 실패
            // ※ 할당된 뽑을 카드 없음
            // ※ 할당되었으나 카드 사용할 수 없음
            if (iDrawOn == 0)
            {
                iResult = -1;
            }

            return iResult;
        }
    }
}