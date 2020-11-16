<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DataUserLogin.aspx.cs" Inherits="DataUserLogin" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
<h3>Data Requestor Login Form</h3>
<br />
<table>
<tr><td>Login ID</td><td><asp:TextBox ID="TxtLogin1" runat="server"></asp:TextBox></td></tr>
<tr><td>Password</td><td><asp:TextBox ID="TxtPass1" runat="server"></asp:TextBox></td></tr>
<tr><td></td><td><asp:Button ID="btnLogin" runat="server" Text="LogIn" 
        onclick="btnLogin_Click" /></td></tr>
</table>

</asp:Content>