namespace CCIS
{
    partial class ClearanceCertificate
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.applicationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ccisDataSet = new CCIS.ccisDataSet();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.applicationTableAdapter = new CCIS.ccisDataSetTableAdapters.applicationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.applicationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccisDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // applicationBindingSource
            // 
            this.applicationBindingSource.DataMember = "application";
            this.applicationBindingSource.DataSource = this.ccisDataSet;
            // 
            // ccisDataSet
            // 
            this.ccisDataSet.DataSetName = "ccisDataSet";
            this.ccisDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.reportViewer1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(1014, 548);
            this.kryptonPanel.TabIndex = 0;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "ccisDataSet_application";
            reportDataSource1.Value = this.applicationBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CCIS.Clearance Certificate.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1014, 548);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // applicationTableAdapter
            // 
            this.applicationTableAdapter.ClearBeforeFill = true;
            // 
            // ClearanceCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 548);
            this.Controls.Add(this.kryptonPanel);
            this.Font = new System.Drawing.Font("Square721 BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ClearanceCertificate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClearanceCertificate";
            this.Load += new System.EventHandler(this.ClearanceCertificate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.applicationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccisDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource applicationBindingSource;
        private ccisDataSet ccisDataSet;
        private CCIS.ccisDataSetTableAdapters.applicationTableAdapter applicationTableAdapter;
    }
}

