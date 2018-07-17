Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient


Namespace BookExamples
    _

  Public Class InvoiceLister
    Inherits System.Windows.Forms.Form

    Private label1 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label2 As System.Windows.Forms.Label
    Private txtLast As System.Windows.Forms.TextBox
    Private txtFirst As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private txtAddress As System.Windows.Forms.TextBox
    Private label4 As System.Windows.Forms.Label
    Private txtCity As System.Windows.Forms.TextBox
    Private txtState As System.Windows.Forms.TextBox
    Private txtZip As System.Windows.Forms.TextBox
    Private customers As CustomerList
    Private label5 As System.Windows.Forms.Label
    Private txtPhone As System.Windows.Forms.TextBox
    Private lstInvoices As System.Windows.Forms.ListView
    Private WithEvents cbCustomers As System.Windows.Forms.ComboBox
    Private InvoiceNumber As System.Windows.Forms.ColumnHeader
    Private InvoiceDate As System.Windows.Forms.ColumnHeader
    Private Terms As System.Windows.Forms.ColumnHeader
    Private PO As System.Windows.Forms.ColumnHeader
    Private FOB As System.Windows.Forms.ColumnHeader
    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.Container = Nothing


    Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()

      Dim conn As New SqlConnection("Server=localhost;Database=ADONET;Integrated Security=true;")
      Try
        conn.Open()
        Dim cmd As SqlCommand = conn.CreateCommand()
        cmd.CommandText = "SELECT Customer.CustomerID, LastName, FirstName, HomePhone, Address, City, State, Zip, " + "       InvoiceID, InvoiceNumber, InvoiceDate, Terms, PO, FOB " + "  FROM Customer " + "  JOIN Invoice on Customer.CustomerID = Invoice.CustomerID " + "  ORDER BY LastName"

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.KeyInfo)
        customers = New CustomerList(rdr)
        rdr.Close()
        cmd.Dispose()
        conn.Dispose()

        ' Fill the combobox
        cbCustomers.Items.AddRange(customers.ToArray())

        ' Set the selected to the first item
        cbCustomers.SelectedIndex = 0

      Catch ex As SqlException
        MessageBox.Show(("Fatal SQL Error: " + ex.Message))
      End Try
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
      Me.Dispose(disposing)
    End Sub 'Dispose

    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
      Me.txtCity = New System.Windows.Forms.TextBox()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me.label5 = New System.Windows.Forms.Label()
      Me.txtPhone = New System.Windows.Forms.TextBox()
      Me.lstInvoices = New System.Windows.Forms.ListView()
      Me.InvoiceNumber = New System.Windows.Forms.ColumnHeader()
      Me.InvoiceDate = New System.Windows.Forms.ColumnHeader()
      Me.Terms = New System.Windows.Forms.ColumnHeader()
      Me.txtZip = New System.Windows.Forms.TextBox()
      Me.txtState = New System.Windows.Forms.TextBox()
      Me.txtAddress = New System.Windows.Forms.TextBox()
      Me.label4 = New System.Windows.Forms.Label()
      Me.txtFirst = New System.Windows.Forms.TextBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me.txtLast = New System.Windows.Forms.TextBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me.cbCustomers = New System.Windows.Forms.ComboBox()
      Me.PO = New System.Windows.Forms.ColumnHeader()
      Me.FOB = New System.Windows.Forms.ColumnHeader()
      Me.groupBox1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' txtCity
      ' 
      Me.txtCity.Location = New System.Drawing.Point(80, 72)
      Me.txtCity.Name = "txtCity"
      Me.txtCity.ReadOnly = True
      Me.txtCity.Size = New System.Drawing.Size(200, 20)
      Me.txtCity.TabIndex = 0
      Me.txtCity.Text = ""
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
      Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.label5, Me.txtPhone, Me.lstInvoices, Me.txtZip, Me.txtState, Me.txtCity, Me.txtAddress, Me.label4, Me.txtFirst, Me.label3, Me.txtLast, Me.label2})
      Me.groupBox1.Location = New System.Drawing.Point(88, 40)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(456, 272)
      Me.groupBox1.TabIndex = 2
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Info"
      ' 
      ' label5
      ' 
      Me.label5.Location = New System.Drawing.Point(16, 96)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(64, 16)
      Me.label5.TabIndex = 1
      Me.label5.Text = "Phone:"
      ' 
      ' txtPhone
      ' 
      Me.txtPhone.Location = New System.Drawing.Point(80, 96)
      Me.txtPhone.Name = "txtPhone"
      Me.txtPhone.ReadOnly = True
      Me.txtPhone.Size = New System.Drawing.Size(144, 20)
      Me.txtPhone.TabIndex = 0
      Me.txtPhone.Text = ""
      ' 
      ' lstInvoices
      ' 
      Me.lstInvoices.Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right
      Me.lstInvoices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.InvoiceNumber, Me.InvoiceDate, Me.PO, Me.FOB, Me.Terms})
      Me.lstInvoices.Location = New System.Drawing.Point(8, 144)
      Me.lstInvoices.Name = "lstInvoices"
      Me.lstInvoices.Size = New System.Drawing.Size(440, 120)
      Me.lstInvoices.TabIndex = 3
      Me.lstInvoices.View = System.Windows.Forms.View.Details
      ' 
      ' InvoiceNumber
      ' 
      Me.InvoiceNumber.Text = "#"
      Me.InvoiceNumber.Width = 40
      ' 
      ' InvoiceDate
      ' 
      Me.InvoiceDate.Text = "Date"
      Me.InvoiceDate.Width = 80
      ' 
      ' Terms
      ' 
      Me.Terms.Text = "Terms"
      Me.Terms.Width = 200
      ' 
      ' txtZip
      ' 
      Me.txtZip.Location = New System.Drawing.Point(352, 72)
      Me.txtZip.Name = "txtZip"
      Me.txtZip.ReadOnly = True
      Me.txtZip.Size = New System.Drawing.Size(88, 20)
      Me.txtZip.TabIndex = 0
      Me.txtZip.Text = ""
      ' 
      ' txtState
      ' 
      Me.txtState.Location = New System.Drawing.Point(288, 72)
      Me.txtState.Name = "txtState"
      Me.txtState.ReadOnly = True
      Me.txtState.Size = New System.Drawing.Size(64, 20)
      Me.txtState.TabIndex = 0
      Me.txtState.Text = ""
      ' 
      ' txtAddress
      ' 
      Me.txtAddress.Location = New System.Drawing.Point(80, 48)
      Me.txtAddress.Name = "txtAddress"
      Me.txtAddress.ReadOnly = True
      Me.txtAddress.Size = New System.Drawing.Size(368, 20)
      Me.txtAddress.TabIndex = 0
      Me.txtAddress.Text = ""
      ' 
      ' label4
      ' 
      Me.label4.Location = New System.Drawing.Point(16, 48)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(64, 16)
      Me.label4.TabIndex = 1
      Me.label4.Text = "Address:"
      ' 
      ' txtFirst
      ' 
      Me.txtFirst.Location = New System.Drawing.Point(304, 24)
      Me.txtFirst.Name = "txtFirst"
      Me.txtFirst.ReadOnly = True
      Me.txtFirst.Size = New System.Drawing.Size(144, 20)
      Me.txtFirst.TabIndex = 0
      Me.txtFirst.Text = ""
      ' 
      ' label3
      ' 
      Me.label3.Location = New System.Drawing.Point(240, 24)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(64, 16)
      Me.label3.TabIndex = 1
      Me.label3.Text = "First Name:"
      ' 
      ' txtLast
      ' 
      Me.txtLast.Location = New System.Drawing.Point(80, 24)
      Me.txtLast.Name = "txtLast"
      Me.txtLast.ReadOnly = True
      Me.txtLast.Size = New System.Drawing.Size(144, 20)
      Me.txtLast.TabIndex = 0
      Me.txtLast.Text = ""
      ' 
      ' label2
      ' 
      Me.label2.Location = New System.Drawing.Point(16, 24)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(64, 16)
      Me.label2.TabIndex = 1
      Me.label2.Text = "Last Name:"
      ' 
      ' label1
      ' 
      Me.label1.Location = New System.Drawing.Point(8, 15)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(64, 16)
      Me.label1.TabIndex = 1
      Me.label1.Text = "Customer:"
      ' 
      ' cbCustomers
      ' 
      Me.cbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cbCustomers.DropDownWidth = 208
      Me.cbCustomers.Location = New System.Drawing.Point(88, 15)
      Me.cbCustomers.Name = "cbCustomers"
      Me.cbCustomers.Size = New System.Drawing.Size(208, 21)
      Me.cbCustomers.TabIndex = 0
      ' 
      ' PO
      ' 
      Me.PO.Text = "PO"
      ' 
      ' FOB
      ' 
      Me.FOB.Text = "FOB"
      ' 
      ' InvoiceLister
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(552, 318)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox1, Me.label1, Me.cbCustomers})
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "InvoiceLister"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Customer Invoice Lister"
      Me.groupBox1.ResumeLayout(False)
      Me.ResumeLayout(False)
    End Sub 'InitializeComponent

    Private Sub label2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click '
    End Sub 'label2_Click

    Private Sub cbAuthors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCustomers.SelectedIndexChanged

      ' When the user selects and customer, fill in the form
      Dim customer As Customer = cbCustomers.SelectedItem '

      If Not (customer Is Nothing) Then
        txtLast.Text = customer.LastName
        txtFirst.Text = customer.FirstName
        txtAddress.Text = customer.Address
        txtCity.Text = customer.City
        txtState.Text = customer.State
        txtZip.Text = customer.Zip
        txtPhone.Text = customer.HomePhone
        AddBooks(customer.Invoices)
      End If
    End Sub 'cbAuthors_SelectedIndexChanged



    Private Sub AddBooks(ByVal invs As InvoiceList)

      ' Clear the Items in the list (lstBooks.Clear() would clear the columns too)      
      lstInvoices.Items.Clear()

      ' Go through each book and add an item to the ListView
      Dim inv As Invoice
      For Each inv In invs
        lstInvoices.Items.Add(New ListViewItem(inv.ToStringArray()))
      Next inv
    End Sub 'AddBooks 
  End Class 'InvoiceLister
End Namespace 'BookExamples 
