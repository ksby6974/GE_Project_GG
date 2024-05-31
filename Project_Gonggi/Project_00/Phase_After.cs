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
            //Console.WriteLine($"Loop :: {Phase.g_iTurn}");

            // 대기 시간
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            // 초기화 및 흐름
            Phase.g_cmd = 0;
            Phase.g_iTurn += 1;

            // 버퍼 처리
            Console.Clear();
        }
    }
}
