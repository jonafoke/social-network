<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Assignment_4_2.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Welcome to the Admin Page!!
    <br />
    <br />
    This is where you can delete Users if they are not following our policies. If you wish to
    go to your home page click the button below.
    <br />
    <br />
    <asp:Button ID="btnHome" runat="server" Text="Go to your Home Page" OnClick="btnHome_Click" />
    <br /><br />
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" OnRowCommand="gvUsers_RowCommand" DataKeyNames="UserID" AllowPaging="True" OnPageIndexChanging="gvUsers_PageIndexChanging" PageSize="8">
        <Columns>
        <asp:ButtonField ButtonType="Button" CommandName="Delete User" Text="Delete" />
        <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="Username" HeaderText="Username" />
        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
        <asp:BoundField DataField="LastName" HeaderText="Last Name" />

        </Columns>
    </asp:GridView>
</asp:Content>
