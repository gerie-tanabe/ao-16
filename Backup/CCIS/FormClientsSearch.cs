using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CCIS
{
    public partial class FormClientsSearch : Form
    {
        public FormClientsSearch()
        {
            InitializeComponent();
        }

        private void FormClientsSearch_Load(object sender, EventArgs e)
        {
            toolStripButton1.PerformClick();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("Select AgencyName as [Agency], Address, ContactNo as [Contact No.] FROM clients  WHERE  Agencyname like @Agency OR  Address like @Address OR ContactNo like @ContactNo ORDER BY AgencyName", cnn);
                cmd.Parameters.AddWithValue("@Agency", "%" + this.toolStripTextBox.Text + "%");
                cmd.Parameters.AddWithValue("@Address", "%" + this.toolStripTextBox.Text + "%");
                cmd.Parameters.AddWithValue("@ContactNo", "%" + this.toolStripTextBox.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                FormAO16 form = (FormAO16)this.Owner;
                
                
                form.textBoxAgency.Text= dataGridView1.SelectedRows[0].Cells[0].Value.ToString() ;
                form.textBoxAddress.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                form.textBoxContact.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
