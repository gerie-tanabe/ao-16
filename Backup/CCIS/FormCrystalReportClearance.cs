using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CCIS
{
    public partial class FormCrystalReportClearance : Form
    {

        
        public FormCrystalReportClearance()
        {
            InitializeComponent();
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            
        }

        private void SetParameter()
        {
            FormAO16 form = (FormAO16)this.Owner;

            crystalReportViewer2.LogOnInfo[0].ConnectionInfo.ServerName = ".\\sqlexpress";
            crystalReportViewer2.LogOnInfo[0].ConnectionInfo.DatabaseName = "ccis";
            crystalReportViewer2.LogOnInfo[0].ConnectionInfo.UserID = "ccis";
            crystalReportViewer2.LogOnInfo[0].ConnectionInfo.Password = "ccis";
            CrystalReportClearance2.SetParameterValue("appno", form.textBoxApplicationNo.Text);
            crystalReportViewer2.Refresh();
        }



        private void CrystalReportClearance1_InitReport(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            crystalReportViewer2.LogOnInfo[0].ConnectionInfo.ServerName = ".\\sqlexpress";
            crystalReportViewer2.LogOnInfo[0].ConnectionInfo.DatabaseName = "ccis";
            crystalReportViewer2.LogOnInfo[0].ConnectionInfo.UserID = "ccis";
            crystalReportViewer2.LogOnInfo[0].ConnectionInfo.Password = "ccis";

            SetParameter();
        }

        private void crystalReportViewer2_Load_1(object sender, EventArgs e)
        {

        }

    }
}