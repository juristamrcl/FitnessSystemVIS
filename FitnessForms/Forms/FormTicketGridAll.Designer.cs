namespace FitnessForms.Forms
{
    partial class FormTicketGridAll
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
            this.ticketsGrid = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ticketsGrid
            // 
            this.ticketsGrid.AccessibleName = "client_grid";
            this.ticketsGrid.BackgroundColor = System.Drawing.Color.White;
            this.ticketsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ticketsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.validity,
            this.cost,
            this.description});
            this.ticketsGrid.GridColor = System.Drawing.Color.DarkGray;
            this.ticketsGrid.Location = new System.Drawing.Point(0, 24);
            this.ticketsGrid.Name = "ticketsGrid";
            this.ticketsGrid.ReadOnly = true;
            this.ticketsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ticketsGrid.Size = new System.Drawing.Size(386, 324);
            this.ticketsGrid.TabIndex = 2;
            this.ticketsGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ticketsGrid_CellContentDoubleClick);
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.type.DataPropertyName = "Type";
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 56;
            // 
            // validity
            // 
            this.validity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.validity.DataPropertyName = "Validity";
            this.validity.HeaderText = "Validity";
            this.validity.Name = "validity";
            this.validity.ReadOnly = true;
            this.validity.Width = 65;
            // 
            // cost
            // 
            this.cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cost.DataPropertyName = "Cost";
            this.cost.HeaderText = "Cost";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            this.cost.Width = 53;
            // 
            // description
            // 
            this.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.description.DataPropertyName = "Description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 85;
            // 
            // FormTicketGridAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(386, 350);
            this.Controls.Add(this.ticketsGrid);
            this.IsMdiContainer = false;
            this.Name = "FormTicketGridAll";
            this.Text = "Tickets";
            this.Controls.SetChildIndex(this.ticketsGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ticketsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ticketsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn validity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
    }
}