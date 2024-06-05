using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_GG
{
    public class Card
    {
        // 카드 생성 순서
        protected string sName;
        protected int iId;
        protected int iAtk;
        protected int iDef;
        protected int iFreeMove;
        protected int iShotType;

        // 효과

        public Card(int id = 0)
        {
            InitCard(id);
        }

        public int Get_ID()
        {
            return iId;
        }

        public string Get_Name()
        {
            return sName;
        }

        public void InitCard(int id)
        {
            Set_Name(id);
            this.iId = id;
            this.iAtk = 0;
            this.iDef = 0;
            this.iFreeMove = 0;
            this.iShotType = 0;
        }

        public void Set_Name(int id)
        {
            string s = _Data.Data_CardName(id);
            this.sName = s;
        }
    }

    public class StraightShot : Card
    {
        public StraightShot(int id) : base(id)
        {
            sName = "StraightShot";
            iShotType = 0;
        }
    }
}
