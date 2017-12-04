<%@ Page Title="" Language="C#" MasterPageFile="~/Fitness.Master" AutoEventWireup="true" CodeBehind="TrainerRate.aspx.cs" Inherits="FitnessWeb.TrainerRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="contentCard materialCard">
            <div class="rateTopText">Rate trainer</div> 
            <div class="line materialCard"></div>
            <div class="cardContentWrapper" runat="server">
                <div class="cardLine">
                    <asp:Label CssClass="cardLabel" ID="Label1" runat="server" Text="Choose trainer"></asp:Label>
                    <asp:DropDownList ID="trainerDropdownId" CssClass="trainerDropdown" runat="server"></asp:DropDownList>
                </div>
                <div class="cardLine">
                    <asp:Label CssClass="cardLabel" ID="Label2" runat="server" Text="Give him stars"></asp:Label>
                    <div id="starRating">
                        <asp:DropDownList ID="trainerStars" runat="server"></asp:DropDownList>
                        <img src="./img/star.png" ID="starImage"/>
                    </div>  
                </div>
                <div class="cardLine">
                    <asp:Label CssClass="cardLabel" ID="Label3" runat="server" Text="Tell us something about him"></asp:Label>
                    <asp:TextBox ID="ratingText" CssClass="ratingText" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="rateConfirmButton" CssClass="rateConfirmButton" runat="server" Text="Send" OnClick="rateConfirmButton_Click1" />
            </div>
        </div>
        <div class="contentCard materialCard">
            <div class="rateTopText">Your Trainer rating</div> 
            <div class="line materialCard"></div>
                <div class="cardLine">
                    <div class="ratingLabelMargin" runat="server" id="theDiv">If you want to see your trainer´s rating, you have to send your rating first!</div>
                    <asp:Label CssClass="cardLabel" ID="ratedTrainerText" runat="server" Text="Rated Trainer"></asp:Label>
                    <asp:Label CssClass="cardLabel ratedTrainer" ID="ratedTrainer" Text="" runat="server"></asp:Label>
                </div>
                <div class="cardLine">
                    <asp:Label CssClass="cardLabel" ID="averageRatingText" runat="server" Text="Average trainer´s rating: "></asp:Label>
                    <asp:Label CssClass="cardLabel averageRating" ID="averageRating" Text="" runat="server"></asp:Label>
                </div>
                <div class="cardLine" ID="clientsRatedTop" runat="server">
                    <asp:Label CssClass="cardLabel" ID="clientsRatedText" runat="server" Text="Clients rated"></asp:Label>
                    <asp:Label CssClass="cardLabel clientsRated" ID="clientsRated" Text="" runat="server"></asp:Label>
                </div>
                <div class="cardLine">
                    <asp:Label CssClass="cardLabel thankRating" ID="thankRating" runat="server" Text="Thank you for your rating!"></asp:Label>
                </div>
        </div>
    </div>
</asp:Content>