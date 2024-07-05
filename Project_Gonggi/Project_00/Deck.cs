using System;
using System.Reflection;
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
        protected Card[] aList_Deck = new Card[_Limit.g_Limit_Deck];
        protected Card[] aList_Draw = new Card[_Limit.g_Limit_Deck];
        protected Card[] aList_Discard = new Card[_Limit.g_Limit_Deck];
        protected Card[] aList_Hand = new Card[_Limit.g_Limit_Hand];

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
                    aList_Deck[0] = null!;

                    Console.WriteLine($"{i} 를 파괴 {aList_Deck[0]}");
                }
            }
        }

        // 덱에 추가
        public void Add_Deck(int iCard)
        {
            int iResult = 0;

            // 부여
            for (int i = 0; i < aList_Deck.Length; i++)
            {
                if (aList_Deck[i] == null)
                {
                    iResult = 1;

                    Card card = new Card(iCard);
                    sCard sCard = new sCard(iCard);

                    sCard.SetCard(ref card);
                    aList_Deck[i] = card;

                    // 자료 할당
                    break;
                }
            }

            // 할당 실패
            if (iResult == 0)
            {
                Console.WriteLine($"카드 추가 실패 : {iCard}");
            }
        }

        public int Check_Draw()
        {
            int iResult = -1;

            for (int i = 0; i < aList_Draw.Length; i++)
            {
                if (aList_Draw[i] != null)
                {
                    iResult = i;
                    //Console.WriteLine($"뽑을 카드 존재 {i}");
                    break;
                }
            }

            return iResult;
        }

        public int Check_Hand(int iIndex)
        {
            int iResult = 0;

            if (iIndex < aList_Hand.Length)
            {
                if (aList_Hand[iIndex - 1] != null)
                {
                    iResult = 1;
                }
            }
            //Console.WriteLine($"길이:{aList_Hand[iIndex - 1]} {aList_Hand.Length} 값:{aList_Hand[iIndex - 1].Get_ID()}");
            //Console.WriteLine($"Check_Hand : {iIndex} 점검한 결과는 {iResult}");

            return iResult;
        }

        // 덱의 카드 총합
        public int Count_Deck()
        {
            int iResult = 0;

            for (int i = 0; i < aList_Deck.Length; i++)
            {
                if (aList_Deck[i] != null)
                {
                    iResult += 1;
                }
            }

            return iResult;
        }

        // 버릴 카드 더미의 카드 총합
        public int Count_Discard()
        {
            int iResult = 0;

            for (int i = 0; i < aList_Discard.Length; i++)
            {
                if (aList_Discard[i] != null)
                {
                    iResult += 1;
                }
            }

            return iResult;

        }

        // 뽑을 카드 더미의 카드 총합
        public int Count_Draw()
        {
            int iResult = 0;

            for (int i = 0; i < aList_Draw.Length; i++)
            {
                if (aList_Draw[i] != null)
                {
                    iResult += 1;
                }
            }

            return iResult;
        }

        // 패의 카드 총합
        public int Count_Hand()
        {
            int iResult = 0;

            for (int i = 0; i < aList_Hand.Length; i++)
            {
                if (aList_Hand[i] != null)
                {
                    iResult += 1;
                }
            }

            return iResult;
        }

        public Card GetCard_Hand(int iCard)
        {
            Card card = null!;

            if (aList_Hand[iCard - 1] != null)
            {
                card = aList_Hand[iCard - 1];
            }

            return card;
        }

        // 카드 뽑기
        public void Draw_()
        {
            int iResult = 0;
            int iDraw = -1;

            // 뽑을 카드 더미 검사 
            iDraw = Check_Draw();

            // 더 이상 뽑을 카드가 없었음
            if (iDraw == -1)
            {
                Set_Circle();

                iDraw = Check_Draw();

                // 그래도 더 이상 뽑을 카드가 없음
                if (iDraw == -1)
                {
                    Console.WriteLine($"뽑을 카드가 없다.");
                    return;
                }
            }

            // 핸드 검사
            for (int j = 0; j < aList_Hand.Length; j++)
            {
                // 비어있는 뽑은 카드 더미에 할당
                if (iResult == 0 && aList_Hand[j] == null)
                {
                    iResult = 1;
                    aList_Hand[j] = aList_Draw[iDraw];
                    aList_Draw[iDraw] = null!;
                    break;
                }
            }

            // 손패 정렬
            Sort_Hand();
        }

        // 메인 드로우
        public void Draw_Main(int Cards = 0)
        {
            if (Cards > 0)
            {
                for (int i = 0; i < Cards; i++)
                {
                    Draw_();
                }
            }
        }

        // 패 버리기
        public void Discard_Hand(int ihandnumber)
        {
            int iResult = -1;
            int iIndex = ihandnumber - 1;

            for (int i = 0; i < aList_Discard.Length; i++)
            {
                if (aList_Discard[i] == null)
                {
                    //Console.WriteLine($"{aList_Hand[ihandnumber].Get_Name()} {aList_Hand[ihandnumber].Get_ID()}를 버립니다.");
                    iResult = i;
                    aList_Discard[i] = aList_Hand[iIndex];
                    aList_Hand[iIndex] = null!;        
                    break;
                }
            }

            if (iResult == -1)
                Console.WriteLine("Discard_Hand : 카드를 버릴 공간 없음");
        }

        // 패 모두 버리기
        public void Discard_Hand_All()
        {
            for (int i = 0; i < aList_Hand.Length; i++)
            {
                if (aList_Hand[i] != null)
                {
                    Discard_Hand(i + 1);
                }
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
                    aList_Deck[0] = null!;
                }
            }
        }

        // 초기화 : 버린 카드 더미
        public void Reset_Discard()
        {
            for (int i = 0; i < aList_Discard.Length; i++)
            {
                aList_Discard[i] = null!;
            }
        }

        // 초기화 : 뽑을 카드 더미
        public void Reset_Draw()
        {
            for (int i = 0; i < aList_Draw.Length; i++)
            {
                aList_Draw[i] = null!;
            }
        }

        // 초기화 : 패
        public void Reset_Hand()
        {
            for (int i = 0; i < aList_Hand.Length; i++)
            {
                aList_Hand[i] = null!;
            }
        }

        // 첫 차례
        public void Reset_TurnFirst()
        {
            Set_Start();
            Shuffle_Draw();
        }

        // 덱 순환
        public void Set_Circle()
        {
            Console.WriteLine($"Player Deck is circulated");

            for (int i = 0; i < aList_Discard.Length; i++)
            {
                // 버린 카드 더미에 카드 존재
                if (aList_Discard[i] != null)
                {
                    for (int j = 0; j < aList_Draw.Length; j++)
                    {
                        // 비어있는 뽑은 카드 더미에 할당
                        if (aList_Draw[j] == null)
                        {
                            aList_Draw[j] = aList_Discard[i];
                            aList_Discard[i] = null!;
                            break;
                        }
                    }
                }
            }
        }

        // 덱을 뽑을 카드 더미에 할당
        public void Set_Start()
        {
            for (int i = 0; i < aList_Deck.Length; i++)
            {
                if (aList_Deck[i] != null)
                {
                    for (int j = 0; j < aList_Draw.Length; j++)
                    {
                        if (aList_Draw[j] == null)
                        {
                            aList_Draw[j] = aList_Deck[i];
                            break;
                        }
                    }
                }
            }
        }

        // 덱 확인
        public void Show_Deck()
        {
            _Draw.DrawLine("None", 2);

            for (int i = 0; i < aList_Deck.Length; i++)
            {
                // 할당된 카드 존재
                if (aList_Deck[i] != null)
                {
                    //Console.WriteLine($"[{i + 1}] : {aList_Deck[i].iCard}");
                    Console.WriteLine($"[{i + 1}] : {aList_Deck[i].Get_Name()}（{aList_Deck[i].Get_ID()}）");
                }
                else
                {
                    break;
                }
            }
        }

        // 버린 더미 확인
        public void Show_Discard()
        {
            _Draw.DrawLine("None", 2);

            for (int i = 0; i < aList_Discard.Length; i++)
            {
                // 할당된 카드 존재
                if (aList_Discard[i] != null)
                {
                    //Console.WriteLine($"[{i + 1}] : {aList_Discard[i].iCard}");
                    Console.WriteLine($"[{i + 1}] : {aList_Discard[i].Get_Name()}");
                }
                else
                {
                    break;
                }
            }

        }

        // 뽑을 더미 확인
        public void Show_Draw()
        {
            _Draw.DrawLine("None", 2);

            for (int i = 0; i < aList_Draw.Length; i++)
            {
                // 할당된 카드 존재
                if (aList_Draw[i] != null)
                {
                    //Console.WriteLine($"[{i + 1}] : {aList_Draw[i].iCard}");
                    Console.WriteLine($"[{i + 1}] : {aList_Draw[i].Get_Name()}（{aList_Draw[i].Get_ID()}）");
                }
            }
        }

        // 손패 확인
        public void Show_Hand()
        {
            _Draw.DrawLine("Hand", 2);
            Console.WriteLine($"[0] : 차례 강제 종료");

            for (int i = 0; i < aList_Hand.Length; i++)
            {
                // 할당된 카드 존재
                if (aList_Hand[i] != null)
                {
                    Console.WriteLine($"[{i + 1}] : {aList_Hand[i].Get_Name()}（{aList_Hand[i].Get_ID()}）");
                }
                else
                {
                    //
                }
            }

        }

        // 손패 재정렬
        public void Sort_Hand()
        {
            int iTemp = -1;
            Card cTemp = new Card();

            for (int i = 0; i < aList_Hand.Length; i++)
            {
                if (aList_Hand[i] == null)
                {
                    if (iTemp == -1)
                    {
                        iTemp = i;
                    }
                    //aList_Hand[i] = null;
                }
                else
                {
                    if (iTemp > -1)
                    {
                        aList_Hand[iTemp] = aList_Hand[i];
                        aList_Hand[i] = null!;
                        iTemp = i;
                    }
                }
            }
        }

        // 뽑을 더미 섞기
        public void Shuffle_Draw()
        {
            int iLimit = Count_Draw();
            int iRand = 0;
            Random rd = new Random();
            Card iTemp = new Card();

            for (int i = 0; i < iLimit; i++)
            {
                iRand = rd.Next(0, iLimit);
                iTemp = aList_Draw[i];
                aList_Draw[i] = aList_Deck[iRand];
                aList_Deck[iRand] = aList_Draw[i];
            }
        }

        // 덱 시작
        public void StarterDeck(int Starter)
        {
            switch (Starter)
            {
                default:
                    Add_Deck(1);
                    Add_Deck(1);
                    Add_Deck(1);
                    Add_Deck(1);

                    Add_Deck(2);
                    Add_Deck(2);

                    Add_Deck(3);
                    Add_Deck(3);
                    Add_Deck(3);
                    Add_Deck(3);
                    break;
            }
        }
    }
}
