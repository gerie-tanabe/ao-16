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
    public partial class FormUsers : Form
    {

        Boolean EditMode;
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlConnection cnn;
        public FormUsers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
            cnn.Open();
            da = new SqlDataAdapter("Select * from users", cnn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;
            
           
            SetToolBar();
        }

       

        private void SetToolBar()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                
                this.ToolBar.Items[0].Enabled = true;
                this.ToolBar.Items[1].Enabled = true;
                this.ToolBar.Items[2].Enabled = true;
                
                this.textBoxUsername.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                this.textBoxPassword.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
              
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
            this.textBoxUsername.Focus();
        }

        private void pSave_Click(object sender, EventArgs e)
        {

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            if (EditMode == true)
            {

                DataRow dr = dt.Rows[this.dataGridView1.SelectedRows[0].Index];
                dr["Username"] = this.textBoxUsername.Text;
                dr["Password"] = this.textBoxPassword.Text;
             
                try
                {

                    da.Update(dt);
                }
                catch (SqlException ex)
                {
                    dt.RejectChanges();

                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Username already exist", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
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


                        if (this.textBoxUsername.Text.Trim() != string.Empty)
                        {
                            if (CheckUsername(this.textBoxUsername.Text.Trim()) == false)
                            {

                                
                                DataRow dr = dt.NewRow();
                                dr["Username"] = this.textBoxUsername.Text.Trim();
                                dr["Password"] = this.textBoxPassword.Text.Trim();
                                dt.Rows.Add(dr);
                                da.Update(dt);
                                SetToolBar();
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                                this.textBoxUsername.Text = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString();
                                this.textBoxPassword.Text = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Username already taken.", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Blank username is not permitted.", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
            }

            EnableFields(false);
        }

        private void EnableFields(Boolean status)
        {
            this.textBoxUsername.ReadOnly = !status;
            this.textBoxPassword.ReadOnly = !status;

        }

        private void ClearTextBoxes()
        {
            this.textBoxUsername.Clear();
            this.textBoxPassword.Clear();
        }

        private void AddeditMode()
        {
            this.ToolBar.Items[0].Enabled = false;
            this.ToolBar.Items[1].Enabled = false;
            this.ToolBar.Items[2].Enabled = false;
            this.ToolBar.Items[4].Enabled = true;
            this.ToolBar.Items[5].Enabled = true;
        }

        private Boolean CheckUsername(string username)
        {
            foreach (DataRow d in dt.Rows)
            {
                if (d["Username"].ToString() == username)
                {
                    return true;
                }
            }

            return false;
        }

        private void pCancel_Click(object sender, EventArgs e)
        {
            SetToolBar();
            EnableFields(false);
            EditMode = false;
        }



       

        private void pDelete_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.Rows.Count > 1)
            {
                if (MessageBox.Show("are you sure you want to delete this user?", "User Accounts", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("Delete from users where username=@username", cnn);
                    cmd.Parameters.AddWithValue("@username", this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    this.dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                    if (dataGridView1.Rows.Count > 0)
                    {
                        this.dataGridView1.Rows[0].Selected = true;
                    }

                    SetToolBar();
                }
            }
            else
            {
                MessageBox.Show("Please create a new user for you to be able to delete this account.", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.textBoxUsername.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.textBoxPassword.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
               this.ToolBar.Items[4].PerformClick();
            }
        }

        private void pEdit_Click(object sender, EventArgs e)
        {
            EditMode = true;
            AddeditMode();
            EnableFields(true);
        }

        private void ToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
