using System;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Project_GG
{
    internal class Program
    {

        static bool bLoop_MainGame = true;


        static void Main(string[] args)
        {
            while (bLoop_MainGame)
            {
                // 【비포 페이즈】

                // 초기화 부분
                Map map = new Map();
                map.DrawMap();

                Deck playerdeck = new Deck();


                // 【메인 페이즈】
                MainPhase(playerdeck);


                // 【애프터 페이즈】


                // 대기 시간
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);


                // 버퍼 처리
                Console.Clear();
            }
        }

        // 메인 페이즈 함수
        static public void MainPhase(Deck playerdeck)
        {
            // 명령 입력 UI
            //Graphics g = this.CreateGraphics();
            

            Console.WriteLine($"[{1}] 덱 확인");

            // 플레이어 입력
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                    playerdeck.ShowDeck();
                    break;

                default:
                    //
                    break;
            }
        }


    }
}