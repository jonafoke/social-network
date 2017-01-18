<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileMaster.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Assignment_4_2.WebForm3" %>

<%@ Register Src="~/Controls/NewsFeed.ascx" TagPrefix="uc1" TagName="NewsFeed" %>
<%@ Register Src="~/Controls/ProfilePic.ascx" TagPrefix="uc2" TagName="ProfilePic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <table style="width: 100%;" cellpadding="3" cellspacing="3">
        <tbody>
<tr>
    <td><uc1:NewsFeed id="NewsFeed1" runat="server">
                 
            </uc1:NewsFeed></td>
        </tr>
<tr>
            <td></td>
        </tr>
</tbody></table>

</asp:Content>
