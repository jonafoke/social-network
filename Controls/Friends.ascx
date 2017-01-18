<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Friends.ascx.cs" Inherits="Assignment_4_2.Controls.Friends" %>;
<style type="text/css">
    .styleFriends
    {
        width: 100%;
    }
    .friendsTD
    {
        width: 20%;
        text-align: center;
    }
</style>
<asp:DataList ID="dlFriends" runat="server" Width="100%">
    <ItemTemplate>
        <table cellpadding="2" class="styleFriends" style="border: 1px ridge #CCCCCC">
            <tr>
                <td class="friendsTD" rowspan="2">
                    <asp:ImageButton ID="imgbtnYou" runat="server" Height="84px" Width="84px"
                    ImageUrl='<%# Eval("ProfilePic") %>'
                    BorderColor="#CCCCCC" BorderStyle="Ridge" BorderWidth="1px" OnClick="imgbtnYou_Click"
                    CommandArgument='<%#Bind("ProfileID") %>' />
                </td>
                <td align="left">
                    <asp:Label ID="lblFirstName" runat="server" Font-Bold="False" Font-Names="Franklin Gothic Medium"
                        Text='<%# Bind("FirstName") %>'></asp:Label><br />
                    <asp:Label ID="lblLastName" runat="server" Font-Bold="False" Font-Names="Franklin Gothic Medium"
                        Text='<%# Bind("LastName") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                      
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>