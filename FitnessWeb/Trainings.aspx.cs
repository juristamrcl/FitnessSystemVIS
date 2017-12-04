using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connective.TableGateway;
using Connective.Tables;
using System.Collections.ObjectModel;
using System.Globalization;

namespace FitnessWeb
{
    public partial class Trainings : System.Web.UI.Page
    {
        bool filtered = false;
        Collection<ClientTraining> trainings;
        Collection<ClientTraining> filteredTrainings = new Collection<ClientTraining>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            trainings = ClientGateway.SelectTrainings(int.Parse(Session["ID"].ToString()));

            if (Session["filter"] != null)
            {
                Session["filter"] = null;

                const string FMT = "O";
                DateTime from = DateTime.ParseExact(Session["dateFrom"].ToString(), FMT, CultureInfo.InvariantCulture);
                DateTime to = DateTime.ParseExact(Session["dateTo"].ToString(), FMT, CultureInfo.InvariantCulture);

                foreach (ClientTraining ct in trainings)
                {
                    if (ct.TimeTo != null)
                    {
                        DateTime dateTimeTo = (DateTime)ct.TimeTo; 
                        if (DateTime.Compare(ct.TimeFrom, from) > 0 && DateTime.Compare(dateTimeTo, to) < 0)
                        {
                            filteredTrainings.Add(ct);
                        }
                    }
                }
                filtered = true;
                filterLabel.Style.Add("display", "inline-block");
                filterLabel.Text = "Filter: " + Session["dateFrom"].ToString().Substring(0, 10) + " - " + Session["dateTo"].ToString().Substring(0, 10);
            }
            else
            {
                filterLabel.Style.Add("display", "none");
            }

            if (!IsPostBack)
            {
                if (filtered)
                {
                    trainingsGridView.DataSource = filteredTrainings;
                    trainingsGridView.DataBind();
                }
                else
                {
                    trainingsGridView.DataSource = trainings;
                    trainingsGridView.DataBind();
                }
            }
        }

        protected void trainingsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Training ID";
                e.Row.Cells[1].Text = "Time From";
                e.Row.Cells[2].Text = "Time To";
                e.Row.Cells[3].Text = "Locker Number";
                e.Row.Cells[4].Text = "Trainer Name";
                e.Row.Cells[5].Text = "Trainer Surname";
            }
        }

        protected void dateConfirmButton_Click(object sender, EventArgs e)
        {
            if (CalendarFrom.SelectedDate != null && CalendarTo.SelectedDate != null && DateTime.Compare(CalendarFrom.SelectedDate, CalendarTo.SelectedDate) > 0)
            {
                DateTime temp = CalendarFrom.SelectedDate;
                CalendarFrom.SelectedDate = CalendarTo.SelectedDate;
                CalendarTo.SelectedDate = temp;
            }

            if (CalendarFrom.SelectedDate == null || CalendarTo.SelectedDate == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You have to enter start and end date.');window.location ='ChangeProfile.aspx';", true);
            }
            else
            {
                Session["filter"] = true;
                const string FMT = "O";
                Session["dateFrom"] = CalendarFrom.SelectedDate.ToString(FMT);
                Session["dateTo"] = CalendarTo.SelectedDate.ToString(FMT);
                Response.Redirect("~/Trainings.aspx");
            }
        }

        protected void dateResetButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Trainings.aspx");
        }
    }
}