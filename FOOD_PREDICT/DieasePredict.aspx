<%@ Page Language="C#" MasterPageFile="~/Patient_Master.master"  AutoEventWireup="true" CodeFile="DieasePredict.aspx.cs" Inherits="DieasePredict" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
<h2>Diease Prediction</h2>
<p>
<asp:DataList ID="RegisterList" runat="server" DataKeyField="RecID" OnDeleteCommand="RegisterList_EditCommand" 
        onselectedindexchanged="RegisterList_SelectedIndexChanged" style="font-size:15px">
<HeaderTemplate>
<table><tr><th>Symptoms</th></tr>
</HeaderTemplate>

<ItemTemplate>
<tr>
<td><%# DataBinder.Eval(Container.DataItem, "Symptom")%></td>
<td><asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" /></td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:DataList>

</p>

<p><asp:Button id="btnResult" runat="server" Text="Predict Result" 
        onclick="btnResult_Click" /></p>

<table style="font-size:15px">
<tr><td><asp:Label ID="LblResult" runat="server" Visible="false"></asp:Label></td><td><asp:Label ID="lblDisease" runat="server" Visible="false"></asp:Label></td></tr>
</table>


</asp:Content>

