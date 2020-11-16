<%@ Page Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="OwnerAnonymity.aspx.cs" Inherits="OwnerAnonymity" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">

<asp:Panel id="PanelMaster" runat="server" Visible="true">
<h3>Data Anonymity Process</h3>
<br />
<table>
<tr>
<th><asp:Button id="btnNoiseGen" runat="server" Text="Noise-based Generation" 
        onclick="btnNoiseGen_Click" /></th>
<th><asp:Button id="BtnNoiseResult" runat="server" Text="Noise-based Result Review" 
        onclick="BtnNoiseResult_Click" /></th>

<th><asp:Button id="btnSensitive" runat="server" Text="Sensitive Anonymity" 
        onclick="btnSensitive_Click" /></th>
<th><asp:Button id="btnSensitiveResult" runat="server" 
        Text="Sensitive Result Review" onclick="btnSensitiveResult_Click" /></th>

</tr>
</table>

</asp:Panel>

<asp:Panel ID="PanelNoiseGeneration" runat="server" Visible="false">
<h3>Noise-based Generation</h3>
<br />
<table>
<tr><td>Data Owner</td><td><asp:DropDownList ID="CboDataOwner" runat="server" 
        AutoPostBack="true" onselectedindexchanged="CboDataOwner_SelectedIndexChanged"></asp:DropDownList></td></tr>
<tr><td>Noise Value</td><td><asp:TextBox ID="TxtNoiseValue" runat="server"></asp:TextBox></td></tr>
<tr><td></td><td><asp:Button ID="btnGenerate1" runat="server" Text="Generate" 
        onclick="btnGenerate1_Click" /></td></tr>
</table>

<br />
<p>
<asp:Button id="btnBack1" runat="server" Text="BACK" onclick="btnBack1_Click" />
</p>

</asp:Panel>


<asp:Panel ID="PanelNoiseResult" runat="server" Visible="false">
<h3>Noise based Sensitive Review</h3>
<br />
<p>
<asp:DataGrid ID="noise_grid" runat="server" AutoGenerateColumns="true"></asp:DataGrid>
</p>
<br />
<p>
<asp:Button ID="Back2" runat="server" Text="BACK" onclick="Back2_Click" />
</p>
</asp:Panel>


<asp:Panel ID="PanelSensitiveResult" runat="server" Visible="false">
<h3>Data Sensitive Review</h3>
<br />
<p>
<asp:DataGrid ID="SensitiveGrid" runat="server" AutoGenerateColumns="true"></asp:DataGrid>
</p>
<br />
<p>
<asp:Button ID="Button4" runat="server" Text="BACK" />
</p>
</asp:Panel>





</asp:Content>


