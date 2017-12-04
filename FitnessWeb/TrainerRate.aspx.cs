using Connective.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connective.TableGateway;
using Connective.Factory;

namespace FitnessWeb
{
    public partial class TrainerRate : System.Web.UI.Page
    {
        private Collection<Trainer> trainers;
        private Collection<string> starNumbers;

        protected void Page_Load(object sender, EventArgs e)
        {
            TrainerFactory trainerFactory = new TrainerFactory();
            TrainerGateway<Trainer> trainerg = (TrainerGateway<Trainer>)trainerFactory.GetTrainer();

            if (Session["ID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            trainers = trainerg.Select();
            Collection<string> trainerNames = new Collection<string>();

            foreach(Trainer tr in trainers)
            {
                trainerNames.Add(tr.ToString());
            }
           
            starNumbers = new Collection<string> {
                    "1",
                    "2",
                    "3",
                    "4",
                    "5"
            };

            if (!IsPostBack)
            {
                trainerStars.DataSource = starNumbers;
                trainerStars.DataBind();

                trainerDropdownId.DataSource = trainerNames;
                trainerDropdownId.DataBind();
            }
            
            if (Session["rated"] != null)
            {
                ratedTrainerText.Attributes.Add("class", "blocked");
                ratedTrainer.Style.Add("display", "inline-block");
                thankRating.Style.Add("display", "inline-block");
                theDiv.Style.Add("display", "none");
                averageRating.Style.Add("display", "inline-block");
                averageRatingText.Style.Add("display", "inline-block");
                clientsRatedTop.Style.Add("display", "inline-block");

                ratedTrainer.Text = Session["ratedTrainer"].ToString();
                var temp = trainerg.SelectAVG(int.Parse(Session["ratedTrainerId"].ToString()));
                averageRating.Text = temp[0].ToString();
                clientsRated.Text = temp[1].ToString();
                Session["rated"] = null;
                Session["ratedTrainer"] = null;
                Session["ratedTrainerId"] = null;
            }
            else
            {
                ratedTrainerText.Style.Add("display", "none");
                ratedTrainer.Style.Add("display", "none");
                thankRating.Style.Add("display", "none");
                averageRating.Style.Add("display", "none");
                averageRatingText.Style.Add("display", "none");
                clientsRatedTop.Style.Add("display", "none");
            }
        }

        public void logout()
        {
            Session["ID"] = null;
        }

        protected void rateConfirmButton_Click1(object sender, EventArgs e)
        {
            TrainerRatingFactory trainerRatingFactory = new TrainerRatingFactory();
            TrainerRatingGateway<TrainerRating> tr = (TrainerRatingGateway<TrainerRating>)trainerRatingFactory.GetTrainerRating();

            decimal temp;
            TrainerRating rating = new TrainerRating();
            rating.TrainerId = trainers[trainerDropdownId.SelectedIndex].RecordId;
            System.Diagnostics.Debug.WriteLine("bu:" + trainerDropdownId.SelectedIndex);

            rating.RatingNumber = (decimal.TryParse(starNumbers[trainerStars.SelectedIndex], out temp) ? temp : 0M);
            rating.Text = ratingText.Text;
            rating.ClientId = int.Parse(Session["ID"].ToString()); ;

            if (string.IsNullOrWhiteSpace(ratingText.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please, fill in rating text');window.location ='TrainerRate.aspx';", true);
            }
            else
            {
                tr.Insert(rating);

                Session["rated"] = "rated";
                Session["ratedTrainer"] = trainers[trainerDropdownId.SelectedIndex].Name + " " + trainers[trainerDropdownId.SelectedIndex].Surname;
                Session["ratedTrainerID"] = trainers[trainerDropdownId.SelectedIndex].RecordId;
                Response.Redirect("~/TrainerRate.aspx");
            }
        }
    }
}