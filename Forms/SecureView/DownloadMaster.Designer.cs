namespace MascotPrintingUtility.Forms.SecureView
{
    partial class DownloadMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSyncBatch = new System.Windows.Forms.Button();
            this.labelSelectBatch = new System.Windows.Forms.Label();
            this.itemcomboBox = new System.Windows.Forms.ComboBox();
            this.lblBatchType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDownloadingMessage = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblQty = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.MR = new System.Windows.Forms.Label();
            this.lblExp = new System.Windows.Forms.Label();
            this.lblMFG = new System.Windows.Forms.Label();
            this.lblGtin = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvSyncData = new System.Windows.Forms.DataGridView();
            this.headerPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSyncData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(142)))), ((int)(((byte)(126)))));
            this.btnUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(8, 272);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(208, 57);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Sync Data";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(142)))), ((int)(((byte)(126)))));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(246, 272);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(199, 57);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(142)))), ((int)(((byte)(126)))));
            this.headerPanel.Controls.Add(this.label4);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.headerPanel.Size = new System.Drawing.Size(1710, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1696, 58);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sync Data From Server";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnSyncBatch);
            this.panel5.Controls.Add(this.labelSelectBatch);
            this.panel5.Controls.Add(this.itemcomboBox);
            this.panel5.Location = new System.Drawing.Point(12, 16);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1330, 84);
            this.panel5.TabIndex = 0;
            // 
            // btnSyncBatch
            // 
            this.btnSyncBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(142)))), ((int)(((byte)(126)))));
            this.btnSyncBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSyncBatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSyncBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncBatch.ForeColor = System.Drawing.Color.White;
            this.btnSyncBatch.Image = ((System.Drawing.Image)(resources.GetObject("btnSyncBatch.Image")));
            this.btnSyncBatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSyncBatch.Location = new System.Drawing.Point(820, 15);
            this.btnSyncBatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSyncBatch.Name = "btnSyncBatch";
            this.btnSyncBatch.Size = new System.Drawing.Size(228, 57);
            this.btnSyncBatch.TabIndex = 2;
            this.btnSyncBatch.Text = "Sync Batch";
            this.btnSyncBatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSyncBatch.UseVisualStyleBackColor = false;
            this.btnSyncBatch.Click += new System.EventHandler(this.btnSyncBatch_Click);
            // 
            // labelSelectBatch
            // 
            this.labelSelectBatch.AutoSize = true;
            this.labelSelectBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectBatch.Location = new System.Drawing.Point(3, 6);
            this.labelSelectBatch.Name = "labelSelectBatch";
            this.labelSelectBatch.Size = new System.Drawing.Size(186, 32);
            this.labelSelectBatch.TabIndex = 0;
            this.labelSelectBatch.Text = "Select Batch";
            // 
            // itemcomboBox
            // 
            this.itemcomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.itemcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.itemcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.itemcomboBox.FormattingEnabled = true;
            this.itemcomboBox.Location = new System.Drawing.Point(7, 42);
            this.itemcomboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.itemcomboBox.Name = "itemcomboBox";
            this.itemcomboBox.Size = new System.Drawing.Size(779, 30);
            this.itemcomboBox.TabIndex = 1;
            this.itemcomboBox.SelectedIndexChanged += new System.EventHandler(this.itemcomboBox_SelectedIndexChanged);
            // 
            // lblBatchType
            // 
            this.lblBatchType.AutoSize = true;
            this.lblBatchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchType.Location = new System.Drawing.Point(657, 47);
            this.lblBatchType.Name = "lblBatchType";
            this.lblBatchType.Size = new System.Drawing.Size(66, 25);
            this.lblBatchType.TabIndex = 4;
            this.lblBatchType.Text = "******";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(481, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Batch Type : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDownloadingMessage);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1710, 382);
            this.panel1.TabIndex = 1;
            // 
            // lblDownloadingMessage
            // 
            this.lblDownloadingMessage.AutoSize = true;
            this.lblDownloadingMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadingMessage.ForeColor = System.Drawing.Color.Red;
            this.lblDownloadingMessage.Location = new System.Drawing.Point(10, 343);
            this.lblDownloadingMessage.Name = "lblDownloadingMessage";
            this.lblDownloadingMessage.Size = new System.Drawing.Size(799, 36);
            this.lblDownloadingMessage.TabIndex = 17;
            this.lblDownloadingMessage.Text = "Please wait while downloading the data from digital link";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblQty);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblMRP);
            this.panel3.Controls.Add(this.MR);
            this.panel3.Controls.Add(this.lblExp);
            this.panel3.Controls.Add(this.lblMFG);
            this.panel3.Controls.Add(this.lblGtin);
            this.panel3.Controls.Add(this.lblProductName);
            this.panel3.Controls.Add(this.lblBatchType);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1330, 160);
            this.panel3.TabIndex = 4;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(657, 119);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(66, 25);
            this.lblQty.TabIndex = 16;
            this.lblQty.Text = "******";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(481, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Qty";
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMRP.Location = new System.Drawing.Point(177, 119);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(66, 25);
            this.lblMRP.TabIndex = 14;
            this.lblMRP.Text = "******";
            // 
            // MR
            // 
            this.MR.AutoSize = true;
            this.MR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MR.Location = new System.Drawing.Point(5, 119);
            this.MR.Name = "MR";
            this.MR.Size = new System.Drawing.Size(58, 25);
            this.MR.TabIndex = 13;
            this.MR.Text = "MRP";
            // 
            // lblExp
            // 
            this.lblExp.AutoSize = true;
            this.lblExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExp.Location = new System.Drawing.Point(657, 81);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(66, 25);
            this.lblExp.TabIndex = 12;
            this.lblExp.Text = "******";
            // 
            // lblMFG
            // 
            this.lblMFG.AutoSize = true;
            this.lblMFG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMFG.Location = new System.Drawing.Point(177, 81);
            this.lblMFG.Name = "lblMFG";
            this.lblMFG.Size = new System.Drawing.Size(66, 25);
            this.lblMFG.TabIndex = 11;
            this.lblMFG.Text = "******";
            // 
            // lblGtin
            // 
            this.lblGtin.AutoSize = true;
            this.lblGtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGtin.Location = new System.Drawing.Point(177, 47);
            this.lblGtin.Name = "lblGtin";
            this.lblGtin.Size = new System.Drawing.Size(66, 25);
            this.lblGtin.TabIndex = 10;
            this.lblGtin.Text = "******";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(177, 12);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(66, 25);
            this.lblProductName.TabIndex = 9;
            this.lblProductName.Text = "******";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(481, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Exp Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "MFG Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "GTIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product Name";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(142)))), ((int)(((byte)(126)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
//            this.btnClose.Image = global::MascotPrintingUtility.Properties.Resources.Canceled;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(487, 272);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(199, 57);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvSyncData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1710, 370);
            this.panel2.TabIndex = 111;
            // 
            // gvSyncData
            // 
            this.gvSyncData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSyncData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvSyncData.ColumnHeadersHeight = 32;
            this.gvSyncData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvSyncData.Location = new System.Drawing.Point(0, 0);
            this.gvSyncData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvSyncData.Name = "gvSyncData";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvSyncData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvSyncData.RowHeadersWidth = 51;
            this.gvSyncData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvSyncData.RowTemplate.Height = 28;
            this.gvSyncData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSyncData.Size = new System.Drawing.Size(1710, 370);
            this.gvSyncData.TabIndex = 0;
            // 
            // DownloadMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1710, 822);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DownloadMaster";
            this.Load += new System.EventHandler(this.DownloadMaster_Load);
            this.headerPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSyncData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox itemcomboBox;
        private System.Windows.Forms.Label labelSelectBatch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSyncBatch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvSyncData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBatchType;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label MR;
        private System.Windows.Forms.Label lblExp;
        private System.Windows.Forms.Label lblMFG;
        private System.Windows.Forms.Label lblGtin;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblDownloadingMessage;
    }
}