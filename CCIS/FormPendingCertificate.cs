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
    public partial class FormPendingCertificate : Form
    {
        public FormPendingCertificate()
        {
            InitializeComponent();
        }



        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.ServerName = builder.DataSource;
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.DatabaseName = "ccis";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.UserID = "ccis";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.Password = "ccis";

          

        }
    }
}
