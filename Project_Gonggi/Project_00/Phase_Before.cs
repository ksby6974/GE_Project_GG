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
        public Enemy enemy;

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
            Phase.player = new Player("Player",100);
            Phase.player.Position(2,2);

            enemy = new Enemy("Slime", 100);
        }
    }
}
