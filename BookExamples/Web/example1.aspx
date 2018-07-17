<%@ Page language="c#" Codebehind="example1.aspx.cs" AutoEventWireup="false" Inherits="BookExamples.example1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <title>Pragmatic ADO.NET Example 1</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="GridLayout">
    <form id="example1" method="post" runat="server">
      <asp:TextBox id="theTextBox" text='<%# productTable.Rows[0]["Price"] %>' style="Z-INDEX: 100; LEFT: 84px; POSITION: absolute; TOP: 23px" runat="server">
      </asp:TextBox>
      <asp:Label id="Label3" style="Z-INDEX: 105; LEFT: 17px; POSITION: absolute; TOP: 23px" runat="server">Product:</asp:Label>
    </form>
  </body>
</HTML>
