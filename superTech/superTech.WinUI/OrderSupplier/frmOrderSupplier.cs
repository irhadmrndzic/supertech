using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace superTech.WinUI.OrderSupplier
{
    public partial class frmOrderSupplier : Form
    {
        public frmOrderSupplier()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmOrderSupplier_Load(object sender, EventArgs e)
        {
            panelParent.AutoScroll = true;
        }
    }
}
