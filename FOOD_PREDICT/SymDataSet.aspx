<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="SymDataSet.aspx.cs" Inherits="SymDataSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

 <h3> Symptom Dataset Management</h3>

<table>
  <tr>
        <td>
            Upload DataSet</td>
        <td>
            <asp:FileUpload ID="StudentFile" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnUpload" runat="server" CssClass="btnmenu" 
                Text="Upload .xls DataSet" onclick="btnUpload_Click" />
        </td>
    </tr>
</table>
 <p>
 <asp:Label ID="lblmsg" runat="server"></asp:Label>
 </p>



</asp:Content>

