﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_GG
{
    public class DoubleBufferPanel : Panel
    {

        public DoubleBufferPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }
}
