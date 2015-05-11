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
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("Select ApplicationNo as [Application Number], AgencyName as [Agency/Client],Address, ContactNo as [Contact],ProjectName as [Project], Purpose as [Purpose],CoverageArea as [Coverage] from Application Where ApplicationNo like @ApplicationNo  OR AgencyName like  @AgencyName OR Address like @Address OR ContactNo like @ContactNo OR Projectname like @Projectname OR CoverageArea like @CoverageArea", cnn);
                cmd.Parameters.AddWithValue("@ApplicationNo", "%" + this.toolStripTextBox.Text + "%");
                cmd.Parameters.AddWithValue("@AgencyName", "%" + this.toolStripTextBox.Text + "%");
                cmd.Parameters.AddWithValue("@Address", "%" + this.toolStripTextBox.Text + "%");
                cmd.Parameters.AddWithValue("@ContactNo", "%" + this.toolStripTextBox.Text + "%");
                cmd.Parameters.AddWithValue("@ProjectName", "%" + this.toolStripTextBox.Text + "%");
                cmd.Parameters.AddWithValue("@CoverageArea", "%" + this.toolStripTextBox.Text + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;
            }
        }

        public string ApplicatioNo { get; set; }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                ApplicatioNo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
