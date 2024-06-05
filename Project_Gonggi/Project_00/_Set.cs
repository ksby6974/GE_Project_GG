using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Project_GG
{
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
