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
    public partial class FormGrid : Form
    {
        public FormGrid()
        {
            InitializeComponent();
        }
        protected virtual void RefreshData()
        {

        }

        /// <summary>
        /// Override this method to implement a custom logic of creating new records.
        /// </summary>
        protected virtual void NewRecord()
        {

        }

        /// <summary>
        /// Override this method to implement a custom logic of editing existing records.
        /// </summary>
        protected virtual void EditRecord()
        {

        }

        private void FormGrid_Shown(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRecord();
        }

        private void FormGrid_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
