<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="PatientEntry.aspx.cs" Inherits="PatientEntry" %>


<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="MainContent">

 <asp:Panel ID="PanelMaster" runat="server" Visible="true">
 <h2>Patient Entry</h2>
<br />
<asp:Button ID="btnAddPack" runat="server" Text="Add New Symtoms Entry" 
         CssClass="btnmenu" onclick="btnAddPack_Click" />
<br />
<p>
    <asp:GridView ID="PackList" runat="server" AllowPaging="true" 
         DataKeyNames="RecID" 
        OnPageIndexChanging="PackList_OnPageIndexChanging" 
        OnRowDeleting="PackList_RowDeleting" OnRowEditing="PackList_RowEditing" 
        onselectedindexchanged="PackList_SelectedIndexChanged" PageSize="5">
        <Columns>
          
            
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btnmenu" 
                DeleteText="Delete" EditText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</p>

</asp:Panel>

<asp:Panel ID="PanelPriceTagAdd" runat="server" Visible="false">
<h3>Add New Patient Entry</h3>
<table>
<tr>
<td>Patientname</td><td><asp:TextBox ID="txt_patname" runat="server" CssClass="input_txt2" Width="150px"></asp:TextBox></td>
</tr>

<tr>
<td>Symptom</td><td><asp:TextBox ID="TxtSymptom" runat="server" 
        TextMode="MultiLine" CssClass="input_txt2" Width="235px" Height="102px"></asp:TextBox></td>
</tr>

<tr>
<td>Age</td><td><asp:TextBox ID="txt_hosp" runat="server" CssClass="input_txt2" Width="150px"></asp:TextBox></td>
</tr>
<tr>
<td>Gender</td><td><asp:RadioButtonList ID="cbogen" runat="server" RepeatDirection="Horizontal" Width="150px">
<asp:ListItem Text="Male"></asp:ListItem>
<asp:ListItem Text="Female"></asp:ListItem>
</asp:RadioButtonList></td>
</tr>
<tr>
<td>DateofBirth</td><td><asp:TextBox ID="txt_dob" runat="server" CssClass="input_txt2" Width="150px" Text="dd-MMM-yyyy"></asp:TextBox></td>
</tr>
<tr>
<td>Address</td><td><asp:TextBox ID="txt_add" runat="server" CssClass="text_area2" TextMode="MultiLine" Width="150px" Height="40px"></asp:TextBox></td>
</tr>
<tr>
<td>City</td><td><asp:TextBox ID="txt_cty" runat="server" CssClass="input_txt2" Width="150px"></asp:TextBox></td>
</tr>
<tr>
<td>State</td><td><asp:TextBox ID="txt_state" runat="server" CssClass="input_txt2" Width="150px"></asp:TextBox></td>
</tr>
<tr>
<td>PinCode</td><td><asp:TextBox ID="txt_pin" runat="server" CssClass="input_txt2" Width="150px"></asp:TextBox></td>
</tr>
<tr>
<td>MobileNo</td><td><asp:TextBox ID="txt_mob" runat="server" CssClass="input_txt2" Width="150px"></asp:TextBox></td>
</tr>
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



