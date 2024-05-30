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
        public int iIndex;

        // 카드 분류
        public int iCard;

        // 카드 이름
        public string sName = "Dummy";
    }


    public class Card_ : Card
    {
        public Card_(int index, int card)
        {
            iIndex = index;
            iCard = card;
        }
    }
}
