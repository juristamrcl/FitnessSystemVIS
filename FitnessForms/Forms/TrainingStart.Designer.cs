namespace FitnessForms.Forms
{
    partial class TrainingStart
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
            this.ticketDetails = new System.Windows.Forms.GroupBox();
            this.comboLocker = new System.Windows.Forms.ComboBox();
            this.comboTrainer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboClient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.acceptButton = new System.Windows.Forms.Button();
            this.ticketDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ticketDetails
            // 
            this.ticketDetails.Controls.Add(this.acceptButton);
            this.ticketDetails.Controls.Add(this.tableLayoutPanel1);
            this.ticketDetails.Location = new System.Drawing.Point(110, 52);
            this.ticketDetails.Name = "ticketDetails";
            this.ticketDetails.Size = new System.Drawing.Size(271, 175);
            this.ticketDetails.TabIndex = 5;
            this.ticketDetails.TabStop = false;
            this.ticketDetails.Text = "Start training";
            // 
            // comboLocker
            // 
            this.comboLocker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocker.FormattingEnabled = true;
            this.comboLocker.Location = new System.Drawing.Point(96, 75);
            this.comboLocker.Name = "comboLocker";
            this.comboLocker.Size = new System.Drawing.Size(121, 21);
            this.comboLocker.TabIndex = 12;
            // 
            // comboTrainer
            // 
            this.comboTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTrainer.FormattingEnabled = true;
            this.comboTrainer.Location = new System.Drawing.Point(96, 39);
            this.comboTrainer.Name = "comboTrainer";
            this.comboTrainer.Size = new System.Drawing.Size(121, 21);
            this.comboTrainer.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Trainer";
            // 
            // comboClient
            // 
            this.comboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClient.FormattingEnabled = true;
            this.comboClient.Location = new System.Drawing.Point(96, 3);
            this.comboClient.Name = "comboClient";
            this.comboClient.Size = new System.Drawing.Size(121, 21);
            this.comboClient.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Locker";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboClient, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboTrainer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboLocker, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 108);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(196, 144);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 11;
            this.acceptButton.Text = "Start training";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // TrainingStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 291);
            this.Controls.Add(this.ticketDetails);
            this.Name = "TrainingStart";
            this.Text = "TrainingStart";
            this.ticketDetails.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ticketDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTrainer;
        private System.Windows.Forms.ComboBox comboLocker;
        private System.Windows.Forms.Button acceptButton;
    }
}