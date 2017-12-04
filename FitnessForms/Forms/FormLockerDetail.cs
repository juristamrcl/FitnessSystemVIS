using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Connective.TableGateway;
using Connective.Tables;
using Connective.Factory;

namespace FitnessForms.Forms
{

    public partial class FormLockerDetail : Templates.FormDetail
    {
        private Locker locker;
        private bool newRecord;
        public FormLockerDetail()
        {
            InitializeComponent();
        }
        public bool OpenRecord(object primaryKey, object toGender)
        {
            LockerFactory lockerFactory = new LockerFactory();

            if (primaryKey != null)
            {
                int idLocker = (int)primaryKey;
                string genderLocker = (string)toGender;
                locker = lockerFactory.GetLocker().Select(idLocker, genderLocker);
                newRecord = false;
            }
            else
            {
                locker = new Locker();
                newRecord = true;
            }
            BindData();
            return true;
        }
        private void BindData()
        {
            Collection<string> genders = new Collection<string>();
            genders.Add("male");
            genders.Add("female");
            Collection<string> statuses = new Collection<string>();
            statuses.Add("freeforuse");
            statuses.Add("reserved");

            comboGender.DataSource = genders;
            comboStatus.DataSource = statuses;

            textLockerId.Text = locker.RecordId.ToString();
            comboGender.Text = locker.ToGender;
            comboStatus.Text = locker.Status;
        }

        private bool GetData()
        {
            bool ret = true;

            errorProvider.Clear();
            int j;
            if (Int32.TryParse(textLockerId.Text, out j))
            {
                locker.RecordId = j;
            }
            else
            {
                ret = false;
                errorProvider.SetError(textLockerId, "Invalid Locker number.");
            }
            locker.ToGender = comboGender.Text;
            locker.Status = comboStatus.Text;

            if (locker.ToGender == "male" || locker.ToGender == "female")
            {

            }
            else
            {
                ret = false;
                errorProvider.SetError(comboGender, "Invalid gender.");
            }

            if (locker.Status == "freeforuse" || locker.Status == "reserved")
            {

            }
            else
            {
                ret = false;
                errorProvider.SetError(comboStatus, "Invalid status.");
            }
            return ret;
        }
        protected override bool SaveRecord()
        {
            LockerFactory lockerFactory = new LockerFactory();

            if (GetData())
            {
                if (newRecord)
                {
                    lockerFactory.GetLocker().Insert(locker);
                }
                else
                {
                    lockerFactory.GetLocker().Update(locker);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override bool DeleteRecord()
        {
            LockerFactory lockerFactory = new LockerFactory();

            lockerFactory.GetLocker().Delete(locker.RecordId);
            return true;
        }
    }
}
