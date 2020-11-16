<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="UserPredict.aspx.cs" Inherits="UserPredict" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

<div class="body_txt">
  <h1>Disease Prediction</h1><br />
       			
<table>
<tr><td>Diease</td><td>
<asp:DropDownList ID="CboDiease" runat="server"></asp:DropDownList>

<%--
<asp:DropDownList ID="CboDiease" runat="server" >
<asp:ListItem Text="Choose"></asp:ListItem>
<asp:ListItem Text="Dengu"></asp:ListItem>
<asp:ListItem Text="Viral Fever"></asp:ListItem>
<asp:ListItem Text="Malaria"></asp:ListItem>
</asp:DropDownList>
--%>
</td></tr>
<tr><td></td><td>
<asp:Button ID="btnFind" runat="server" Text="Predict Record" 
        onclick="btnFind_Click" CssClass="button-style" />
</td></tr>
</table>
       			<br /><br />
       			<p>
       			<asp:DataList ID="DataPreList" runat="server" GridLines="Both">
       			<HeaderTemplate>
       			<table><tr><th>Patient ID</th><th>Patient Name</th><th>Symptom</th><th>Hospital</th><th>Gender</th><th>DOB</th><th>Address</th><th>Mobile No.</th></tr>
       			</HeaderTemplate>
       			
       			<ItemTemplate>
       			<tr>
       			<td><%#DataBinder.Eval(Container.DataItem,"PatID") %></td>
       			<td><%#DataBinder.Eval(Container.DataItem,"PatientName") %></td>
       			<td><%#DataBinder.Eval(Container.DataItem, "Symptom")%></td>
       			<td><%#DataBinder.Eval(Container.DataItem,"Age") %></td>
       			<td><%#DataBinder.Eval(Container.DataItem,"Gen") %></td>
       			<td><%#DataBinder.Eval(Container.DataItem,"DOb") %></td>
       			<td><%#DataBinder.Eval(Container.DataItem,"Address") %></td>
       			<td><%#DataBinder.Eval(Container.DataItem,"Mobile") %></td>
       			</tr>
       			</ItemTemplate>
       			
       			<FooterTemplate>
       			</table>
       			</FooterTemplate>       			
       			
       			</asp:DataList>
       			
       			</p>
  </div>


</asp:Content>

