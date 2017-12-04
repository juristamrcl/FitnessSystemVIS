<%@ Page Title="" Language="C#" MasterPageFile="~/Fitness.Master" AutoEventWireup="true" CodeBehind="Trainings.aspx.cs" Inherits="FitnessWeb.Trainings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="contentCardTraining materialCard">
            <div class="rateTopText">Trainings overview</div> 
            <div class="line materialCard"></div>
            <div class="cardTrainings" runat="server">
                <div class="cardLine centeredLine">
                    <asp:Label CssClass="cardLabel firstLabel" ID="dateFromText" runat="server" Text="Date From"></asp:Label>
                    <asp:Label CssClass="cardLabel" ID="Label1" runat="server" Text="Date To"></asp:Label>
                </div>
                <div class="cardLine centeredLine">
                    <asp:Calendar CssClass="calendar" ID="CalendarFrom" runat="server"></asp:Calendar>
                    <div class="divideDiv"></div>
                    <asp:Calendar CssClass="calendarTo" ID="CalendarTo" runat="server"></asp:Calendar>
                </div>
                <div class="cardLine centeredLine">
                    <asp:Button ID="dateResetButton" CssClass="dateConfirmButton dateResetButton" runat="server" Text="Reset" OnClick="dateResetButton_Click" />
                    <div class="divideDiv"></div>
                    <asp:Button ID="dateConfirmButton" CssClass="dateConfirmButton" runat="server" Text="Filter" OnClick="dateConfirmButton_Click" />
                </div>
                <div class="cardLine filterLabel">
                    <asp:Label CssClass="cardLabel" ID="filterLabel" runat="server" Text="Date To"></asp:Label>
                </div>
                <div class="cardLine trainingGrid">
                    <asp:GridView CssClass="trainingsGridView" ID="trainingsGridView" CellPadding="10" OnRowDataBound="trainingsGridView_RowDataBound" runat="server"></asp:GridView>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>