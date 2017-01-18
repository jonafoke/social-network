<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment_4_2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style2"
        style="border-bottom: thin solid #000000; width: 910px;
        border-left-color: #000000; border-left-width: medium;
        border-right-color: #000000; border-right-width: medium;
        border-top-color: #000000; border-top-width: medium;">
        <tr>
            <td align="center" class="style3" rowspan="2">
                <asp:Image ID="Image1" runat="server" Height="280px"
                    ImageUrl="~/Images/social-network.jpg" Width="349px" />
                
                <asp:Label ID="Label2" runat="server" Font-Names="Raavi" Font-Bold="True">
                Welcome to the FriendBook Social Network</asp:Label>
            </td>
            <td align="center"
            style="border-left-style: solid; border-width: medium; border-color: #3366CC">
                 
            <table style="width: 80%">
                    <tr>
                        <td colspan="2">
                                     
                         </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                             First Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                             </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                            Last Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 23px; width: 207px">
                            Phone</td>
                        <td style="height: 23px" align="left">
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                           </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                            City</td>
                        <td align="left">
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                            Email</td>
                        <td align="left">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                            Username</td>
                        <td align="left">
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                            Password</td>
                        <td align="left">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>

                    <tr> 
                        <td style="width: 207px">
                            Your Photo</td>
                        <td align="left">
                            <asp:FileUpload ID="uploadPhoto" runat="server" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="width: 207px">
                             </td>
                        <td>
                             </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                             </td>
                        <td align="left">
                            <asp:Button ID="btnRegister" runat="server" Text="Register"
                                onclick="btnRegister_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                             </td>
                        <td>
                             </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                             </td>
                        <td>
                             </td>
                    </tr>
                    <tr>
                        <td style="width: 207px">
                             </td>
                        <td>
                             </td>
                    </tr>
                    </table> 
         
             
            </td>
        </tr>
      
    </table>
</asp:Content>


