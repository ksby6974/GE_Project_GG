using Project_GG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Phase_Before
    {
        public Phase_Before()
        {
            Program.iStart = 1;
            InitGame();
        }

        public void Update(int iStart)
        {
            Phase.currentmap.Update();

            if (Phase.g_battle == 0)
            {
                int iPlayer = _Check.Check_SearchPlayer();
                Phase.aTargets[iPlayer].targetdeck.Reset_TurnFirst();
                Phase.aTargets[iPlayer].targetdeck.Draw_Main(5);

                Phase.g_battle += 1;
            }

            switch (iStart)
            {
                case 0:
                    break;

                default:
                    break;

            }
        }

        public void InitGame()
        {
            Phase.currentmap = new Map();

            // 플레이어 생성
            int iPlayer = Phase.CreateTarget(0,10);
            if (iPlayer > -1)
            {
                // 플레이어 위치
                Phase.aTargets[iPlayer].Set_Position(5, 9);
            }

            // 적 생성
            int iEnemy = Phase.CreateTarget(1,3);
            if (iEnemy > -1)
            {
                // 적 위치
                Phase.aTargets[iEnemy].Set_Position(5, 2);
            }

            // 적 위치
        }
    }
}
