using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Target
    {
        public int iId;
        protected string sName = "defaultName";
        public int x;
        public int y;
        protected int iHpLimit;
        public int iHp = 0;
        public Deck targetdeck;

        public Target(int ihp)
        {
            this.iHpLimit = ihp;
            this.iHp = iHpLimit;
            targetdeck = new Deck();
            targetdeck.InitDeck();
        }


        public void Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Player : Target
    {

        public Player(int cf, int ihp) : base(ihp)
        {
            sName = "Player";
            this.iId = 0;
            //Console.WriteLine("Player");
            this.targetdeck.StarterDeck(0);
        }
    }

    public class Enemy : Target
    {

        public Enemy(int cf, int ihp) : base(ihp)
        {
            // 이름 분류
            sName = _Data.Data_EnemyName(cf);
            this.iId = cf;
            //Console.WriteLine("Enemy");
            //
        }
    }
}
