<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="ReviewSymDataSet.aspx.cs" Inherits="ReviewSymDataSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h3>Dataset Review</h3>

<p>
<asp:DataGrid ID="HealthDataSet" runat="server" AutoGenerateColumns="true" 
        onselectedindexchanged="HealthDataSet_SelectedIndexChanged">
</asp:DataGrid>
</p>
</asp:Content>

