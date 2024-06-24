using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    static class _Limit
    {
        public const int g_Limit = 10000;
        public const int g_Limit_Hand = 10;
        public const int g_Limit_Deck = 20;

        public static int g_Limit_Position = 12;
        public static int g_Limit_Target = 10;

        // 
        public const int g_Limit_Blank = 8;
        public const int g_Limit_WindowWidth = 80;
        public const int g_Limit_WindowHeight = 44;

        // 글자색
        public const int g_Limit_Color_Player = (int)ConsoleColor.Green;
        public const int g_Limit_Color_Enemy = (int)ConsoleColor.Red;

        // 범위 제한
        static public int Limit(int value, int min, int max)
        {
            int iResult = value;

            if (min > max)
                throw new ArgumentException("【Limit】 최소값이 최대값보다 큽니다");

            if (value < min)
                value = min;

            if (value > max)
                value = max;

            return iResult;
        }

        /// 위치 제한
        static public int Limit_PlayerPosition(int x, int y)
        {
            int iResult = 1;

            // 화면 밖
            if (x + 1 > _Limit.g_Limit_Position || x < 0)
                iResult = 0;

            if (y + 1 > _Limit.g_Limit_Position || y < 0)
                iResult = 0;

            // 적 존재
            if (_Check.Check_TargetOnMap(x,y) > -1)
                iResult = 0;

            return iResult;
        }

        // 플레이어 위치 제한
        static public int Limit_PlayerPosition_CMD(int x, int y)
        {
            int iResult = 0;

            if (_Limit.Limit_PlayerPosition(x, y) == 1)
            {
                Phase.aTargets[_Check.Check_SearchPlayer()].Set_Position(x, y);
            }
            else
            {
                iResult = -1;
            }

            return iResult;
        }

        static public int Get_MainDraw(int draws)
        {
            int iResult = 5 + draws;

            return iResult;
        }
    }
}
