using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class KayıtlıHastalar
    {
        Hasta hasta = new Hasta();
        List<Hasta> mhastalar = new List<Hasta>();
        public static List<Hasta> rhastalar = new List<Hasta>();
        public List<Hasta> GetAll()
        {
            SqlConnection connection = new SqlConnection(@"server=. ; initial catalog=Hasta; integrated security=true");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Hastalar ",connection);
            SqlDataReader dr = command.ExecuteReader();
            int tumHastalar = 0;
            while (dr.Read())
            {
                {
                    Hasta hasta = new Hasta();
                    hasta.HastaId = Convert.ToInt32(dr[0]);
                    hasta.HastaTc = dr[1].ToString();
                    hasta.HastaAdSoyad = dr[2].ToString();
                    hasta.HastaSikayet = dr[3].ToString();
                    hasta.MuayeneDurum = dr[4].ToString();
                    hasta.YatısDurum = dr[5].ToString();
                    tumHastalar++;
                   if(dr[4].ToString().Equals("True")&& dr[5].ToString().Equals("False"))
                    {
                        rhastalar.Add(hasta);
                    }
                };
            }
            Taburcuİslem islem = new Taburcuİslem();
            islem.TumHastalar = tumHastalar;
            connection.Close();
            return rhastalar;

        }
    }
}
