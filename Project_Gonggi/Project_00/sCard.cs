using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_GG
{
    public class sCard
    {
        private int iIndex;

        public sCard(int iCard)
        {
            iIndex = iCard;

            iIndex = 1;
        }

        public void SetCard(ref Card card)
        {
            sCard newCard = new sCard(1);

            var method = typeof(sCard).GetMethod($"SetCard_{this.iIndex}");
            //method.Invoke(newCard, null);

            Console.WriteLine($"{method}");
        }

        public void SetCard_1(ref Card card)
        {

        }
    }
}
