using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using System.Windows.Markup;

namespace Project_GG
{
    public class Entity
    {
        public class Node
        {
            public string sName = "Default";     // 이름
            public int iIndex;                   // 순서
            public int iMaster;                  // 개체의 주인
            public int iX;                       // X좌표
            public int iY;                       // Y좌표
            public int iDestination;             // 목표지점
            public int iMovetype;                // 이동유형
            public int iDamage;                  // 파괴력

            public int iMaxHp;                   // 최대체력 
            public int iHp = 0;                  // 체력

            public Node? nPre;
            public Node? nNext;

            public Node()
            {
                iIndex = 0;
            }
        }

        private Node? nHead;
        private Node? nTail;
        private int iSize;

        public Entity()
        {
            nHead = null;
            nTail = null;
            iSize = 0;
        }

        public int Create()
        {
            Node? node = new Node();

            if (nHead == null)
            {
                nHead = node;
                nTail = nHead;

                node.nPre = null;
                node.nNext = null;
            }
            else
            {
                node.nNext = nHead;
                nHead.nPre = node;
                nHead = node;
                node.nPre = null;
            }

            iSize += 1;
            node.iIndex = iSize;
            return iSize;
        }

        public Node Find(int index)
        {
            Node? node = nHead;

            while (node != null)
            {
                if (index.ToString() == node.iIndex.ToString())
                {
                    break;
                }

                node = node.nNext;
            }

            return node!;
        }

        public int GetSize()
        {
            return iSize;
        }

        public void Remove(int index)
        {
            Node? node = Find(index);

            if (node == null)
            {
                Console.WriteLine($"Entitiy is Empty");
            }
            else
            {
                if (nHead == nTail)
                {
                    nHead = null;
                    nTail = null;
                }
                else if (node == nHead)
                {
                    if (nHead == nTail)
                    {
                        nHead = null;
                        nTail = null;
                    }
                    else
                    {
                        nHead.nNext!.nPre = null;
                        nHead = nHead.nNext;
                    }
                }
                else if (node == nTail)
                {
                    nTail.nPre!.nNext = null;
                    nTail = nTail.nPre;
                }
                else
                {
                    node!.nPre!.nNext = node.nNext;
                    node.nNext!.nPre = node.nPre;
                    node = null;
                }
            }
        }

        public void Update()
        {
            Node? node = nHead;

            while (node != null)
            {
                node = node.nNext;
            }
        }
    }
}
