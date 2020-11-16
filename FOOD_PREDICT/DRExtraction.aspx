<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DRExtraction.aspx.cs" Inherits="DRExtraction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<center>

<h2> Extraction Form</h2><br /><br /><br />


<table>
<tr><td>Data Owner</td><td><asp:DropDownList ID="CboDataOwner" runat="server" 
        AutoPostBack="true" ></asp:DropDownList></td>
        <td><asp:Button ID="bntReq" Text="DataRequest" runat="server" OnClick="DataRequest_Click"  /></td>
       
         <td><asp:TextBox ID="TxtNoiseValue1" runat="server" Visible="false"></asp:TextBox></td>
        </tr>

</table>


<asp:Panel ID="PanelMaster" runat="server" Visible="false">
<h3>Extract Sensitive Data</h3>
<br />
<table>
<tr><td>Sensitive Key</td><td><asp:TextBox ID="TxtKey1" runat="server"></asp:TextBox></td></tr>
<tr><td></td><td><asp:Button ID="btnExtractKey" runat="server" Text="Extract Data" 
        onclick="btnExtractKey_Click" /></td></tr>
</table>
<br />
<p>
<asp:DataGrid ID="ResultGrid" runat="server" AutoGenerateColumns="true">
</asp:DataGrid>
</p>
<p>

<asp:DataGrid ID="DummyResult" runat="server" AutoGenerateColumns="true">
</asp:DataGrid>

</p>

</asp:Panel>

</center>
</asp:Content>

