<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendRequests.ascx.cs" Inherits="Assignment_4_2.Controls.FriendRequests" %>
<asp:DataList ID="dlFriendRequests" runat="server" Width="100%" OnSelectedIndexChanged="dlFriendRequests_SelectedIndexChanged">
    <ItemTemplate>
        <table cellpadding="2" style="border: 1px ridge #CCCCCC; width: 100%;">
            <tr>
                <td class="style1" rowspan="2" align="center">
                    <asp:ImageButton ID="imgbtnYou" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge"
                        BorderWidth="1px" CommandArgument='<%#Eval("ProfileID") %>'
                        Height="84px" ImageUrl='<%# Eval("ProfilePic") %>'
                        OnClick="imgbtnYou_Click" Width="84px" />
                </td>
                <td align="left">
                    <asp:Label ID="lblFirstName" runat="server" Font-Bold="False"
                    Font-Names="Franklin Gothic Medium"
                    Text='<%# Bind("FirstName") %>'></asp:Label><br />
                    <asp:Label ID="lblLastName" runat="server" Font-Bold="False"
                    Font-Names="Franklin Gothic Medium"
                    Text='<%# Bind("LastName") %>'></asp:Label>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAccept" runat="server" ToolTip="Accept"
                    Text="Accept" OnClick="btnAccept_Click"
                     CommandArgument='<%# Bind("ProfileID") %>' /> 
                    <asp:Button ID="btnReject" runat="server" ToolTip="Reject" Text="Reject" Width="59px"
                    CommandArgument='<%#Bind("ProfileID") %>' OnClick="btnReject_Click" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>