Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Text
Imports System.Reflection
Imports System.IO
Imports System.Data.SqlClient


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Form1.
  ' </summary>
  Public Class MainForm
    Inherits System.Windows.Forms.Form

    Private mainMenu1 As System.Windows.Forms.MainMenu
    Private menuItem1 As System.Windows.Forms.MenuItem '

    Private menuItem3 As System.Windows.Forms.MenuItem
    Private menuItem4 As System.Windows.Forms.MenuItem
    Private menuItem5 As System.Windows.Forms.MenuItem
    Private menuItem6 As System.Windows.Forms.MenuItem
    Private menuItem7 As System.Windows.Forms.MenuItem
    Private menuItem9 As System.Windows.Forms.MenuItem
    Private menuItem10 As System.Windows.Forms.MenuItem
    Private menuItem11 As System.Windows.Forms.MenuItem
    Private menuItem12 As System.Windows.Forms.MenuItem
    Private WithEvents theTabCtrl As System.Windows.Forms.TabControl
    Private pageGrid As System.Windows.Forms.TabPage
    Private pageOutput As System.Windows.Forms.TabPage
    Private _theGrid As System.Windows.Forms.DataGrid
    Private ch1 As New Chapter1()
    Private ch2 As New Chapter2()
    Private ch3 As New Chapter3()
    Private ch4 As New Chapter4()
    Private ch5 As New Chapter5()
    Private ch6 As New Chapter6()
    Private ch7 As New Chapter7()
    Private ch8 As New Chapter8()
    Private ch9 As New Chapter9()
    Private ch10 As New Chapter10()
    Private appendix As New appendix()
    Private menuCh5Ex1 As System.Windows.Forms.MenuItem
    Private menuItem8 As System.Windows.Forms.MenuItem
    Private menuCreateDB As System.Windows.Forms.MenuItem
    Private menuExit As System.Windows.Forms.MenuItem
    Private menuCh5Ex2 As System.Windows.Forms.MenuItem
    Private menuCh5Ex3 As System.Windows.Forms.MenuItem
    Private menuCh5Ex4 As System.Windows.Forms.MenuItem
    Private menuCh5Ex5 As System.Windows.Forms.MenuItem
    Private menuCh5Ex6 As System.Windows.Forms.MenuItem
    Private menuCh5Ex7 As System.Windows.Forms.MenuItem
    Private menuCh5Ex8 As System.Windows.Forms.MenuItem
    Private menuCh5Ex9 As System.Windows.Forms.MenuItem
    Private menuCh5Ex10 As System.Windows.Forms.MenuItem
    Private menuCh5Ex11 As System.Windows.Forms.MenuItem
    Private menuCh5Ex12 As System.Windows.Forms.MenuItem
    Private menuCh5Ex13 As System.Windows.Forms.MenuItem
    Private menuCh5Ex14 As System.Windows.Forms.MenuItem
    Private menuCh5Ex15 As System.Windows.Forms.MenuItem
    Private menuCh5Ex16 As System.Windows.Forms.MenuItem
    Private textOutput As System.Windows.Forms.TextBox
    Private menuCh5Ex17 As System.Windows.Forms.MenuItem
    Private menuItem2 As System.Windows.Forms.MenuItem
    Private menuItem13 As System.Windows.Forms.MenuItem
    Private menuCh5Ex18 As System.Windows.Forms.MenuItem
    Private menuCh5Ex19 As System.Windows.Forms.MenuItem
    Private menuCh5Ex20 As System.Windows.Forms.MenuItem
    Private menuCh6Ex1 As System.Windows.Forms.MenuItem
    Private menuCh6Ex2 As System.Windows.Forms.MenuItem
    Private menuCh7Ex1 As System.Windows.Forms.MenuItem
    Private menuCh7Ex2 As System.Windows.Forms.MenuItem
    Private menuCh7Ex3 As System.Windows.Forms.MenuItem
    Private menuCh7Ex4 As System.Windows.Forms.MenuItem
    Private menuCh7Ex5 As System.Windows.Forms.MenuItem
    Private menuCh7Ex6 As System.Windows.Forms.MenuItem
    Private menuCh7Ex7 As System.Windows.Forms.MenuItem
    Private menuCh7Ex8 As System.Windows.Forms.MenuItem
    Private menuCh7Ex9 As System.Windows.Forms.MenuItem
    Private menuCh7Ex10 As System.Windows.Forms.MenuItem
    Private menuCh7Ex11 As System.Windows.Forms.MenuItem
    Private menuCh7Ex12 As System.Windows.Forms.MenuItem
    Private menuCh7Ex13 As System.Windows.Forms.MenuItem
    Private menuCh7Ex14 As System.Windows.Forms.MenuItem
    Private menuCh7Ex15 As System.Windows.Forms.MenuItem
    Private menuCh8Ex1 As System.Windows.Forms.MenuItem
    Private menuCh8Ex2 As System.Windows.Forms.MenuItem
    Private menuCh8Ex3 As System.Windows.Forms.MenuItem
    Private menuCh8Ex4 As System.Windows.Forms.MenuItem
    Private menuCh8Ex5 As System.Windows.Forms.MenuItem
    Private menuItem14 As System.Windows.Forms.MenuItem
    Private menuCh8Ex6 As System.Windows.Forms.MenuItem
    Private menuCh8Ex7 As System.Windows.Forms.MenuItem
    Private menuCh8Ex8 As System.Windows.Forms.MenuItem
    Private menuCh8Ex9 As System.Windows.Forms.MenuItem
    Private menuCh8Ex10 As System.Windows.Forms.MenuItem
    Private menuCh8Ex11 As System.Windows.Forms.MenuItem
    Private menuCh8Ex12 As System.Windows.Forms.MenuItem
    Private menuCh1Ex2 As System.Windows.Forms.MenuItem
    Private menuCh1Ex3 As System.Windows.Forms.MenuItem
    Private menuCh1Ex4 As System.Windows.Forms.MenuItem
    Private menuCh1Ex5 As System.Windows.Forms.MenuItem
    Private menuCh1Ex6 As System.Windows.Forms.MenuItem
    Private menuCh8Ex13 As System.Windows.Forms.MenuItem
    Private menuCh9Ex1 As System.Windows.Forms.MenuItem
    Private menuCh9Ex2 As System.Windows.Forms.MenuItem
    Private menuCh9Ex3 As System.Windows.Forms.MenuItem
    Private menuCh9Ex4 As System.Windows.Forms.MenuItem
    Private menuCh9Ex5 As System.Windows.Forms.MenuItem
    Private menuCh9Ex6 As System.Windows.Forms.MenuItem
    Private menuCh9Ex7 As System.Windows.Forms.MenuItem
    Private menuCh9Ex8 As System.Windows.Forms.MenuItem
    Private menuCh9Ex9 As System.Windows.Forms.MenuItem
    Private menuCh9Ex10 As System.Windows.Forms.MenuItem
    Private menuCh9Ex11 As System.Windows.Forms.MenuItem
    Private menuCh9Ex12 As System.Windows.Forms.MenuItem
    Private menuCh9Ex13 As System.Windows.Forms.MenuItem
    Private menuCh9Ex14 As System.Windows.Forms.MenuItem
    Private menuCh9Ex15 As System.Windows.Forms.MenuItem
    Private menuCh9Ex16 As System.Windows.Forms.MenuItem
    Private menuCh10 As System.Windows.Forms.MenuItem
    Private menuCh4ExDlg As System.Windows.Forms.MenuItem
    Private menuCh5Ex21 As System.Windows.Forms.MenuItem
    Private menuCh4Ex11 As System.Windows.Forms.MenuItem
    Private menuCh5Ex22 As System.Windows.Forms.MenuItem
    Private menuCh5Ex23 As System.Windows.Forms.MenuItem
    Private menuCh5Ex24 As System.Windows.Forms.MenuItem
    Private menuCh5Ex25 As System.Windows.Forms.MenuItem
    Private menuInvoiceLister As System.Windows.Forms.MenuItem
    Private menuCh6Ex3 As System.Windows.Forms.MenuItem
    Private menuCh6Ex4 As System.Windows.Forms.MenuItem
    Private menuCh6Ex5 As System.Windows.Forms.MenuItem
    Private menuCh7Ex16 As System.Windows.Forms.MenuItem
    Private menuCh7Ex17 As System.Windows.Forms.MenuItem
    Private menuCh1Ex7 As System.Windows.Forms.MenuItem
    Private menuCh1Ex8 As System.Windows.Forms.MenuItem
    Private menuCh2Ex1 As System.Windows.Forms.MenuItem
    Private menuCh2Ex2 As System.Windows.Forms.MenuItem
    Private menuCh2Ex3 As System.Windows.Forms.MenuItem
    Private menuCh2Ex5 As System.Windows.Forms.MenuItem
    Private menuCh2Ex9 As System.Windows.Forms.MenuItem
    Private menuCh2Ex10 As System.Windows.Forms.MenuItem
    Private menuCh2Ex11 As System.Windows.Forms.MenuItem
    Private menuCh2Ex12 As System.Windows.Forms.MenuItem
    Private menuCh3Ex1 As System.Windows.Forms.MenuItem
    Private menuCh3Ex2 As System.Windows.Forms.MenuItem
    Private menuCh3Ex3 As System.Windows.Forms.MenuItem
    Private menuCh3Ex4 As System.Windows.Forms.MenuItem
    Private menuCh3Ex5 As System.Windows.Forms.MenuItem
    Private menuCh3Ex6 As System.Windows.Forms.MenuItem
    Private menuCh3Ex7 As System.Windows.Forms.MenuItem
    Private menuCh3Ex9 As System.Windows.Forms.MenuItem
    Private menuCh3Ex10 As System.Windows.Forms.MenuItem
    Private menuCh3Ex11 As System.Windows.Forms.MenuItem
    Private menuCh3Ex12 As System.Windows.Forms.MenuItem
    Private menuCh3Ex13 As System.Windows.Forms.MenuItem
    Private menuCh3Ex15 As System.Windows.Forms.MenuItem
    Private menuCh3Ex16 As System.Windows.Forms.MenuItem
    Private menuCh3Ex17 As System.Windows.Forms.MenuItem
    Private menuCh3Ex18 As System.Windows.Forms.MenuItem
    Private menuCh3Ex19 As System.Windows.Forms.MenuItem
    Private menuCh4Ex1 As System.Windows.Forms.MenuItem
    Private menuCh4Ex2 As System.Windows.Forms.MenuItem
    Private menuCh4Ex3 As System.Windows.Forms.MenuItem
    Private menuCh4Ex4 As System.Windows.Forms.MenuItem
    Private menuCh4Ex5 As System.Windows.Forms.MenuItem
    Private menuCh4Ex6 As System.Windows.Forms.MenuItem
    Private menuCh4Ex10 As System.Windows.Forms.MenuItem
    Private menuCh4Ex12 As System.Windows.Forms.MenuItem

    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.Container = Nothing

    Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()

      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
    End Sub 'New

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
    Shared Sub Main()
      Application.Run(New MainForm())
    End Sub 'Main


    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub 'MainForm_Load


    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub 'Dispose


    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
      Me.mainMenu1 = New System.Windows.Forms.MainMenu()
      Me.menuItem1 = New System.Windows.Forms.MenuItem()
      Me.menuCreateDB = New System.Windows.Forms.MenuItem()
      Me.menuItem8 = New System.Windows.Forms.MenuItem()
      Me.menuExit = New System.Windows.Forms.MenuItem()
      Me.menuItem3 = New System.Windows.Forms.MenuItem()
      Me.menuCh1Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh1Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh1Ex4 = New System.Windows.Forms.MenuItem()
      Me.menuCh1Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuCh1Ex6 = New System.Windows.Forms.MenuItem()
      Me.menuCh1Ex7 = New System.Windows.Forms.MenuItem()
      Me.menuCh1Ex8 = New System.Windows.Forms.MenuItem()
      Me.menuItem4 = New System.Windows.Forms.MenuItem()
      Me.menuCh2Ex1 = New System.Windows.Forms.MenuItem()
      Me.menuCh2Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh2Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh2Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuCh2Ex9 = New System.Windows.Forms.MenuItem()
      Me.menuCh2Ex10 = New System.Windows.Forms.MenuItem()
      Me.menuCh2Ex11 = New System.Windows.Forms.MenuItem()
      Me.menuCh2Ex12 = New System.Windows.Forms.MenuItem()
      Me.menuItem5 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex1 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex4 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex6 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex7 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex9 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex10 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex11 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex12 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex13 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex15 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex16 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex17 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex18 = New System.Windows.Forms.MenuItem()
      Me.menuCh3Ex19 = New System.Windows.Forms.MenuItem()
      Me.menuItem6 = New System.Windows.Forms.MenuItem()
      Me.menuCh4Ex1 = New System.Windows.Forms.MenuItem()
      Me.menuCh4Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh4Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh4ExDlg = New System.Windows.Forms.MenuItem()
      Me.menuCh4Ex11 = New System.Windows.Forms.MenuItem()
      Me.menuItem7 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex1 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex4 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex6 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex7 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex8 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex9 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex10 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex11 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex12 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex13 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex14 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex15 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex16 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex17 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex18 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex19 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex20 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex21 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex22 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex23 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex24 = New System.Windows.Forms.MenuItem()
      Me.menuCh5Ex25 = New System.Windows.Forms.MenuItem()
      Me.menuInvoiceLister = New System.Windows.Forms.MenuItem()
      Me.menuItem9 = New System.Windows.Forms.MenuItem()
      Me.menuCh6Ex1 = New System.Windows.Forms.MenuItem()
      Me.menuCh6Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh6Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh6Ex4 = New System.Windows.Forms.MenuItem()
      Me.menuCh6Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuItem10 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex1 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex4 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex6 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex7 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex8 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex9 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex10 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex11 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex12 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex13 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex14 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex15 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex16 = New System.Windows.Forms.MenuItem()
      Me.menuCh7Ex17 = New System.Windows.Forms.MenuItem()
      Me.menuItem11 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex1 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex4 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex6 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex7 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex8 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex9 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex10 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex11 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex12 = New System.Windows.Forms.MenuItem()
      Me.menuCh8Ex13 = New System.Windows.Forms.MenuItem()
      Me.menuItem2 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex1 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex2 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex3 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex4 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex6 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex7 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex8 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex9 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex10 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex11 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex12 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex13 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex14 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex15 = New System.Windows.Forms.MenuItem()
      Me.menuCh9Ex16 = New System.Windows.Forms.MenuItem()
      Me.menuItem13 = New System.Windows.Forms.MenuItem()
      Me.menuCh10 = New System.Windows.Forms.MenuItem()
      Me.menuItem14 = New System.Windows.Forms.MenuItem()
      Me.menuItem12 = New System.Windows.Forms.MenuItem()
      Me.theTabCtrl = New System.Windows.Forms.TabControl()
      Me.pageOutput = New System.Windows.Forms.TabPage()
      Me.textOutput = New System.Windows.Forms.TextBox()
      Me.pageGrid = New System.Windows.Forms.TabPage()
      Me._theGrid = New System.Windows.Forms.DataGrid()
      Me.menuCh4Ex4 = New System.Windows.Forms.MenuItem()
      Me.menuCh4Ex5 = New System.Windows.Forms.MenuItem()
      Me.menuCh4Ex6 = New System.Windows.Forms.MenuItem()
      Me.menuCh4Ex10 = New System.Windows.Forms.MenuItem()
      Me.menuCh4Ex12 = New System.Windows.Forms.MenuItem()
      Me.theTabCtrl.SuspendLayout()
      Me.pageOutput.SuspendLayout()
      Me.pageGrid.SuspendLayout()
      CType(Me.theGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      MyBase.SuspendLayout()
      ' 
      ' mainMenu1
      ' 
      Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem1, Me.menuItem3, Me.menuItem4, Me.menuItem5, Me.menuItem6, Me.menuItem7, Me.menuItem9, Me.menuItem10, Me.menuItem11, Me.menuItem2, Me.menuItem13, Me.menuItem14, Me.menuItem12})
      ' 
      ' menuItem1
      ' 
      Me.menuItem1.Index = 0
      Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCreateDB, Me.menuItem8, Me.menuExit})
      Me.menuItem1.Text = "&File"
      ' 
      ' menuCreateDB
      ' 
      Me.menuCreateDB.Index = 0
      Me.menuCreateDB.Text = "&Create Database"
      ' 
      ' menuItem8
      ' 
      Me.menuItem8.Index = 1
      Me.menuItem8.Text = "-"
      ' 
      ' menuExit
      ' 
      Me.menuExit.Index = 2
      Me.menuExit.Text = "E&xit"
      ' 
      ' menuItem3
      ' 
      Me.menuItem3.Index = 1
      Me.menuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh1Ex2, Me.menuCh1Ex3, Me.menuCh1Ex4, Me.menuCh1Ex5, Me.menuCh1Ex6, Me.menuCh1Ex7, Me.menuCh1Ex8})
      Me.menuItem3.Text = "Ch &1"
      ' 
      ' menuCh1Ex2
      ' 
      Me.menuCh1Ex2.Index = 0
      Me.menuCh1Ex2.Text = "Listing 1.2"
      ' 
      ' menuCh1Ex3
      ' 
      Me.menuCh1Ex3.Index = 1
      Me.menuCh1Ex3.Text = "Listing 1.3"
      ' 
      ' menuCh1Ex4
      ' 
      Me.menuCh1Ex4.Index = 2
      Me.menuCh1Ex4.Text = "Listing 1.4"
      ' 
      ' menuCh1Ex5
      ' 
      Me.menuCh1Ex5.Index = 3
      Me.menuCh1Ex5.Text = "Listing 1.5"
      ' 
      ' menuCh1Ex6
      ' 
      Me.menuCh1Ex6.Index = 4
      Me.menuCh1Ex6.Text = "Listing 1.6"
      ' 
      ' menuCh1Ex7
      ' 
      Me.menuCh1Ex7.Index = 5
      Me.menuCh1Ex7.Text = "Listing 1.7"
      ' 
      ' menuCh1Ex8
      ' 
      Me.menuCh1Ex8.Index = 6
      Me.menuCh1Ex8.Text = "Listing 1.8"
      ' 
      ' menuItem4
      ' 
      Me.menuItem4.Index = 2
      Me.menuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh2Ex1, Me.menuCh2Ex2, Me.menuCh2Ex3, Me.menuCh2Ex5, Me.menuCh2Ex9, Me.menuCh2Ex10, Me.menuCh2Ex11, Me.menuCh2Ex12})
      Me.menuItem4.Text = "Ch &2"
      ' 
      ' menuCh2Ex1
      ' 
      Me.menuCh2Ex1.Index = 0
      Me.menuCh2Ex1.Text = "Listing 2.1"
      ' 
      ' menuCh2Ex2
      ' 
      Me.menuCh2Ex2.Index = 1
      Me.menuCh2Ex2.Text = "Listing 2.2"
      ' 
      ' menuCh2Ex3
      ' 
      Me.menuCh2Ex3.Index = 2
      Me.menuCh2Ex3.Text = "Listing 2.3"
      ' 
      ' menuCh2Ex5
      ' 
      Me.menuCh2Ex5.Index = 3
      Me.menuCh2Ex5.Text = "Listing 2.5"
      ' 
      ' menuCh2Ex9
      ' 
      Me.menuCh2Ex9.Index = 4
      Me.menuCh2Ex9.Text = "Listing 2.9"
      ' 
      ' menuCh2Ex10
      ' 
      Me.menuCh2Ex10.Index = 5
      Me.menuCh2Ex10.Text = "Listing 2.10"
      ' 
      ' menuCh2Ex11
      ' 
      Me.menuCh2Ex11.Index = 6
      Me.menuCh2Ex11.Text = "Listing 2.11"
      ' 
      ' menuCh2Ex12
      ' 
      Me.menuCh2Ex12.Index = 7
      Me.menuCh2Ex12.Text = "Listing 2.12"
      ' 
      ' menuItem5
      ' 
      Me.menuItem5.Index = 3
      Me.menuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh3Ex1, Me.menuCh3Ex2, Me.menuCh3Ex3, Me.menuCh3Ex4, Me.menuCh3Ex5, Me.menuCh3Ex6, Me.menuCh3Ex7, Me.menuCh3Ex9, Me.menuCh3Ex10, Me.menuCh3Ex11, Me.menuCh3Ex12, Me.menuCh3Ex13, Me.menuCh3Ex15, Me.menuCh3Ex16, Me.menuCh3Ex17, Me.menuCh3Ex18, Me.menuCh3Ex19})
      Me.menuItem5.Text = "Ch &3"
      ' 
      ' menuCh3Ex1
      ' 
      Me.menuCh3Ex1.Index = 0
      Me.menuCh3Ex1.Text = "Listing 3.1"
      ' 
      ' menuCh3Ex2
      ' 
      Me.menuCh3Ex2.Index = 1
      Me.menuCh3Ex2.Text = "Listing 3.2"
      ' 
      ' menuCh3Ex3
      ' 
      Me.menuCh3Ex3.Index = 2
      Me.menuCh3Ex3.Text = "Listing 3.3"
      ' 
      ' menuCh3Ex4
      ' 
      Me.menuCh3Ex4.Index = 3
      Me.menuCh3Ex4.Text = "Listing 3.4"
      ' 
      ' menuCh3Ex5
      ' 
      Me.menuCh3Ex5.Index = 4
      Me.menuCh3Ex5.Text = "Listing 3.5"
      ' 
      ' menuCh3Ex6
      ' 
      Me.menuCh3Ex6.Index = 5
      Me.menuCh3Ex6.Text = "Listing 3.6"
      ' 
      ' menuCh3Ex7
      ' 
      Me.menuCh3Ex7.Index = 6
      Me.menuCh3Ex7.Text = "Listing 3.7"
      ' 
      ' menuCh3Ex9
      ' 
      Me.menuCh3Ex9.Index = 7
      Me.menuCh3Ex9.Text = "Listing 3.9"
      ' 
      ' menuCh3Ex10
      ' 
      Me.menuCh3Ex10.Index = 8
      Me.menuCh3Ex10.Text = "Listing 3.10"
      ' 
      ' menuCh3Ex11
      ' 
      Me.menuCh3Ex11.Index = 9
      Me.menuCh3Ex11.Text = "Listing 3.11"
      ' 
      ' menuCh3Ex12
      ' 
      Me.menuCh3Ex12.Index = 10
      Me.menuCh3Ex12.Text = "Listing 3.12"
      ' 
      ' menuCh3Ex13
      ' 
      Me.menuCh3Ex13.Index = 11
      Me.menuCh3Ex13.Text = "Listing 3.13"
      ' 
      ' menuCh3Ex15
      ' 
      Me.menuCh3Ex15.Index = 12
      Me.menuCh3Ex15.Text = "Listing 3.15"
      ' 
      ' menuCh3Ex16
      ' 
      Me.menuCh3Ex16.Index = 13
      Me.menuCh3Ex16.Text = "Listing 3.16"
      ' 
      ' menuCh3Ex17
      ' 
      Me.menuCh3Ex17.Index = 14
      Me.menuCh3Ex17.Text = "Listing 3.17"
      ' 
      ' menuCh3Ex18
      ' 
      Me.menuCh3Ex18.Index = 15
      Me.menuCh3Ex18.Text = "Listing 3.18"
      ' 
      ' menuCh3Ex19
      ' 
      Me.menuCh3Ex19.Index = 16
      Me.menuCh3Ex19.Text = "Listing 3.19"
      ' 
      ' menuItem6
      ' 
      Me.menuItem6.Index = 4
      Me.menuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh4Ex1, Me.menuCh4Ex2, Me.menuCh4Ex3, Me.menuCh4Ex4, Me.menuCh4Ex5, Me.menuCh4Ex6, Me.menuCh4Ex10, Me.menuCh4Ex11, Me.menuCh4Ex12, Me.menuCh4ExDlg})
      Me.menuItem6.Text = "Ch &4"
      ' 
      ' menuCh4Ex1
      ' 
      Me.menuCh4Ex1.Index = 0
      Me.menuCh4Ex1.Text = "Listing 4.1"
      ' 
      ' menuCh4Ex2
      ' 
      Me.menuCh4Ex2.Index = 1
      Me.menuCh4Ex2.Text = "Listing 4.2"
      ' 
      ' menuCh4Ex3
      ' 
      Me.menuCh4Ex3.Index = 2
      Me.menuCh4Ex3.Text = "Listing 4.3"
      ' 
      ' menuCh4ExDlg
      ' 
      Me.menuCh4ExDlg.Index = 9
      Me.menuCh4ExDlg.Text = "Example Dialog"
      ' 
      ' menuCh4Ex11
      ' 
      Me.menuCh4Ex11.Index = 7
      Me.menuCh4Ex11.Text = "Listing 4.11"
      ' 
      ' menuItem7
      ' 
      Me.menuItem7.Index = 5
      Me.menuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh5Ex1, Me.menuCh5Ex2, Me.menuCh5Ex3, Me.menuCh5Ex4, Me.menuCh5Ex5, Me.menuCh5Ex6, Me.menuCh5Ex7, Me.menuCh5Ex8, Me.menuCh5Ex9, Me.menuCh5Ex10, Me.menuCh5Ex11, Me.menuCh5Ex12, Me.menuCh5Ex13, Me.menuCh5Ex14, Me.menuCh5Ex15, Me.menuCh5Ex16, Me.menuCh5Ex17, Me.menuCh5Ex18, Me.menuCh5Ex19, Me.menuCh5Ex20, Me.menuCh5Ex21, Me.menuCh5Ex22, Me.menuCh5Ex23, Me.menuCh5Ex24, Me.menuCh5Ex25, Me.menuInvoiceLister})
      Me.menuItem7.Text = "Ch &5"
      ' 
      ' menuCh5Ex1
      ' 
      Me.menuCh5Ex1.Index = 0
      Me.menuCh5Ex1.Text = "Example 1"
      ' 
      ' menuCh5Ex2
      ' 
      Me.menuCh5Ex2.Index = 1
      Me.menuCh5Ex2.Text = "Example 2"
      ' 
      ' menuCh5Ex3
      ' 
      Me.menuCh5Ex3.Index = 2
      Me.menuCh5Ex3.Text = "Example 3"
      ' 
      ' menuCh5Ex4
      ' 
      Me.menuCh5Ex4.Index = 3
      Me.menuCh5Ex4.Text = "Example 4"
      ' 
      ' menuCh5Ex5
      ' 
      Me.menuCh5Ex5.Index = 4
      Me.menuCh5Ex5.Text = "Example 5"
      ' 
      ' menuCh5Ex6
      ' 
      Me.menuCh5Ex6.Index = 5
      Me.menuCh5Ex6.Text = "Example 6"
      ' 
      ' menuCh5Ex7
      ' 
      Me.menuCh5Ex7.Index = 6
      Me.menuCh5Ex7.Text = "Example 7"
      ' 
      ' menuCh5Ex8
      ' 
      Me.menuCh5Ex8.Index = 7
      Me.menuCh5Ex8.Text = "Example 8"
      ' 
      ' menuCh5Ex9
      ' 
      Me.menuCh5Ex9.Index = 8
      Me.menuCh5Ex9.Text = "Example 9"
      ' 
      ' menuCh5Ex10
      ' 
      Me.menuCh5Ex10.Index = 9
      Me.menuCh5Ex10.Text = "Example 10"
      ' 
      ' menuCh5Ex11
      ' 
      Me.menuCh5Ex11.Index = 10
      Me.menuCh5Ex11.Text = "Example 11"
      ' 
      ' menuCh5Ex12
      ' 
      Me.menuCh5Ex12.Index = 11
      Me.menuCh5Ex12.Text = "Example 12"
      ' 
      ' menuCh5Ex13
      ' 
      Me.menuCh5Ex13.Index = 12
      Me.menuCh5Ex13.Text = "Example 13"
      ' 
      ' menuCh5Ex14
      ' 
      Me.menuCh5Ex14.Index = 13
      Me.menuCh5Ex14.Text = "Example 14"
      ' 
      ' menuCh5Ex15
      ' 
      Me.menuCh5Ex15.Index = 14
      Me.menuCh5Ex15.Text = "Example 15"
      ' 
      ' menuCh5Ex16
      ' 
      Me.menuCh5Ex16.Index = 15
      Me.menuCh5Ex16.Text = "Example 16"
      ' 
      ' menuCh5Ex17
      ' 
      Me.menuCh5Ex17.Index = 16
      Me.menuCh5Ex17.Text = "Example 17"
      ' 
      ' menuCh5Ex18
      ' 
      Me.menuCh5Ex18.Index = 17
      Me.menuCh5Ex18.Text = "Example 18"
      ' 
      ' menuCh5Ex19
      ' 
      Me.menuCh5Ex19.Index = 18
      Me.menuCh5Ex19.Text = "Example 19"
      ' 
      ' menuCh5Ex20
      ' 
      Me.menuCh5Ex20.Index = 19
      Me.menuCh5Ex20.Text = "Example 20"
      ' 
      ' menuCh5Ex21
      ' 
      Me.menuCh5Ex21.Index = 20
      Me.menuCh5Ex21.Text = "Example 21"
      ' 
      ' menuCh5Ex22
      ' 
      Me.menuCh5Ex22.Index = 21
      Me.menuCh5Ex22.Text = "Example 22"
      ' 
      ' menuCh5Ex23
      ' 
      Me.menuCh5Ex23.Index = 22
      Me.menuCh5Ex23.Text = "Example 23"
      ' 
      ' menuCh5Ex24
      ' 
      Me.menuCh5Ex24.Index = 23
      Me.menuCh5Ex24.Text = "Example 24"
      ' 
      ' menuCh5Ex25
      ' 
      Me.menuCh5Ex25.Index = 24
      Me.menuCh5Ex25.Text = "Example 25"
      ' 
      ' menuInvoiceLister
      ' 
      Me.menuInvoiceLister.Index = 25
      Me.menuInvoiceLister.Text = "Invoice Lister"
      ' 
      ' menuItem9
      ' 
      Me.menuItem9.Index = 6
      Me.menuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh6Ex1, Me.menuCh6Ex2, Me.menuCh6Ex3, Me.menuCh6Ex4, Me.menuCh6Ex5})
      Me.menuItem9.Text = "Ch &6"
      ' 
      ' menuCh6Ex1
      ' 
      Me.menuCh6Ex1.Index = 0
      Me.menuCh6Ex1.Text = "Example 1"
      ' 
      ' menuCh6Ex2
      ' 
      Me.menuCh6Ex2.Index = 1
      Me.menuCh6Ex2.Text = "Example 2"
      ' 
      ' menuCh6Ex3
      ' 
      Me.menuCh6Ex3.Index = 2
      Me.menuCh6Ex3.Text = "Example 3"
      ' 
      ' menuCh6Ex4
      ' 
      Me.menuCh6Ex4.Index = 3
      Me.menuCh6Ex4.Text = "Example 4"
      ' 
      ' menuCh6Ex5
      ' 
      Me.menuCh6Ex5.Index = 4
      Me.menuCh6Ex5.Text = "Example 5"
      ' 
      ' menuItem10
      ' 
      Me.menuItem10.Index = 7
      Me.menuItem10.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh7Ex1, Me.menuCh7Ex2, Me.menuCh7Ex3, Me.menuCh7Ex4, Me.menuCh7Ex5, Me.menuCh7Ex6, Me.menuCh7Ex7, Me.menuCh7Ex8, Me.menuCh7Ex9, Me.menuCh7Ex10, Me.menuCh7Ex11, Me.menuCh7Ex12, Me.menuCh7Ex13, Me.menuCh7Ex14, Me.menuCh7Ex15, Me.menuCh7Ex16, Me.menuCh7Ex17})
      Me.menuItem10.Text = "Ch &7"
      ' 
      ' menuCh7Ex1
      ' 
      Me.menuCh7Ex1.Index = 0
      Me.menuCh7Ex1.Text = "Example 1"
      ' 
      ' menuCh7Ex2
      ' 
      Me.menuCh7Ex2.Index = 1
      Me.menuCh7Ex2.Text = "Example 2"
      ' 
      ' menuCh7Ex3
      ' 
      Me.menuCh7Ex3.Index = 2
      Me.menuCh7Ex3.Text = "Example 3"
      ' 
      ' menuCh7Ex4
      ' 
      Me.menuCh7Ex4.Index = 3
      Me.menuCh7Ex4.Text = "Example 4"
      ' 
      ' menuCh7Ex5
      ' 
      Me.menuCh7Ex5.Index = 4
      Me.menuCh7Ex5.Text = "Example 5"
      ' 
      ' menuCh7Ex6
      ' 
      Me.menuCh7Ex6.Index = 5
      Me.menuCh7Ex6.Text = "Example 6"
      ' 
      ' menuCh7Ex7
      ' 
      Me.menuCh7Ex7.Index = 6
      Me.menuCh7Ex7.Text = "Example 7"
      ' 
      ' menuCh7Ex8
      ' 
      Me.menuCh7Ex8.Index = 7
      Me.menuCh7Ex8.Text = "Example 8"
      ' 
      ' menuCh7Ex9
      ' 
      Me.menuCh7Ex9.Index = 8
      Me.menuCh7Ex9.Text = "Example 9"
      ' 
      ' menuCh7Ex10
      ' 
      Me.menuCh7Ex10.Index = 9
      Me.menuCh7Ex10.Text = "Example 10"
      ' 
      ' menuCh7Ex11
      ' 
      Me.menuCh7Ex11.Index = 10
      Me.menuCh7Ex11.Text = "Example 11"
      ' 
      ' menuCh7Ex12
      ' 
      Me.menuCh7Ex12.Index = 11
      Me.menuCh7Ex12.Text = "Example 12"
      ' 
      ' menuCh7Ex13
      ' 
      Me.menuCh7Ex13.Index = 12
      Me.menuCh7Ex13.Text = "Example 13"
      ' 
      ' menuCh7Ex14
      ' 
      Me.menuCh7Ex14.Index = 13
      Me.menuCh7Ex14.Text = "Example 14"
      ' 
      ' menuCh7Ex15
      ' 
      Me.menuCh7Ex15.Index = 14
      Me.menuCh7Ex15.Text = "Example 15"
      ' 
      ' menuCh7Ex16
      ' 
      Me.menuCh7Ex16.Index = 15
      Me.menuCh7Ex16.Text = "Example 16"
      ' 
      ' menuCh7Ex17
      ' 
      Me.menuCh7Ex17.Index = 16
      Me.menuCh7Ex17.Text = "Example 17"
      ' 
      ' menuItem11
      ' 
      Me.menuItem11.Index = 8
      Me.menuItem11.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh8Ex1, Me.menuCh8Ex2, Me.menuCh8Ex3, Me.menuCh8Ex4, Me.menuCh8Ex5, Me.menuCh8Ex6, Me.menuCh8Ex7, Me.menuCh8Ex8, Me.menuCh8Ex9, Me.menuCh8Ex10, Me.menuCh8Ex11, Me.menuCh8Ex12, Me.menuCh8Ex13})
      Me.menuItem11.Text = "Ch &8"
      ' 
      ' menuCh8Ex1
      ' 
      Me.menuCh8Ex1.Index = 0
      Me.menuCh8Ex1.Text = "Example 1"
      ' 
      ' menuCh8Ex2
      ' 
      Me.menuCh8Ex2.Index = 1
      Me.menuCh8Ex2.Text = "Example 2"
      ' 
      ' menuCh8Ex3
      ' 
      Me.menuCh8Ex3.Index = 2
      Me.menuCh8Ex3.Text = "Example 3"
      ' 
      ' menuCh8Ex4
      ' 
      Me.menuCh8Ex4.Index = 3
      Me.menuCh8Ex4.Text = "Example 4"
      ' 
      ' menuCh8Ex5
      ' 
      Me.menuCh8Ex5.Index = 4
      Me.menuCh8Ex5.Text = "Example 5"
      ' 
      ' menuCh8Ex6
      ' 
      Me.menuCh8Ex6.Index = 5
      Me.menuCh8Ex6.Text = "Example 6"
      ' 
      ' menuCh8Ex7
      ' 
      Me.menuCh8Ex7.Index = 6
      Me.menuCh8Ex7.Text = "Example 7"
      ' 
      ' menuCh8Ex8
      ' 
      Me.menuCh8Ex8.Index = 7
      Me.menuCh8Ex8.Text = "Example 8"
      ' 
      ' menuCh8Ex9
      ' 
      Me.menuCh8Ex9.Index = 8
      Me.menuCh8Ex9.Text = "Example 9"
      ' 
      ' menuCh8Ex10
      ' 
      Me.menuCh8Ex10.Index = 9
      Me.menuCh8Ex10.Text = "Example 10"
      ' 
      ' menuCh8Ex11
      ' 
      Me.menuCh8Ex11.Index = 10
      Me.menuCh8Ex11.Text = "Example 11"
      ' 
      ' menuCh8Ex12
      ' 
      Me.menuCh8Ex12.Index = 11
      Me.menuCh8Ex12.Text = "Example 12"
      ' 
      ' menuCh8Ex13
      ' 
      Me.menuCh8Ex13.Index = 12
      Me.menuCh8Ex13.Text = "Example 13"
      ' 
      ' menuItem2
      ' 
      Me.menuItem2.Index = 9
      Me.menuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh9Ex1, Me.menuCh9Ex2, Me.menuCh9Ex3, Me.menuCh9Ex4, Me.menuCh9Ex5, Me.menuCh9Ex6, Me.menuCh9Ex7, Me.menuCh9Ex8, Me.menuCh9Ex9, Me.menuCh9Ex10, Me.menuCh9Ex11, Me.menuCh9Ex12, Me.menuCh9Ex13, Me.menuCh9Ex14, Me.menuCh9Ex15, Me.menuCh9Ex16})
      Me.menuItem2.Text = "Ch &9"
      ' 
      ' menuCh9Ex1
      ' 
      Me.menuCh9Ex1.Index = 0
      Me.menuCh9Ex1.Text = "Example 1"
      ' 
      ' menuCh9Ex2
      ' 
      Me.menuCh9Ex2.Index = 1
      Me.menuCh9Ex2.Text = "Example 2"
      ' 
      ' menuCh9Ex3
      ' 
      Me.menuCh9Ex3.Index = 2
      Me.menuCh9Ex3.Text = "Example 3"
      ' 
      ' menuCh9Ex4
      ' 
      Me.menuCh9Ex4.Index = 3
      Me.menuCh9Ex4.Text = "Example 4"
      ' 
      ' menuCh9Ex5
      ' 
      Me.menuCh9Ex5.Index = 4
      Me.menuCh9Ex5.Text = "Example 5"
      ' 
      ' menuCh9Ex6
      ' 
      Me.menuCh9Ex6.Index = 5
      Me.menuCh9Ex6.Text = "Example 6"
      ' 
      ' menuCh9Ex7
      ' 
      Me.menuCh9Ex7.Index = 6
      Me.menuCh9Ex7.Text = "Example 7"
      ' 
      ' menuCh9Ex8
      ' 
      Me.menuCh9Ex8.Index = 7
      Me.menuCh9Ex8.Text = "Example 8"
      ' 
      ' menuCh9Ex9
      ' 
      Me.menuCh9Ex9.Index = 8
      Me.menuCh9Ex9.Text = "Example 9"
      ' 
      ' menuCh9Ex10
      ' 
      Me.menuCh9Ex10.Index = 9
      Me.menuCh9Ex10.Text = "Example 10"
      ' 
      ' menuCh9Ex11
      ' 
      Me.menuCh9Ex11.Index = 10
      Me.menuCh9Ex11.Text = "Example 11"
      ' 
      ' menuCh9Ex12
      ' 
      Me.menuCh9Ex12.Index = 11
      Me.menuCh9Ex12.Text = "Example 12"
      ' 
      ' menuCh9Ex13
      ' 
      Me.menuCh9Ex13.Index = 12
      Me.menuCh9Ex13.Text = "Example 13"
      ' 
      ' menuCh9Ex14
      ' 
      Me.menuCh9Ex14.Index = 13
      Me.menuCh9Ex14.Text = "Example 14"
      ' 
      ' menuCh9Ex15
      ' 
      Me.menuCh9Ex15.Index = 14
      Me.menuCh9Ex15.Text = "Example 15"
      ' 
      ' menuCh9Ex16
      ' 
      Me.menuCh9Ex16.Index = 15
      Me.menuCh9Ex16.Text = "Example 16"
      ' 
      ' menuItem13
      ' 
      Me.menuItem13.Index = 10
      Me.menuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCh10})
      Me.menuItem13.Text = "Ch 1&0"
      ' 
      ' menuCh10
      ' 
      Me.menuCh10.Index = 0
      Me.menuCh10.Text = "DataBinding Form"
      ' 
      ' menuItem14
      ' 
      Me.menuItem14.Index = 11
      Me.menuItem14.Text = "C&h 11"
      ' 
      ' menuItem12
      ' 
      Me.menuItem12.Index = 12
      Me.menuItem12.Text = "&Appendix"
      ' 
      ' theTabCtrl
      ' 
      Me.theTabCtrl.Controls.AddRange(New System.Windows.Forms.Control() {Me.pageOutput, Me.pageGrid})
      Me.theTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill
      Me.theTabCtrl.Name = "theTabCtrl"
      Me.theTabCtrl.SelectedIndex = 0
      Me.theTabCtrl.Size = New System.Drawing.Size(664, 254)
      Me.theTabCtrl.TabIndex = 0
      ' 
      ' pageOutput
      ' 
      Me.pageOutput.Controls.AddRange(New System.Windows.Forms.Control() {Me.textOutput})
      Me.pageOutput.Location = New System.Drawing.Point(4, 22)
      Me.pageOutput.Name = "pageOutput"
      Me.pageOutput.Size = New System.Drawing.Size(656, 228)
      Me.pageOutput.TabIndex = 1
      Me.pageOutput.Text = "Output"
      ' 
      ' textOutput
      ' 
      Me.textOutput.AcceptsReturn = True
      Me.textOutput.Dock = System.Windows.Forms.DockStyle.Fill
      Me.textOutput.Font = New System.Drawing.Font("Lucida Console", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
      Me.textOutput.Multiline = True
      Me.textOutput.Name = "textOutput"
      Me.textOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.textOutput.Size = New System.Drawing.Size(656, 228)
      Me.textOutput.TabIndex = 0
      Me.textOutput.Text = ""
      ' 
      ' pageGrid
      ' 
      Me.pageGrid.Controls.AddRange(New System.Windows.Forms.Control() {Me.theGrid})
      Me.pageGrid.Location = New System.Drawing.Point(4, 22)
      Me.pageGrid.Name = "pageGrid"
      Me.pageGrid.Size = New System.Drawing.Size(656, 228)
      Me.pageGrid.TabIndex = 0
      Me.pageGrid.Text = "DataGrid"
      ' 
      ' theGrid
      ' 
      Me.theGrid.DataMember = ""
      Me.theGrid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.theGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.theGrid.Name = "theGrid"
      Me.theGrid.Size = New System.Drawing.Size(656, 228)
      Me.theGrid.TabIndex = 0
      ' 
      ' menuCh4Ex4
      ' 
      Me.menuCh4Ex4.Index = 3
      Me.menuCh4Ex4.Text = "Listing 4.4"
      ' 
      ' menuCh4Ex5
      ' 
      Me.menuCh4Ex5.Index = 4
      Me.menuCh4Ex5.Text = "Listing 4.5"
      ' 
      ' menuCh4Ex6
      ' 
      Me.menuCh4Ex6.Index = 5
      Me.menuCh4Ex6.Text = "Listing 4.6"
      ' 
      ' menuCh4Ex10
      ' 
      Me.menuCh4Ex10.Index = 6
      Me.menuCh4Ex10.Text = "Listing 4.10"
      ' 
      ' menuCh4Ex12
      ' 
      Me.menuCh4Ex12.Index = 8
      Me.menuCh4Ex12.Text = "Listing 4.12"
      ' 
      ' MainForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(664, 254)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.theTabCtrl})
      Me.Menu = Me.mainMenu1
      MyBase.Name = "MainForm"
      MyBase.Text = "Pragmatic ADO.NET Examples"
      MyBase.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.theTabCtrl.ResumeLayout(False)
      Me.pageOutput.ResumeLayout(False)
      Me.pageGrid.ResumeLayout(False)
      CType(Me.theGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
    End Sub 'InitializeComponent

    ' <summary>
    ' Mimics the System.Console class's output
    ' </summary>
    ' <param name="s">Format String</param>
    ' <param name="arg">Arguments</param>
    Public Overloads Sub WriteLine(ByVal s As String, ByVal ParamArray arg() As Object)
      Dim bldr As New StringBuilder()
      bldr.AppendFormat(s, arg)
      WriteLine(bldr.ToString())
    End Sub 'WriteLine


    ' <summary>
    ' Mimics the System.Console class's output
    ' </summary>
    ' <param name="s">Text to write</param>
    Public Overloads Sub WriteLine(ByVal s As String)
      Write((s + ControlChars.Cr + ControlChars.Lf))
    End Sub 'WriteLine


    ' <summary>
    ' Mimics the System.Console class's output
    ' </summary>
    ' <param name="s">Text to write</param>
    Public Overloads Sub WriteLine(ByVal o As Object)
      Write((o.ToString() + ControlChars.Cr + ControlChars.Lf))
    End Sub 'WriteLine


    ' <summary>
    ' Mimics the System.Console.Write function
    ' </summary>
    ' <param name="s">String to output</param>
    Public Overloads Sub Write(ByVal s As String)
      textOutput.Text += s
      theTabCtrl.SelectedTab = pageOutput
    End Sub 'Write


    ' <summary>
    ' Mimics the System.Console.Write function
    ' </summary>
    ' <param name="s">String to output</param>
    Public Overloads Sub Write(ByVal o As Object)
      textOutput.Text += o.ToString()
      theTabCtrl.SelectedTab = pageOutput
    End Sub 'Write

    ' <summary>
    ' Gives access to the grid without allowing 
    ' code to set the grid.
    ' </summary>

    Public ReadOnly Property TheGrid() As DataGrid
      Get
        theTabCtrl.SelectedTab = pageGrid
        Return TheGrid
      End Get
    End Property


    Private Sub menuCreateDB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      Dim dlg As New CreateDBDialog()
      dlg.ShowDialog(Me)
    End Sub 'menuCreateDB_Click


    Public Function CreateConnection() As SqlConnection
      Return New SqlConnection("server=Mainsrv;" + "database=ADONET;" + "Integrated Security=true;")
    End Function 'CreateConnection


    Private Sub menuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      Application.Exit()
    End Sub 'menuExit_Click

    Private Sub menuCh1Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch1.Example2()
    End Sub 'menuCh1Ex2_Click


    Private Sub menuCh1Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch1.Example3()
    End Sub 'menuCh1Ex3_Click


    Private Sub menuCh1Ex4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch1.Example4()
    End Sub 'menuCh1Ex4_Click


    Private Sub menuCh1Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch1.Example5()
    End Sub 'menuCh1Ex5_Click


    Private Sub menuCh1Ex6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch1.Example6()
    End Sub 'menuCh1Ex6_Click


    Private Sub menuCh1Ex7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch1.Example7()
    End Sub 'menuCh1Ex7_Click


    Private Sub menuCh1Ex8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch1.Example8()
    End Sub 'menuCh1Ex8_Click

    Private Sub menuCh2Ex1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch2.Example1()
    End Sub 'menuCh2Ex1_Click


    Private Sub menuCh2Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch2.Example2()
    End Sub 'menuCh2Ex2_Click


    Private Sub menuCh2Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch2.Example3()
    End Sub 'menuCh2Ex3_Click


    Private Sub menuCh2Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch2.Example5()
    End Sub 'menuCh2Ex5_Click


    Private Sub menuCh2Ex9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch2.Example9()
    End Sub 'menuCh2Ex9_Click


    Private Sub menuCh2Ex10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch2.Example10()
    End Sub 'menuCh2Ex10_Click


    Private Sub menuCh2Ex11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch2.Example11()
    End Sub 'menuCh2Ex11_Click


    Private Sub menuCh2Ex12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch2.Example12()
    End Sub 'menuCh2Ex12_Click

    Private Sub menuCh3Ex1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example1()
    End Sub 'menuCh3Ex1_Click


    Private Sub menuCh3Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example2()
    End Sub 'menuCh3Ex2_Click


    Private Sub menuCh3Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example3()
    End Sub 'menuCh3Ex3_Click


    Private Sub menuCh3Ex4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example4()
    End Sub 'menuCh3Ex4_Click


    Private Sub menuCh3Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example5()
    End Sub 'menuCh3Ex5_Click


    Private Sub menuCh3Ex6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example6()
    End Sub 'menuCh3Ex6_Click


    Private Sub menuCh3Ex7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example7()
    End Sub 'menuCh3Ex7_Click


    Private Sub menuCh3Ex9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example9()
    End Sub 'menuCh3Ex9_Click


    Private Sub menuCh3Ex10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example10()
    End Sub 'menuCh3Ex10_Click


    Private Sub menuCh3Ex11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example11()
    End Sub 'menuCh3Ex11_Click


    Private Sub menuCh3Ex12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example12()
    End Sub 'menuCh3Ex12_Click


    Private Sub menuCh3Ex13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example13()
    End Sub 'menuCh3Ex13_Click


    Private Sub menuCh3Ex15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example15()
    End Sub 'menuCh3Ex15_Click


    Private Sub menuCh3Ex16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example16()
    End Sub 'menuCh3Ex16_Click


    Private Sub menuCh3Ex17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example17()
    End Sub 'menuCh3Ex17_Click


    Private Sub menuCh3Ex18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example18()
    End Sub 'menuCh3Ex18_Click


    Private Sub menuCh3Ex19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch3.Example19()
    End Sub 'menuCh3Ex19_Click

    Private Sub menuCh4Ex1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example1()
    End Sub 'menuCh4Ex1_Click


    Private Sub menuCh4Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example2()
    End Sub 'menuCh4Ex2_Click


    Private Sub menuCh4Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example3()
    End Sub 'menuCh4Ex3_Click


    Private Sub menuCh4Ex4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example4()
    End Sub 'menuCh4Ex4_Click


    Private Sub menuCh4Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example5()
    End Sub 'menuCh4Ex5_Click


    Private Sub menuCh4Ex6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example6()
    End Sub 'menuCh4Ex6_Click


    Private Sub menuCh4Ex10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example10()
    End Sub 'menuCh4Ex10_Click


    Private Sub menuCh4Ex11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example11()
    End Sub 'menuCh4Ex11_Click


    Private Sub menuCh4Ex12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.Example12()
    End Sub 'menuCh4Ex12_Click


    Private Sub menuCh4ExDlg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch4.ExampleDialog()
    End Sub 'menuCh4ExDlg_Click


    Private Sub menuInvoiceLister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.InvoiceLister()
    End Sub 'menuInvoiceLister_Click

    Private Sub menuCh5Ex1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example1()
    End Sub 'menuCh5Ex1_Click


    Private Sub menuCh5Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example2()
    End Sub 'menuCh5Ex2_Click


    Private Sub menuCh5Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example3()
    End Sub 'menuCh5Ex3_Click


    Private Sub menuCh5Ex4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example4()
    End Sub 'menuCh5Ex4_Click


    Private Sub menuCh5Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example5()
    End Sub 'menuCh5Ex5_Click


    Private Sub menuCh5Ex6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example6()
    End Sub 'menuCh5Ex6_Click


    Private Sub menuCh5Ex7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example7()
    End Sub 'menuCh5Ex7_Click


    Private Sub menuCh5Ex8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example8()
    End Sub 'menuCh5Ex8_Click


    Private Sub menuCh5Ex9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example9()
    End Sub 'menuCh5Ex9_Click


    Private Sub menuCh5Ex10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example10()
    End Sub 'menuCh5Ex10_Click


    Private Sub menuCh5Ex11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example11()
    End Sub 'menuCh5Ex11_Click


    Private Sub menuCh5Ex12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example12()
    End Sub 'menuCh5Ex12_Click


    Private Sub menuCh5Ex13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example13()
    End Sub 'menuCh5Ex13_Click


    Private Sub menuCh5Ex14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example14()
    End Sub 'menuCh5Ex14_Click


    Private Sub menuCh5Ex15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example15()
    End Sub 'menuCh5Ex15_Click


    Private Sub menuCh5Ex16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example16()
    End Sub 'menuCh5Ex16_Click


    Private Sub menuCh5Ex17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example17()
    End Sub 'menuCh5Ex17_Click


    Private Sub menuCh5Ex18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example18()
    End Sub 'menuCh5Ex18_Click


    Private Sub menuCh5Ex19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example19()
    End Sub 'menuCh5Ex19_Click


    Private Sub menuCh5Ex20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example20()
    End Sub 'menuCh5Ex20_Click

    Private Sub menuCh5Ex21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example21()
    End Sub 'menuCh5Ex21_Click


    Private Sub menuCh5Ex22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example22()
    End Sub 'menuCh5Ex22_Click


    Private Sub menuCh5Ex23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example23()
    End Sub 'menuCh5Ex23_Click


    Private Sub menuCh5Ex24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example24()
    End Sub 'menuCh5Ex24_Click


    Private Sub menuCh5Ex25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch5.Example25()
    End Sub 'menuCh5Ex25_Click


    Private Sub menuCh6Ex1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch6.Example1()
    End Sub 'menuCh6Ex1_Click


    Private Sub menuCh6Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch6.Example2()
    End Sub 'menuCh6Ex2_Click

    Private Sub menuCh6Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch6.Example3()
    End Sub 'menuCh6Ex3_Click


    Private Sub menuCh6Ex4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch6.Example4()
    End Sub 'menuCh6Ex4_Click


    Private Sub menuCh6Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch6.Example5()
    End Sub 'menuCh6Ex5_Click


    Private Sub menuCh7Ex1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example1()
    End Sub 'menuCh7Ex1_Click


    Private Sub menuCh7Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example2()
    End Sub 'menuCh7Ex2_Click


    Private Sub menuCh7Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example3()
    End Sub 'menuCh7Ex3_Click


    Private Sub menuCh7Ex4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example4()
    End Sub 'menuCh7Ex4_Click


    Private Sub menuCh7Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example5()
    End Sub 'menuCh7Ex5_Click


    Private Sub menuCh7Ex6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example6()
    End Sub 'menuCh7Ex6_Click


    Private Sub menuCh7Ex7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example7()
    End Sub 'menuCh7Ex7_Click


    Private Sub menuCh7Ex8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example8()
    End Sub 'menuCh7Ex8_Click


    Private Sub menuCh7Ex9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example9()
    End Sub 'menuCh7Ex9_Click


    Private Sub menuCh7Ex10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example10()
    End Sub 'menuCh7Ex10_Click


    Private Sub menuCh7Ex11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example11()
    End Sub 'menuCh7Ex11_Click


    Private Sub menuCh7Ex12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example12()
    End Sub 'menuCh7Ex12_Click


    Private Sub menuCh7Ex13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example13()
    End Sub 'menuCh7Ex13_Click


    Private Sub menuCh7Ex14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example14()
    End Sub 'menuCh7Ex14_Click


    Private Sub menuCh7Ex15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example15()
    End Sub 'menuCh7Ex15_Click

    Private Sub menuCh7Ex16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example16()
    End Sub 'menuCh7Ex16_Click


    Private Sub menuCh7Ex17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch7.Example17()
    End Sub 'menuCh7Ex17_Click

    Private Sub menuCh8Ex1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example1()
    End Sub 'menuCh8Ex1_Click


    Private Sub menuCh8Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example2()
    End Sub 'menuCh8Ex2_Click


    Private Sub menuCh8Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example3()
    End Sub 'menuCh8Ex3_Click


    Private Sub menuCh8Ex4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example4()
    End Sub 'menuCh8Ex4_Click


    Private Sub menuCh8Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example5()
    End Sub 'menuCh8Ex5_Click


    Private Sub menuCh8Ex6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example6()
    End Sub 'menuCh8Ex6_Click


    Private Sub menuCh8Ex7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example7()
    End Sub 'menuCh8Ex7_Click


    Private Sub menuCh8Ex8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example8()
    End Sub 'menuCh8Ex8_Click


    Private Sub menuCh8Ex9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example9()
    End Sub 'menuCh8Ex9_Click


    Private Sub menuCh8Ex10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example10()
    End Sub 'menuCh8Ex10_Click


    Private Sub menuCh8Ex11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example11()
    End Sub 'menuCh8Ex11_Click


    Private Sub menuCh8Ex12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example12()
    End Sub 'menuCh8Ex12_Click


    Private Sub menuCh8Ex13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch8.Example13()
    End Sub 'menuCh8Ex13_Click

    Private Sub menuCh9Ex1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example1()
    End Sub 'menuCh9Ex1_Click


    Private Sub menuCh9Ex2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example2()
    End Sub 'menuCh9Ex2_Click


    Private Sub menuCh9Ex3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example3()
    End Sub 'menuCh9Ex3_Click


    Private Sub menuCh9Ex4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example4()
    End Sub 'menuCh9Ex4_Click


    Private Sub menuCh9Ex5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example5()
    End Sub 'menuCh9Ex5_Click


    Private Sub menuCh9Ex6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example6()
    End Sub 'menuCh9Ex6_Click


    Private Sub menuCh9Ex7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example7()
    End Sub 'menuCh9Ex7_Click


    Private Sub menuCh9Ex8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example8()
    End Sub 'menuCh9Ex8_Click


    Private Sub menuCh9Ex9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example9()
    End Sub 'menuCh9Ex9_Click


    Private Sub menuCh9Ex10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example10()
    End Sub 'menuCh9Ex10_Click


    Private Sub menuCh9Ex11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example11()
    End Sub 'menuCh9Ex11_Click


    Private Sub menuCh9Ex12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example12()
    End Sub 'menuCh9Ex12_Click


    Private Sub menuCh9Ex13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example13()
    End Sub 'menuCh9Ex13_Click


    Private Sub menuCh9Ex14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example14()
    End Sub 'menuCh9Ex14_Click


    Private Sub menuCh9Ex15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example15()
    End Sub 'menuCh9Ex15_Click


    Private Sub menuCh9Ex16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      ch9.Example16()
    End Sub 'menuCh9Ex16_Click


    Private Sub menuCh10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      Dim form As New DataBindingForm()
      form.ShowDialog(Me)
    End Sub 'menuCh10_Click
  End Class 'MainForm 
End Namespace 'BookExamples '
