using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacadePattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"server =. ; initial catalog = Hasta; integrated security = true");


        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter("Select * from Hastalar", connection);
            da.Fill (dt);
            hastabilgigrid.DataSource = dt;
            connection.Close();
        }
        KayıtlıHastalar recetesizHastalar = new KayıtlıHastalar();
        private void btnOgren_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = recetesizHastalar.GetAll();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            ReceteForm.id = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[0].Value);
            ReceteForm.tc = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            ReceteForm.adsoyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            FormControl.CreateReceteForm();
        }

        private void hastabilgigrid_Click(object sender, EventArgs e)
        {

        }
    }
}
