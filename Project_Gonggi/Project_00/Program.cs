using System;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Project_GG;

namespace Project_GG
{

    internal class Program
    {
        // 전역 변수
        public const int g_blank = 8;
        public const int g_iLimit = 10000;
        public const int g_WindowWidth = 80;
        public const int g_WindowHeight = 40;

        public static bool bLoop_MainGame = true;
        public static int iStart = 0;
        //public int g_iTurn = 0;

        static void Main(string[] args)
        {
            // 초기화
            Set_Screen.SetScreen();

            // 전체 페이즈
            Phase phase = new Phase();

            while (bLoop_MainGame)
            {  
                // 【비포 페이즈】
                phase.phase_bf.Update(iStart);

                // 【메인 페이즈】
                phase.phase_main.Update(iStart);

                // 【애프터 페이즈】
                phase.phase_af.Update(iStart);
            }

            Console.WriteLine("Main ::");
        }
    }
}