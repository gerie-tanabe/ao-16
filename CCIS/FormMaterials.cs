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
    public partial class FormMaterials : Form
    {

        DataTable dtMaterials;

        public FormMaterials(DataTable _dtMaterials)
        {
            InitializeComponent();
            dtMaterials = _dtMaterials;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                this.textBoxLink.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void FormMaterials_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxDescription.Text) == false)
            {

                

                    DataRow dr = dtMaterials.NewRow();
                    dr["Description"] = this.textBoxDescription.Text;
                    dr["Path"] = this.textBoxLink.Text;
                    dtMaterials.Rows.Add(dr);
                    this.Close();

                
            }
        }
    }
}
