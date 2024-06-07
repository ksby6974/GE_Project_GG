using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public class Phase_After
    {
        public void Update(int iStart)
        {
            int iTurn = 1;

            //Console.WriteLine($"Loop :: {Phase.g_iTurn}");

            // 대기 시간
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            // 초기화 및 흐름
            switch (Phase.g_cmd)
            {
                //명령 재시도
                case -1:
                    iTurn = 0;
                    break;

                // 플레이어 정보 확인
                case -2:
                    iTurn = 0;
                    break;

                default:
                    break;
            }

            // 차례 진행
            if (iTurn >= 1)
                Phase.g_iTurn += 1;

            // 버퍼 처리
            Console.Clear();
        }
    }
}
