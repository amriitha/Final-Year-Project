<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatRegister.aspx.cs" Inherits="PatRegister" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">

<h2>Patient Registration</h2>
<table>
<tr><td>First Name</td><td><asp:TextBox ID="TxtFirstName" runat="server"></asp:TextBox></td></tr>
<tr><td>Last Name</td><td><asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox></td></tr>
<tr><td>E-Mail ID</td><td><asp:TextBox ID="TxtEMailID" runat="server"></asp:TextBox></td></tr>
<tr><td>Mobile Number</td><td><asp:TextBox ID="TxtMobileNo" runat="server"></asp:TextBox></td></tr>
<tr><td>Password</td><td><asp:TextBox ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox></td></tr>
<tr><td colspan='2' align="center"><asp:Button ID="btnLogin" runat="server" 
        Text="Register" onclick="btnLogin_Click" /></td></tr>
</table>


</asp:Content>


