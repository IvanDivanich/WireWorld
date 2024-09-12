using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WireworldForms
{
    public class DataGridViewEx : DataGridView
    {
        public DataGridViewEx() : base()
        {
            // как это работает понятия не имею, в инете нашёл, но нужно для более быстрой работы
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
