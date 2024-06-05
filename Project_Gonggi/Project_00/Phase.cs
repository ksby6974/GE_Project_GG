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
        static public int g_battle = 0;
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

            InitTargets();
            phase_bf = new Phase_Before();
            phase_main = new Phase_Main();
            phase_af = new Phase_After();
        }

        // id = 분류
        // hp = 체력
        static public int CreateTarget(int iId = 0, int iHp = 0)
        {
            int iIndex = -1;

            for (int i = 0; i < aTargets.Length; i++)
            {
                if (aTargets[i].Get_ID() == -1)
                {
                    iIndex = i;
                    //Console.WriteLine($"대상 【{iIndex}】번째 비었음");
                    break;
                }
            }

            // 생성 성공
            if (iIndex >= 0)
            {
               if (iId == 0)
               {
                    //Console.WriteLine($"플레이어 생성");
                    aTargets[iIndex] = new Player(iId,iHp);
               }
               else
               {
                    //Console.WriteLine($"적 생성");
                    aTargets[iIndex] = new Enemy(iId,iHp);
               }
            }
            // 생성 실패
            else
            {
                Console.WriteLine($"생성 실패");
            }

            return iIndex;
        }

        // 대상들 초기화
        static public void InitTargets()
        {
            for (int i = 0; i < _Limit.g_Limit_Target; i++)
            {
                aTargets[i] = new Target(-1,-1);
                //Console.WriteLine($"【{i}】{aTargets[i]}　NM:{aTargets[i].sName}　ID:{aTargets[i].iId}　HP:{aTargets[i].iHp}");
            }
        }

        // 대상들 확인
        static public void ShowTargets()
        {
            for (int i = 0; i < aTargets.Length; i++)
            {
                Console.WriteLine($"【{i}】{aTargets[i]}　NM:{aTargets[i].Get_Name()}　ID:{aTargets[i].Get_ID()}　HP:{aTargets[i].Get_HP()}");
            }
        }

        //
        public void ShowTurn()
        {
            Console.WriteLine($"차례 : {g_iTurn}");
        }
    }
}
