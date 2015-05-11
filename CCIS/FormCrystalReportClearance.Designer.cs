namespace CCIS
{
    partial class FormCrystalReportClearance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportClearance1 = new CCIS.CrystalReportClearance();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportClearance2 = new CCIS.CrystalReportClearance();
            this.crystalReportViewerClearance = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReportClearance3 = new CCIS.CrystalReportClearance();
            this.SuspendLayout();
            // 
           
           
            // crystalReportViewerClearance
            // 
            this.crystalReportViewerClearance.ActiveViewIndex = 0;
            this.crystalReportViewerClearance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerClearance.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerClearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerClearance.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerClearance.Name = "crystalReportViewerClearance";
            this.crystalReportViewerClearance.ReportSource = this.CrystalReportClearance3;
            this.crystalReportViewerClearance.Size = new System.Drawing.Size(1143, 594);
            this.crystalReportViewerClearance.TabIndex = 1;
            this.crystalReportViewerClearance.Load += new System.EventHandler(this.crystalReportViewer2_Load);
            // 
            // FormCrystalReportClearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 594);
            this.Controls.Add(this.crystalReportViewerClearance);
            this.Controls.Add(this.crystalReportViewer2);
            this.Name = "FormCrystalReportClearance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clearance Certificate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.crystalReportViewer2_Load);
            this.ResumeLayout(false);

        }

        #endregion

    
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReportClearance CrystalReportClearance1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private CrystalReportClearance CrystalReportClearance2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerClearance;
        private CrystalReportClearance CrystalReportClearance3;
    }
}

