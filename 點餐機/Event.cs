using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
    internal class Event
    {
        public static event EventHandler<FlowLayoutPanel> NotifyRenderhPanel;

        public static void RefreshPanel (FlowLayoutPanel flowLayoutPaneldata)
        {
            NotifyRenderhPanel.Invoke(null, flowLayoutPaneldata);
        }
    }
}
