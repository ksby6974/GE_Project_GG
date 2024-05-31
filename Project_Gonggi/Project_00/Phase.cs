using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Phase
    {
        // 전역
        static public int g_iTurn = 0;
        static public int g_cmd = 0;

        // 페이즈
        public Phase_Before phase_bf;
        public Phase_Main phase_main;
        public Phase_After phase_af;

        // 맵
        static public Map currentmap;
        static public Player player;

        public Phase()
        {
            //Console.WriteLine("Phase 생성");

            phase_bf = new Phase_Before();
            phase_main = new Phase_Main();
            phase_af = new Phase_After();
        }

        public void ShowTurn()
        {
            Console.WriteLine($"차례 : {g_iTurn}");
        }
    }
}
