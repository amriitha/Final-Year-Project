<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User.master" CodeFile="ReviewDataset.aspx.cs" Inherits="ReviewDataset" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent"></asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">

<h3>Dataset Review</h3>

<p>
<asp:DataGrid ID="HealthDataSet" runat="server" AutoGenerateColumns="true" 
        onselectedindexchanged="HealthDataSet_SelectedIndexChanged">
</asp:DataGrid>
</p>


</asp:Content>
