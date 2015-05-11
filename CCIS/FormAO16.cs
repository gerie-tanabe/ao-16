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
using System.Drawing.Drawing2D;

namespace CCIS
{
    public partial class FormAO16 : Form
    {
        Record MyRecord;
        public FormAO16()
        {
            InitializeComponent();
        }

        private void FormAO16_Load(object sender, EventArgs e)
        {
            MyRecord = new Record(this.ToolBar);           
            LoadUsers();
            DisplayRecords();
            

        }

        

        public void DisplayRecords()
        {
            this.textBoxApplicationNo.Text = MyRecord.ApplicationNo.ToString();
            this.textBoxAgency.Text = MyRecord.Agency.ToString();
            this.textBoxAddress.Text = MyRecord.Address.ToString();
            this.textBoxContact.Text = MyRecord.ContactNo.ToString();
            this.textBoxProjectName.Text = MyRecord.ProjectName.ToString();
            this.textBoxPurpose.Text = MyRecord.Purpose.ToString();
            this.textBoxCoverage.Text = MyRecord.CoverageArea.ToString();
            this.textBoxProjectDetails.Text = MyRecord.ProjectDetails.ToString();
            this.textBoxFindings.Text = MyRecord.Findings.ToString();
            this.textBoxRecommendations.Text = MyRecord.Recommendations.ToString();

            if (string.IsNullOrEmpty(MyRecord.DateIssued))
            {

                this.dtpIssued.Checked = false;
                this.dtpIssued.CustomFormat = " ";
            }
            else
            {

                this.dtpIssued.Checked = true;
                this.dtpIssued.CustomFormat = "MMMM dd, yyyy";
                this.dtpIssued.Value = Convert.ToDateTime(MyRecord.DateIssued);
            }

            if (string.IsNullOrEmpty(MyRecord.DateReleased))
            {

                this.dtpReleased.Checked = false;
                this.dtpReleased.CustomFormat = " ";
            }
            else
            {

                this.dtpReleased.Checked = true;
                this.dtpReleased.CustomFormat = "MMMM dd, yyyy";
                this.dtpReleased.Value = Convert.ToDateTime(MyRecord.DateReleased);
            }

            if (string.IsNullOrEmpty(MyRecord.DateRequested))
            {

                this.dtpRequested.Checked = false;
                this.dtpRequested.CustomFormat = " ";
            }
            else
            {

                this.dtpRequested.Checked = true;
                this.dtpRequested.CustomFormat = "MMMM dd, yyyy"; 
                this.dtpRequested.Value = Convert.ToDateTime(MyRecord.DateRequested);
            }

            this.dataGridViewProcurement.DataSource = MyRecord.Procurement();
            this.dataGridViewProcurement.Columns["ApplicationNo"].Visible = false;
            this.dataGridViewTechDetails.DataSource = MyRecord.TechDetails();
            this.dataGridViewTechDetails.Columns["ApplicationNo"].Visible = false;

            this.dataGridViewMaterials.DataSource = MyRecord.Materials();
            this.dataGridViewMaterials.Columns["ApplicationNo"].Visible = false;
            this.dataGridViewMaterials.Columns["Path"].Visible = false;
            
            this.checkBox1.Checked = String.IsNullOrEmpty(MyRecord.InNamria)?false:Convert.ToBoolean(MyRecord.InNamria);
            this.checkBox2.Checked = String.IsNullOrEmpty(MyRecord.InGovernment)?false:Convert.ToBoolean(MyRecord.InGovernment);
            this.checkBox3.Checked = String.IsNullOrEmpty(MyRecord.OnGoing)?false:Convert.ToBoolean(MyRecord.OnGoing);
            
        }

        private void pNext_Click(object sender, EventArgs e)
        {
            MyRecord.Next();
            DisplayRecords();
        }

        private void pBack_Click(object sender, EventArgs e)
        {
            MyRecord.Back();
            DisplayRecords();
        }

        private void pAdd_Click(object sender, EventArgs e)
        {
            
            EnableFields(true);
           
            MyRecord.New();
            ClearForm();
            
        }

        private void ClearForm()
        {
            foreach (Control c in tabData.Controls)
            {

                if (c.GetType() == typeof(TextBox))
                {
                    c.Text = string.Empty;
                }

                if (c.GetType() == typeof(DateTimePicker))
                {
                    (c as DateTimePicker).Value = DateTime.Now;
                    (c as DateTimePicker).Checked = false;                    
                    (c as DateTimePicker).CustomFormat = " ";
                    
                }
            }

           this.dataGridViewProcurement.DataSource = MyRecord.Procurement();
        }

