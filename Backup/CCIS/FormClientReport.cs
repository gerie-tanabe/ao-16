using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCIS
{
    public partial class FormClientReport : Form
    {
        public FormClientReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.ServerName = ".\\sqlexpress";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.DatabaseName = "ccis";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.UserID = "ccis";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.Password = "ccis";
        }
    }
}
