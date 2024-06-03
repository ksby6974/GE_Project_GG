using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Deck
    {
        public int[] decklist = new int[_Limit.g_Limit];

        public Deck()
        {
            InitDeck();
        }

        // 덱 초기화
        public void InitDeck()
        {
            for (int i = 0; i < decklist.Length; i++)
            {
                decklist[i] = -1;

            }
        }

        // 덱 보여주기
        public void ShowDeck()
        {
            QuickDraw.DrawLine("None", 2);

            for (int i = 0; i < decklist.Length; i++)
            {
                if (decklist[i] >= 0)
                {
                    Console.WriteLine($"[{i}] : {decklist[i]}");
                }
                else
                {
                    break;
                }
            }
        }

        // 덱 시작
        public void StarterDeck(int Starter)
        {
            switch (Starter)
            {
                default: 
                    for (int i = 0; i < 10; i++)
                    {
                        if (i > 7)
                        {
                            decklist[i] = 2;
                        }
                        else if (i > 4)
                        {
                            decklist[i] = 1;
                        }
                        else
                        {
                            decklist[i] = 3;
                        }         
                    }
                    break;
            }
        }
    }
}
