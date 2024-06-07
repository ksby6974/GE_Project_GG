using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using System.Buffers;

namespace Project_GG
{
    public class ConsoleBuffer
    {
        private readonly int width;
        private readonly int height;
        private char[,] backBuffer = null;
        private char[,] frontBuffer = null;

        public ConsoleBuffer()
        {
            width = _Limit.g_Limit_WindowWidth;
            height = _Limit.g_Limit_WindowHeight;
            backBuffer = new char[height, width];
            frontBuffer = new char[height, width];
            Console.SetWindowSize(width, height + 1);
            Console.CursorVisible = false;
        }

        public char[,] Buffer => backBuffer;

        private bool IsRangeOut(int iX, int iY)
        {
            if ((iX >= width || iY >= height) || (iX < 0 || iY < 0))
            {
                return true;
            }

            return false;
        }

        public void Draw(char cChar, int iX, int iY)
        {
            if (!IsRangeOut(iX, iY))
            {
                backBuffer[iX, iY] = cChar;
            }
        }

        public void Draw(string s, int iX, int iY)
        {
            char[] ctemp = s.ToCharArray();
            for (int i = 0; i < ctemp.Length; i++)
            {
                if (!IsRangeOut(iX, iY))
                {
                    backBuffer[iX, iY + 1] = ctemp[i];
                }
            }
        }

        private void BufferExtraction()
        {
            Array.Copy(backBuffer, frontBuffer, width * height);
        }

        public void ClearBuffer()
        {
            Array.Clear(backBuffer, 0, width * height);
        }

        private void Print()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(frontBuffer[y, x]);
                }
                Console.WriteLine();
            }
        }

        public void Show()
        {
            BufferExtraction();
            Console.SetCursorPosition(0, 0);
            Print();
        }
    }


        static public class EnumHelper
    {
        public static string ToDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }

    static public class _Set
    {
        static public void SetTextColor(string s)
        {
            switch (s)
            {
                case "Player":
                    Console.ForegroundColor = (ConsoleColor)_Limit.g_Limit_Color_Player;
                    break;

                case "Enemy":
                    Console.ForegroundColor = (ConsoleColor)_Limit.g_Limit_Color_Enemy;
                    break;

                default:
                    break;
            }
        }

        static public void SetScreen()
        {
            Console.SetWindowSize(_Limit.g_Limit_WindowWidth,_Limit.g_Limit_WindowHeight);
        }
    }
}
