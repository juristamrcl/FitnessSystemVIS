using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Connective.TableGateway;
using Connective.Tables;
using Connective.Backup;
using Connective.Factory;

namespace FitnessForms.Forms
{
    public partial class FormLockerGrid : Templates.FormGrid
    {
        public FormLockerGrid()
        {
            InitializeComponent();
        }
        protected override void RefreshData()
        {
            LockerFactory lockerFactory = new LockerFactory();

            Collection<Locker> lockers = lockerFactory.GetLocker().Select();
            BindingList<Locker> bindingList = new BindingList<Locker>(lockers);
            lockersGrid.AutoGenerateColumns = false;
            lockersGrid.DataSource = bindingList;
        }
        private Locker GetSelectedLocker()
        {
            if (lockersGrid.SelectedRows.Count == 1)
            {
                Locker locker = lockersGrid.SelectedRows[0].DataBoundItem as Locker;
                return locker;
            }
            else
            {
                return null;
            }
        }
        protected override void NewRecord()
        {

            FormLockerDetail form = new FormLockerDetail();
            if (form.OpenRecord(null, null))
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        protected override void EditRecord()
        {
            Locker selectedLocker = GetSelectedLocker();
            if (selectedLocker != null)
            {
                FormLockerDetail form = new FormLockerDetail();
                if (form.OpenRecord(selectedLocker.RecordId, selectedLocker.ToGender))
                {
                    form.ShowDialog();
                    RefreshData();
                }
            }
        }

        private void lockersGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditRecord();
        }
    }
}
