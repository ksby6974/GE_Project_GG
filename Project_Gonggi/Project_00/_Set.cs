using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    static public class _Set
    {
        static public void SetTextColor(string s)
        {
            switch (s)
            {
                case "Player":
                    Console.ForegroundColor = (ConsoleColor)_Limit.g_Limit_Color_Player;
                    break;

                case "Enemy":
                    Console.ForegroundColor = (ConsoleColor)_Limit.g_Limit_Color_Enemy;
                    break;

                default:
                    break;
            }
        }

        static public void SetScreen()
        {
            Console.SetWindowSize(_Limit.g_Limit_WindowWidth,_Limit.g_Limit_WindowHeight);
        }
    }
}
