using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CCIS
{
    class Record
    {

        DataTable dt = new DataTable();
        DataTable dtProcurement;
        DataTable dtTechDetails;
        DataTable dtMaterials;

        SqlDataAdapter da;
        SqlDataAdapter daProcurement;
        SqlDataAdapter daTechDetails;
        SqlDataAdapter daMaterials;

        ToolStrip MyToolStrip;
        int index = -1;
        int _Count;
        Boolean isNew;

        public Record(ToolStrip _toolstrip)
        {
            MyToolStrip = _toolstrip;

             SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
           
                cnn.Open();

                da = new SqlDataAdapter("Select * from Application ORDER BY ApplicationNo desc", cnn);
                da.Fill(dt);
                index = dt.Rows.Count > 0 ? 0 : -1;
                _Count = dt.Rows.Count;
                SetToolBar();
                GetValues();

            
        }

        public DataTable Procurement()
        {
            dtProcurement = new DataTable();           
          
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
            cnn.Open();
            
            SqlCommand cmd = new SqlCommand("Select * from Procurement WHERE ApplicationNo=@AppNo", cnn);
            cmd.Parameters.AddWithValue("@AppNo",ApplicationNo);
            daProcurement = new SqlDataAdapter(cmd);   

            daProcurement.Fill(dtProcurement);         
            return dtProcurement;

        }

        public DataTable TechDetails()
        {
            dtTechDetails = new DataTable();

            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Select * from TechDetails WHERE ApplicationNo=@AppNo", cnn);
            cmd.Parameters.AddWithValue("@AppNo", ApplicationNo);
            daTechDetails = new SqlDataAdapter(cmd);

            daTechDetails.Fill(dtTechDetails);

          
            return dtTechDetails;

        }


        public DataTable Materials()
        {
            dtMaterials = new DataTable();

            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Attachments WHERE ApplicationNo=@AppNo", cnn);
            cmd.Parameters.AddWithValue("@AppNo", ApplicationNo);
            daMaterials = new SqlDataAdapter(cmd);
            daMaterials.Fill(dtMaterials);

            return dtMaterials;

        }



        public DataTable TempProcurement()
        {
            return dtProcurement;
        }

        public DataTable TempTechDetails()
        {
            return dtTechDetails;
        }

        public DataTable TempMaterials()
        {
            return dtMaterials;
        }

       



        private void SetToolBar()
        {
            if (Count > 0)
            {

                if (Count == 1)
                {
                    MyToolStrip.Items[0].Enabled = false;
                    MyToolStrip.Items[3].Enabled = false;
                }
                else
                {
                    if (index == 0)
                    {
                        MyToolStrip.Items[0].Enabled = false;
                        MyToolStrip.Items[3].Enabled = true;

                    }
                    else if (index == Count - 1)
                    {
                        MyToolStrip.Items[0].Enabled = true;
                        MyToolStrip.Items[3].Enabled = false;
                    }
                    else
                    {
                        MyToolStrip.Items[0].Enabled = true;
                        MyToolStrip.Items[3].Enabled = true;
                    }
                }

                MyToolStrip.Items[5].Enabled = true;
                MyToolStrip.Items[6].Enabled = true;
                MyToolStrip.Items[7].Enabled = true;
                MyToolStrip.Items[9].Enabled = false;
                MyToolStrip.Items[10].Enabled = false;
                MyToolStrip.Items[12].Enabled = true;
                MyToolStrip.Items[13].Enabled = true;              

            }
            
            else
            {
                MyToolStrip.Items[0].Enabled = false;
                MyToolStrip.Items[3].Enabled = false;
                MyToolStrip.Items[5].Enabled = true;
                MyToolStrip.Items[6].Enabled = false;
                MyToolStrip.Items[7].Enabled = false;
                MyToolStrip.Items[9].Enabled = false;
                MyToolStrip.Items[10].Enabled = false;
                MyToolStrip.Items[12].Enabled = false;
                MyToolStrip.Items[13].Enabled = false;   

            }
           
            MyToolStrip.Items[1].Text = (index + 1).ToString();
            MyToolStrip.Items[2].Text = " of " + Count.ToString();
        }


        public void AddEditMode()
        {
            MyToolStrip.Items[0].Enabled = false;
            MyToolStrip.Items[3].Enabled = false;
            MyToolStrip.Items[5].Enabled = false;
            MyToolStrip.Items[6].Enabled = false;
            MyToolStrip.Items[7].Enabled = false;
            MyToolStrip.Items[9].Enabled = true;
            MyToolStrip.Items[10].Enabled = true;
            MyToolStrip.Items[12].Enabled = false;
            MyToolStrip.Items[13].Enabled = false;   
        }


        public string ApplicationNo { get; set; }
        public string Agency { get; set; }
        public string Address{ get; set; }
        public string ContactNo { get; set; }
        public string ProjectName { get; set; }
        public string Purpose { get; set; }
        public string CoverageArea { get; set; }
        public string DateIssued { get; set; }
        public string DateReleased { get; set; }
        public string DateRequested { get; set; }
        public string InNamria { get; set; }
        public string InGovernment { get; set; }
        public string OnGoing { get; set; }
        public string Recommendations { get; set; }
        public string ProjectDetails { get; set; }
        public string Findings { get; set; }
        
        public int Count
        {
            get
            {
               return _Count;
            }
        }
        

        private void GetValues()
        {

            ApplicationNo = index > -1 ? dt.Rows[index]["ApplicationNo"].ToString() : string.Empty;
            Agency = index > -1 ? dt.Rows[index]["AgencyName"].ToString() : string.Empty;
            Address = index > -1 ? dt.Rows[index]["Address"].ToString() : string.Empty;
            ContactNo = index > -1 ? dt.Rows[index]["ContactNo"].ToString() : string.Empty;
            ProjectName = index > -1 ? dt.Rows[index]["ProjectName"].ToString() : string.Empty;
            Purpose = index > -1 ? dt.Rows[index]["Purpose"].ToString() : string.Empty;
            CoverageArea = index > -1 ? dt.Rows[index]["CoverageArea"].ToString() : string.Empty;
            DateIssued = index > -1 ?  dt.Rows[index]["DateIssued"].ToString() : string.Empty;
            DateReleased = index > -1 ? dt.Rows[index]["DateReleased"].ToString() : string.Empty;
            DateRequested = index > -1 ? dt.Rows[index]["RequestDate"].ToString() : string.Empty;
            ProjectDetails= index > -1 ? dt.Rows[index]["ProjectDetails"].ToString() : string.Empty;
            Findings = index > -1 ? dt.Rows[index]["Findings"].ToString() : string.Empty;
            Recommendations = index > -1 ? dt.Rows[index]["Recommendations"].ToString() : string.Empty;
            InNamria = index > -1 ? dt.Rows[index]["InNamria"].ToString() : string.Empty;
            InGovernment = index > -1 ? dt.Rows[index]["InGovernment"].ToString() : string.Empty;
            OnGoing = index > -1 ? dt.Rows[index]["OnGoing"].ToString() : string.Empty;
        }




        public void Next()
        {
            if (index != dt.Rows.Count - 1 && dt.Rows.Count != 0)
            {
                index++;

            }

            if (index != -1)
            {
                GetValues();                
            }

            SetToolBar();
        }

        public void Back()
        {
            if (index > 0)
            {
                index--;
                GetValues();
               
            }

            SetToolBar();
        }

        public void New()
        {
            AddEditMode();

            ApplicationNo = string.Empty;
            Agency =string.Empty;
            Address = string.Empty;
            ContactNo = string.Empty;
            ProjectName =string.Empty;
            Purpose = string.Empty;
            CoverageArea = string.Empty;
            DateIssued = string.Empty;
            DateReleased = string.Empty;
            DateRequested = string.Empty;
            ProjectDetails = string.Empty;
            Findings = string.Empty;
            Recommendations = string.Empty;
            

            isNew = true;
        }

        public void Cancel()
        {
            SetToolBar();
            GetValues();
            isNew = false;
        }


        public void Save()
        {

            DataRow dr;
            if (isNew == true)

            {
                ApplicationNo = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString("00") + "-" + FindNextSequence().ToString("000");
                dr = dt.NewRow();
            }

            else
            {
               dr = dt.Rows[index];
            }


           
            dr["ApplicationNo"] = ApplicationNo;
            dr["AgencyName"] = Agency;
            dr["Address"] =Address;           
            dr["ContactNo"] = ContactNo;
            dr["ProjectName"] = ProjectName;
            dr["Purpose"] = Purpose;
            dr["CoverageArea"] = CoverageArea;
            dr["DateIssued"] = String.IsNullOrEmpty(DateIssued) ? (object)DBNull.Value : DateIssued;
            dr["DateReleased"] = String.IsNullOrEmpty(DateReleased) ? (object)DBNull.Value : DateReleased;
            dr["RequestDate"] = String.IsNullOrEmpty(DateRequested) ? (object)DBNull.Value : DateRequested;
            dr["ProjectDetails"] = ProjectDetails;
            dr["Findings"] =Findings;
            dr["Recommendations"] = Recommendations;
            dr["inNamria"] = InNamria;
            dr["inGovernment"] = InGovernment;
            dr["OnGoing"] = OnGoing;

            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            
            if (isNew == true)
            {
                dt.Rows.Add(dr);
                
            }
            da.Update(dt);

            if (isNew == true)
            {
                _Count++;
                index = Count - 1;
            }




           
      
                foreach (DataRow d in dtProcurement.Rows)
                {

                    if (d.RowState != DataRowState.Deleted)
                    {
                        d["ApplicationNo"] = ApplicationNo;
                    }

                }

                foreach (DataRow details in dtTechDetails.Rows)
                {

                    if (details.RowState != DataRowState.Deleted)
                    {
                        details["ApplicationNo"] = ApplicationNo;
                    }

                }
                foreach (DataRow details in dtMaterials.Rows)
                {

                    if (details.RowState != DataRowState.Deleted)
                    {
                        details["ApplicationNo"] = ApplicationNo;
                    }

                }


            SqlCommandBuilder cb = new SqlCommandBuilder(daProcurement);
            daProcurement.Update(dtProcurement);
            SqlCommandBuilder cb2 = new SqlCommandBuilder(daTechDetails);
            daTechDetails.Update(dtTechDetails);
            SqlCommandBuilder cb3 = new SqlCommandBuilder(daMaterials);
            daMaterials.Update(dtMaterials);
            
            SetToolBar();
            isNew = false;
            
        }

        public void Delete()
        {
            if (index > -1)
            {

                foreach (DataRow d in dtProcurement.Rows)
                
                {
                    d.Delete();
                }

                SqlCommandBuilder cbProc = new SqlCommandBuilder(daProcurement);
                daProcurement.Update(dtProcurement);


                foreach (DataRow d in dtTechDetails.Rows)
                {
                    d.Delete();
                }

                SqlCommandBuilder cbTech = new SqlCommandBuilder(daTechDetails);
                daTechDetails.Update(dtTechDetails);

                foreach (DataRow d in dtMaterials.Rows)
                {
                    d.Delete();
                }

                SqlCommandBuilder cbMat = new SqlCommandBuilder(daMaterials);
                daMaterials.Update(dtMaterials);


                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                dt.Rows[index].Delete();
                da.Update(dt);


                if (index != -1 && index == dt.Rows.Count)
                {
                    index--;
                }



                GetValues();
                _Count--;
                SetToolBar();
            }

        }

        public int FindNextSequence()
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ccis"].ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Select cast(max(substring(ApplicationNo,9,3)) as integer) from [Application] where substring(ApplicationNo,1,4)=year(getdate()) and substring(ApplicationNo,6,2)=month(getdate())", cnn);

                try
                {
                    return (int)cmd.ExecuteScalar() + 1;
                }
                catch
                {
                    return 1;
                }


            }
        }


        public void Search(string ApplicationNo)
        {

            DataRow[] dr;
            dr = dt.Select("ApplicationNo='" + ApplicationNo + "'");
            if (dr.Length > 0)
            {
                index = dt.Rows.IndexOf(dr[0]);
                GetValues();
                SetToolBar();
            }
            else
            {
                MessageBox.Show("Record not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

    }    

}
