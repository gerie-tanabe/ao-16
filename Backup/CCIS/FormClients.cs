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
    public partial class FormClients : Form
    {
        SqlConnection cnn;
        DataTable dt= new DataTable();
        SqlDataAdapter da;
        Boolean EditMode;

        public FormClients()
        {
            InitializeComponent();
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
            cnn.Open();
            da = new SqlDataAdapter("Select * from CLIENTS", cnn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           


            SetToolBar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                this.textBoxAgency.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                this.textBoxAddress.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.textBoxContact.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EnableFields(Boolean status)
        {
            this.textBoxAgency.ReadOnly = !status;
            this.textBoxAddress.ReadOnly = !status;
            this.textBoxContact.ReadOnly = !status;

        }

        private void ClearTextBoxes()
        {
            this.textBoxAgency.Clear();
            this.textBoxAddress.Clear();
            this.textBoxContact.Clear();

        }

        private void AddeditMode()
        {
            this.ToolBar.Items[0].Enabled = false;
            this.ToolBar.Items[1].Enabled = false;
            this.ToolBar.Items[2].Enabled = false;
            this.ToolBar.Items[4].Enabled = true;
            this.ToolBar.Items[5].Enabled = true;
        }


        private void SetToolBar()
        {
            if (dataGridView1.Rows.Count > 0)
            {

                this.ToolBar.Items[0].Enabled = true;
                this.ToolBar.Items[1].Enabled = true;
                this.ToolBar.Items[2].Enabled = true;

                this.textBoxAgency.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                this.textBoxAddress.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.textBoxContact.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            }
            else
            {
                this.ToolBar.Items[0].Enabled = true;
                this.ToolBar.Items[1].Enabled = false;
                this.ToolBar.Items[2].Enabled = false;
            }

            this.ToolBar.Items[4].Enabled = false;
            this.ToolBar.Items[5].Enabled = false;




        }

        private void pAdd_Click(object sender, EventArgs e)
        {
            AddeditMode();
            EnableFields(true);
            ClearTextBoxes();
            this.textBoxAgency.Focus();
        }

        private void pSave_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            if (EditMode == true)
            {

                DataRow dr = dt.Rows[this.dataGridView1.SelectedRows[0].Index];
                dr["AgencyName"] = this.textBoxAgency.Text;                
                dr["Address"] = this.textBoxAddress.Text;
                dr["ContactNo"] = this.textBoxContact.Text;

                try
                {

                    da.Update(dt);
                }
                catch (SqlException ex)
                {
                    dt.RejectChanges();

                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Client name already exist", "Clients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        MessageBox.Show("Error occur while saving.");
                    }



                }
                EditMode = false;
                SetToolBar();
            }

            else
            {


                if (this.textBoxAgency.Text.Trim() != string.Empty)
                {
                    


                        DataRow dr = dt.NewRow();
                        dr["AgencyName"] = this.textBoxAgency.Text.Trim();
                        dr["Address"] = this.textBoxAddress.Text.Trim();
                        dr["ContactNo"] = this.textBoxContact.Text.Trim();
                        dt.Rows.Add(dr);

                        try
                        {
                            da.Update(dt);
                        }
                        catch(SqlException ex)
                        {
                            dt.RejectChanges();
                            if (ex.Number == 2627)
                            {
                                MessageBox.Show("Client name already exist", "Clients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        
                        SetToolBar();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                        this.textBoxAgency.Text = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString();
                        this.textBoxAddress.Text = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value.ToString();
                        this.textBoxContact.Text = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value.ToString();
                   

                }
                else
                {
                    MessageBox.Show("Agency name is required.", "Clients", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            EnableFields(false);
        }

        private void pEdit_Click(object sender, EventArgs e)
        {
            EditMode = true;
            AddeditMode();
            EnableFields(true);
        }

        private void pDelete_Click(object sender, EventArgs e)
        {
            
                if (MessageBox.Show("Are you sure you want to delete this client?", "Clients", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("Delete from clients where Agencyname=@agency", cnn);
                    cmd.Parameters.AddWithValue("@agency", this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    this.dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                    if (dataGridView1.Rows.Count > 0)
                    {
                        this.dataGridView1.Rows[0].Selected = true;
                    }
                    else
                    {
                        this.textBoxAgency.Clear();
                        this.textBoxAddress.Clear();
                        this.textBoxContact.Clear();
                    }

                    SetToolBar();
                }
                      
        }

        private void pCancel_Click(object sender, EventArgs e)
        {
            SetToolBar();
            EnableFields(false);
            EditMode = false;
        }
    }
}
