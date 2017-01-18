<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsFeed.ascx.cs" Inherits="Assignment_4_2.Controls.NewsFeed" %>
<style type="text/css">
    .styleLatestUpdates
    {
        width: 400px;
    }
    .stylePost
    {
        width: 98%;
        height: 90px;
    }
    .styleComment
    {
        width: 103px;
    }
    .stylePostPic
    {
        width: 110px;
        vertical-align: top;
    }
</style>
<table style="width: 550px" align="center">
    <tr>
        <td align="left" style="padding-left: 10px;">
            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Names="Georgia" Font-Size="Large"></asp:Label>
        </td>
        <td align="right">
        </td>
    </tr>
    <tr>
        
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table align="center" cellpadding="0" cellspacing="0" class="styleLatestUpdates">
            <tr>
                <td>
                    <table style="width: 550px">
                        <tr>
                            <td align="left">
                                <panel runat="server" id="pnlStatus">
                             
                                <asp:TextBox ID="txtWhatsOnYourMind" runat="server" Height="59px" TextMode="MultiLine"
                                    Width="543px"></asp:TextBox>
                                 
 
                                 <asp:Button ID="btnPost" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC"
                                    BorderStyle="Ridge" BorderWidth="1px" Font-Bold="True" ForeColor="#333333" OnClick="btnPost_Click"
                                    Text="Post" Width="52px" />
                                <asp:UpdateProgress ID="ProgressBar" runat="server">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress> 
                                </panel>
                            </td>
                        </tr>
                    </table>
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataList ID="dlPosts" runat="server" Width="550px">
                        <ItemTemplate>
                            <div>
                                <table cellpadding="0" cellspacing="0" class="stylePost">
                                    <tr>
                                        <td class="stylePostPic" rowspan="2" align="center">
                                            <asp:ImageButton ID="YourPic" runat="server" BorderColor="Black" BorderStyle="Ridge"
                                                BorderWidth="1px" Height="60px" ImageUrl='<%# Eval("ProfilePic") %>'
                                                Width="60px" OnClick="YourPic_Click" CommandArgument='<%#Bind("ProfilePic") %>' /><br />
                                            <asp:Hyperlink ID="btnProfileId" runat="server" NavigateUrl='<%# string.Format("~/AboutMe.aspx?ProfileID={0}", Eval("ProfileID")) %>'
                                                 Text='<%# Eval("ProfileID")%>' >
                                            </asp:Hyperlink>
                                        </td>
                                        <td valign="top" align="left">
                                            <asp:Label runat="server" ID="lblName" ForeColor="Blue" Font-Bold="True" Font-Italic="True">
                                            <%# DataBinder.Eval(Container.DataItem, "FirstName")%> Posted:</asp:Label>
                                             <div style="width: 300px">
                                                <%# DataBinder.Eval(Container.DataItem, "StatusUpdate")%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                        </td>
                                        <td align="right" valign="bottom">
                                            <asp:Label runat="server" ID="lblPostedOn" ForeColor="Black" Font-Italic="True" Font-Size="Small">
                                            Posted On: <%# DataBinder.Eval(Container.DataItem, "PostDate")%>
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                 
 
                                <hr />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnPost" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>