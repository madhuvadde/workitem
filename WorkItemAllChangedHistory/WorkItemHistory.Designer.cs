namespace WorkItemAllChangedHistory
{
    partial class WorkItemHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtTFSURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtWorkItemId = new System.Windows.Forms.TextBox();
            this.btnWorkItemId = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.gvAllChanges = new System.Windows.Forms.DataGridView();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.ChangedByAllChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangedDateAllChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllChanges)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtTFSURL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 47);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TFS Connection";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(624, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(77, 30);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtTFSURL
            // 
            this.txtTFSURL.Location = new System.Drawing.Point(88, 17);
            this.txtTFSURL.Name = "txtTFSURL";
            this.txtTFSURL.Size = new System.Drawing.Size(518, 21);
            this.txtTFSURL.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TFS Server : ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtWorkItemId);
            this.groupBox4.Controls.Add(this.btnWorkItemId);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(760, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 45);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "WorkItem";
            // 
            // txtWorkItemId
            // 
            this.txtWorkItemId.Location = new System.Drawing.Point(114, 17);
            this.txtWorkItemId.Name = "txtWorkItemId";
            this.txtWorkItemId.Size = new System.Drawing.Size(138, 21);
            this.txtWorkItemId.TabIndex = 10;
            // 
            // btnWorkItemId
            // 
            this.btnWorkItemId.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnWorkItemId.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnWorkItemId.Enabled = false;
            this.btnWorkItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorkItemId.Location = new System.Drawing.Point(258, 13);
            this.btnWorkItemId.Name = "btnWorkItemId";
            this.btnWorkItemId.Size = new System.Drawing.Size(58, 25);
            this.btnWorkItemId.TabIndex = 8;
            this.btnWorkItemId.Text = "GO";
            this.btnWorkItemId.UseVisualStyleBackColor = false;
            this.btnWorkItemId.Click += new System.EventHandler(this.btnWorkItemId_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "WorkItem Id :";
            // 
            // gvAllChanges
            // 
            this.gvAllChanges.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gvAllChanges.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAllChanges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvAllChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAllChanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChangedByAllChanges,
            this.ChangedDateAllChanges,
            this.FieldName,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Comment});
            this.gvAllChanges.EnableHeadersVisualStyles = false;
            this.gvAllChanges.Location = new System.Drawing.Point(12, 75);
            this.gvAllChanges.Name = "gvAllChanges";
            this.gvAllChanges.RowHeadersVisible = false;
            this.gvAllChanges.RowHeadersWidth = 20;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAllChanges.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvAllChanges.Size = new System.Drawing.Size(1147, 600);
            this.gvAllChanges.TabIndex = 11;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Enabled = false;
            this.btnExportToExcel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(961, 681);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(130, 30);
            this.btnExportToExcel.TabIndex = 13;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // ChangedByAllChanges
            // 
            this.ChangedByAllChanges.HeaderText = "Changed By";
            this.ChangedByAllChanges.Name = "ChangedByAllChanges";
            this.ChangedByAllChanges.Width = 150;
            // 
            // ChangedDateAllChanges
            // 
            this.ChangedDateAllChanges.HeaderText = "Changed Date";
            this.ChangedDateAllChanges.Name = "ChangedDateAllChanges";
            this.ChangedDateAllChanges.Width = 150;
            // 
            // FieldName
            // 
            this.FieldName.HeaderText = "Field Name";
            this.FieldName.Name = "FieldName";
            this.FieldName.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 1.849234F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Old Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 230;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "New Value";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 230;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.Width = 200;
            // 
            // WorkItemHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 723);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.gvAllChanges);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "WorkItemHistory";
            this.Text = "WorkItem History";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllChanges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTFSURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtWorkItemId;
        private System.Windows.Forms.Button btnWorkItemId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView gvAllChanges;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangedByAllChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangedDateAllChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}

