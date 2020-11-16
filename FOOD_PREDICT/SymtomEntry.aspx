<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="SymtomEntry.aspx.cs" Inherits="SymtomEntry" %>





<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="MainContent">

 <asp:Panel ID="PanelMaster" runat="server" Visible="true">
 <h2>Patient Entry</h2>
<br />
<asp:Button ID="btnAddPack" runat="server" Text="Add New Patient" 
         CssClass="btnmenu" onclick="btnAddPack_Click" />
<br />
<p>
    <asp:GridView ID="PackList" runat="server" AllowPaging="true" 
        AutoGenerateColumns="false" DataKeyNames="RecID" 
        OnPageIndexChanging="PackList_OnPageIndexChanging" 
        OnRowDeleting="PackList_RowDeleting" OnRowEditing="PackList_RowEditing" 
        onselectedindexchanged="PackList_SelectedIndexChanged" PageSize="5">
        <Columns>
          
            <asp:BoundField DataField="CateName" HeaderText="Category Name" />
            <asp:BoundField DataField="Symtoms" HeaderText="Symtoms Name" />
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btnmenu" 
                EditText="Edit" ShowEditButton="true" />
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btnmenu" 
                DeleteText="Delete" EditText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</p>

</asp:Panel>

<asp:Panel ID="PanelPriceTagAdd" runat="server" Visible="false">
<h3>Add New Patient</h3>
<table>
<tr><td>CategoryName</td><td><asp:DropDownList ID="Catename" runat="server"></asp:DropDownList></td></tr>
<tr><td>Symtoms</td><td><asp:TextBox ID="TxtName" runat="server"></asp:TextBox></td></tr>
<tr><td></td><td><asp:Button ID="btnInsertPack" runat="server" Text="INSERT RECORD" 
        CssClass="btnmenu" onclick="btnInsertPack_Click" /></td></tr>
</table>
<br />
    <p>
        <asp:Button ID="btnAddPackBack" runat="server" CssClass="btnmenu" Text="BACK" 
            onclick="btnAddPackBack_Click" />
    </p>

</asp:Panel>


</asp:Content>

