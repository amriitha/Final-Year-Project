<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
                    <h2>
                        Create a New Account
                    </h2>
                    <table>
                    
                    <tr>
                    <td>
                    <asp:Label ID="UserNameLabel" runat="server">User Name:</asp:Label>
                    </td>
                    <td>
                    <asp:TextBox ID="TxtUserName" runat="server" CssClass="textEntry"></asp:TextBox>
                    </td>
                    </tr>
                    
                    <tr>
                    <td>
                         <asp:Label ID="EmailLabel" runat="server">E-mail:</asp:Label>
                    </td>
                    <td>
                                <asp:TextBox ID="TxtEmail" runat="server" CssClass="textEntry"></asp:TextBox>
                    </td>
                    </tr>

                    <tr>
                    <td>
                                <asp:Label ID="PasswordLabel" runat="server">Password:</asp:Label>
                    </td>
                    <td>
                                <asp:TextBox ID="TxtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    </td>
                    </tr>

                    <tr>
                    <td>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server">Mobile Number:</asp:Label>
                    </td>
                    <td>
                                <asp:TextBox ID="TxtConfirmPassword" runat="server" CssClass="textEntry"></asp:TextBox>
                    </td>
                    </tr>

                    <tr>
                    <td></td>
                    <td>
                            <asp:Button ID="CreateUserButton" runat="server" Text="Create User" 
                                onclick="CreateUserButton_Click" />
                    </td>
                    </tr>


                    </table>
                    
                    
   
   </asp:Content>