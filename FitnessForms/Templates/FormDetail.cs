using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessForms.Templates
{
    public partial class FormDetail : Form
    {
        public FormDetail()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveRecord())
            {
                Close();
            }
        }
        protected virtual bool SaveRecord()
        {
            return false;
        }

        /// <summary>
        /// Override this method to delete an existing record.
        /// </summary>
        protected virtual bool DeleteRecord()
        {
            return false;
        }

        /// <summary>
        /// Opens an existing record with a given PK or prepares a new empty record if the PK argument is null.
        /// </summary>
        /// <param name="primaryKey"></param>
        public virtual bool OpenRecord(object primaryKey)
        {
            return false;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete the record?", "Auction App", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                if (DeleteRecord())
                {
                    Close();
                }
            }
        }
    }
}
