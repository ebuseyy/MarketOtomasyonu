using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarketOtomasyonu
{
    public partial class SatisFormu : Form
    {
        DBislem dbis = new DBislem();
        public SatisFormu()
        {
            InitializeComponent();
        }

        private void SatisFormu_Load(object sender, EventArgs e)
        {
            DataTable dt=dbis.getir("select MusID,Adi+' '+Soyadi as adsoyad from T_Musteri");
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                comboBox1.DataSource = dt;

                comboBox1.ValueMember = "MusID";

                comboBox1.DisplayMember = "adsoyad";
            }

            

            DataTable dt1 = dbis.getir("select UrunID,Adi from T_Urun");

            for (int i = 0; i < dt1.Rows.Count; i++)
            {

                comboBox2.DataSource = dt1;

                comboBox2.ValueMember = "UrunID";

                comboBox2.DisplayMember = "Adi";
            }


            verigetirSatis();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mid = (int)comboBox1.SelectedValue;

            int uid = (int)comboBox2.SelectedValue;


            DataTable dt = dbis.getir("select kalanstok from Vw_KalanStokGetir where UrunId="+ uid + "");

            if (Convert.ToInt32(textBox3.Text)> Convert.ToInt32(dt.Rows[0][0]))
            {
                MessageBox.Show("Yeterli stoğumuz yok");
            }
            else
                dbis.CreateUpdateDelete("insert into T_Satıs (musID,UrunID,miktar,fiyat) values(" + mid + "," + uid + ",'" + textBox3.Text + "','" + textBox4.Text + "')", "Müşteri Kayıt Başarılı");
            verigetirSatis();

        }
        public void verigetirSatis()
        {
            DataTable dt1 = dbis.getir("select (select Adi+' '+Soyadi from T_Musteri where MusID=S.MusID) as adsoyad,(select Adi from T_Urun where UrunID=S.UrunID) UrunAdi,miktar,fiyat from T_Satıs S");
            dataGridView1.DataSource = dt1;
        }

    }
}
