<%@ Page Title="" Language="C#" MasterPageFile="~/Fitness.Master" AutoEventWireup="true" CodeBehind="ChangeProfile.aspx.cs" Inherits="FitnessWeb.ChangeProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="content">
       <div class="contentCard materialCard">
           <div class="rateTopText">Change Profile</div> 
           <div class="line materialCard"></div>
           <div class="cardContentWrapper" runat="server">
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="nameLabel" runat="server" Text="Name"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" ID="nameElement" Text="" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="surnameLabel" runat="server" Text="Surname"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" ID="surnameElement" Text="" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="mailLabel" runat="server" Text="Mail"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" ID="mailElement" Text="" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="genderLabel" runat="server" Text="Gender"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" ID="genderElement" Enabled="false" Text="" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="Label1" runat="server" Text="Card"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" ID="cardElement" Enabled="false" Text="" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="Label2" runat="server" Text="Favourite Locker"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" ID="lockerElement" Enabled="false" Text="" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="Label5" runat="server" Text="Old password"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" TextMode="Password" ID="oldPassword" Text="" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="Label3" runat="server" Text="Change Password"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" TextMode="Password" ID="password1" Text="" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" TextMode="Password" ID="password2" Text="" runat="server"></asp:TextBox>
               </div>
               <asp:Button ID="profileConfirmButton" CssClass="rateConfirmButton" runat="server" Text="Update" OnClick="profileConfirmButton_Click1" />
           </div>
       </div>

       <div class="contentCard materialCard">
           <div class="rateTopText">Set favourite locker</div> 
           <div class="line materialCard"></div>
           <div class="cardContentWrapper" runat="server">
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="Label6" runat="server" Text="Old favourite locker"></asp:Label>
                   <asp:TextBox CssClass="rightCardElement profileInput" ID="oldFavouriteLocker" Text="" Enabled="false" runat="server"></asp:TextBox>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="Label8" runat="server" Text="People with your old favourite locker"></asp:Label>
                   <asp:Label CssClass="rightCardElement profileInput" ID="peopleWithLocker" runat="server"></asp:Label>
               </div>
               <div class="cardLine">
                   <asp:Label CssClass="cardLabel" ID="Label7" runat="server" Text="New favourite locker"></asp:Label>
                   <asp:DropDownList CssClass="rightCardElement customInput" ID="lockerDropdown" runat="server"></asp:DropDownList>
               </div>
               <asp:Button ID="saveLocker" CssClass="rateConfirmButton" runat="server" Text="Update" OnClick="saveFavouriteLockerClick" />
           </div>
       </div>
   </div>
</asp:Content>