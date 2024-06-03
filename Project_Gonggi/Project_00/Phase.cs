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

        // 대상
        static public Target[] aTargets = new Target[_Limit.g_Limit_Target];

        // 생성자
        public Phase()
        {
            //Console.WriteLine("Phase 생성");

            phase_bf = new Phase_Before();
            phase_main = new Phase_Main();
            phase_af = new Phase_After();

            for (int i = 0; i < _Limit.g_Limit_Target; i++)
            {
                aTargets[i] = new Target(0);
                aTargets[i].iHp = 0;
            }
        }

        // id = 분류
        // hp = 체력
        public void CreateTarget(int iId = 0, int iHp = 0)
        {
            int iResult = 1;
            int iIndex = 0;

            Console.Write($"{aTargets[0].iHp}");
            
            //for (int i = 0; i < aTargets.Length; i++)
            {
                //if (aTargets[i].iId != 0)
                //{
                   // Console.Write($"{i} : {aTargets[i].iId}");

                    //iIndex = i;
                    //break;
                //}
            }

            // 생성 성공
            if (iIndex > 0)
            {
               if (iId == 1)
               {
                   //aTargets[iIndex] = new Player(iId,iHp);
               }
               else
               {
                   //aTargets[iIndex] = new Enemy(iId,iHp);
               }
            }
            // 생성 실패
            else
            {
                Console.WriteLine($"생성 실패");
            }
        }

        public void ShowTurn()
        {
            Console.WriteLine($"차례 : {g_iTurn}");
        }
    }
}
