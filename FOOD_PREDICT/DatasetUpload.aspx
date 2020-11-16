<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User.master" CodeFile="DatasetUpload.aspx.cs" Inherits="DatasetUpload" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent"></asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">


    <h3>Dataset Management</h3>

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
