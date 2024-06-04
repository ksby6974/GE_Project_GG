using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Deck
    {
        public Card[] aList_Deck = new Card[_Limit.g_Limit_Deck];
        public Card[] aList_Draw = new Card[_Limit.g_Limit_Deck];
        public Card[] aList_Discard = new Card[_Limit.g_Limit_Deck];
        public Card[] aList_Hand = new Card[_Limit.g_Limit_Hand];

        // 초기화
        public Deck()
        {
            InitDeck();
            Reset_Discard();
            Reset_Draw();
            Reset_Hand();
        }

        public void Test()
        {
            aList_Deck[0] = new Card(0);

            for (int i = 0; i < aList_Deck.Length; i++)
            {
                if (aList_Deck[i] == null)
                {
                    Console.WriteLine($"{i} 공백");
                }
                else
                {
                    Console.WriteLine($"{i} 존재");
                    aList_Deck[0] = null;

                    Console.WriteLine($"{i} 를 파괴 {aList_Deck[0]}");
                }
            }
        }

        // 메인 드로우
        public void Draw_Main()
        {
            
        }

        void Draw_Main_First()
        {
            //Reset_Discard();
            //Reset_Draw();
            //Reset_Hand();

            // 메인 드로우
            //Draw_Main();
        }

        // 덱에 추가
        public void Add_Deck(int iCard)
        {
            int iResult = 1;
            int iIndex = -1;

            // 부여
            for (int i = 0; i < aList_Deck.Length;  i++)
            {
                if (aList_Deck[i] == null)
                {
                    iIndex = i;
                    break;
                }
            }

            // 할당
            if (iIndex >= 0)
            {
                aList_Deck[iIndex] = new Card(iCard);
            }
            else
            {
                Console.WriteLine($"카드 추가 실패 : {iCard}");
            }
        }


        // 덱 초기화
        public void InitDeck()
        {
            for (int i = 0; i < aList_Deck.Length; i++)
            {
                if (aList_Deck[i] == null)
                {
                }
                else
                {
                    aList_Deck[0] = null;
                }
            }
        }

        // 초기화 : 버린 카드 더미
        void Reset_Discard()
        {
            for (int i = 0; i < aList_Discard.Length; i++)
            {
                aList_Discard[i] = null;
            }
        }

        // 초기화 : 뽑을 카드 더미
        void Reset_Draw()
        {
            for (int i = 0; i < aList_Draw.Length; i++)
            {
                aList_Draw[i] = null;
            }
        }

        // 초기화 : 패
        void Reset_Hand()
        {
            for (int i = 0; i < aList_Hand.Length; i++)
            {
                aList_Hand[i] = null;
            }
        }

        // 덱 확인
        public void Show_Deck()
        {
            QuickDraw.DrawLine("None", 2);

            for (int i = 0; i < aList_Deck.Length; i++)
            {
                // 할당된 카드 존재
                if (aList_Deck[i] != null)
                {
                    Console.WriteLine($"[{i}] : {aList_Deck[i].iCard}");
                }
                else
                {
                    break;
                }
            }
        }

        // 버린 더미 보기
        public void Show_Discard()
        {
            QuickDraw.DrawLine("None", 2);

            for (int i = 0; i < aList_Discard.Length; i++)
            {
                // 할당된 카드 존재
                if (aList_Deck[i] != null)
                {
                    Console.WriteLine($"[{i}] : {aList_Discard[i]}");
                }
                else
                {
                    break;
                }
            }

        }

        // 뽑을 더미 보기
        public void Show_Draw()
        {
            QuickDraw.DrawLine("None", 2);

            for (int i = 0; i < aList_Draw.Length; i++)
            {
                // 할당된 카드 존재
                if (aList_Deck[i] != null)
                {
                    Console.WriteLine($"[{i}] : {aList_Draw[i]}");
                }
                else
                {
                    break;
                }
            }
        }

        // 손패 보기
        public void Show_Hand()
        {
            QuickDraw.DrawLine("None", 2);

            for (int i = 0; i < aList_Hand.Length; i++)
            {
                // 할당된 카드 존재
                if (aList_Hand[i] != null)
                {
                    Console.WriteLine($"[{i}] : {aList_Hand[i]}");
                }
                else
                {
                    //
                }
            }

        }
        // 뽑을 카드 더미 섞기
        public void Shuffle_Draw()
        {
            int iLimit = 0;
            Card iTemp = new Card();

            for (int i = 0; i < aList_Deck.Length; i++)
            {
                if (aList_Deck[i] != null)
                    iLimit += 1;
            }

            Random Rand = new Random();
            // 뽑을 카드 존재
            if (iLimit > 0)
            {
                // 섞기
                for (int i = 0; i < iLimit; i++)
                {
                    iTemp = aList_Draw[i];

                    aList_Draw[i] = aList_Deck[Rand.Next(0, iLimit)];


                }
            }

            //뽑을 카드 없음
            else
            {
                ;
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
                            Add_Deck(2);
                        }
                        else if (i > 4)
                        {
                            Add_Deck(1);
                        }
                        else
                        {
                            Add_Deck(3);
                        }         
                    }
                    break;
            }
        }
    }
}
