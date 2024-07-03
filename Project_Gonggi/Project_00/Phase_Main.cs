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
                    _Draw.ClearLine();
                    iResult = -2;
                    Phase.aTargets[iPlayer].targetdeck.Show_Deck();
                    break;

                case ConsoleKey.Q:
                    _Draw.ClearLine();
                    iResult = -2;
                    Phase.aTargets[iPlayer].targetdeck.Show_Draw();
                    break;

                case ConsoleKey.W:
                    _Draw.ClearLine();
                    iResult = -2;
                    Phase.aTargets[iPlayer].targetdeck.Show_Discard();
                    break;

                case ConsoleKey.R:
                    _Draw.ClearLine();
                    iResult = 0;
                    Phase.aTargets[iPlayer].targetdeck.Discard_Hand_All();
                    Phase.aTargets[iPlayer].targetdeck.Draw_Main(5);
                    Console.WriteLine($"카드를 새로 뽑았다.");


                    //_Limit.Get_MainDraw()

                    break;

                case ConsoleKey.A:
                    _Draw.ClearLine();
                    Console.Write($"사용할 카드의 번호 : ");

                    int i = 0;
                    string? s = Console.ReadLine();
                    bool bResult = int.TryParse(s, out i);

                    if (bResult)
                    {
                        iResult = int.Parse(s!);
                        Console.WriteLine($"입력된 명령:{s}　결과:{bResult}　결과값:{iResult}");
                    }
                    else
                    {
                        Console.WriteLine($"잘못된 입력입니다.");
                    }

                    // 차례 강제 종료
                    if (iResult == 0)
                    {
                        Console.WriteLine($"차례를 강제로 넘겼다.");
                        iResult = 0;
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
            // 카드 사용 효과
            Card cTemp = Phase.aTargets[_Check.Check_SearchPlayer()].targetdeck.GetCard_Hand(iCard);
            cTemp.Use();

            // 해당 버리기
            Phase.aTargets[_Check.Check_SearchPlayer()].targetdeck.Discard_Hand(iCard);

            // 손패 정렬
            Phase.aTargets[_Check.Check_SearchPlayer()].targetdeck.Sort_Hand();

            Console.WriteLine($"카드가 사용되었습니다. : {iCard}");
        }
    }
}