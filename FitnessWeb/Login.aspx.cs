using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connective.TableGateway;
using Connective.Tables;
using Connective;

namespace FitnessWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID"] = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = String.Format("{0}", Request.Form["loginInput"]);
            string password = String.Format("{0}", Request.Form["passwordInput"]);

            Client client = new Client();
            client.Password = password;
            client.Mail = login;
            if (string.IsNullOrWhiteSpace(login))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No mail was entered');window.location ='ChangeProfile.aspx';", true);
            }
            else if (!Functions.IsValidEmail(login))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You entered non-valid email address');window.location ='ChangeProfile.aspx';", true);
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You entered non-valid password');window.location ='ChangeProfile.aspx';", true);
            }
            else
            {
                Client cl = ClientGateway.CheckPassword(client);
                if (cl != null)
                {
                    Session["ID"] = cl.RecordId;
                    Session["login"] = cl.Mail;
                    Response.Redirect("~/TrainerRate.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Wrong credentials!');window.location ='ChangeProfile.aspx';", true);
                }
            }            
        }
    }
}