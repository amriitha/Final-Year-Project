<%@ Page Language="C#" MasterPageFile="~/Patient_Master.master" AutoEventWireup="true" CodeFile="DietRecommend.aspx.cs" Inherits="DietRecommend" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">

<h2>Diet Recommendation</h2>
<table style="font-size:15px">
<tr><td>Disease</td><td><asp:DropDownList ID="CboDisease" runat="server"></asp:DropDownList></td></tr>
<tr><td>Age</td><td><asp:DropDownList id="CboAge" runat="server">
</asp:DropDownList></td></tr>
<tr><td>Sugar FP Value</td><td><asp:DropDownList id="CboFPValue" runat="server">
</asp:DropDownList></td></tr>
<tr><td>Sugar AF Value</td><td><asp:DropDownList id="CboAFValue" runat="server">
</asp:DropDownList></td></tr>

<tr><td>Hyper BP Min. Value</td><td><asp:DropDownList id="CboBPMin" runat="server">
</asp:DropDownList></td></tr>

<tr><td>Hyper BP Max. Value</td><td><asp:DropDownList id="CboBPMax" runat="server">
</asp:DropDownList></td></tr>

<tr><td colspan="2" align="center"><asp:Button ID="btnFind" runat="server" 
        Text="SUBMIT" onclick="btnFind_Click" /></td></tr>
</table>

<p>
<asp:DataGrid ID="ResultGrid" runat="server" AutoGenerateColumns="true" style="font-size:15px"></asp:DataGrid>
</p>


</asp:Content>
