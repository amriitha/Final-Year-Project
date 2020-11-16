<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatLogin.aspx.cs" Inherits="PatLogin" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
<h2>Patient Login</h2>
<table>
<tr><td>E-Mail ID</td><td><asp:TextBox ID="TxtLogin1" runat="server"></asp:TextBox></td></tr>
<tr><td>Password</td><td><asp:TextBox ID="TxtPass1" TextMode="Password" runat="server"></asp:TextBox></td></tr>
<tr><td colspan="2" align="center"><asp:Button id="btnLogin" runat="server" 
        Text="LogIn" onclick="btnLogin_Click" /></td></tr>
</table>



</asp:Content>

