
using System.Data;

namespace MarketOtomasyonu
{
    public partial class UrunFormu : Form
    {
        int secilenID = 0;
        DBislem db = new DBislem();
        public UrunFormu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            DataTable dt1 = db.getir("exec Sp_UrunIsýmKontrol '" + textBox1.Text + "','" + textBox2.Text + "'");


            MessageBox.Show(dt1.Rows[0][0].ToString());

            verigetirurun();



        }

        private void UrunFormu_Load(object sender, EventArgs e)
        {
            verigetirurun();
        }
        public void verigetirurun()
        {
            DataTable dt1 = db.getir("select * from T_Urun");
            dataGridView1.DataSource = dt1;
        }
        public void verigetirurunDetay( int ID)
        {
            DataTable dt1 = db.getir("select * from T_UrunDetay where UrunID="+ID+"");
            dataGridView2.DataSource = dt1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.CreateUpdateDelete("update T_Urun set adi='" + textBox1.Text + "',aciklama='" + textBox2.Text + "' where UrunID=" + secilenID + " ", "Ürün Güncelleme Baþarýlý");
            verigetirurun();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int satirno = dataGridView1.CurrentCell.RowIndex;

            secilenID = Convert.ToInt32(dataGridView1.Rows[satirno].Cells["UrunID"].Value);

            textBox1.Text = dataGridView1.Rows[satirno].Cells["Adi"].Value.ToString();

            textBox2.Text = dataGridView1.Rows[satirno].Cells["Aciklama"].Value.ToString();


            verigetirurunDetay(secilenID);
            panel1.Visible = true;




          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.CreateUpdateDelete("delete from T_Urun where UrunID=" + secilenID + " ", "Ürün Silme Baþarýlý");
            verigetirurun();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Satýþ")
            {
                DataTable dt1 = db.getir("exec Sp_UrunKontrol " + secilenID + "");

                if (Convert.ToInt32(textBox3.Text) > Convert.ToInt32(dt1.Rows[0][0]))
                {
                    MessageBox.Show("Satoðundan fazla Satýþ yapamazsýnýz...", "Uyarý");
                    return;
                }
            }


            db.CreateUpdateDelete("insert into T_URUNdetay (urunID,islem,miktar,fiyat) values(" + secilenID + ",'" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", "Ürün detay Kayýt Baþarýlý");
            
           

            verigetirurunDetay(secilenID);
        }
    }
}