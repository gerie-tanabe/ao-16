using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CCIS
{
    public partial class FormProcurement : Form
    {

        DataTable dtProc;
        
        public FormProcurement(DataTable dt)
        {
            InitializeComponent();
            dtProc = dt;
        }

        private void FormProcurement_Load(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand("Select Distinct [Description] FROM Procurement", cnn);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridViewProcurement.DataSource = dt;
            }
        }

        private void dataGridViewProcurement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewProcurement_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewProcurement.SelectedRows.Count>0)
            {
                this.textBoxProcurement.Text = this.dataGridViewProcurement.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            

            if (!string.IsNullOrEmpty(this.textBoxProcurement.Text))
            {
                if (ProcurementExist(this.textBoxProcurement.Text) == false)
                {
                    DataRow dr = dtProc.NewRow();
                    dr["Description"] = this.textBoxProcurement.Text;
                    dtProc.Rows.Add(dr);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Item already in the list");
                }
            }
        }
        public Boolean ProcurementExist(string strProc)
        {
            foreach (DataRow d in dtProc.Rows)
            {

                if (d.RowState != DataRowState.Deleted)
                {
                    if (d["Description"].ToString() == strProc)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
