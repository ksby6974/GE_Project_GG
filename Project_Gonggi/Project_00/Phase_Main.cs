using Project_GG;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            _Draw.DrawLine("Turn", 0, Phase.g_iTurn);
            _Draw.DrawLine("Enemy", 1);
            Phase.currentmap.DrawMap();
            _Draw.DrawLine("Player", 1);

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
                case -2:
                    break;

                default:
                    //int iResult = 0;

                    _Draw.DrawLine("Cmd", 2);
                    Console.WriteLine($"[D] 현재 덱 확인");
                    Console.WriteLine($"[Q] 뽑을 카드 뭉치 확인");
                    Console.WriteLine($"[W] 버린 카드 뭉치 확인");
                    Console.WriteLine($"[R] 패를 모두 버리고 카드를 새로 뽑습니다.");
                    Console.WriteLine($"[A] 패에 있는 카드를 사용합니다.");
                    break;
           }
        }

        static public int CommandInput()
        {
            //정수값만 받도록
            int iResult = -1;
            int iPlayer = _Check.Check_SearchPlayer();
            int iPx = Phase.aTargets[iPlayer].Get_PositionX();
            int iPy = Phase.aTargets[iPlayer].Get_PositionY();

            ConsoleKeyInfo key;
            key = Console.ReadKey();

            switch (key.Key)
            {
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

                case ConsoleKey.D:
                    iResult = -2;
                    Phase.aTargets[iPlayer].targetdeck.Show_Deck();
                    break;

                case ConsoleKey.Q:
                    iResult = -2;
                    Phase.aTargets[iPlayer].targetdeck.Show_Draw();
                    break;

                case ConsoleKey.W:
                    iResult = -2;
                    Phase.aTargets[iPlayer].targetdeck.Show_Discard();
                    break;

                case ConsoleKey.R:
                    iResult = 1;
                    Phase.aTargets[iPlayer].targetdeck.Discard_Hand_All();
                    Phase.aTargets[iPlayer].targetdeck.Draw_Main(5);
                    //_Limit.Get_MainDraw()

                    break;

                case ConsoleKey.A:
                    int i = 0;
                    string? s = Console.ReadLine();
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
                    break;

                default:
                    break;
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
            else
            {
                Use_Card(iResult);
            }

            return iResult;
        }

        public void Use_Card(int iCard)
        {
            Console.WriteLine($"카드가 사용되었습니다. : {iCard}");
        }
    }
}