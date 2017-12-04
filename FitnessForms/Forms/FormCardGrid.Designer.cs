namespace FitnessForms.Forms
{
    partial class FormCardGrid
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
            this.cardsGrid = new System.Windows.Forms.DataGridView();
            this.card_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cardsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cardsGrid
            // 
            this.cardsGrid.AccessibleName = "client_grid";
            this.cardsGrid.BackgroundColor = System.Drawing.Color.White;
            this.cardsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cardsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.card_id,
            this.name,
            this.credit});
            this.cardsGrid.GridColor = System.Drawing.Color.DarkGray;
            this.cardsGrid.Location = new System.Drawing.Point(0, 24);
            this.cardsGrid.Name = "cardsGrid";
            this.cardsGrid.ReadOnly = true;
            this.cardsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cardsGrid.Size = new System.Drawing.Size(409, 368);
            this.cardsGrid.TabIndex = 2;
            this.cardsGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cardsGrid_CellContentDoubleClick);
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
            this.name.HeaderText = "Client Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 89;
            // 
            // credit
            // 
            this.credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.credit.DataPropertyName = "Credit";
            this.credit.HeaderText = "Credit";
            this.credit.Name = "credit";
            this.credit.ReadOnly = true;
            this.credit.Width = 59;
            // 
            // FormCardGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(409, 392);
            this.Controls.Add(this.cardsGrid);
            this.IsMdiContainer = false;
            this.Name = "FormCardGrid";
            this.Text = "Card";
            this.Controls.SetChildIndex(this.cardsGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cardsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cardsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn card_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
    }
}