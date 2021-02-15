using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacadePattern
{
    public class ReceteOlustur
    {
        SqlConnection connection = new SqlConnection(@"server =. ; initial catalog = Hasta; integrated security = true");
        public void ReceteYaz()
        {
            int receteliHastaSayisi = 0;


            if (ControlManager.ReceteDurum())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into Recete (HastaAdSoyad,HastaTc,IlacAd,KacKutu,GundeKacTane,AcTok) values(@p2,@p3,@p4,@p5,@p6,@p7)",connection);
                command.Parameters.AddWithValue("@p2", ReceteForm.adsoyad);
                command.Parameters.AddWithValue("@p3", ReceteForm.tc);
                command.Parameters.AddWithValue("@p4", ReceteForm.ilacad);
                command.Parameters.AddWithValue("@p5", ReceteForm.kaçkutu);
                command.Parameters.AddWithValue("@p6", ReceteForm.kackez);
                command.Parameters.AddWithValue("@p7", ReceteForm.actok);
                command.ExecuteNonQuery();

                connection.Close();

                receteliHastaSayisi++;
                ReceteListele();
                MessageBox.Show("Recete basarı ile oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
        public List<ReceteliHasta> ReceteListele()
        {
            List<ReceteliHasta> recetelihastalar = new List<ReceteliHasta>();
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Recete", connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                ReceteliHasta h = new ReceteliHasta();
                h.ReceteId = Convert.ToInt32(dr[0]);
                h.HastaAdSoyad = dr[1].ToString();
                h.HastaTc = dr[2].ToString();
                h.IlacAd = dr[3].ToString();
                h.KacKutu = Convert.ToInt32(dr[4]);
                h.GundeKacTane = Convert.ToInt32(dr[5].ToString());
                h.AcTok = dr[6].ToString();
                recetelihastalar.Add(h);
            }

            Taburcuİslem islem = new Taburcuİslem();
            islem.ReceteliHasta = recetelihastalar.GroupBy(x => x.HastaTc).Count();
            connection.Close();
            return recetelihastalar;

        }
    }
}
