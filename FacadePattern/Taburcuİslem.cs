using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacadePattern
{
   public class Taburcuİslem
    {
       
        private static int _receteliHasta;
        private static int _tumHastalar;
        public int ReceteliHasta
        {
            get { return _receteliHasta; }
            set { _receteliHasta = value; }
        }
        public int TumHastalar
        {
            get { return _tumHastalar; }
            set { _tumHastalar = value; }
        }

       
        public void TaburcuBilgisiVer()
        {
            MessageBox.Show("Receteli Hasta Sayısı: " + _receteliHasta + "\nRecetesiz Hasta Sayısı: " + (_tumHastalar - _receteliHasta) + "\nToplam Hasta Sayısı : " + (_tumHastalar ), "Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
