namespace FitnessForms.Forms
{
    partial class FormTrainingGrid
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
            this.trainingsGrid = new System.Windows.Forms.DataGridView();
            this.card_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.trainingsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // trainingsGrid
            // 
            this.trainingsGrid.AccessibleName = "client_grid";
            this.trainingsGrid.BackgroundColor = System.Drawing.Color.White;
            this.trainingsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trainingsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.card_id,
            this.name,
            this.surname,
            this.mail,
            this.gender,
            this.trainings});
            this.trainingsGrid.GridColor = System.Drawing.Color.DarkGray;
            this.trainingsGrid.Location = new System.Drawing.Point(0, 0);
            this.trainingsGrid.Name = "trainingsGrid";
            this.trainingsGrid.ReadOnly = true;
            this.trainingsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.trainingsGrid.Size = new System.Drawing.Size(690, 386);
            this.trainingsGrid.TabIndex = 2;
            this.trainingsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.trainingsGrid_CellContentClick);
            // 
            // card_id
            // 
            this.card_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.card_id.DataPropertyName = "ClientName";
            this.card_id.HeaderText = "Client Name";
            this.card_id.Name = "card_id";
            this.card_id.ReadOnly = true;
            this.card_id.Width = 82;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.DataPropertyName = "TrainerName";
            this.name.HeaderText = "Trainer Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 88;
            // 
            // surname
            // 
            this.surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.surname.DataPropertyName = "LockerId";
            this.surname.HeaderText = "Locker Number";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            this.surname.Width = 96;
            // 
            // mail
            // 
            this.mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mail.DataPropertyName = "ToGender";
            this.mail.HeaderText = "Locker Gender";
            this.mail.Name = "mail";
            this.mail.ReadOnly = true;
            this.mail.Width = 95;
            // 
            // gender
            // 
            this.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gender.DataPropertyName = "Start";
            this.gender.HeaderText = "Start";
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Width = 54;
            // 
            // trainings
            // 
            this.trainings.DataPropertyName = "End";
            this.trainings.HeaderText = "End";
            this.trainings.Name = "trainings";
            this.trainings.ReadOnly = true;
            // 
            // FormTrainingGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(691, 388);
            this.Controls.Add(this.trainingsGrid);
            this.Name = "FormTrainingGrid";
            this.Text = "Trainings";
            ((System.ComponentModel.ISupportInitialize)(this.trainingsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView trainingsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn card_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainings;
    }
}