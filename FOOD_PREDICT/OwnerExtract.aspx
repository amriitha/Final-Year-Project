<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User.master" CodeFile="OwnerExtract.aspx.cs" Inherits="OwnerExtract" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
<asp:Panel ID="PanelMaster" runat="server" Visible="true">
<h3>Extract Sensitive Data</h3>
<br />
<table>
<tr><td>Sensitive Key</td><td><asp:TextBox ID="TxtKey1" runat="server"></asp:TextBox></td></tr>
<tr><td></td><td><asp:Button ID="btnExtractKey" runat="server" Text="Extract Data" 
        onclick="btnExtractKey_Click" /></td></tr>
</table>
<br />
<p>
<asp:DataGrid ID="ResultGrid" runat="server" AutoGenerateColumns="true">
</asp:DataGrid>
</p>




</asp:Panel>


</asp:Content>


