using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCIS
{
    class MyTab : System.Windows.Forms.TabControl
    {
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode)
                m.Result = (IntPtr)1;
            else
                base.WndProc(ref m);
        }    
    }    
}
