using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    static public class Set_Screen
    {
        static public void SetScreen()
        {
            Console.SetWindowSize(_Limit.g_Limit_WindowWidth,_Limit.g_Limit_WindowHeight);
        }
    }
}
