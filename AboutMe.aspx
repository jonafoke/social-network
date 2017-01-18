<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileMaster.Master" AutoEventWireup="true" CodeBehind="AboutMe.aspx.cs" Inherits="Assignment_4_2.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="1" class="style2">
        <tr>
            <td align="left" style="width: 280px">
            </td>
            <td align="left">
                  
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <hr />
                
                        <table cellspacing="1" style="width: 432px">
                            <tr>
                                <td align="center" style="width: 183px">
                                      
                                </td>
                                <td align="center">
                                      
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 183px; height: 22px;">
                                    First Name
                                </td>
                                <td align="left" style="height: 22px">
                                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>   
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 183px">
                                    Last Name
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 183px">
                                    Phone
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 183px">
                                    City
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="center" style="width: 183px">
                                      
                                </td>
                                <td align="center">
                                      
                                </td>
                            </tr>
                        </table>
                    
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 280px">
            <asp:Button ID="btnEdit" runat="server" Text="Edit Profile" OnClick="Edit_Click" />     
  
            </td>
            <td align="right">
                  
                <asp:LinkButton ID="btnAddAsFriend" runat="server" Text="Add As Friend" Font-Bold="True"
                Font-Italic="True" OnClick="btnAddAsFriend_Click"></asp:LinkButton>
                  
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 280px">
                  
            </td>
            <td align="left">
                  
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlProfile" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblEditFirstName" runat="server" Text="First Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEditLastName" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEditPhone" runat="server" Text="Phone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEditCity" runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="uploadNewPhoto" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" OnClick="btnSubmit_Click" /></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
