namespace FitnessForms.Forms
{
    partial class FormClientGrid
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
            this.clientsGrid = new System.Windows.Forms.DataGridView();
            this.card_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxMinutes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // clientsGrid
            // 
            this.clientsGrid.AccessibleName = "client_grid";
            this.clientsGrid.BackgroundColor = System.Drawing.Color.White;
            this.clientsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.card_id,
            this.name,
            this.surname,
            this.mail,
            this.gender,
            this.trainings,
            this.maxMinutes});
            this.clientsGrid.GridColor = System.Drawing.Color.DarkGray;
            this.clientsGrid.Location = new System.Drawing.Point(0, 27);
            this.clientsGrid.Name = "clientsGrid";
            this.clientsGrid.ReadOnly = true;
            this.clientsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientsGrid.Size = new System.Drawing.Size(784, 349);
            this.clientsGrid.TabIndex = 1;
            this.clientsGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsGrid_CellContentDoubleClick);
            // 
            // card_id
            // 
            this.card_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.card_id.DataPropertyName = "CardId";
            this.card_id.HeaderText = "Card Number";
            this.card_id.Name = "card_id";
            this.card_id.ReadOnly = true;
            this.card_id.Width = 94;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.DataPropertyName = "Name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 60;
            // 
            // surname
            // 
            this.surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.surname.DataPropertyName = "Surname";
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            this.surname.Width = 74;
            // 
            // mail
            // 
            this.mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mail.DataPropertyName = "Mail";
            this.mail.HeaderText = "Mail";
            this.mail.Name = "mail";
            this.mail.ReadOnly = true;
            this.mail.Width = 51;
            // 
            // gender
            // 
            this.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gender.DataPropertyName = "Gender";
            this.gender.HeaderText = "Gender";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Width = 67;
            // 
            // trainings
            // 
            this.trainings.DataPropertyName = "Trainings";
            this.trainings.HeaderText = "Trainings";
            this.trainings.Name = "trainings";
            this.trainings.ReadOnly = true;
            // 
            // maxMinutes
            // 
            this.maxMinutes.DataPropertyName = "MaxMinutes";
            this.maxMinutes.HeaderText = "Max Minutes";
            this.maxMinutes.Name = "maxMinutes";
            this.maxMinutes.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "Training Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(653, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 21);
            this.button2.TabIndex = 3;
            this.button2.Text = "Training End";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormClientGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(785, 375);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clientsGrid);
            this.Name = "FormClientGrid";
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.FormClientGrid_Load);
            this.Controls.SetChildIndex(this.clientsGrid, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.clientsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView clientsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn card_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainings;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxMinutes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}