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

            // 차례 진행

            // 환경 행동

            // 적의 행동
        }

        static public void CommandPhase(int iCmd)
        {
            switch (iCmd)
            {
                default:
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
                    iResult = 0;
                    Phase.aTargets[iPlayer].targetdeck.Discard_Hand_All();
                    Phase.aTargets[iPlayer].targetdeck.Draw_Main(5);
                    //_Limit.Get_MainDraw()

                    break;

                case ConsoleKey.A:
                    Console.Write($"사용할 카드의 번호 : ");

                    int i = 0;
                    string? s = Console.ReadLine();
                    bool bResult = int.TryParse(s, out i);

                    if (bResult)
                    {
                        Console.WriteLine($"입력된 명령:{s}　결과:{bResult}　값:{int.Parse(s!)}");
                        iResult = int.Parse(s);
                    }
                    else
                    {
                        Console.WriteLine($"잘못된 입력입니다.");
                    }

                    if (iResult == 0)
                        iResult = 0;

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

            // 카드 사용 처리
            if (input > 0)
            {
                //카드 사용 가능 여부
                if (_Check.Check_CMD_CardUse(input) == 0)
                {
                    iResult = -1;
                }
                else
                {
                    Use_Card(iResult);
                }
            }

            return iResult;
        }

        public void Use_Card(int iCard)
        {
            // 해당 버리기
            Phase.aTargets[_Check.Check_SearchPlayer()].targetdeck.Discard_Hand(iCard);

            Console.WriteLine($"카드가 사용되었습니다. : {iCard}");
        }
    }
}