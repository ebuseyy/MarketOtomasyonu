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
            verigetirmusteri();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.CreateUpdateDelete("update T_Musteri set adi='"+textBox1.Text+ "',soyadi='"+textBox2.Text+ "',Tel='"+textBox3.Text+ "',adres='"+textBox4.Text+"' where MusID="+textBox5.Text+" ", "Müşteri Güncelleme Başarılı");
            verigetirmusteri();
        }

        private void MusteriFormu_Load(object sender, EventArgs e)
        {
            verigetirmusteri();
        }
        public void verigetirmusteri()
        {
            DataTable dt1 = db.getir("select * from T_Musteri");
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int satirno = dataGridView1.CurrentCell.RowIndex;

            textBox5.Text = dataGridView1.Rows[satirno].Cells["MusID"].Value.ToString();

            textBox1.Text = dataGridView1.Rows[satirno].Cells["Adi"].Value.ToString();

            textBox2.Text = dataGridView1.Rows[satirno].Cells["Soyadi"].Value.ToString();

            textBox3.Text = dataGridView1.Rows[satirno].Cells["Tel"].Value.ToString();

            textBox4.Text = dataGridView1.Rows[satirno].Cells["Adres"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.CreateUpdateDelete("delete from T_Musteri where MusID=" + textBox5.Text + " ", "Müşteri Silme Başarılı");
            verigetirmusteri();
        }
    }
}
