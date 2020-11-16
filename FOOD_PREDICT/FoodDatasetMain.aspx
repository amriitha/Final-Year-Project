<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="FoodDatasetMain.aspx.cs" Inherits="FoodDatasetMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<center>
<h1>Food DataSet </h1>
<br /><br />

<table>

<tr><td><asp:Button ID="btn" runat="server"  Text="DataSet" OnClick="Dataset_Click" /></td>

<td></td>
<td><asp:Button ID="Button1" runat="server"  Text="ViewSet" OnClick="Foodset_Click" /></td>
</tr>

</table>


</center>

</asp:Content>