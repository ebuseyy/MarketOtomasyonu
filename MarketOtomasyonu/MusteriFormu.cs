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
    public partial class MusteriFormu : Form
    {
        DBislem db = new DBislem();
        public MusteriFormu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            db.CreateUpdateDelete("insert into T_Musteri (adi,soyadi,tel,adres) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')","Müşteri Kayıt Başarılı");
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //db.CreateUpdateDelete("update T_Musteri set ", "Müşteri Güncelleme Başarılı");
        }

        private void MusteriFormu_Load(object sender, EventArgs e)
        {
            DataTable dt1=db.getir("select * from T_Musteri");
            dataGridView1.DataSource = dt1;
        }
    }
}
