<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileMaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Assignment_4_2.WebForm2" %>

<%@ Register Src="~/Controls/Search.ascx" TagPrefix="uc1" TagName="Search" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="style2">
        <tr>
            <td>
                 </td>
        </tr>
        <tr>
            <td>
                Search Results:</td>
        </tr>
        <tr>
            <td>
                 </td>
        </tr>
        <tr>
            <td>
            <uc1:Search runat="server" id="Search" />
            </td>
        </tr>
        <tr>
            <td>
                 </td>
        </tr>
        <tr>
            <td>
                 </td>
        </tr>
        <tr>
            <td>
                 </td>
        </tr>
    </table>
</asp:Content>
