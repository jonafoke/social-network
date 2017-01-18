<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfilePic.ascx.cs" Inherits="Assignment_4_2.Controls.ProfilePic" %>
<style type="text/css">
    .ProfilePic
    {
        width: 171px;
    }
</style>
<table align="center" class="ProfilePic">
    <tr>
        <td align="center">
            <asp:DataList ID="dlProfile" runat="server" BorderColor="Black"
            BorderStyle="Ridge"
                BorderWidth="0px" Visible="false" Width="60px">
                <ItemTemplate>
                    <table align="center" style="width: 100%">
                        <tr>
                            <td>
                            <asp:ImageButton ID="ImagePhoto" runat="server"
                             BorderColor="Black" BorderStyle="Ridge"
                             BorderWidth="1px" Height="170px"
                             ImageUrl='<%# Eval("ProfilePic") %>'
                             Width="158px" />
                            </td>
                        </tr>
                    </table>
                
        </td>
    </tr>
    <tr>
        <td align="center" style="border: 1px ridge #CCCCCC">
            <asp:HyperLink ID="AboutMe" runat="server" NavigateUrl='<%# string.Format("~/AboutMe.aspx?ProfileID={0}", Eval("ProfileID")) %>' 
                Text='<%# Eval("ProfileID")%>'>About Me</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td align="center" style="border: 1px ridge #CCCCCC">
            <asp:LinkButton ID="btnFriends" runat="server"
            OnClick="btnFriends_Click">Friends</asp:LinkButton>
        </td>
    </tr>
    </ItemTemplate>
            </asp:DataList>
    <tr>
        <td align="center">
           The number above is your Profile ID. Click that to go to your Profile!   
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
    <tr>
        <td align="center">
              
        </td>
    </tr>
</table>