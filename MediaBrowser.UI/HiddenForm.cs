﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBrowser.UI
{
    public partial class HiddenForm : Form
    {
        private const int WM_APP = 0x8000;
        private const int WM_GRAPHNOTIFY = WM_APP + 1;
        private const int WM_DVD_EVENT = 0x00008002;
        
        public HiddenForm()
        {
            InitializeComponent();
        }

        public Action OnWMGRAPHNOTIFY { get; set; }
        public Action OnDVDEVENT { get; set; }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_GRAPHNOTIFY:
                    if (OnWMGRAPHNOTIFY != null)
                    {
                        OnWMGRAPHNOTIFY();
                    }
                    break;
                case WM_DVD_EVENT:
                    if (OnDVDEVENT != null)
                    {
                        OnDVDEVENT();
                    }
                    break;
            }
            
            base.WndProc(ref m);
        }
    }
}
