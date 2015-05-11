namespace CCIS
{
    partial class FormSignatories
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label signatoryLabel;
            System.Windows.Forms.Label notedByLabel;
            System.Windows.Forms.Label evaluatorLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignatories));
            this.evaluatorTextBox = new System.Windows.Forms.TextBox();
            this.noterDesignationTextBox = new System.Windows.Forms.TextBox();
            this.notedByTextBox = new System.Windows.Forms.TextBox();
            this.signatoryTextBox = new System.Windows.Forms.TextBox();
            this.signatoryDesignationTextBox = new System.Windows.Forms.TextBox();
            this.evaluatorDesignationTextBox = new System.Windows.Forms.TextBox();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.pEdit = new System.Windows.Forms.ToolStripButton();
            this.pSave = new System.Windows.Forms.ToolStripButton();
            this.pCancel = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            signatoryLabel = new System.Windows.Forms.Label();
            notedByLabel = new System.Windows.Forms.Label();
            evaluatorLabel = new System.Windows.Forms.Label();
            this.ToolBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(23, 239);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(59, 16);
            label4.TabIndex = 41;
            label4.Text = "Position:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(23, 206);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 16);
            label3.TabIndex = 40;
            label3.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(23, 365);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 16);
            label2.TabIndex = 39;
            label2.Text = "Position:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(23, 332);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 16);
            label1.TabIndex = 38;
            label1.Text = "Name:";
            // 
            // signatoryLabel
            // 
            signatoryLabel.AutoSize = true;
            signatoryLabel.BackColor = System.Drawing.Color.Transparent;
            signatoryLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            signatoryLabel.Location = new System.Drawing.Point(23, 50);
            signatoryLabel.Name = "signatoryLabel";
            signatoryLabel.Size = new System.Drawing.Size(118, 19);
            signatoryLabel.TabIndex = 29;
            signatoryLabel.Text = "Administrator:";
            // 
            // notedByLabel
            // 
            notedByLabel.AutoSize = true;
            notedByLabel.BackColor = System.Drawing.Color.Transparent;
            notedByLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            notedByLabel.Location = new System.Drawing.Point(23, 302);
            notedByLabel.Name = "notedByLabel";
            notedByLabel.Size = new System.Drawing.Size(84, 19);
            notedByLabel.TabIndex = 35;
            notedByLabel.Text = "Noted by:";
            // 
            // evaluatorLabel
            // 
            evaluatorLabel.AutoSize = true;
            evaluatorLabel.BackColor = System.Drawing.Color.Transparent;
            evaluatorLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            evaluatorLabel.Location = new System.Drawing.Point(23, 176);
            evaluatorLabel.Name = "evaluatorLabel";
            evaluatorLabel.Size = new System.Drawing.Size(114, 19);
            evaluatorLabel.TabIndex = 32;
            evaluatorLabel.Text = "Evaluated by:";
            // 
            // evaluatorTextBox
            // 
            this.evaluatorTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.evaluatorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluatorTextBox.Location = new System.Drawing.Point(173, 209);
            this.evaluatorTextBox.Multiline = true;
            this.evaluatorTextBox.Name = "evaluatorTextBox";
            this.evaluatorTextBox.ReadOnly = true;
            this.evaluatorTextBox.Size = new System.Drawing.Size(264, 27);
            this.evaluatorTextBox.TabIndex = 33;
            // 
            // noterDesignationTextBox
            // 
            this.noterDesignationTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.noterDesignationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noterDesignationTextBox.Location = new System.Drawing.Point(173, 368);
            this.noterDesignationTextBox.Multiline = true;
            this.noterDesignationTextBox.Name = "noterDesignationTextBox";
            this.noterDesignationTextBox.ReadOnly = true;
            this.noterDesignationTextBox.Size = new System.Drawing.Size(264, 27);
            this.noterDesignationTextBox.TabIndex = 37;
            // 
            // notedByTextBox
            // 
            this.notedByTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.notedByTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notedByTextBox.Location = new System.Drawing.Point(173, 335);
            this.notedByTextBox.Multiline = true;
            this.notedByTextBox.Name = "notedByTextBox";
            this.notedByTextBox.ReadOnly = true;
            this.notedByTextBox.Size = new System.Drawing.Size(264, 27);
            this.notedByTextBox.TabIndex = 36;
            // 
            // signatoryTextBox
            // 
            this.signatoryTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.signatoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signatoryTextBox.Location = new System.Drawing.Point(173, 83);
            this.signatoryTextBox.Multiline = true;
            this.signatoryTextBox.Name = "signatoryTextBox";
            this.signatoryTextBox.ReadOnly = true;
            this.signatoryTextBox.Size = new System.Drawing.Size(264, 27);
            this.signatoryTextBox.TabIndex = 30;
            // 
            // signatoryDesignationTextBox
            // 
            this.signatoryDesignationTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.signatoryDesignationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signatoryDesignationTextBox.Location = new System.Drawing.Point(173, 116);
            this.signatoryDesignationTextBox.Multiline = true;
            this.signatoryDesignationTextBox.Name = "signatoryDesignationTextBox";
            this.signatoryDesignationTextBox.ReadOnly = true;
            this.signatoryDesignationTextBox.Size = new System.Drawing.Size(264, 27);
            this.signatoryDesignationTextBox.TabIndex = 31;
            // 
            // evaluatorDesignationTextBox
            // 
            this.evaluatorDesignationTextBox.BackColor = System.Drawing.Color.LemonChiffon;
            this.evaluatorDesignationTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluatorDesignationTextBox.Location = new System.Drawing.Point(173, 242);
            this.evaluatorDesignationTextBox.Multiline = true;
            this.evaluatorDesignationTextBox.Name = "evaluatorDesignationTextBox";
            this.evaluatorDesignationTextBox.ReadOnly = true;
            this.evaluatorDesignationTextBox.Size = new System.Drawing.Size(264, 27);
            this.evaluatorDesignationTextBox.TabIndex = 34;
            // 
            // ToolBar
            // 
            this.ToolBar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ToolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pEdit,
            this.pSave,
            this.pCancel});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(460, 31);
            this.ToolBar.TabIndex = 42;
            this.ToolBar.TabStop = true;
            this.ToolBar.Text = "toolStrip23";
            // 
            // pEdit
            // 
            this.pEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pEdit.Image = ((System.Drawing.Image)(resources.GetObject("pEdit.Image")));
            this.pEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pEdit.Name = "pEdit";
            this.pEdit.Size = new System.Drawing.Size(28, 28);
            this.pEdit.Text = "Edit";
            this.pEdit.Click += new System.EventHandler(this.pEdit_Click);
            // 
            // pSave
            // 
            this.pSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pSave.Enabled = false;
            this.pSave.Image = ((System.Drawing.Image)(resources.GetObject("pSave.Image")));
            this.pSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pSave.Name = "pSave";
            this.pSave.Size = new System.Drawing.Size(28, 28);
            this.pSave.Text = "Save";
            this.pSave.Click += new System.EventHandler(this.pSave_Click);
            // 
            // pCancel
            // 
            this.pCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pCancel.Enabled = false;
            this.pCancel.Image = ((System.Drawing.Image)(resources.GetObject("pCancel.Image")));
            this.pCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pCancel.Name = "pCancel";
            this.pCancel.Size = new System.Drawing.Size(28, 28);
            this.pCancel.Text = "Cancel";
            this.pCancel.Click += new System.EventHandler(this.pCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(signatoryLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.signatoryTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(label4, 1, 7);
            this.tableLayoutPanel1.Controls.Add(evaluatorLabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(label3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.signatoryDesignationTextBox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.evaluatorTextBox, 2, 6);
            this.tableLayoutPanel1.Controls.Add(label1, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.evaluatorDesignationTextBox, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.noterDesignationTextBox, 2, 11);
            this.tableLayoutPanel1.Controls.Add(notedByLabel, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.notedByTextBox, 2, 10);
            this.tableLayoutPanel1.Controls.Add(label2, 1, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 449);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // FormSignatories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 480);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ToolBar);
            this.MinimumSize = new System.Drawing.Size(468, 514);
            this.Name = "FormSignatories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Signatories";
            this.Load += new System.EventHandler(this.FormSignatories_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox evaluatorTextBox;
        private System.Windows.Forms.TextBox noterDesignationTextBox;
        private System.Windows.Forms.TextBox notedByTextBox;
        private System.Windows.Forms.TextBox signatoryTextBox;
        private System.Windows.Forms.TextBox signatoryDesignationTextBox;
        private System.Windows.Forms.TextBox evaluatorDesignationTextBox;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton pEdit;
        private System.Windows.Forms.ToolStripButton pSave;
        private System.Windows.Forms.ToolStripButton pCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}