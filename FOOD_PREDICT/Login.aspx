<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <table>
    
    <tr>
    <td>
    <asp:Label ID="UserNameLabel" runat="server">Username:</asp:Label>
    </td>
    <td>
    <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
    <asp:Label ID="PasswordLabel" runat="server">Password:</asp:Label>
    </td>
    <td>
    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
    </td>
    </tr>
<tr>
<td></td>
<td>
<asp:Button ID="LoginButton" runat="server" Text="Log In" 
        onclick="LoginButton_Click" />
</td>
</tr>

    </table>
   
        
</asp:Content>