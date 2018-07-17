Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter4Example.
  ' </summary>
  Public Class Chapter4Example
    Inherits System.Windows.Forms.Form

    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.Container = Nothing
    Private WithEvents cbCustomers As System.Windows.Forms.ComboBox
    Private theView As System.Windows.Forms.ListView
    Private InvoiceNumber As System.Windows.Forms.ColumnHeader
    Private InvoiceDate As System.Windows.Forms.ColumnHeader
    Private PO As System.Windows.Forms.ColumnHeader
    Private FOB As System.Windows.Forms.ColumnHeader
    Private Terms As System.Windows.Forms.ColumnHeader
    Private customerList As customerList


    Public Sub New()
      ' Required for Windows Form Designer support
      InitializeComponent()

      ' Our Query
      Dim query As String = "SELECT Customer.CustomerID, FirstName, LastName, HomePhone, " + "       Address, City, State, Zip, DOB, " + "       InvoiceNumber, InvoiceDate, FOB, PO, Terms " + "  FROM Customer " + "    JOIN Invoice on Customer.CustomerID = Invoice.CustomerID " + "  ORDER BY Customer.CustomerID, Invoice.InvoiceID "

      ' Attach to the database and execute the query
      Dim conn As New SqlConnection("Server=localhost;Database=ADONET;Integrated Security=true;")
      conn.Open()

      ' Make a new commmand for our query
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = query

      ' Get the DataReader
      Dim rdr As SqlDataReader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))

      ' Use the DataReader to construct our object model
      customerList = New CustomerList(rdr)

      ' Clean up the DataReader, we are done with it
      rdr.Close()

      ' Fill the combobox
      cbCustomers.Items.AddRange(customerList.ToArray())

      ' Set the selected to the first item
      cbCustomers.SelectedIndex = 0
    End Sub 'New


    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
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
      Me.theView = New System.Windows.Forms.ListView()
      Me.cbCustomers = New System.Windows.Forms.ComboBox()
      Me.InvoiceNumber = New System.Windows.Forms.ColumnHeader()
      Me.InvoiceDate = New System.Windows.Forms.ColumnHeader()
      Me.PO = New System.Windows.Forms.ColumnHeader()
      Me.FOB = New System.Windows.Forms.ColumnHeader()
      Me.Terms = New System.Windows.Forms.ColumnHeader()
      MyBase.SuspendLayout()
      ' 
      ' theView
      ' 
      Me.theView.CheckBoxes = True
      Me.theView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.InvoiceNumber, Me.InvoiceDate, Me.PO, Me.FOB, Me.Terms})
      Me.theView.FullRowSelect = True
      Me.theView.GridLines = True
      Me.theView.Location = New System.Drawing.Point(8, 32)
      Me.theView.Name = "theView"
      Me.theView.Size = New System.Drawing.Size(544, 416)
      Me.theView.TabIndex = 0
      Me.theView.View = System.Windows.Forms.View.Details
      ' 
      ' cbCustomers
      ' 
      Me.cbCustomers.Location = New System.Drawing.Point(8, 8)
      Me.cbCustomers.Name = "cbCustomers"
      Me.cbCustomers.Size = New System.Drawing.Size(544, 21)
      Me.cbCustomers.TabIndex = 1
      ' 
      ' Chapter4Example
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(560, 454)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cbCustomers, Me.theView})
      MyBase.Name = "Chapter4Example"
      MyBase.Text = "Chapter4Example"
      MyBase.ResumeLayout(False)
    End Sub 'InitializeComponent

    Private Sub cbCustomers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCustomers.SelectedIndexChanged '
      theView.Items.Clear()

      Dim cust As Customer = CType(cbCustomers.SelectedItem, Customer)

      Dim inv As Invoice
      For Each inv In cust.Invoices
        theView.Items.Add(New ListViewItem(inv.ToStringArray()))
      Next inv
    End Sub 'cbCustomers_SelectedIndexChanged
  End Class 'Chapter4Example
End Namespace 'BookExamples