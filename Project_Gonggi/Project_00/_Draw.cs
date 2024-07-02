using Project_GG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    static class _Draw
    {
        static public void ClearLine()
        {
            string s = "\r";
            s += new string(' ', Console.CursorLeft);
            s += "\r";
            Console.Write(s);
        }

        static public void DrawLine(string sValue = "default", int iValue = 0, int iTurn = 0)
        {
            int iBlank = _Limit.g_Limit_Blank;
            int iWho = 0;

            switch (sValue)
            {
                case "Hand":
                    iWho = -3;

                    break;
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
                        case -3:
                            DrawLine_Hand();
                            break;

                        case -2:
                            DrawLine_Cmd();
                            break;

                        case -1:
                            DrawLine_Turn(iTurn);
                            break;

                        case 1:
                            iTemp = _Check.Check_SearchPlayer();
                            DrawLine_Player(Phase.aTargets[iTemp].Get_PositionX(), Phase.aTargets[iTemp].Get_PositionY());
                            break;

                        case 2:
                            iTemp = _Check.Check_SearchEnemy_First();
                            DrawLine_Enemy(Phase.aTargets[iTemp].Get_PositionX(), Phase.aTargets[iTemp].Get_PositionY());
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
                int iPlayer = _Check.Check_SearchPlayer();

                // 상태창
                Draw_Target_Stat(Phase.aTargets[iPlayer]);

                // 플레이어 현재 패 보여주기
                Phase.aTargets[iPlayer].targetdeck.Show_Hand();

                iBlank = _Limit.Limit(iBlank - Phase.aTargets[iPlayer].targetdeck.Count_Hand(),0,iBlank);

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
                case -2:
                    sShow = "플레이어 정보 확인";
                    break;

                case -1:
                    sShow = "명령 재시도 부여";
                    break;

                case 0:
                    sShow = "차례는 소모되는 행동";
                    break;

                case 1:
                    sShow = "플레이어 차례 소모";
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

        static public void DrawLine_Hand()
        {
            Console.Write($"【 Hand 】");

        }
        static public void Draw_Target_Stat(Target target)
        {
            string name = target.Get_Name();
            double hp = Convert.ToDouble(target.Get_HP());
            double hpLimit = Convert.ToDouble(target.Get_HPLimit());

            //컬러
            if (name == "Player")
            {
                _Set.SetTextColor("Player");
            }
            else
            {
                _Set.SetTextColor("Enemy");
            }

            //Star
            Console.Write($"{name}");

            double hp_bar = Getpercentage(hp,hpLimit,2);
            int iLimit = _Limit.Limit(Convert.ToInt32(hp_bar), 0, 100);

            //Console.Write($"{hp_bar}");

            Console.Write($"（{hp,3}／{hpLimit,3}）");

            Console.ResetColor();

            Console.WriteLine();
        }

        static double Getpercentage(double value, double total, int de)
        {
            return System.Math.Round(value * 100 / total, de);
        }
    }
}
