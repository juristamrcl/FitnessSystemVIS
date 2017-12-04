namespace FitnessForms.Forms
{
    partial class ChangeCredit
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.clientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ticketType = new System.Windows.Forms.TextBox();
            this.credit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toSubstract = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.ticketDetails.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ticketDetails
            // 
            this.ticketDetails.Controls.Add(this.acceptButton);
            this.ticketDetails.Controls.Add(this.tableLayoutPanel1);
            this.ticketDetails.Location = new System.Drawing.Point(41, 50);
            this.ticketDetails.Name = "ticketDetails";
            this.ticketDetails.Size = new System.Drawing.Size(271, 187);
            this.ticketDetails.TabIndex = 6;
            this.ticketDetails.TabStop = false;
            this.ticketDetails.Text = "Credit";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel1.Controls.Add(this.toSubstract, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.credit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ticketType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.clientName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 124);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // clientName
            // 
            this.clientName.Enabled = false;
            this.clientName.Location = new System.Drawing.Point(96, 3);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(121, 20);
            this.clientName.TabIndex = 13;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Credit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ticket type";
            // 
            // ticketType
            // 
            this.ticketType.Enabled = false;
            this.ticketType.Location = new System.Drawing.Point(96, 34);
            this.ticketType.Name = "ticketType";
            this.ticketType.Size = new System.Drawing.Size(121, 20);
            this.ticketType.TabIndex = 14;
            // 
            // credit
            // 
            this.credit.Enabled = false;
            this.credit.Location = new System.Drawing.Point(96, 65);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(121, 20);
            this.credit.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Substract";
            // 
            // toSubstract
            // 
            this.toSubstract.Location = new System.Drawing.Point(96, 96);
            this.toSubstract.Name = "toSubstract";
            this.toSubstract.Size = new System.Drawing.Size(121, 20);
            this.toSubstract.TabIndex = 17;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(196, 164);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 7;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // ChangeCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 287);
            this.Controls.Add(this.ticketDetails);
            this.Name = "ChangeCredit";
            this.Text = "ChangeCredit";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clientName;
        private System.Windows.Forms.TextBox ticketType;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.TextBox toSubstract;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox credit;
    }
}