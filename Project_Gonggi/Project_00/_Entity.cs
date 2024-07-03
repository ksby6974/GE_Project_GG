using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Project_GG
{
    public class Entity
    {
        private class Node
        {
            public string sName = "Default";
            public int iMaster;                  // 개체의 주인
            public int iX;                       // X좌표
            public int iY;                       // Y좌표
            public int iDestination;             // 목표지점
            public int iMovetype;                // 이동유형
            public int iDamage;                  // 파괴력

            public int iMaxHp;                   // 최대체력 
            public int iHp = 0;                  // 체력

            public Node? nNext;
        }

        private Node? nHead;

        public Entity() 
        {
            nHead = null;
        }

        public void Create()
        {
            if (nHead == null)
            {
                nHead = new Node();
                nHead.nNext = null;
            }
            else
            {
                Node node = new Node();
                node.nNext = nHead;
                nHead = node;
            }
        }
    }
}
