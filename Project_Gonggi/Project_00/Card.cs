using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Card
    {
        // 카드 생성 순서
        public int iCard;
        public string sName;

        // 효과

        public Card(int iCard = 0)
        {
            InitCard();
            this.iCard = iCard;
        }

        public void InitCard()
        {
            this.sName = "Blank";
        }
    }
}
