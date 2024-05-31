using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Target
    {
        private int iIndex;
        protected string sName;
        public int x;
        public int y;
        protected int iHpLimit;
        protected int iHp;
        public Deck targetdeck;

        public Target(string name, int i)
        {
            this.sName = name;
            this.iHpLimit = i;
            iHp = iHpLimit;
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

        public Player(string sName, int i) : base(sName, i)
        {
            //Console.WriteLine("Player");
            this.targetdeck.StarterDeck(0);
        }
    }

    public class Enemy : Target
    {

        public Enemy(string sName, int i) : base(sName, i)
        {
            //Console.WriteLine("Enemy");
            //
        }
    }
}
