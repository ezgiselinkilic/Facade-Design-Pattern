using DevExpress.XtraExport.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacadePattern
{
    public partial class ReceteForm : Form
    {
        public static int id;
        public static string adsoyad;
        public static string tc;
        public static string ilacad;
        public static int kaçkutu;
        public static int kackez;
        public static string actok;
        public ReceteForm()
        {
            InitializeComponent();
        }
        Facade facade = new Facade();
        private void btnOlustur_Click(object sender, EventArgs e)
        {
           
            adsoyad = txtAdSoyad.Text;
            tc = txtTC.Text;
            ilacad = txtilacad.Text;
            kaçkutu = Convert.ToInt32(txtkackutu.Text);
            kackez = Convert.ToInt32(txtkackez.Text);
            actok = txtactok.Text;
            facade.ReceteYaz();
            recetegrid.DataSource = facade.ReceteYazdır();
            facade.TaburcuBilgisiVer();
            
        }
        private void ReceteForm_Load(object sender, EventArgs e)
        {
            txtAdSoyad.Text = adsoyad;
            txtTC.Text = tc;
        }

        private void recetegrid_Click(object sender, EventArgs e)
        {

        }
    }
}
