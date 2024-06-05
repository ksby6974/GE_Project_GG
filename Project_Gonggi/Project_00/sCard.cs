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
        [Description ("Straight Shot")] StraightShot,
        [Description("Defense")] Defense,
        [Description("Moving")] Moving,
    }
}
