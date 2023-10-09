using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MarketOtomasyonu
{

    internal class DBislem
    {
        SqlConnection baglanti = new SqlConnection("server=yourservername; database=marketoto; user id=userid; password=yourpass;");

        public void CreateUpdateDelete(string sql,string mesaj)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand(sql, baglanti);
            int sonuc = cmd.ExecuteNonQuery();

            if (sonuc > 0)
                MessageBox.Show(mesaj);

            baglanti.Close();
        }
        public DataTable getir(string sqlcumle)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlcumle,baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
