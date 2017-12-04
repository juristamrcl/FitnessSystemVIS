using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connective.TableGateway;
using Connective.Tables;
using Connective;
using System.Collections.ObjectModel;
using Connective.Factory;
using Connective.Backup;

namespace FitnessWeb
{
    public partial class ChangeProfile : System.Web.UI.Page
    {
        Client client;
        Collection<Locker> lockers;
        Client newClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();

            LockerFactory lockerFactory = new LockerFactory();
            LockerXMLGateway<Locker> lg = (LockerXMLGateway<Locker>)lockerFactory.GetLocker();
        

            if (Session["ID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            client = cg.Select(int.Parse((Session["ID"].ToString())));
            newClient = client;

            nameElement.Attributes.Add("placeholder", client.Name);
            surnameElement.Attributes.Add("placeholder", client.Surname);
            mailElement.Attributes.Add("placeholder", client.Mail);
            genderElement.Text = client.Gender;
            cardElement.Text = client.CardId.ToString();
            lockerElement.Text = client.Favourite_locker.ToString();
            password1.Attributes.Add("placeholder", "********");
            password2.Attributes.Add("placeholder", "********");
            oldPassword.Attributes.Add("placeholder", "********");

            oldFavouriteLocker.Text = client.Favourite_locker.ToString();
            int locker = (int)client.Favourite_locker;
            peopleWithLocker.Text = cg.SelectLockerNumb((client.Favourite_locker != null) ? locker : 1).ToString();

            lockers = lg.Select(client.Gender);
            Collection<string> lockerStrings = new Collection<string>();

            foreach (Locker l in lockers)
            {
                lockerStrings.Add("  " + l.RecordId.ToString() + "  ");
            }

            if (!IsPostBack)
            {
                lockerDropdown.DataSource = lockerStrings;
                lockerDropdown.DataBind();
            }
            
            
        }

        protected void profileConfirmButton_Click1(object sender, EventArgs e)
        {
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();

            bool toInsert = true;
            string errorMessage = "";
            if (!string.IsNullOrWhiteSpace(nameElement.Text))
            {
                newClient.Name = nameElement.Text;
            }
            if (!string.IsNullOrWhiteSpace(surnameElement.Text))
            {
                newClient.Surname = surnameElement.Text;
            }
            if (!string.IsNullOrWhiteSpace(mailElement.Text))
            {
                if (Functions.IsValidEmail(mailElement.Text))
                {
                    newClient.Mail = mailElement.Text;
                }
                else
                {
                    toInsert = false;
                    errorMessage = "Entered Mail is invalid.";
                }
            }
            if (!string.IsNullOrWhiteSpace(password1.Text) && !string.IsNullOrWhiteSpace(password2.Text))
            {
                if (password1.Text == password2.Text && password1.Text.Length > 7 && oldPassword.Text == client.Password)
                {
                    newClient.Password = password1.Text;
                }
                else
                {
                    errorMessage = "An error occured, password is too short or does not match.";
                    toInsert = false;
                }
            }

            if (toInsert)
            {
                cg.Update(newClient);
                Response.Redirect("~/ChangeProfile.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('" + errorMessage + "');window.location ='ChangeProfile.aspx';", true);
            }
        }

        protected void saveFavouriteLockerClick(object sender, EventArgs e)
        {
            ClientFactory clientFactory = new ClientFactory();
            ClientGateway<Client> cg = (ClientGateway<Client>)clientFactory.GetClient();

            client.Favourite_locker = lockers[lockerDropdown.SelectedIndex].RecordId;
            cg.Update(client);
            Response.Redirect("~/ChangeProfile.aspx");
        }
    }
}