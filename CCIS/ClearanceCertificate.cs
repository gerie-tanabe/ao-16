using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace CCIS
{
    public partial class ClearanceCertificate : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        

        public ClearanceCertificate()
        {
           
            InitializeComponent();
        }

        private void ClearanceCertificate_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'ccisDataSet.application' table. You can move, or remove it, as needed.
            
            
            
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }
    }
}