<%@ Page Title="" Language="C#" MasterPageFile="~/ProfileMaster.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="Assignment_4_2.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvMessages_PageIndexChanging" OnSorting="gvMessages_Sorting" PageSize="5">
        <Columns>
            <asp:TemplateField HeaderText="Date Received" SortExpression="DateReceived">
                <ItemTemplate>
                     <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/Details.aspx?MessageID={0}", Eval("MessageID")) %>' 
                        Text='<%# Eval("DateReceived") %>'>Date</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FirstName" HeaderText="From" SortExpression="FirstName" />
            <asp:BoundField DataField="MessageBody" HeaderText="Message" ItemStyle-Width="1000px" >
<ItemStyle Width="1000px"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
