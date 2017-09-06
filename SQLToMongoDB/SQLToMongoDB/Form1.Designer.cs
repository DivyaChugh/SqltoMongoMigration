namespace SQLToMongoDB
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMongoDBString = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.RichTextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.RichTextBox();
            this.Migrate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txttChunkSize = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUniqueColumn = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.63636F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.36364F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtConnectionString, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMongoDBString, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDBName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTableName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Migrate, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblRecordCount, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txttChunkSize, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtUniqueColumn, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(660, 448);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SQL Connection String ";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(191, 3);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(459, 48);
            this.txtConnectionString.TabIndex = 2;
            this.txtConnectionString.Text = "Data Source=cha-en-pdp2\\sqlexpress;Initial Catalog=WinshuttleLicensing;Integrated" +
    " Security=False;User Id=sa;Password=$abcd1234;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mongo Connection String";
            // 
            // txtMongoDBString
            // 
            this.txtMongoDBString.Location = new System.Drawing.Point(191, 63);
            this.txtMongoDBString.Name = "txtMongoDBString";
            this.txtMongoDBString.Size = new System.Drawing.Size(440, 51);
            this.txtMongoDBString.TabIndex = 4;
            this.txtMongoDBString.Text = "mongodb://wil120:27017";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Database Name";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(191, 121);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(440, 24);
            this.txtDBName.TabIndex = 11;
            this.txtDBName.Text = "WinshuttleLicensing";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(191, 372);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Table Name";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(191, 181);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(440, 21);
            this.txtTableName.TabIndex = 14;
            this.txtTableName.Text = "TransactionLog";
            // 
            // Migrate
            // 
            this.Migrate.Location = new System.Drawing.Point(191, 341);
            this.Migrate.Name = "Migrate";
            this.Migrate.Size = new System.Drawing.Size(75, 19);
            this.Migrate.TabIndex = 8;
            this.Migrate.Text = "Migrate";
            this.Migrate.UseVisualStyleBackColor = true;
            this.Migrate.Click += new System.EventHandler(this.Migrate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 19);
            this.button1.TabIndex = 15;
            this.button1.Text = "Record Count";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.ForeColor = System.Drawing.Color.Red;
            this.lblRecordCount.Location = new System.Drawing.Point(3, 221);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(13, 13);
            this.lblRecordCount.TabIndex = 16;
            this.lblRecordCount.Text = "0";
            this.lblRecordCount.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Chunk Size";
            // 
            // txttChunkSize
            // 
            this.txttChunkSize.Location = new System.Drawing.Point(191, 301);
            this.txttChunkSize.Name = "txttChunkSize";
            this.txttChunkSize.Size = new System.Drawing.Size(440, 24);
            this.txttChunkSize.TabIndex = 18;
            this.txttChunkSize.Text = "1000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Unique Column ";
            // 
            // txtUniqueColumn
            // 
            this.txtUniqueColumn.Location = new System.Drawing.Point(191, 265);
            this.txtUniqueColumn.Name = "txtUniqueColumn";
            this.txtUniqueColumn.Size = new System.Drawing.Size(440, 24);
            this.txtUniqueColumn.TabIndex = 20;
            this.txtUniqueColumn.Text = "id";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 494);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "SQL to Mongo Migrate";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtConnectionString;
        private System.Windows.Forms.Button Migrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtMongoDBString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtDBName;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtTableName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txttChunkSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtUniqueColumn;
    }
}