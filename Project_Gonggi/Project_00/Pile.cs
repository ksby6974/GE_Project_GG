using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    internal class Pile
    {
        // 뽑을 뭉치
        protected int[] Pile_draw = new int[Program.g_iLimit];

        // 버릴 뭉치
        protected int[] Pile_discard = new int[Program.g_iLimit];


        public Pile()
        { 
        }
    }
}
