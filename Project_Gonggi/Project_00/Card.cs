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
        protected string sName;     // 이름
        protected int iMaster;      // 주인
        protected int iId;          // 분류
        protected int iAtk;         // 공격
        protected int iDef;         // 방어
        protected int iFreeMove;    // 이동
        protected int iShotType;    // 공격

        // 효과

        public Card(int id = 0)
        {
            sName = "Blank";
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

            this.iMaster = 0;
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

        public void ShowInfo()
        {
            Console.WriteLine($"\n───────────────────────────────────────");
            Console.WriteLine($"{sName}　{iShotType}");
            Console.WriteLine($"{Get_ID()}:{Get_Name()}");
            Console.WriteLine($"───────────────────────────────────────\n");
        }

        public void Use()
        {
            ShowInfo();

            // 엔티티 생성
            if (iShotType > 0)
            {
                int iTemp = Phase.aEntity.Create();
                Console.WriteLine($"text {iTemp}");
            }
        }
    }

    public class StraightShot : Card
    {
        public StraightShot()
        {
            this.iShotType = 1;
        }
    }
}
