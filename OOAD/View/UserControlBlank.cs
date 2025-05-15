using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD
{
    public partial class UserControlBlank: UserControl
    {
        public UserControlBlank()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#FFF7F1");
        }

    }
}
