using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using System.Data.SqlClient;

namespace CCIS
{
    public partial class FormEvaluation : Form
    {
      
        
        public FormEvaluation()
        {
            InitializeComponent(); 
          
        }

   


        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

          FormAO16 xform = (FormAO16)this.Owner;
          SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
          crystalReportViewer1.LogOnInfo[0].ConnectionInfo.ServerName = builder.DataSource;
          crystalReportViewer1.LogOnInfo[0].ConnectionInfo.DatabaseName = "ccis";
          crystalReportViewer1.LogOnInfo[0].ConnectionInfo.UserID = "ccis";
          crystalReportViewer1.LogOnInfo[0].ConnectionInfo.Password = "ccis";


          CrystalReportEvaluation1.SetParameterValue("appno", xform.textBoxApplicationNo.Text);
          CrystalReportEvaluation1.SetParameterValue("APPNO", xform.textBoxApplicationNo.Text, "Materials");
          CrystalReportEvaluation1.SetParameterValue("APPNO", xform.textBoxApplicationNo.Text, "TechReq");

            //using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString))
            //{

            //    cnn.Open();
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter("select *,stuff ((select ' and ' + [description]   from procurement where procurement.ApplicationNo=Application.applicationNo for xml path('')),1,5,'') as [procurements] from Application", cnn);
            //    da.Fill(dt);
            //    //crystalReportViewer1.ReportSource = dt;
                
            
            //}
            crystalReportViewer1.Refresh();


        }
      

             
    }
}
