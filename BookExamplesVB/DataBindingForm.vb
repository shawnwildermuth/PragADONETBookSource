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
  ' Summary description for Form1.
  ' </summary>
  Public Class DataBindingForm
    Inherits System.Windows.Forms.Form

    Private Ex1 As System.Windows.Forms.TabPage
    Private Ex2 As System.Windows.Forms.TabPage

    Private Ex3 As System.Windows.Forms.TabPage
    Friend txtDesc As System.Windows.Forms.TextBox
    Private asdf As System.Windows.Forms.Label
    Private chkInStock As System.Windows.Forms.CheckBox
    Private btnShowPID As System.Windows.Forms.Button
    Private listProducts As System.Windows.Forms.ListBox
    Private theGrid As System.Windows.Forms.DataGrid
    Private gridDetail As System.Windows.Forms.DataGrid
    Private gridMaster As System.Windows.Forms.DataGrid
    Private gridInvoiceDetail As System.Windows.Forms.DataGrid
    Private btnFirst As System.Windows.Forms.Button
    Private btnPrev As System.Windows.Forms.Button
    Private btnNext As System.Windows.Forms.Button
    Private btnLast As System.Windows.Forms.Button
    Private txtCustName As System.Windows.Forms.TextBox
    Private label1 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label2 As System.Windows.Forms.Label
    Private txtAddress As System.Windows.Forms.TextBox
    Private txtCity As System.Windows.Forms.TextBox
    Private txtState As System.Windows.Forms.TextBox
    Private txtZip As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private listInvoices As System.Windows.Forms.ListBox
    Private txtHomePhone As System.Windows.Forms.TextBox
    Private txtWorkPhone As System.Windows.Forms.TextBox
    Private Detail6 As System.Windows.Forms.DataGrid
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private theTabCtrl As System.Windows.Forms.TabControl
    Private theDSGrid As System.Windows.Forms.DataGrid
    Private theDataViewGrid As System.Windows.Forms.DataGrid
    Private Ex4 As System.Windows.Forms.TabPage
    Private Ex5 As System.Windows.Forms.TabPage
    Private Ex7 As System.Windows.Forms.TabPage
    Private Ex6 As System.Windows.Forms.TabPage
    Private parentGrid As System.Windows.Forms.DataGrid
    Private childGrid As System.Windows.Forms.DataGrid
    Private Ex8 As System.Windows.Forms.TabPage

    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.Container = Nothing


    Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()
    End Sub 'New

    '
    ' TODO: Add any constructor code after InitializeComponent call
    '

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
      Me.theTabCtrl = New System.Windows.Forms.TabControl()
      Me.Ex1 = New System.Windows.Forms.TabPage()
      Me.chkInStock = New System.Windows.Forms.CheckBox()
      Me.asdf = New System.Windows.Forms.Label()
      Me.txtDesc = New System.Windows.Forms.TextBox()
      Me.Ex2 = New System.Windows.Forms.TabPage()
      Me.listProducts = New System.Windows.Forms.ListBox()
      Me.btnShowPID = New System.Windows.Forms.Button()
      Me.Ex3 = New System.Windows.Forms.TabPage()
      Me.theGrid = New System.Windows.Forms.DataGrid()
      Me.Ex7 = New System.Windows.Forms.TabPage()
      Me.gridInvoiceDetail = New System.Windows.Forms.DataGrid()
      Me.gridMaster = New System.Windows.Forms.DataGrid()
      Me.gridDetail = New System.Windows.Forms.DataGrid()
      Me.Ex8 = New System.Windows.Forms.TabPage()
      Me.label5 = New System.Windows.Forms.Label()
      Me.txtWorkPhone = New System.Windows.Forms.TextBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me.txtHomePhone = New System.Windows.Forms.TextBox()
      Me.txtZip = New System.Windows.Forms.TextBox()
      Me.txtState = New System.Windows.Forms.TextBox()
      Me.txtCity = New System.Windows.Forms.TextBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.txtAddress = New System.Windows.Forms.TextBox()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me.listInvoices = New System.Windows.Forms.ListBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me.btnLast = New System.Windows.Forms.Button()
      Me.btnNext = New System.Windows.Forms.Button()
      Me.btnPrev = New System.Windows.Forms.Button()
      Me.btnFirst = New System.Windows.Forms.Button()
      Me.txtCustName = New System.Windows.Forms.TextBox()
      Me.Detail6 = New System.Windows.Forms.DataGrid()
      Me.label4 = New System.Windows.Forms.Label()
      Me.Ex4 = New System.Windows.Forms.TabPage()
      Me.Ex5 = New System.Windows.Forms.TabPage()
      Me.theDSGrid = New System.Windows.Forms.DataGrid()
      Me.theDataViewGrid = New System.Windows.Forms.DataGrid()
      Me.Ex6 = New System.Windows.Forms.TabPage()
      Me.parentGrid = New System.Windows.Forms.DataGrid()
      Me.childGrid = New System.Windows.Forms.DataGrid()
      Me.theTabCtrl.SuspendLayout()
      Me.Ex1.SuspendLayout()
      Me.Ex2.SuspendLayout()
      Me.Ex3.SuspendLayout()
      CType(Me.theGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Ex7.SuspendLayout()
      CType(Me.gridInvoiceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.gridMaster, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.gridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Ex8.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      CType(Me.Detail6, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Ex4.SuspendLayout()
      Me.Ex5.SuspendLayout()
      CType(Me.theDSGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.theDataViewGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Ex6.SuspendLayout()
      CType(Me.parentGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.childGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      MyBase.SuspendLayout()
      ' 
      ' theTabCtrl
      ' 
      Me.theTabCtrl.Controls.AddRange(New System.Windows.Forms.Control() {Me.Ex1, Me.Ex2, Me.Ex3, Me.Ex4, Me.Ex5, Me.Ex6, Me.Ex7, Me.Ex8})
      Me.theTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill
      Me.theTabCtrl.Name = "theTabCtrl"
      Me.theTabCtrl.SelectedIndex = 0
      Me.theTabCtrl.Size = New System.Drawing.Size(472, 339)
      Me.theTabCtrl.TabIndex = 0
      ' 
      ' Ex1
      ' 
      Me.Ex1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkInStock, Me.asdf, Me.txtDesc})
      Me.Ex1.Location = New System.Drawing.Point(4, 22)
      Me.Ex1.Name = "Ex1"
      Me.Ex1.Size = New System.Drawing.Size(464, 313)
      Me.Ex1.TabIndex = 0
      Me.Ex1.Text = "Ex 1"
      ' 
      ' chkInStock
      ' 
      Me.chkInStock.Location = New System.Drawing.Point(80, 40)
      Me.chkInStock.Name = "chkInStock"
      Me.chkInStock.TabIndex = 2
      Me.chkInStock.Text = "In stock?"
      ' 
      ' asdf
      ' 
      Me.asdf.Location = New System.Drawing.Point(8, 16)
      Me.asdf.Name = "asdf"
      Me.asdf.Size = New System.Drawing.Size(64, 16)
      Me.asdf.TabIndex = 1
      Me.asdf.Text = "Description:"
      ' 
      ' txtDesc
      ' 
      Me.txtDesc.Location = New System.Drawing.Point(80, 16)
      Me.txtDesc.Name = "txtDesc"
      Me.txtDesc.Size = New System.Drawing.Size(136, 20)
      Me.txtDesc.TabIndex = 0
      Me.txtDesc.Text = ""
      ' 
      ' Ex2
      ' 
      Me.Ex2.Controls.AddRange(New System.Windows.Forms.Control() {Me.listProducts, Me.btnShowPID})
      Me.Ex2.Location = New System.Drawing.Point(4, 22)
      Me.Ex2.Name = "Ex2"
      Me.Ex2.Size = New System.Drawing.Size(464, 313)
      Me.Ex2.TabIndex = 1
      Me.Ex2.Text = "Ex 2"
      ' 
      ' listProducts
      ' 
      Me.listProducts.Location = New System.Drawing.Point(16, 24)
      Me.listProducts.Name = "listProducts"
      Me.listProducts.Size = New System.Drawing.Size(168, 186)
      Me.listProducts.TabIndex = 2
      ' 
      ' btnShowPID
      ' 
      Me.btnShowPID.Location = New System.Drawing.Point(16, 216)
      Me.btnShowPID.Name = "btnShowPID"
      Me.btnShowPID.Size = New System.Drawing.Size(168, 24)
      Me.btnShowPID.TabIndex = 1
      Me.btnShowPID.Text = "Show ProductID of Selected"
      ' 
      ' Ex3
      ' 
      Me.Ex3.Controls.AddRange(New System.Windows.Forms.Control() {Me.theGrid})
      Me.Ex3.Location = New System.Drawing.Point(4, 22)
      Me.Ex3.Name = "Ex3"
      Me.Ex3.Size = New System.Drawing.Size(464, 313)
      Me.Ex3.TabIndex = 2
      Me.Ex3.Text = "Ex 3"
      ' 
      ' theGrid
      ' 
      Me.theGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.theGrid.BackColor = System.Drawing.Color.Gainsboro
      Me.theGrid.BackgroundColor = System.Drawing.Color.DarkGray
      Me.theGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.theGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.theGrid.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.theGrid.CaptionForeColor = System.Drawing.Color.Black
      Me.theGrid.DataMember = ""
      Me.theGrid.FlatMode = True
      Me.theGrid.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.theGrid.ForeColor = System.Drawing.Color.Black
      Me.theGrid.GridLineColor = System.Drawing.Color.Silver
      Me.theGrid.HeaderBackColor = System.Drawing.Color.Black
      Me.theGrid.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.theGrid.HeaderForeColor = System.Drawing.Color.White
      Me.theGrid.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.theGrid.Location = New System.Drawing.Point(8, 16)
      Me.theGrid.Name = "theGrid"
      Me.theGrid.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.theGrid.ParentRowsForeColor = System.Drawing.Color.Black
      Me.theGrid.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.theGrid.SelectionForeColor = System.Drawing.Color.White
      Me.theGrid.Size = New System.Drawing.Size(448, 288)
      Me.theGrid.TabIndex = 0
      ' 
      ' Ex7
      ' 
      Me.Ex7.Controls.AddRange(New System.Windows.Forms.Control() {Me.gridInvoiceDetail, Me.gridMaster, Me.gridDetail})
      Me.Ex7.Location = New System.Drawing.Point(4, 22)
      Me.Ex7.Name = "Ex7"
      Me.Ex7.Size = New System.Drawing.Size(464, 313)
      Me.Ex7.TabIndex = 3
      Me.Ex7.Text = "Ex 7"
      ' 
      ' gridInvoiceDetail
      ' 
      Me.gridInvoiceDetail.AllowNavigation = False
      Me.gridInvoiceDetail.AllowSorting = False
      Me.gridInvoiceDetail.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.gridInvoiceDetail.BackColor = System.Drawing.Color.Gainsboro
      Me.gridInvoiceDetail.BackgroundColor = System.Drawing.Color.DarkGray
      Me.gridInvoiceDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.gridInvoiceDetail.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.gridInvoiceDetail.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.gridInvoiceDetail.CaptionForeColor = System.Drawing.Color.Black
      Me.gridInvoiceDetail.CaptionVisible = False
      Me.gridInvoiceDetail.DataMember = ""
      Me.gridInvoiceDetail.FlatMode = True
      Me.gridInvoiceDetail.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.gridInvoiceDetail.ForeColor = System.Drawing.Color.Black
      Me.gridInvoiceDetail.GridLineColor = System.Drawing.Color.Silver
      Me.gridInvoiceDetail.HeaderBackColor = System.Drawing.Color.Black
      Me.gridInvoiceDetail.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.gridInvoiceDetail.HeaderForeColor = System.Drawing.Color.White
      Me.gridInvoiceDetail.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.gridInvoiceDetail.Location = New System.Drawing.Point(8, 224)
      Me.gridInvoiceDetail.Name = "gridInvoiceDetail"
      Me.gridInvoiceDetail.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.gridInvoiceDetail.ParentRowsForeColor = System.Drawing.Color.Black
      Me.gridInvoiceDetail.ParentRowsVisible = False
      Me.gridInvoiceDetail.ReadOnly = True
      Me.gridInvoiceDetail.RowHeadersVisible = False
      Me.gridInvoiceDetail.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.gridInvoiceDetail.SelectionForeColor = System.Drawing.Color.White
      Me.gridInvoiceDetail.Size = New System.Drawing.Size(456, 88)
      Me.gridInvoiceDetail.TabIndex = 3
      ' 
      ' gridMaster
      ' 
      Me.gridMaster.AllowNavigation = False
      Me.gridMaster.AllowSorting = False
      Me.gridMaster.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.gridMaster.BackColor = System.Drawing.Color.Gainsboro
      Me.gridMaster.BackgroundColor = System.Drawing.Color.DarkGray
      Me.gridMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.gridMaster.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.gridMaster.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.gridMaster.CaptionForeColor = System.Drawing.Color.Black
      Me.gridMaster.CaptionVisible = False
      Me.gridMaster.DataMember = ""
      Me.gridMaster.FlatMode = True
      Me.gridMaster.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.gridMaster.ForeColor = System.Drawing.Color.Black
      Me.gridMaster.GridLineColor = System.Drawing.Color.Silver
      Me.gridMaster.HeaderBackColor = System.Drawing.Color.Black
      Me.gridMaster.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.gridMaster.HeaderForeColor = System.Drawing.Color.White
      Me.gridMaster.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.gridMaster.Location = New System.Drawing.Point(8, 8)
      Me.gridMaster.Name = "gridMaster"
      Me.gridMaster.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.gridMaster.ParentRowsForeColor = System.Drawing.Color.Black
      Me.gridMaster.ParentRowsVisible = False
      Me.gridMaster.RowHeadersVisible = False
      Me.gridMaster.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.gridMaster.SelectionForeColor = System.Drawing.Color.White
      Me.gridMaster.Size = New System.Drawing.Size(456, 104)
      Me.gridMaster.TabIndex = 2
      ' 
      ' gridDetail
      ' 
      Me.gridDetail.AllowNavigation = False
      Me.gridDetail.AllowSorting = False
      Me.gridDetail.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.gridDetail.BackColor = System.Drawing.Color.Gainsboro
      Me.gridDetail.BackgroundColor = System.Drawing.Color.DarkGray
      Me.gridDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.gridDetail.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.gridDetail.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.gridDetail.CaptionForeColor = System.Drawing.Color.Black
      Me.gridDetail.CaptionVisible = False
      Me.gridDetail.DataMember = ""
      Me.gridDetail.FlatMode = True
      Me.gridDetail.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.gridDetail.ForeColor = System.Drawing.Color.Black
      Me.gridDetail.GridLineColor = System.Drawing.Color.Silver
      Me.gridDetail.HeaderBackColor = System.Drawing.Color.Black
      Me.gridDetail.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.gridDetail.HeaderForeColor = System.Drawing.Color.White
      Me.gridDetail.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.gridDetail.Location = New System.Drawing.Point(8, 112)
      Me.gridDetail.Name = "gridDetail"
      Me.gridDetail.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.gridDetail.ParentRowsForeColor = System.Drawing.Color.Black
      Me.gridDetail.ParentRowsVisible = False
      Me.gridDetail.ReadOnly = True
      Me.gridDetail.RowHeadersVisible = False
      Me.gridDetail.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.gridDetail.SelectionForeColor = System.Drawing.Color.White
      Me.gridDetail.Size = New System.Drawing.Size(456, 112)
      Me.gridDetail.TabIndex = 1
      ' 
      ' Ex8
      ' 
      Me.Ex8.Controls.AddRange(New System.Windows.Forms.Control() {Me.label5, Me.txtWorkPhone, Me.label3, Me.txtHomePhone, Me.txtZip, Me.txtState, Me.txtCity, Me.label2, Me.txtAddress, Me.groupBox1, Me.label1, Me.btnLast, Me.btnNext, Me.btnPrev, Me.btnFirst, Me.txtCustName, Me.Detail6, Me.label4})
      Me.Ex8.Location = New System.Drawing.Point(4, 22)
      Me.Ex8.Name = "Ex8"
      Me.Ex8.Size = New System.Drawing.Size(464, 313)
      Me.Ex8.TabIndex = 5
      Me.Ex8.Text = "Ex 8"
      ' 
      ' label5
      ' 
      Me.label5.Location = New System.Drawing.Point(296, 80)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(32, 16)
      Me.label5.TabIndex = 25
      Me.label5.Text = "(Wk)"
      ' 
      ' txtWorkPhone
      ' 
      Me.txtWorkPhone.Location = New System.Drawing.Point(200, 80)
      Me.txtWorkPhone.Name = "txtWorkPhone"
      Me.txtWorkPhone.Size = New System.Drawing.Size(96, 20)
      Me.txtWorkPhone.TabIndex = 23
      Me.txtWorkPhone.Text = ""
      ' 
      ' label3
      ' 
      Me.label3.Location = New System.Drawing.Point(8, 80)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(64, 16)
      Me.label3.TabIndex = 22
      Me.label3.Text = "Phone:"
      ' 
      ' txtHomePhone
      ' 
      Me.txtHomePhone.Location = New System.Drawing.Point(72, 80)
      Me.txtHomePhone.Name = "txtHomePhone"
      Me.txtHomePhone.Size = New System.Drawing.Size(96, 20)
      Me.txtHomePhone.TabIndex = 21
      Me.txtHomePhone.Text = ""
      ' 
      ' txtZip
      ' 
      Me.txtZip.Location = New System.Drawing.Point(264, 56)
      Me.txtZip.Name = "txtZip"
      Me.txtZip.Size = New System.Drawing.Size(56, 20)
      Me.txtZip.TabIndex = 20
      Me.txtZip.Text = "textBox3"
      ' 
      ' txtState
      ' 
      Me.txtState.Location = New System.Drawing.Point(224, 56)
      Me.txtState.Name = "txtState"
      Me.txtState.Size = New System.Drawing.Size(32, 20)
      Me.txtState.TabIndex = 19
      Me.txtState.Text = "textBox2"
      ' 
      ' txtCity
      ' 
      Me.txtCity.Location = New System.Drawing.Point(72, 56)
      Me.txtCity.Name = "txtCity"
      Me.txtCity.Size = New System.Drawing.Size(144, 20)
      Me.txtCity.TabIndex = 18
      Me.txtCity.Text = "textBox1"
      ' 
      ' label2
      ' 
      Me.label2.Location = New System.Drawing.Point(8, 32)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(64, 16)
      Me.label2.TabIndex = 17
      Me.label2.Text = "Address:"
      ' 
      ' txtAddress
      ' 
      Me.txtAddress.Location = New System.Drawing.Point(72, 32)
      Me.txtAddress.Name = "txtAddress"
      Me.txtAddress.Size = New System.Drawing.Size(248, 20)
      Me.txtAddress.TabIndex = 16
      Me.txtAddress.Text = ""
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.listInvoices})
      Me.groupBox1.Location = New System.Drawing.Point(336, 32)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(128, 192)
      Me.groupBox1.TabIndex = 15
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Invoices"
      ' 
      ' listInvoices
      ' 
      Me.listInvoices.Location = New System.Drawing.Point(8, 16)
      Me.listInvoices.Name = "listInvoices"
      Me.listInvoices.Size = New System.Drawing.Size(112, 160)
      Me.listInvoices.TabIndex = 0
      ' 
      ' label1
      ' 
      Me.label1.Location = New System.Drawing.Point(8, 8)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(64, 16)
      Me.label1.TabIndex = 14
      Me.label1.Text = "Customer:"
      ' 
      ' btnLast
      ' 
      Me.btnLast.Location = New System.Drawing.Point(432, 0)
      Me.btnLast.Name = "btnLast"
      Me.btnLast.Size = New System.Drawing.Size(32, 24)
      Me.btnLast.TabIndex = 13
      Me.btnLast.Text = ">>"
      ' 
      ' btnNext
      ' 
      Me.btnNext.Location = New System.Drawing.Point(400, 0)
      Me.btnNext.Name = "btnNext"
      Me.btnNext.Size = New System.Drawing.Size(32, 24)
      Me.btnNext.TabIndex = 12
      Me.btnNext.Text = ">"
      ' 
      ' btnPrev
      ' 
      Me.btnPrev.Location = New System.Drawing.Point(368, 0)
      Me.btnPrev.Name = "btnPrev"
      Me.btnPrev.Size = New System.Drawing.Size(32, 24)
      Me.btnPrev.TabIndex = 11
      Me.btnPrev.Text = "<"
      ' 
      ' btnFirst
      ' 
      Me.btnFirst.Location = New System.Drawing.Point(336, 0)
      Me.btnFirst.Name = "btnFirst"
      Me.btnFirst.Size = New System.Drawing.Size(32, 24)
      Me.btnFirst.TabIndex = 10
      Me.btnFirst.Text = "<<"
      ' 
      ' txtCustName
      ' 
      Me.txtCustName.Location = New System.Drawing.Point(72, 8)
      Me.txtCustName.Name = "txtCustName"
      Me.txtCustName.Size = New System.Drawing.Size(248, 20)
      Me.txtCustName.TabIndex = 9
      Me.txtCustName.Text = ""
      ' 
      ' Detail6
      ' 
      Me.Detail6.AllowNavigation = False
      Me.Detail6.AllowSorting = False
      Me.Detail6.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.Detail6.BackColor = System.Drawing.Color.Gainsboro
      Me.Detail6.BackgroundColor = System.Drawing.Color.DarkGray
      Me.Detail6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Detail6.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.Detail6.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.Detail6.CaptionForeColor = System.Drawing.Color.Black
      Me.Detail6.CaptionVisible = False
      Me.Detail6.DataMember = ""
      Me.Detail6.FlatMode = True
      Me.Detail6.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.Detail6.ForeColor = System.Drawing.Color.Black
      Me.Detail6.GridLineColor = System.Drawing.Color.Silver
      Me.Detail6.HeaderBackColor = System.Drawing.Color.Black
      Me.Detail6.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.Detail6.HeaderForeColor = System.Drawing.Color.White
      Me.Detail6.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.Detail6.Location = New System.Drawing.Point(4, 224)
      Me.Detail6.Name = "Detail6"
      Me.Detail6.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.Detail6.ParentRowsForeColor = System.Drawing.Color.Black
      Me.Detail6.ParentRowsVisible = False
      Me.Detail6.ReadOnly = True
      Me.Detail6.RowHeadersVisible = False
      Me.Detail6.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.Detail6.SelectionForeColor = System.Drawing.Color.White
      Me.Detail6.Size = New System.Drawing.Size(456, 88)
      Me.Detail6.TabIndex = 8
      ' 
      ' label4
      ' 
      Me.label4.Location = New System.Drawing.Point(168, 80)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(32, 16)
      Me.label4.TabIndex = 24
      Me.label4.Text = "(Hm)"
      ' 
      ' Ex4
      ' 
      Me.Ex4.Controls.AddRange(New System.Windows.Forms.Control() {Me.theDataViewGrid})
      Me.Ex4.Location = New System.Drawing.Point(4, 22)
      Me.Ex4.Name = "Ex4"
      Me.Ex4.Size = New System.Drawing.Size(464, 313)
      Me.Ex4.TabIndex = 6
      Me.Ex4.Text = "Ex4"
      ' 
      ' Ex5
      ' 
      Me.Ex5.Controls.AddRange(New System.Windows.Forms.Control() {Me.theDSGrid})
      Me.Ex5.Location = New System.Drawing.Point(4, 22)
      Me.Ex5.Name = "Ex5"
      Me.Ex5.Size = New System.Drawing.Size(464, 313)
      Me.Ex5.TabIndex = 7
      Me.Ex5.Text = "Ex 5"
      ' 
      ' theDSGrid
      ' 
      Me.theDSGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.theDSGrid.BackColor = System.Drawing.Color.Gainsboro
      Me.theDSGrid.BackgroundColor = System.Drawing.Color.DarkGray
      Me.theDSGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.theDSGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.theDSGrid.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.theDSGrid.CaptionForeColor = System.Drawing.Color.Black
      Me.theDSGrid.DataMember = ""
      Me.theDSGrid.FlatMode = True
      Me.theDSGrid.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.theDSGrid.ForeColor = System.Drawing.Color.Black
      Me.theDSGrid.GridLineColor = System.Drawing.Color.Silver
      Me.theDSGrid.HeaderBackColor = System.Drawing.Color.Black
      Me.theDSGrid.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.theDSGrid.HeaderForeColor = System.Drawing.Color.White
      Me.theDSGrid.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.theDSGrid.Location = New System.Drawing.Point(8, 16)
      Me.theDSGrid.Name = "theDSGrid"
      Me.theDSGrid.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.theDSGrid.ParentRowsForeColor = System.Drawing.Color.Black
      Me.theDSGrid.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.theDSGrid.SelectionForeColor = System.Drawing.Color.White
      Me.theDSGrid.Size = New System.Drawing.Size(448, 288)
      Me.theDSGrid.TabIndex = 1
      ' 
      ' theDataViewGrid
      ' 
      Me.theDataViewGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.theDataViewGrid.BackColor = System.Drawing.Color.Gainsboro
      Me.theDataViewGrid.BackgroundColor = System.Drawing.Color.DarkGray
      Me.theDataViewGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.theDataViewGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.theDataViewGrid.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.theDataViewGrid.CaptionForeColor = System.Drawing.Color.Black
      Me.theDataViewGrid.DataMember = ""
      Me.theDataViewGrid.FlatMode = True
      Me.theDataViewGrid.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.theDataViewGrid.ForeColor = System.Drawing.Color.Black
      Me.theDataViewGrid.GridLineColor = System.Drawing.Color.Silver
      Me.theDataViewGrid.HeaderBackColor = System.Drawing.Color.Black
      Me.theDataViewGrid.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.theDataViewGrid.HeaderForeColor = System.Drawing.Color.White
      Me.theDataViewGrid.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.theDataViewGrid.Location = New System.Drawing.Point(8, 16)
      Me.theDataViewGrid.Name = "theDataViewGrid"
      Me.theDataViewGrid.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.theDataViewGrid.ParentRowsForeColor = System.Drawing.Color.Black
      Me.theDataViewGrid.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.theDataViewGrid.SelectionForeColor = System.Drawing.Color.White
      Me.theDataViewGrid.Size = New System.Drawing.Size(448, 288)
      Me.theDataViewGrid.TabIndex = 1
      ' 
      ' Ex6
      ' 
      Me.Ex6.Controls.AddRange(New System.Windows.Forms.Control() {Me.parentGrid, Me.childGrid})
      Me.Ex6.Location = New System.Drawing.Point(4, 22)
      Me.Ex6.Name = "Ex6"
      Me.Ex6.Size = New System.Drawing.Size(464, 313)
      Me.Ex6.TabIndex = 8
      Me.Ex6.Text = "Ex 6"
      ' 
      ' parentGrid
      ' 
      Me.parentGrid.AllowNavigation = False
      Me.parentGrid.AllowSorting = False
      Me.parentGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.parentGrid.BackColor = System.Drawing.Color.Gainsboro
      Me.parentGrid.BackgroundColor = System.Drawing.Color.DarkGray
      Me.parentGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.parentGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.parentGrid.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.parentGrid.CaptionForeColor = System.Drawing.Color.Black
      Me.parentGrid.CaptionVisible = False
      Me.parentGrid.DataMember = ""
      Me.parentGrid.FlatMode = True
      Me.parentGrid.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.parentGrid.ForeColor = System.Drawing.Color.Black
      Me.parentGrid.GridLineColor = System.Drawing.Color.Silver
      Me.parentGrid.HeaderBackColor = System.Drawing.Color.Black
      Me.parentGrid.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.parentGrid.HeaderForeColor = System.Drawing.Color.White
      Me.parentGrid.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.parentGrid.Location = New System.Drawing.Point(4, 8)
      Me.parentGrid.Name = "parentGrid"
      Me.parentGrid.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.parentGrid.ParentRowsForeColor = System.Drawing.Color.Black
      Me.parentGrid.ParentRowsVisible = False
      Me.parentGrid.RowHeadersVisible = False
      Me.parentGrid.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.parentGrid.SelectionForeColor = System.Drawing.Color.White
      Me.parentGrid.Size = New System.Drawing.Size(456, 104)
      Me.parentGrid.TabIndex = 4
      ' 
      ' childGrid
      ' 
      Me.childGrid.AllowNavigation = False
      Me.childGrid.AllowSorting = False
      Me.childGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke
      Me.childGrid.BackColor = System.Drawing.Color.Gainsboro
      Me.childGrid.BackgroundColor = System.Drawing.Color.DarkGray
      Me.childGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.childGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki
      Me.childGrid.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.childGrid.CaptionForeColor = System.Drawing.Color.Black
      Me.childGrid.CaptionVisible = False
      Me.childGrid.DataMember = ""
      Me.childGrid.FlatMode = True
      Me.childGrid.Font = New System.Drawing.Font("Times New Roman", 9.0F)
      Me.childGrid.ForeColor = System.Drawing.Color.Black
      Me.childGrid.GridLineColor = System.Drawing.Color.Silver
      Me.childGrid.HeaderBackColor = System.Drawing.Color.Black
      Me.childGrid.HeaderFont = New System.Drawing.Font("Tahoma", 8.0F, System.Drawing.FontStyle.Bold)
      Me.childGrid.HeaderForeColor = System.Drawing.Color.White
      Me.childGrid.LinkColor = System.Drawing.Color.DarkSlateBlue
      Me.childGrid.Location = New System.Drawing.Point(4, 112)
      Me.childGrid.Name = "childGrid"
      Me.childGrid.ParentRowsBackColor = System.Drawing.Color.LightGray
      Me.childGrid.ParentRowsForeColor = System.Drawing.Color.Black
      Me.childGrid.ParentRowsVisible = False
      Me.childGrid.ReadOnly = True
      Me.childGrid.RowHeadersVisible = False
      Me.childGrid.SelectionBackColor = System.Drawing.Color.Firebrick
      Me.childGrid.SelectionForeColor = System.Drawing.Color.White
      Me.childGrid.Size = New System.Drawing.Size(456, 112)
      Me.childGrid.TabIndex = 3
      ' 
      ' DataBindingForm
      ' 
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(472, 339)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.theTabCtrl})
      MyBase.MaximizeBox = False
      MyBase.MinimizeBox = False
      MyBase.Name = "DataBindingForm"
      MyBase.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      MyBase.Text = "Pragmatic Data Binding"
      Me.theTabCtrl.ResumeLayout(False)
      Me.Ex1.ResumeLayout(False)
      Me.Ex2.ResumeLayout(False)
      Me.Ex3.ResumeLayout(False)
      CType(Me.theGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Ex7.ResumeLayout(False)
      CType(Me.gridInvoiceDetail, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.gridMaster, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.gridDetail, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Ex8.ResumeLayout(False)
      Me.groupBox1.ResumeLayout(False)
      CType(Me.Detail6, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Ex4.ResumeLayout(False)
      Me.Ex5.ResumeLayout(False)
      CType(Me.theDSGrid, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.theDataViewGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Ex6.ResumeLayout(False)
      CType(Me.parentGrid, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.childGrid, System.ComponentModel.ISupportInitialize).EndInit()
      MyBase.ResumeLayout(False)
    End Sub 'InitializeComponent

    Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      Close()
    End Sub 'menuItem2_Click


    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      InitializeData()
      Example1()
      Example2()
      Example3()
      Example4()
      Example5()
      Example6()
      Example7()
      Example8()
    End Sub 'MainForm_Load

    Private Sub btnShowPID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      MessageBox.Show(String.Format("Selected Product's ID: {0}", listProducts.SelectedValue))
    End Sub 'btnShowPID_Click

    Private dataSet As New dataSet()
    Private customerTable As DataTable '

    Private invoiceTable As DataTable
    Private invoiceItemTable As DataTable
    Private productTable As DataTable


    Private Sub InitializeData()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE;", conn)
      Dim daInvoiceItems As New SqlDataAdapter("SELECT * FROM INVOICEITEM;", conn)
      Dim daProducts As New SqlDataAdapter("SELECT * FROM PRODUCT;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")
      daInvoices.Fill(dataSet, "Invoices")
      daInvoiceItems.Fill(dataSet, "InvoiceItems")
      daProducts.Fill(dataSet, "Products")

      ' Close the Connection
      conn.Close()

      ' Grab our Tables for simplicity
      customerTable = dataSet.Tables("Customers")
      invoiceTable = dataSet.Tables("Invoices")
      invoiceItemTable = dataSet.Tables("InvoiceItems")
      productTable = dataSet.Tables("Products")

      ' Set up PrimaryKeys
      customerTable.PrimaryKey = New DataColumn() {customerTable.Columns("CustomerID")}
      invoiceTable.PrimaryKey = New DataColumn() {invoiceTable.Columns("InvoiceID")}
      invoiceItemTable.PrimaryKey = New DataColumn() {invoiceItemTable.Columns("InvoiceItemID")}
      productTable.PrimaryKey = New DataColumn() {productTable.Columns("ProductID")}

      ' Setup Relations
      ' Create the first Relationship (Between INVOICE and INVOICEITEM)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("Invoices_InvoiceItems", invoiceTable.Columns("InvoiceID"), invoiceItemTable.Columns("InvoiceID"), True)

      ' Create the first Relationship (Between CUSTOMER and INVOICE)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("Customers_Invoices", customerTable.Columns("CustomerID"), invoiceTable.Columns("CustomerID"), True)

      ' Create the second Relationship (Between CUSTOMER and INVOICE)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("InvoiceItems_Products", invoiceItemTable.Columns("ProductID"), productTable.Columns("ProductID"), False)

      ' Add a few Expression Columns
      customerTable.Columns.Add("FullName", GetType(String), "LastName + ', ' + FirstName")
      invoiceItemTable.Columns.Add("Price", GetType(String), "Avg(Child.Price)")
      invoiceItemTable.Columns.Add("Total", GetType(String), "Quantity * Avg(Child.Price)")
      invoiceItemTable.Columns.Add("Description", GetType(String), "MAX(Child.Description)")
      invoiceTable.Columns.Add("Description", GetType(String), "InvoiceNumber + ': ' + InvoiceDate")
    End Sub 'InitializeData


    ' <summary>
    ' Simple Data Binding
    ' </summary>
    Private Sub Example1()
      ' Bind the Textbox to the Product's Description
      txtDesc.DataBindings.Add("Text", productTable, "Description")

      ' Bind the Value of the Check box to the InStock column
      chkInStock.DataBindings.Add("Checked", productTable, "InStock")
    End Sub 'Example1


    ' <summary>
    ' Complex  Binding to a List Based Control
    ' </summary>
    Private Sub Example2()
      ' Bind the Products to the ListBox
      listProducts.DataSource = productTable
      listProducts.DisplayMember = "Description"
      listProducts.ValueMember = "ProductID"
    End Sub 'Example2


    ' <summary>
    ' DataGrid Binding
    ' </summary>
    Private Sub Example3()
      ' Bind the Grid to the ProductTable
      theGrid.SetDataBinding(productTable, "")
    End Sub 'Example3

    ' Could have used the following:
    ' theGrid.SetDataBinding(dataSet, "Products");

    ' <summary>
    ' DataGrid DataView Binding
    ' </summary>
    Private Sub Example4()
      ' Create a DataView that is sorted by Price
      Dim sortedView As New DataView(productTable, "", "Price", DataViewRowState.CurrentRows)

      ' Set the DataBinding to the DataView
      theDataViewGrid.SetDataBinding(sortedView, "")
    End Sub 'Example4


    ' <summary>
    ' DataGrid Relational Binding
    ' </summary>
    Private Sub Example5()
      theDSGrid.SetDataBinding(customerTable, "")
    End Sub 'Example5


    ' <summary>
    ' Master-Detail-Detail Binding
    ' </summary>
    Private Sub Example6()
      ' Bind the Master 
      parentGrid.SetDataBinding(customerTable, "")

      ' Bind the Detail 
      childGrid.SetDataBinding(customerTable, "Customers_Invoices")
    End Sub 'Example6


    ' <summary>
    ' Master-Detail-Detail Binding
    ' </summary>
    Private Sub Example7()
      ' Bind the master 
      gridMaster.SetDataBinding(customerTable, "")

      ' Bind the Detail 
      gridDetail.SetDataBinding(customerTable, "Customers_Invoices")

      ' Bind the Detail 
      gridInvoiceDetail.SetDataBinding(customerTable, "Customers_Invoices.Invoices_InvoiceItems")
    End Sub 'Example7


    ' <summary>
    ' Master-Detail Binding with CurrencyManager
    ' </summary>
    Private Sub Example8()
      ' Bind the master controls
      txtCustName.DataBindings.Add("Text", customerTable, "FullName")
      txtAddress.DataBindings.Add("Text", customerTable, "Address")
      txtCity.DataBindings.Add("Text", customerTable, "City")
      txtState.DataBindings.Add("Text", customerTable, "State")
      txtZip.DataBindings.Add("Text", customerTable, "Zip")
      txtHomePhone.DataBindings.Add("Text", customerTable, "HomePhone")
      txtWorkPhone.DataBindings.Add("Text", customerTable, "BusinessPhone")

      ' Bind the Invoices 
      listInvoices.DataSource = customerTable
      listInvoices.DisplayMember = "Customers_Invoices.Description"

      ' Bind the Detail 
      Detail6.SetDataBinding(customerTable, "Customers_Invoices.Invoices_InvoiceItems")
    End Sub 'Example8


    Private Sub btnFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      BindingContext(customerTable).Position = 0
    End Sub 'btnFirst_Click


    Private Sub btnPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      If BindingContext(customerTable).Position <> 0 Then
        BindingContext(customerTable).Position -= 1
      End If
    End Sub 'btnPrev_Click

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      If BindingContext(customerTable).Position < BindingContext(customerTable).Count - 1 Then
        BindingContext(customerTable).Position += 1
      End If
    End Sub 'btnNext_Click

    Private Sub btnLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      BindingContext(customerTable).Position = BindingContext(customerTable).Count - 1
    End Sub 'btnLast_Click
  End Class 'DataBindingForm
End Namespace 'BookExamples