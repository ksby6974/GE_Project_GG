using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_GG_VAR;

namespace Project_GG
{
    internal class Pile
    {
        // 뽑을 뭉치
        protected int[] Pile_draw = new int[GlobalVAR.iLimit];

        // 버릴 뭉치
        protected int[] Pile_discard = new int[GlobalVAR.iLimit];


        public Pile()
        { 
        }
    }
}
