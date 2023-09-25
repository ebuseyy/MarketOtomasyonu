using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOtomasyonu
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MusteriFormu ms = new MusteriFormu();
            ms.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrunFormu ur = new UrunFormu();
            ur.ShowDialog();
        }
    }
}
