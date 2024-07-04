using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    public enum CardName
    {
        [Description("Blank")] Blank,
        [Description("Straight Shot")] StraightShot,
        [Description("Trick Shot")] TrickShot,
        [Description("Defense")] Defense,
    }

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
                    sName = "Straight Shot";
                    break;

                case (int)CardName.Defense:
                    sName = "Defense";
                    break;

                case (int)CardName.TrickShot:
                    sName = "Trick Shot";
                    break;

                default:
                    sName = "Blank";
                    break;
            }

            return sName;
        }
    }
}
