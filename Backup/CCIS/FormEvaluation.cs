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

            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.ServerName = ".\\sqlexpress";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.DatabaseName = "ccis";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.UserID = "ccis";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.Password = "ccis";
            ReportParameter();


        }
        private void ReportParameter()
        {
            FormAO16 xform = (FormAO16)this.Owner;
    
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.ServerName = ".\\sqlexpress";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.DatabaseName = "ccis";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.UserID = "ccis";
            crystalReportViewer1.LogOnInfo[0].ConnectionInfo.Password = "ccis";


           CrystalReportEvaluation1.SetParameterValue("appno", xform.textBoxApplicationNo.Text);
           CrystalReportEvaluation1.SetParameterValue("APPNO", xform.textBoxApplicationNo.Text, "Materials");
           CrystalReportEvaluation1.SetParameterValue("APPNO", xform.textBoxApplicationNo.Text, "TechReq");


            crystalReportViewer1.Refresh();

        }

        private void FormEvaluation_Load(object sender, EventArgs e)
        {

        }
    }
}
