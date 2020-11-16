<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DataUserRegister.aspx.cs" Inherits="DataUserRegister" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">

<h3>Data Requestor Account Registration Form</h3>
<br />
<table>
<tr><td>First Name</td><td><asp:TextBox ID="TxtFirstName" runat="server"></asp:TextBox></td></tr>
<tr><td>Last Name</td><td><asp:TextBox ID="TxtLastName" runat="server"></asp:TextBox></td></tr>
<tr><td>E-Mail ID</td><td><asp:TextBox ID="TxtEMail" runat="server"></asp:TextBox></td></tr>
<tr><td>Mobile Number</td><td><asp:TextBox ID="TxtMobileNo" runat="server"></asp:TextBox></td></tr>
<tr><td>User Type</td><td><asp:DropDownList id="CboUsertype" runat="server">
<asp:ListItem Text="Choose"></asp:ListItem>
<asp:ListItem Text="Patient"></asp:ListItem>
<asp:ListItem Text="Research Scholar"></asp:ListItem>
<asp:ListItem Text="Lab Technician"></asp:ListItem>
<asp:ListItem Text="Doctor"></asp:ListItem>
</asp:DropDownList></td></tr>
<tr><td>Login ID</td><td><asp:TextBox ID="TxtLogin1" runat="server"></asp:TextBox></td></tr>
<tr><td>Password</td><td><asp:TextBox ID="TxtPass1" TextMode="Password" runat="server"></asp:TextBox></td></tr>
<tr><td></td>
<td>
<asp:Button ID="btnRegister" runat="server" Text="Register Now" 
        onclick="btnRegister_Click" />
</td>

</tr>



</table>


</asp:Content>


