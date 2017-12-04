using System;
using System.Windows.Forms;
using Connective;
using Connective.TableGateway;
using Connective.Tables;

namespace FitnessForms.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }


        private void acceptButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee(0, mailInput.Text, passwordInput.Text);

            if (Functions.IsValidEmail(mailInput.Text))
            {
                if (passwordInput.Text.Length > 6)
                {
                    if (EmployeeGateway.CheckPassword(employee))
                    {
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("You enetered wrong credentials, try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Password is too short!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("You entered invalid mail address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Login",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
