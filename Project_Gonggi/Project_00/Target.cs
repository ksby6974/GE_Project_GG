using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Target
    {
        protected int iId;
        protected string sName = "defaultName";
        protected int x;
        protected int y;
        protected int iHpLimit;
        protected int iHp = 0;
        public Deck targetdeck;

        public Target(int cf, int ihp)
        {
            this.iId = cf;
            this.iHpLimit = ihp;
            this.iHp = iHpLimit;
            targetdeck = new Deck();
        }

        public void Set_HP(int hp)
        {
            this.iHp = hp;
        }

        public void Set_Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Get_HP()
        {
            return this.iHp;
        }

        public int Get_HPLimit()
        {
            return this.iHpLimit;
        }

        public int Get_ID()
        {
            return this.iId;
        }

        public string Get_Name()
        {
            return this.sName;

        }

        public int Get_PositionX()
        {
            return this.x;
        }

        public int Get_PositionY()
        {
            return this.y;
        }
    }

    public class Player : Target
    {

        public Player(int cf, int ihp) : base(cf, ihp)
        {
            sName = "Player";
            this.iId = 0;
            //Console.WriteLine("Player");
            this.targetdeck.StarterDeck(0);
        }
    }

    public class Enemy : Target
    {

        public Enemy(int cf, int ihp) : base(cf, ihp)
        {
            // 이름 분류
            sName = _Data.Data_EnemyName(cf);
            this.iId = cf;
            //Console.WriteLine("Enemy");
            //
        }
    }
}
