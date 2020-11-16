<%@ Page Language="C#" MasterPageFile="~/Patient_Master.master" AutoEventWireup="true" CodeFile="SymptomSubmit.aspx.cs" Inherits="SymptomSubmit" %>

<asp:Content id="Content1" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">

<h2>Symptom Information</h2>

<table width="100%">
<tr>
<td width="50%">

    <asp:GridView ID="PackList" runat="server" AllowPaging="true" 
        AutoGenerateColumns="false" DataKeyNames="RecID" 
        OnPageIndexChanging="PackList_OnPageIndexChanging" 
        OnRowEditing="PackList_RowEditing" 
        onselectedindexchanged="PackList_SelectedIndexChanged" PageSize="20" style="font-size:15px">
        <Columns>
            <asp:BoundField DataField="Symptom" HeaderText="Symptom" />
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btnmenu" 
                EditText="Select" ShowEditButton="true" />
        </Columns>
    </asp:GridView>

</td>
<td valign="top">
<h2>Registered Symptoms</h2>
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

</td>

</tr>

</table>




</asp:Content>