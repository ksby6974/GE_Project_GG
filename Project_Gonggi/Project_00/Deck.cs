using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_GG_VAR;

namespace Project_GG
{
    public class Deck
    {
        static public int[] decklist = new int[GlobalVAR.iLimit];

        public Deck()
        {
            InitDeck();
            StarterDeck(0);
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
