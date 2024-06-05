using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    static public class _Data
    {
        static public string Data_EnemyName(int id)
        {
            string sName = "default";

            switch (id)
            {
                case 1:
                    sName = "Slime";
                    break;

                default:
                    sName = "default";
                    break;
            }

            return sName;
        }

        static public string Data_CardName(int id)
        {
            string sName = "Blank";

            switch (id)
            {
                case (int)CardName.StraightShot:
                    sName = "StraightShot";
                    break;

                case (int)CardName.Defense:
                    sName = "Defense";
                    break;

                case (int)CardName.Moving:
                    sName = "Moving";
                    break;

                default:
                    sName = "Blank";
                    break;
            }

            return sName;
        }
    }
}
