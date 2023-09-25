
using System.Data;

namespace MarketOtomasyonu
{
    public partial class UrunFormu : Form
    {
        DBislem db = new DBislem();
        public UrunFormu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            db.CreateUpdateDelete("insert into T_URUN (adi,aciklama) values('" + textBox1.Text + "','" + textBox2.Text + "')","Ürün Kayýt Baþarýlý");
  


        }

        private void UrunFormu_Load(object sender, EventArgs e)
        {
            DataTable dt1 = db.getir("select * from T_Urun");
            dataGridView1.DataSource = dt1;
        }
    }
}