        private void EnableFields(Boolean status)
        {
            foreach (Control c in tabData.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ( c as TextBox).ReadOnly = !status;
                   
                }

                this.textBoxApplicationNo.ReadOnly = true;
                if (c.GetType() == typeof(DateTimePicker))
                {
                    (c as DateTimePicker).Enabled = status;

                }

                toolStripProcurement.Enabled = status;
                toolStripTechnicalDetails.Enabled = status;
                toolStripMaterials.Enabled = status;

                checkBox1.Enabled = status;
                checkBox2.Enabled = status;
                checkBox3.Enabled = status;

                buttonAgency.Enabled = status;


            }
        }


        private void tabLogin_Click(object sender, EventArgs e)
        {

        }

        public void LoadUsers()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString))
            {

                cnn.Open();
                DataTable dtusers = new DataTable();


                SqlDataAdapter da = new SqlDataAdapter("SELECT Username from Users", cnn);
                da.Fill(dtusers);

                this.comboBoxUsernames.DataSource = dtusers;
                this.comboBoxUsernames.DisplayMember = "Username";
                this.comboBoxUsernames.SelectedIndex = -1;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabMain.SelectTab("tabData");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            
            
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString))
            {
                try
                {
                    cnn.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message,"Cannot open connection to AO16 Database.");
                    return;
                }
                DataTable dtusers = new DataTable();
                SqlCommand cmd = new SqlCommand("SELECT * from Users Where username=@uid and password=@pwd", cnn);
                cmd.Parameters.AddWithValue("@uid", this.comboBoxUsernames.Text);
                cmd.Parameters.AddWithValue("@pwd", this.textBoxPassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(dtusers);

                if (dtusers.Rows.Count > 0)
                {
                    this.comboBoxUsernames.Text = "";
                    this.textBoxPassword.Text = "";
                    this.tabMain.SelectTab("tabData");
                    textBoxAgency.DeselectAll();
                    this.toolStripLabel1.Text =  dtusers.Rows[0]["username"].ToString();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Access Denied");
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonLogout_Click(object sender, EventArgs e)
        {
            LoadUsers();
            this.tabMain.SelectTab("tabLogin");
        }

        private void tabData_Click(object sender, EventArgs e)
        {

        }

        private void pCancel_Click(object sender, EventArgs e)
        {
            MyRecord.Cancel();
            DisplayRecords();
            EnableFields(false);
        }

        private void pSave_Click(object sender, EventArgs e)
        {
            
            
            
            
            
            MyRecord.Agency = this.textBoxAgency.Text;
            MyRecord.Address = this.textBoxAddress.Text;
            MyRecord.ContactNo = this.textBoxContact.Text;
            MyRecord.ProjectName = this.textBoxProjectName.Text;
            MyRecord.Purpose = this.textBoxPurpose.Text;
            MyRecord.CoverageArea = this.textBoxCoverage.Text;
            MyRecord.DateIssued = dtpIssued.Checked ? dtpIssued.Value.ToShortDateString() : string.Empty;
            MyRecord.DateReleased = dtpReleased.Checked ? dtpReleased.Value.ToShortDateString() : string.Empty;
            MyRecord.DateRequested = dtpRequested.Checked ? dtpRequested.Value.ToShortDateString() : string.Empty;
            MyRecord.ProjectDetails = this.textBoxProjectDetails.Text;
            MyRecord.Findings = this.textBoxFindings.Text;
            MyRecord.Recommendations = this.textBoxRecommendations.Text;
            MyRecord.InNamria = this.checkBox1.Checked.ToString();
            MyRecord.InGovernment = this.checkBox2.Checked.ToString();
            MyRecord.OnGoing = this.checkBox3.Checked.ToString();

            MyRecord.Save();
            DisplayRecords();
            EnableFields(false);
        }

        private void dtpIssued_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;


            if (dtp.Checked != true)
            {
                dtp.CustomFormat = " ";
                dtp.Format = DateTimePickerFormat.Custom;
            }
            else
            {

                dtp.CustomFormat = "MMMM dd, yyyy";               
                
            }
        }

        private void dtpReleased_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;


            if (dtp.Checked != true)
            {
                dtp.CustomFormat = " ";
                dtp.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtp.CustomFormat = "MMMM dd, yyyy";    

            }
        }

        private void dtpRequested_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;


            if (dtp.Checked != true)
                
            {
                dtp.CustomFormat = " ";
                dtp.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtp.CustomFormat = "MMMM dd, yyyy";    

            }
        }

        private void pEdit_Click(object sender, EventArgs e)
        {
            MyRecord.AddEditMode();
            EnableFields(true);
        }

        private void pDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this record?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MyRecord.Delete();
                DisplayRecords();
                
            }
        }

        private void procAdd_Click(object sender, EventArgs e)
        {
            FormProcurement xform = new FormProcurement(MyRecord.TempProcurement());
            xform.ShowDialog();

            this.dataGridViewProcurement.DataSource = MyRecord.TempProcurement();
          

        }

        private void procDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewProcurement.SelectedRows)
            {

                this.dataGridViewProcurement.Rows.RemoveAt(row.Index);
               
            }  
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormTechDetails form = new FormTechDetails(MyRecord.TempTechDetails());
            form.ShowDialog();
            this.dataGridViewTechDetails.DataSource = MyRecord.TempTechDetails();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void techDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewTechDetails.SelectedRows)
            {

                this.dataGridViewTechDetails.Rows.RemoveAt(row.Index);

            }
        }

        private void comboBoxUsernames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.textBoxPassword.Focus();
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.buttonLogin.PerformClick();
            }
        }

        private void matAdd_Click(object sender, EventArgs e)
        {
            FormMaterials form = new FormMaterials(MyRecord.TempMaterials());
            form.ShowDialog();
            this.dataGridViewMaterials.DataSource = MyRecord.TempMaterials();
        }

        private void matDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewMaterials.SelectedRows)
            {

                this.dataGridViewMaterials.Rows.RemoveAt(row.Index);

            }
        }

        private void dataGridViewMaterials_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                

              if (e.RowIndex != -1)
              {
                System.Diagnostics.Process.Start(dataGridViewMaterials.SelectedRows[0].Cells[2].Value.ToString());
                  
              }
            }
            catch
            {
                
                 MessageBox.Show("Cannot open file");
            }
        }

        private void buttonAgency_Click(object sender, EventArgs e)
        {
            FormClientsSearch form = new FormClientsSearch();

            form.ShowDialog(this);
        }


        public void AgencyName(string Agency)
        {
            this.textBoxAgency.Text = Agency;

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FormUsers form = new FormUsers();
            form.ShowDialog();
        }

        private void clientListingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientReport form = new FormClientReport();
            form.ShowDialog();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClients form = new FormClients();
            form.ShowDialog();
        }

        private void signatoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSignatories xform = new FormSignatories();
            xform.ShowDialog();
        }

        private void issuedCertificatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIssuedCertificates xform = new FormIssuedCertificates();
            xform.ShowDialog();
        }

        private void pendingCertificatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPendingCertificate xform = new FormPendingCertificate();
            xform.ShowDialog();
        }

        private void clearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormCrystalReportClearance();
            form.Show(this);
        }

        private void evaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormEvaluation();
            form.Show(this);
        }

        private void FormAO16_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void pSearch_Click(object sender, EventArgs e)
        {
            


            using (var form = new FormSearch())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MyRecord.Search(form.ApplicatioNo.ToString());
                        DisplayRecords();
                        form.Dispose();
                    }
                }


        }

        private void linkLabelClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.comboBoxUsernames.SelectedIndex = -1;
            this.textBoxPassword.Text = string.Empty;
        }

        private void tabLogin_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, this.tabLogin.Width - 1, this.tabLogin.Height - 1);
            LinearGradientBrush mybrush = new LinearGradientBrush(rect,  Color.White,Color.Gainsboro, 90);
            e.Graphics.FillRectangle(mybrush, rect);
        }

        private void tabData_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, this.tabData.Width - 1, this.tabData.Height - 1);
            LinearGradientBrush mybrush = new LinearGradientBrush(rect, Color.White, Color.Gainsboro, 90);
            e.Graphics.FillRectangle(mybrush, rect);
        }

        private void pPrint_Click(object sender, EventArgs e)
        {
            Form form = new FormCrystalReportClearance();
            form.Show(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        private void abouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox1 form = new AboutBox1();
            form.ShowDialog();
        }

        private void toolStripCount_Click(object sender, EventArgs e)
        {

        }

    }
}
