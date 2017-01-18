<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Assignment_4_2.Controls.Header" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .HeaderStyle
    {
        width: 80px;
        padding-right: 7px;
    }
    .LogoStyle
    {
        width: 50px;
        padding-right: 7px;
    }
    .Red
    {
        color: Red;
        font-weight: bold;
    }

    .unwatermarked
        {
            height: 18px;
            width: 148px;
        }

    .watermarked
        {
            height: 20px;
            width: 150px;
            padding: 2px 0 0 2px;
            border: 1px solid #BEBEBE;
            background-color: #F0F8FF;
            color: gray;
        }
</style>

        <table cellpadding="0" cellspacing="1" width="900px">
    <tr>
        <td align="center" class="LogoStyle">
            <asp:LinkButton ID="btnLogo" runat="server" Font-Bold="True"
            Font-Names="Franklin Gothic Medium"
            Font-Underline="False" ForeColor="White"
            Font-Size="Large"
            OnClick="btnLogo_Click" Enabled="False">FriendBook</asp:LinkButton>
        </td>
        <td class="HeaderStyle">
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="imgBtnMain" runat="server"
                        ImageUrl="~/images/globe.png" OnClick="imgBtnMain_Click"></asp:ImageButton>
                    </td>
                    <td>
                        <asp:ImageButton ID="imgBtnMsg" runat="server"
                        ImageUrl="~/images/msgr.png" OnClick="imgBtnMsg_Click" />
                    </td>
                    <td>
                        
                    </td>
                </tr>
            </table>
        </td>
        <td align="left">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
            <asp:TextBox ID="txtSearch" runat="server" Width="300px"
            Height="21px"></asp:TextBox>
 
            <asp:TextBoxWatermarkExtender ID="txtSearch_TextBoxWatermarkExtender" runat="server" Enabled="True" 
            TargetControlID="txtSearch" WatermarkCssClass="watermarked" WatermarkText="Search Friends...">
            </asp:TextBoxWatermarkExtender>
 
            <asp:AutoCompleteExtender ID="txtSearch_AutoCompleteExtender"
            runat="server" DelimiterCharacters="" ServiceMethod="SearchFriends"
            Enabled="True" TargetControlID="txtSearch" ServicePath="~/AutoCompleteService.asmx"
            CompletionInterval="100" MinimumPrefixLength="1">
            </asp:AutoCompleteExtender>
 
            <asp:Button ID="btnSearch" runat="server" Text="Search"
             OnClick="btnSearch_Click" BorderColor="#0033CC"
             BorderStyle="Ridge" Font-Bold="True" ForeColor="Black"
             Height="27px" />
 
        </td>
        <td align="right">
            <asp:LinkButton ID="btnLogout" runat="server"
            Font-Bold="False" ForeColor="White"
            OnClick="btnLogout_Click"
            Font-Names="Arial Rounded MT Bold"
            Font-Underline="False">Logout</asp:LinkButton>
        </td>
    </tr>
</table>
       

<script>
    window.onload = function () { document.getElementById("imgBtnMsg").style.visibility = "hidden"; };
    window.onload = function () { document.getElementById("imgBtnFriendReq").style.visibility = "hidden"; };
</script>