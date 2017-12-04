namespace FitnessForms.Forms
{
    partial class FormLockerGrid
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
            this.lockersGrid = new System.Windows.Forms.DataGridView();
            this.lockerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lockersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lockersGrid
            // 
            this.lockersGrid.AccessibleName = "client_grid";
            this.lockersGrid.BackgroundColor = System.Drawing.Color.White;
            this.lockersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lockersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lockerNumber,
            this.toGender,
            this.status});
            this.lockersGrid.GridColor = System.Drawing.Color.DarkGray;
            this.lockersGrid.Location = new System.Drawing.Point(0, 27);
            this.lockersGrid.Name = "lockersGrid";
            this.lockersGrid.ReadOnly = true;
            this.lockersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lockersGrid.Size = new System.Drawing.Size(356, 320);
            this.lockersGrid.TabIndex = 3;
            this.lockersGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lockersGrid_CellContentDoubleClick);
            // 
            // lockerNumber
            // 
            this.lockerNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lockerNumber.DataPropertyName = "RecordId";
            this.lockerNumber.HeaderText = "Locker Number";
            this.lockerNumber.Name = "lockerNumber";
            this.lockerNumber.ReadOnly = true;
            this.lockerNumber.Width = 96;
            // 
            // toGender
            // 
            this.toGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.toGender.DataPropertyName = "ToGender";
            this.toGender.HeaderText = "To Gender";
            this.toGender.Name = "toGender";
            this.toGender.ReadOnly = true;
            this.toGender.Width = 77;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 62;
            // 
            // FormLockerGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(357, 347);
            this.Controls.Add(this.lockersGrid);
            this.Name = "FormLockerGrid";
            this.Text = "Lockers";
            this.Controls.SetChildIndex(this.lockersGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lockersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lockersGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn lockerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn toGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}