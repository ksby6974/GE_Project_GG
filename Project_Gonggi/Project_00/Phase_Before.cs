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
            Phase.aTargets[0] = new Player(-1,100);

            //Phase.CreateTarget(-1,100);

            // 플레이어 위치
            //Phase.player.Position(5,9);

            // 적 생성
            //Phase.CreateTarget(1,100);

            // 적 위치
        }
    }
}
