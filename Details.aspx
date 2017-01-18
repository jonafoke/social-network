<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileMaster.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Assignment_4_2.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
<table>
    <tr>
        <td>
            <b>Date: </b>
        </td>
        <td>
            <asp:Label ID="lblDate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>From: </b>
        </td>
        <td>
            <asp:Label ID="lblFrom" runat="server"></asp:Label>
        </td>
    </tr>
        <tr>
        <td>
            <b>Message</b>
        </td>
        <td>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="btnReply_Click" /> 
        </td>
        <td>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CommandArgument='<%# Bind("MessageBody") %>' />
        </td>
    </tr>
</table>
         <%--Invisible ID on the page to track the FromUserID for this message--%>
    <asp:Label ID="lblFromUserID" runat="server" Visible="false" Text=""></asp:Label>
</div><br /><br />

    <div>
        <asp:Panel ID="pnlReply" runat="server">
            <asp:TextBox ID="txtReplyMessage" runat="server" Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox><br />
            <asp:Button ID="btnSend" runat="server" Text="Send Message" OnClick="btnSend_Click" CommandArgument='<%# Bind("FromUserID") %>' />
        </asp:Panel>
    </div>
</asp:Content>
