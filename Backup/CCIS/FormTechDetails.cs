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
    public partial class FormTechDetails : Form
 
    {
        DataTable dtTech;

        public FormTechDetails(DataTable dt)
        {
            InitializeComponent();
            dtTech = dt;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.textBoxTechReq.Text) == false)
            {

                if (TechDetailsExist(this.textBoxTechReq.Text) == false)
                {


                    DataRow dr = dtTech.NewRow();
                    dr["TechnicalDetails"] = this.textBoxTechReq.Text;
                    dtTech.Rows.Add(dr);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Item already in the list");
                }
            }
        }

        private void FormTechDetails_Load(object sender, EventArgs e)
        {

        }

        public Boolean TechDetailsExist(string strTechDetails)
        {
            foreach (DataRow d in dtTech.Rows)
            {
                if (d["TechnicalDetails"].ToString() == strTechDetails)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
