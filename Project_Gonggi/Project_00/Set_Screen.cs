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
            Console.SetWindowSize(Program.g_WindowWidth, Program.g_WindowHeight);
        }
    }
}
