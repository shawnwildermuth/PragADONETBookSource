<%@ Page language="c#" Codebehind="example3.aspx.cs" AutoEventWireup="false" Inherits="BookExamples.example2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>example2</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="GridLayout">
    <form id="example2" method="post" runat="server">
      <asp:DataGrid id="theGrid" style="Z-INDEX: 101; LEFT: 23px; POSITION: absolute; TOP: 22px" runat="server" Width="619px" Height="144px" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Horizontal" ForeColor="Black">
        <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CC3333"></SelectedItemStyle>
        <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#333333"></HeaderStyle>
        <FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
        <PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="White"></PagerStyle>
      </asp:DataGrid>
    </form>
  </body>
</HTML>
