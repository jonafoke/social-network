<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="Assignment_4_2.Controls.Search" %>
<style type="text/css">
    .styleFriends
    {
        width: 100%;
    }
    .friendsTD
    {
        width: 30%;
        text-align: center;
    }
 
</style>
 
<asp:DataList ID="SearchList" runat="server" Width="100%">
    <ItemTemplate>
        <table cellpadding="2" class="styleFriends" style="border: 1px ridge #CCCCCC">
            <tr>
                <td class="friendsTD" rowspan="2">
                    <asp:ImageButton ID="imgbtnPic" runat="server" Height="84px" Width="84px"
                     ImageUrl='<%# Eval("ProfilePic") %>'
                     BorderColor="#CCCCCC" BorderStyle="Ridge" BorderWidth="1px"
                     CommandArgument='<%#Bind("ProfileID") %>' onclick="imgbtnPic_Click"/><br />
                    <asp:Hyperlink ID="btnProfileId" runat="server" NavigateUrl='<%# string.Format("~/AboutMe.aspx?ProfileID={0}", Eval("ProfileID")) %>'
                                                 Text='<%# Eval("ProfileID")%>' ></asp:Hyperlink>
                </td>
                <td align="left">
                    <asp:Label ID="lblFriendName" runat="server" Font-Bold="False"
                        Font-Names="Franklin Gothic Medium" Text='<%# Bind("FirstName") %>'></asp:Label><br />
                    <asp:Label ID="lblLastName" runat="server" Font-Bold="False"
                        Font-Names="Franklin Gothic Medium" Text='<%# Bind("LastName") %>'></asp:Label>
                </td>

            </tr>
            <tr>
                <td>
                     </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>