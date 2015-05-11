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
    public partial class FormSignatories : Form
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da;

        public FormSignatories()
        {
            InitializeComponent();
        }

        private void FormSignatories_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
          
                
                cnn.Open();
                da = new SqlDataAdapter("Select * from documentdetails", cnn);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    this.signatoryTextBox.Text = dt.Rows[0]["Signatory"].ToString();
                    this.signatoryDesignationTextBox.Text = dt.Rows[0]["SignatoryDesignation"].ToString();
                    this.evaluatorTextBox.Text = dt.Rows[0]["Evaluator"].ToString();
                    this.evaluatorDesignationTextBox.Text = dt.Rows[0]["EvaluatorDesignation"].ToString();
                    this.notedByTextBox.Text = dt.Rows[0]["NotedBy"].ToString();
                    this.noterDesignationTextBox.Text = dt.Rows[0]["NoterDesignation"].ToString();
                }


           
        }



        private void pEdit_Click(object sender, EventArgs e)
        {
            this.ToolBar.Items[0].Enabled = false;
            this.ToolBar.Items[1].Enabled = true;
            this.ToolBar.Items[2].Enabled = true;
            EnableFields(true);
        }

        private void EnableFields(Boolean status)
        {


            foreach (Control t in this.tableLayoutPanel1.Controls)
            {
                //MessageBox.Show(t.Name + " " + t.GetType().ToString());
                if (t.GetType() == typeof(TextBox))
                {
                    (t as TextBox).ReadOnly = !status;
                }
            }
        }

        private void pCancel_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                this.signatoryTextBox.Text = dt.Rows[0]["Signatory"].ToString();
                this.signatoryDesignationTextBox.Text = dt.Rows[0]["SignatoryDesignation"].ToString();
                this.evaluatorTextBox.Text = dt.Rows[0]["Evaluator"].ToString();
                this.evaluatorDesignationTextBox.Text = dt.Rows[0]["EvaluatorDesignation"].ToString();
                this.notedByTextBox.Text = dt.Rows[0]["NotedBy"].ToString();
                this.noterDesignationTextBox.Text = dt.Rows[0]["NoterDesignation"].ToString();
            }
            EnableFields(false);
            this.ToolBar.Items[0].Enabled = true;
            this.ToolBar.Items[1].Enabled = false;
            this.ToolBar.Items[2].Enabled = false;

        }

        private void pSave_Click(object sender, EventArgs e)
        {

           
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataRow dr = dt.Rows[0];
                dr["Signatory"] = this.signatoryTextBox.Text;
                dr["SignatoryDesignation"] = this.signatoryDesignationTextBox.Text;
                dr["Evaluator"] = this.evaluatorTextBox.Text;
                dr["EvaluatorDesignation"] = this.evaluatorDesignationTextBox.Text;
                dr["NotedBy"] = this.notedByTextBox.Text;
                dr["NoterDesignation"] = this.noterDesignationTextBox.Text;


                da.Update(dt);
            

            EnableFields(false);
            this.ToolBar.Items[0].Enabled = true;
            this.ToolBar.Items[1].Enabled = false;
            this.ToolBar.Items[2].Enabled = false;
        }
    }
}
