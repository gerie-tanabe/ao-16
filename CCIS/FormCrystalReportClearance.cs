using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using System.Data.SqlClient;

namespace CCIS
{
    public partial class FormCrystalReportClearance : Form
    {

        
        public FormCrystalReportClearance()
        {
            InitializeComponent();
           
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
             FormAO16 form = (FormAO16)this.Owner;

             SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
  
             crystalReportViewerClearance.LogOnInfo[0].ConnectionInfo.ServerName = builder.DataSource;
             crystalReportViewerClearance.LogOnInfo[0].ConnectionInfo.DatabaseName = "ccis";
             crystalReportViewerClearance.LogOnInfo[0].ConnectionInfo.UserID = "ccis";
             crystalReportViewerClearance.LogOnInfo[0].ConnectionInfo.Password = "ccis";
             CrystalReportClearance3.SetParameterValue("appno", form.textBoxApplicationNo.Text);           
             crystalReportViewerClearance.Refresh();            

        }



    }
}