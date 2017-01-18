<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileMaster.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="Assignment_4_2.WebForm4" %>

<%@ Register Src="~/Controls/Friends.ascx" TagPrefix="uc1" TagName="Friends" %>
<%@ Register Src="~/Controls/FriendRequests.ascx" TagPrefix="uc2" TagName="FriendRequests" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="3" cellspacing="3" style="width: 100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblRequests" runat="server" Text="Your Friend Requests"
                    Font-Names="Franklin Gothic Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <uc2:FriendRequests ID="FriendRequests1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center">
               
                <hr />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblFriends" runat="server" Text="Your Friends"
                    Font-Names="Franklin Gothic Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:Friends ID="Friends1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                 </td>
        </tr>
    </table>
</asp:Content>
