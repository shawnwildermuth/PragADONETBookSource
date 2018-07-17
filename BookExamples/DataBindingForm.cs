using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BookExamples
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class DataBindingForm : System.Windows.Forms.Form
  {
    #region controls
    private System.Windows.Forms.TabPage Ex1;
    private System.Windows.Forms.TabPage Ex2;
    private System.Windows.Forms.TabPage Ex3;
    internal System.Windows.Forms.TextBox txtDesc;
    private System.Windows.Forms.Label asdf;
    private System.Windows.Forms.CheckBox chkInStock;
    private System.Windows.Forms.Button btnShowPID;
    private System.Windows.Forms.ListBox listProducts;
    private System.Windows.Forms.DataGrid theGrid;
    private System.Windows.Forms.DataGrid gridDetail;
    private System.Windows.Forms.DataGrid gridMaster;
    private System.Windows.Forms.DataGrid gridInvoiceDetail;
    private System.Windows.Forms.Button btnFirst;
    private System.Windows.Forms.Button btnPrev;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnLast;
    private System.Windows.Forms.TextBox txtCustName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.TextBox txtCity;
    private System.Windows.Forms.TextBox txtState;
    private System.Windows.Forms.TextBox txtZip;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ListBox listInvoices;
    private System.Windows.Forms.TextBox txtHomePhone;
    private System.Windows.Forms.TextBox txtWorkPhone;
    private System.Windows.Forms.DataGrid Detail6;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TabControl theTabCtrl;
    private System.Windows.Forms.DataGrid theDSGrid;
    private System.Windows.Forms.DataGrid theDataViewGrid;
    private System.Windows.Forms.TabPage Ex4;
    private System.Windows.Forms.TabPage Ex5;
    private System.Windows.Forms.TabPage Ex7;
    private System.Windows.Forms.TabPage Ex6;
    private System.Windows.Forms.DataGrid parentGrid;
    private System.Windows.Forms.DataGrid childGrid;
    private System.Windows.Forms.TabPage Ex8;
    #endregion
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public DataBindingForm()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

		#region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.theTabCtrl = new System.Windows.Forms.TabControl();
      this.Ex1 = new System.Windows.Forms.TabPage();
      this.chkInStock = new System.Windows.Forms.CheckBox();
      this.asdf = new System.Windows.Forms.Label();
      this.txtDesc = new System.Windows.Forms.TextBox();
      this.Ex2 = new System.Windows.Forms.TabPage();
      this.listProducts = new System.Windows.Forms.ListBox();
      this.btnShowPID = new System.Windows.Forms.Button();
      this.Ex3 = new System.Windows.Forms.TabPage();
      this.theGrid = new System.Windows.Forms.DataGrid();
      this.Ex7 = new System.Windows.Forms.TabPage();
      this.gridInvoiceDetail = new System.Windows.Forms.DataGrid();
      this.gridMaster = new System.Windows.Forms.DataGrid();
      this.gridDetail = new System.Windows.Forms.DataGrid();
      this.Ex8 = new System.Windows.Forms.TabPage();
      this.label5 = new System.Windows.Forms.Label();
      this.txtWorkPhone = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtHomePhone = new System.Windows.Forms.TextBox();
      this.txtZip = new System.Windows.Forms.TextBox();
      this.txtState = new System.Windows.Forms.TextBox();
      this.txtCity = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtAddress = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.listInvoices = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnLast = new System.Windows.Forms.Button();
      this.btnNext = new System.Windows.Forms.Button();
      this.btnPrev = new System.Windows.Forms.Button();
      this.btnFirst = new System.Windows.Forms.Button();
      this.txtCustName = new System.Windows.Forms.TextBox();
      this.Detail6 = new System.Windows.Forms.DataGrid();
      this.label4 = new System.Windows.Forms.Label();
      this.Ex4 = new System.Windows.Forms.TabPage();
      this.Ex5 = new System.Windows.Forms.TabPage();
      this.theDSGrid = new System.Windows.Forms.DataGrid();
      this.theDataViewGrid = new System.Windows.Forms.DataGrid();
      this.Ex6 = new System.Windows.Forms.TabPage();
      this.parentGrid = new System.Windows.Forms.DataGrid();
      this.childGrid = new System.Windows.Forms.DataGrid();
      this.theTabCtrl.SuspendLayout();
      this.Ex1.SuspendLayout();
      this.Ex2.SuspendLayout();
      this.Ex3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.theGrid)).BeginInit();
      this.Ex7.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceDetail)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
      this.Ex8.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Detail6)).BeginInit();
      this.Ex4.SuspendLayout();
      this.Ex5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.theDSGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.theDataViewGrid)).BeginInit();
      this.Ex6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.parentGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.childGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // theTabCtrl
      // 
      this.theTabCtrl.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.Ex1,
                                                                             this.Ex2,
                                                                             this.Ex3,
                                                                             this.Ex4,
                                                                             this.Ex5,
                                                                             this.Ex6,
                                                                             this.Ex7,
                                                                             this.Ex8});
      this.theTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.theTabCtrl.Name = "theTabCtrl";
      this.theTabCtrl.SelectedIndex = 0;
      this.theTabCtrl.Size = new System.Drawing.Size(472, 339);
      this.theTabCtrl.TabIndex = 0;
      // 
      // Ex1
      // 
      this.Ex1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.chkInStock,
                                                                      this.asdf,
                                                                      this.txtDesc});
      this.Ex1.Location = new System.Drawing.Point(4, 22);
      this.Ex1.Name = "Ex1";
      this.Ex1.Size = new System.Drawing.Size(464, 313);
      this.Ex1.TabIndex = 0;
      this.Ex1.Text = "Ex 1";
      // 
      // chkInStock
      // 
      this.chkInStock.Location = new System.Drawing.Point(80, 40);
      this.chkInStock.Name = "chkInStock";
      this.chkInStock.TabIndex = 2;
      this.chkInStock.Text = "In stock?";
      // 
      // asdf
      // 
      this.asdf.Location = new System.Drawing.Point(8, 16);
      this.asdf.Name = "asdf";
      this.asdf.Size = new System.Drawing.Size(64, 16);
      this.asdf.TabIndex = 1;
      this.asdf.Text = "Description:";
      // 
      // txtDesc
      // 
      this.txtDesc.Location = new System.Drawing.Point(80, 16);
      this.txtDesc.Name = "txtDesc";
      this.txtDesc.Size = new System.Drawing.Size(136, 20);
      this.txtDesc.TabIndex = 0;
      this.txtDesc.Text = "";
      // 
      // Ex2
      // 
      this.Ex2.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.listProducts,
                                                                      this.btnShowPID});
      this.Ex2.Location = new System.Drawing.Point(4, 22);
      this.Ex2.Name = "Ex2";
      this.Ex2.Size = new System.Drawing.Size(464, 313);
      this.Ex2.TabIndex = 1;
      this.Ex2.Text = "Ex 2";
      // 
      // listProducts
      // 
      this.listProducts.Location = new System.Drawing.Point(16, 24);
      this.listProducts.Name = "listProducts";
      this.listProducts.Size = new System.Drawing.Size(168, 186);
      this.listProducts.TabIndex = 2;
      // 
      // btnShowPID
      // 
      this.btnShowPID.Location = new System.Drawing.Point(16, 216);
      this.btnShowPID.Name = "btnShowPID";
      this.btnShowPID.Size = new System.Drawing.Size(168, 24);
      this.btnShowPID.TabIndex = 1;
      this.btnShowPID.Text = "Show ProductID of Selected";
      this.btnShowPID.Click += new System.EventHandler(this.btnShowPID_Click);
      // 
      // Ex3
      // 
      this.Ex3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.theGrid});
      this.Ex3.Location = new System.Drawing.Point(4, 22);
      this.Ex3.Name = "Ex3";
      this.Ex3.Size = new System.Drawing.Size(464, 313);
      this.Ex3.TabIndex = 2;
      this.Ex3.Text = "Ex 3";
      // 
      // theGrid
      // 
      this.theGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.theGrid.BackColor = System.Drawing.Color.Gainsboro;
      this.theGrid.BackgroundColor = System.Drawing.Color.DarkGray;
      this.theGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.theGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.theGrid.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.theGrid.CaptionForeColor = System.Drawing.Color.Black;
      this.theGrid.DataMember = "";
      this.theGrid.FlatMode = true;
      this.theGrid.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.theGrid.ForeColor = System.Drawing.Color.Black;
      this.theGrid.GridLineColor = System.Drawing.Color.Silver;
      this.theGrid.HeaderBackColor = System.Drawing.Color.Black;
      this.theGrid.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.theGrid.HeaderForeColor = System.Drawing.Color.White;
      this.theGrid.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.theGrid.Location = new System.Drawing.Point(8, 16);
      this.theGrid.Name = "theGrid";
      this.theGrid.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.theGrid.ParentRowsForeColor = System.Drawing.Color.Black;
      this.theGrid.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.theGrid.SelectionForeColor = System.Drawing.Color.White;
      this.theGrid.Size = new System.Drawing.Size(448, 288);
      this.theGrid.TabIndex = 0;
      // 
      // Ex7
      // 
      this.Ex7.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.gridInvoiceDetail,
                                                                      this.gridMaster,
                                                                      this.gridDetail});
      this.Ex7.Location = new System.Drawing.Point(4, 22);
      this.Ex7.Name = "Ex7";
      this.Ex7.Size = new System.Drawing.Size(464, 313);
      this.Ex7.TabIndex = 3;
      this.Ex7.Text = "Ex 7";
      // 
      // gridInvoiceDetail
      // 
      this.gridInvoiceDetail.AllowNavigation = false;
      this.gridInvoiceDetail.AllowSorting = false;
      this.gridInvoiceDetail.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.gridInvoiceDetail.BackColor = System.Drawing.Color.Gainsboro;
      this.gridInvoiceDetail.BackgroundColor = System.Drawing.Color.DarkGray;
      this.gridInvoiceDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.gridInvoiceDetail.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.gridInvoiceDetail.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridInvoiceDetail.CaptionForeColor = System.Drawing.Color.Black;
      this.gridInvoiceDetail.CaptionVisible = false;
      this.gridInvoiceDetail.DataMember = "";
      this.gridInvoiceDetail.FlatMode = true;
      this.gridInvoiceDetail.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.gridInvoiceDetail.ForeColor = System.Drawing.Color.Black;
      this.gridInvoiceDetail.GridLineColor = System.Drawing.Color.Silver;
      this.gridInvoiceDetail.HeaderBackColor = System.Drawing.Color.Black;
      this.gridInvoiceDetail.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridInvoiceDetail.HeaderForeColor = System.Drawing.Color.White;
      this.gridInvoiceDetail.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.gridInvoiceDetail.Location = new System.Drawing.Point(8, 224);
      this.gridInvoiceDetail.Name = "gridInvoiceDetail";
      this.gridInvoiceDetail.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.gridInvoiceDetail.ParentRowsForeColor = System.Drawing.Color.Black;
      this.gridInvoiceDetail.ParentRowsVisible = false;
      this.gridInvoiceDetail.ReadOnly = true;
      this.gridInvoiceDetail.RowHeadersVisible = false;
      this.gridInvoiceDetail.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.gridInvoiceDetail.SelectionForeColor = System.Drawing.Color.White;
      this.gridInvoiceDetail.Size = new System.Drawing.Size(456, 88);
      this.gridInvoiceDetail.TabIndex = 3;
      // 
      // gridMaster
      // 
      this.gridMaster.AllowNavigation = false;
      this.gridMaster.AllowSorting = false;
      this.gridMaster.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.gridMaster.BackColor = System.Drawing.Color.Gainsboro;
      this.gridMaster.BackgroundColor = System.Drawing.Color.DarkGray;
      this.gridMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.gridMaster.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.gridMaster.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridMaster.CaptionForeColor = System.Drawing.Color.Black;
      this.gridMaster.CaptionVisible = false;
      this.gridMaster.DataMember = "";
      this.gridMaster.FlatMode = true;
      this.gridMaster.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.gridMaster.ForeColor = System.Drawing.Color.Black;
      this.gridMaster.GridLineColor = System.Drawing.Color.Silver;
      this.gridMaster.HeaderBackColor = System.Drawing.Color.Black;
      this.gridMaster.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridMaster.HeaderForeColor = System.Drawing.Color.White;
      this.gridMaster.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.gridMaster.Location = new System.Drawing.Point(8, 8);
      this.gridMaster.Name = "gridMaster";
      this.gridMaster.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.gridMaster.ParentRowsForeColor = System.Drawing.Color.Black;
      this.gridMaster.ParentRowsVisible = false;
      this.gridMaster.RowHeadersVisible = false;
      this.gridMaster.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.gridMaster.SelectionForeColor = System.Drawing.Color.White;
      this.gridMaster.Size = new System.Drawing.Size(456, 104);
      this.gridMaster.TabIndex = 2;
      // 
      // gridDetail
      // 
      this.gridDetail.AllowNavigation = false;
      this.gridDetail.AllowSorting = false;
      this.gridDetail.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.gridDetail.BackColor = System.Drawing.Color.Gainsboro;
      this.gridDetail.BackgroundColor = System.Drawing.Color.DarkGray;
      this.gridDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.gridDetail.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.gridDetail.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridDetail.CaptionForeColor = System.Drawing.Color.Black;
      this.gridDetail.CaptionVisible = false;
      this.gridDetail.DataMember = "";
      this.gridDetail.FlatMode = true;
      this.gridDetail.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.gridDetail.ForeColor = System.Drawing.Color.Black;
      this.gridDetail.GridLineColor = System.Drawing.Color.Silver;
      this.gridDetail.HeaderBackColor = System.Drawing.Color.Black;
      this.gridDetail.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridDetail.HeaderForeColor = System.Drawing.Color.White;
      this.gridDetail.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.gridDetail.Location = new System.Drawing.Point(8, 112);
      this.gridDetail.Name = "gridDetail";
      this.gridDetail.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.gridDetail.ParentRowsForeColor = System.Drawing.Color.Black;
      this.gridDetail.ParentRowsVisible = false;
      this.gridDetail.ReadOnly = true;
      this.gridDetail.RowHeadersVisible = false;
      this.gridDetail.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.gridDetail.SelectionForeColor = System.Drawing.Color.White;
      this.gridDetail.Size = new System.Drawing.Size(456, 112);
      this.gridDetail.TabIndex = 1;
      // 
      // Ex8
      // 
      this.Ex8.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.label5,
                                                                      this.txtWorkPhone,
                                                                      this.label3,
                                                                      this.txtHomePhone,
                                                                      this.txtZip,
                                                                      this.txtState,
                                                                      this.txtCity,
                                                                      this.label2,
                                                                      this.txtAddress,
                                                                      this.groupBox1,
                                                                      this.label1,
                                                                      this.btnLast,
                                                                      this.btnNext,
                                                                      this.btnPrev,
                                                                      this.btnFirst,
                                                                      this.txtCustName,
                                                                      this.Detail6,
                                                                      this.label4});
      this.Ex8.Location = new System.Drawing.Point(4, 22);
      this.Ex8.Name = "Ex8";
      this.Ex8.Size = new System.Drawing.Size(464, 313);
      this.Ex8.TabIndex = 5;
      this.Ex8.Text = "Ex 8";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(296, 80);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(32, 16);
      this.label5.TabIndex = 25;
      this.label5.Text = "(Wk)";
      // 
      // txtWorkPhone
      // 
      this.txtWorkPhone.Location = new System.Drawing.Point(200, 80);
      this.txtWorkPhone.Name = "txtWorkPhone";
      this.txtWorkPhone.Size = new System.Drawing.Size(96, 20);
      this.txtWorkPhone.TabIndex = 23;
      this.txtWorkPhone.Text = "";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(8, 80);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(64, 16);
      this.label3.TabIndex = 22;
      this.label3.Text = "Phone:";
      // 
      // txtHomePhone
      // 
      this.txtHomePhone.Location = new System.Drawing.Point(72, 80);
      this.txtHomePhone.Name = "txtHomePhone";
      this.txtHomePhone.Size = new System.Drawing.Size(96, 20);
      this.txtHomePhone.TabIndex = 21;
      this.txtHomePhone.Text = "";
      // 
      // txtZip
      // 
      this.txtZip.Location = new System.Drawing.Point(264, 56);
      this.txtZip.Name = "txtZip";
      this.txtZip.Size = new System.Drawing.Size(56, 20);
      this.txtZip.TabIndex = 20;
      this.txtZip.Text = "textBox3";
      // 
      // txtState
      // 
      this.txtState.Location = new System.Drawing.Point(224, 56);
      this.txtState.Name = "txtState";
      this.txtState.Size = new System.Drawing.Size(32, 20);
      this.txtState.TabIndex = 19;
      this.txtState.Text = "textBox2";
      // 
      // txtCity
      // 
      this.txtCity.Location = new System.Drawing.Point(72, 56);
      this.txtCity.Name = "txtCity";
      this.txtCity.Size = new System.Drawing.Size(144, 20);
      this.txtCity.TabIndex = 18;
      this.txtCity.Text = "textBox1";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(8, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 16);
      this.label2.TabIndex = 17;
      this.label2.Text = "Address:";
      // 
      // txtAddress
      // 
      this.txtAddress.Location = new System.Drawing.Point(72, 32);
      this.txtAddress.Name = "txtAddress";
      this.txtAddress.Size = new System.Drawing.Size(248, 20);
      this.txtAddress.TabIndex = 16;
      this.txtAddress.Text = "";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.listInvoices});
      this.groupBox1.Location = new System.Drawing.Point(336, 32);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(128, 192);
      this.groupBox1.TabIndex = 15;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Invoices";
      // 
      // listInvoices
      // 
      this.listInvoices.Location = new System.Drawing.Point(8, 16);
      this.listInvoices.Name = "listInvoices";
      this.listInvoices.Size = new System.Drawing.Size(112, 160);
      this.listInvoices.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(8, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 16);
      this.label1.TabIndex = 14;
      this.label1.Text = "Customer:";
      // 
      // btnLast
      // 
      this.btnLast.Location = new System.Drawing.Point(432, 0);
      this.btnLast.Name = "btnLast";
      this.btnLast.Size = new System.Drawing.Size(32, 24);
      this.btnLast.TabIndex = 13;
      this.btnLast.Text = ">>";
      this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
      // 
      // btnNext
      // 
      this.btnNext.Location = new System.Drawing.Point(400, 0);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new System.Drawing.Size(32, 24);
      this.btnNext.TabIndex = 12;
      this.btnNext.Text = ">";
      this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
      // 
      // btnPrev
      // 
      this.btnPrev.Location = new System.Drawing.Point(368, 0);
      this.btnPrev.Name = "btnPrev";
      this.btnPrev.Size = new System.Drawing.Size(32, 24);
      this.btnPrev.TabIndex = 11;
      this.btnPrev.Text = "<";
      this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
      // 
      // btnFirst
      // 
      this.btnFirst.Location = new System.Drawing.Point(336, 0);
      this.btnFirst.Name = "btnFirst";
      this.btnFirst.Size = new System.Drawing.Size(32, 24);
      this.btnFirst.TabIndex = 10;
      this.btnFirst.Text = "<<";
      this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
      // 
      // txtCustName
      // 
      this.txtCustName.Location = new System.Drawing.Point(72, 8);
      this.txtCustName.Name = "txtCustName";
      this.txtCustName.Size = new System.Drawing.Size(248, 20);
      this.txtCustName.TabIndex = 9;
      this.txtCustName.Text = "";
      // 
      // Detail6
      // 
      this.Detail6.AllowNavigation = false;
      this.Detail6.AllowSorting = false;
      this.Detail6.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.Detail6.BackColor = System.Drawing.Color.Gainsboro;
      this.Detail6.BackgroundColor = System.Drawing.Color.DarkGray;
      this.Detail6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Detail6.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.Detail6.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.Detail6.CaptionForeColor = System.Drawing.Color.Black;
      this.Detail6.CaptionVisible = false;
      this.Detail6.DataMember = "";
      this.Detail6.FlatMode = true;
      this.Detail6.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.Detail6.ForeColor = System.Drawing.Color.Black;
      this.Detail6.GridLineColor = System.Drawing.Color.Silver;
      this.Detail6.HeaderBackColor = System.Drawing.Color.Black;
      this.Detail6.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.Detail6.HeaderForeColor = System.Drawing.Color.White;
      this.Detail6.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.Detail6.Location = new System.Drawing.Point(4, 224);
      this.Detail6.Name = "Detail6";
      this.Detail6.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.Detail6.ParentRowsForeColor = System.Drawing.Color.Black;
      this.Detail6.ParentRowsVisible = false;
      this.Detail6.ReadOnly = true;
      this.Detail6.RowHeadersVisible = false;
      this.Detail6.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.Detail6.SelectionForeColor = System.Drawing.Color.White;
      this.Detail6.Size = new System.Drawing.Size(456, 88);
      this.Detail6.TabIndex = 8;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(168, 80);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(32, 16);
      this.label4.TabIndex = 24;
      this.label4.Text = "(Hm)";
      // 
      // Ex4
      // 
      this.Ex4.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.theDataViewGrid});
      this.Ex4.Location = new System.Drawing.Point(4, 22);
      this.Ex4.Name = "Ex4";
      this.Ex4.Size = new System.Drawing.Size(464, 313);
      this.Ex4.TabIndex = 6;
      this.Ex4.Text = "Ex4";
      // 
      // Ex5
      // 
      this.Ex5.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.theDSGrid});
      this.Ex5.Location = new System.Drawing.Point(4, 22);
      this.Ex5.Name = "Ex5";
      this.Ex5.Size = new System.Drawing.Size(464, 313);
      this.Ex5.TabIndex = 7;
      this.Ex5.Text = "Ex 5";
      // 
      // theDSGrid
      // 
      this.theDSGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.theDSGrid.BackColor = System.Drawing.Color.Gainsboro;
      this.theDSGrid.BackgroundColor = System.Drawing.Color.DarkGray;
      this.theDSGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.theDSGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.theDSGrid.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.theDSGrid.CaptionForeColor = System.Drawing.Color.Black;
      this.theDSGrid.DataMember = "";
      this.theDSGrid.FlatMode = true;
      this.theDSGrid.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.theDSGrid.ForeColor = System.Drawing.Color.Black;
      this.theDSGrid.GridLineColor = System.Drawing.Color.Silver;
      this.theDSGrid.HeaderBackColor = System.Drawing.Color.Black;
      this.theDSGrid.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.theDSGrid.HeaderForeColor = System.Drawing.Color.White;
      this.theDSGrid.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.theDSGrid.Location = new System.Drawing.Point(8, 16);
      this.theDSGrid.Name = "theDSGrid";
      this.theDSGrid.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.theDSGrid.ParentRowsForeColor = System.Drawing.Color.Black;
      this.theDSGrid.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.theDSGrid.SelectionForeColor = System.Drawing.Color.White;
      this.theDSGrid.Size = new System.Drawing.Size(448, 288);
      this.theDSGrid.TabIndex = 1;
      // 
      // theDataViewGrid
      // 
      this.theDataViewGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.theDataViewGrid.BackColor = System.Drawing.Color.Gainsboro;
      this.theDataViewGrid.BackgroundColor = System.Drawing.Color.DarkGray;
      this.theDataViewGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.theDataViewGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.theDataViewGrid.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.theDataViewGrid.CaptionForeColor = System.Drawing.Color.Black;
      this.theDataViewGrid.DataMember = "";
      this.theDataViewGrid.FlatMode = true;
      this.theDataViewGrid.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.theDataViewGrid.ForeColor = System.Drawing.Color.Black;
      this.theDataViewGrid.GridLineColor = System.Drawing.Color.Silver;
      this.theDataViewGrid.HeaderBackColor = System.Drawing.Color.Black;
      this.theDataViewGrid.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.theDataViewGrid.HeaderForeColor = System.Drawing.Color.White;
      this.theDataViewGrid.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.theDataViewGrid.Location = new System.Drawing.Point(8, 16);
      this.theDataViewGrid.Name = "theDataViewGrid";
      this.theDataViewGrid.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.theDataViewGrid.ParentRowsForeColor = System.Drawing.Color.Black;
      this.theDataViewGrid.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.theDataViewGrid.SelectionForeColor = System.Drawing.Color.White;
      this.theDataViewGrid.Size = new System.Drawing.Size(448, 288);
      this.theDataViewGrid.TabIndex = 1;
      // 
      // Ex6
      // 
      this.Ex6.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.parentGrid,
                                                                      this.childGrid});
      this.Ex6.Location = new System.Drawing.Point(4, 22);
      this.Ex6.Name = "Ex6";
      this.Ex6.Size = new System.Drawing.Size(464, 313);
      this.Ex6.TabIndex = 8;
      this.Ex6.Text = "Ex 6";
      // 
      // parentGrid
      // 
      this.parentGrid.AllowNavigation = false;
      this.parentGrid.AllowSorting = false;
      this.parentGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.parentGrid.BackColor = System.Drawing.Color.Gainsboro;
      this.parentGrid.BackgroundColor = System.Drawing.Color.DarkGray;
      this.parentGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.parentGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.parentGrid.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.parentGrid.CaptionForeColor = System.Drawing.Color.Black;
      this.parentGrid.CaptionVisible = false;
      this.parentGrid.DataMember = "";
      this.parentGrid.FlatMode = true;
      this.parentGrid.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.parentGrid.ForeColor = System.Drawing.Color.Black;
      this.parentGrid.GridLineColor = System.Drawing.Color.Silver;
      this.parentGrid.HeaderBackColor = System.Drawing.Color.Black;
      this.parentGrid.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.parentGrid.HeaderForeColor = System.Drawing.Color.White;
      this.parentGrid.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.parentGrid.Location = new System.Drawing.Point(4, 8);
      this.parentGrid.Name = "parentGrid";
      this.parentGrid.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.parentGrid.ParentRowsForeColor = System.Drawing.Color.Black;
      this.parentGrid.ParentRowsVisible = false;
      this.parentGrid.RowHeadersVisible = false;
      this.parentGrid.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.parentGrid.SelectionForeColor = System.Drawing.Color.White;
      this.parentGrid.Size = new System.Drawing.Size(456, 104);
      this.parentGrid.TabIndex = 4;
      // 
      // childGrid
      // 
      this.childGrid.AllowNavigation = false;
      this.childGrid.AllowSorting = false;
      this.childGrid.AlternatingBackColor = System.Drawing.Color.WhiteSmoke;
      this.childGrid.BackColor = System.Drawing.Color.Gainsboro;
      this.childGrid.BackgroundColor = System.Drawing.Color.DarkGray;
      this.childGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.childGrid.CaptionBackColor = System.Drawing.Color.DarkKhaki;
      this.childGrid.CaptionFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.childGrid.CaptionForeColor = System.Drawing.Color.Black;
      this.childGrid.CaptionVisible = false;
      this.childGrid.DataMember = "";
      this.childGrid.FlatMode = true;
      this.childGrid.Font = new System.Drawing.Font("Times New Roman", 9F);
      this.childGrid.ForeColor = System.Drawing.Color.Black;
      this.childGrid.GridLineColor = System.Drawing.Color.Silver;
      this.childGrid.HeaderBackColor = System.Drawing.Color.Black;
      this.childGrid.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.childGrid.HeaderForeColor = System.Drawing.Color.White;
      this.childGrid.LinkColor = System.Drawing.Color.DarkSlateBlue;
      this.childGrid.Location = new System.Drawing.Point(4, 112);
      this.childGrid.Name = "childGrid";
      this.childGrid.ParentRowsBackColor = System.Drawing.Color.LightGray;
      this.childGrid.ParentRowsForeColor = System.Drawing.Color.Black;
      this.childGrid.ParentRowsVisible = false;
      this.childGrid.ReadOnly = true;
      this.childGrid.RowHeadersVisible = false;
      this.childGrid.SelectionBackColor = System.Drawing.Color.Firebrick;
      this.childGrid.SelectionForeColor = System.Drawing.Color.White;
      this.childGrid.Size = new System.Drawing.Size(456, 112);
      this.childGrid.TabIndex = 3;
      // 
      // DataBindingForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(472, 339);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.theTabCtrl});
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DataBindingForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Pragmatic Data Binding";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.theTabCtrl.ResumeLayout(false);
      this.Ex1.ResumeLayout(false);
      this.Ex2.ResumeLayout(false);
      this.Ex3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.theGrid)).EndInit();
      this.Ex7.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceDetail)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
      this.Ex8.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.Detail6)).EndInit();
      this.Ex4.ResumeLayout(false);
      this.Ex5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.theDSGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.theDataViewGrid)).EndInit();
      this.Ex6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.parentGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.childGrid)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion

    #region Event Handlers
    private void menuItem2_Click(object sender, System.EventArgs e)
    {
      Close();
    }

    private void MainForm_Load(object sender, System.EventArgs e)
    {
      InitializeData();
      Example1();    
      Example2();
      Example3();
      Example4();
      Example5();
      Example6();
      Example7();
      Example8();
    }
    private void btnShowPID_Click(object sender, System.EventArgs e)
    {
      MessageBox.Show(string.Format("Selected Product's ID: {0}", listProducts.SelectedValue));
    }
    #endregion

    #region Example Code
    private DataSet dataSet = new DataSet();
    private DataTable customerTable;
    private DataTable invoiceTable;
    private DataTable invoiceItemTable;
    private DataTable productTable;

    private void InitializeData()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter daCustomers = new 
        SqlDataAdapter("SELECT * FROM CUSTOMER;", 
        conn);
      SqlDataAdapter daInvoices = new 
        SqlDataAdapter("SELECT * FROM INVOICE;", 
        conn);
      SqlDataAdapter daInvoiceItems = new 
        SqlDataAdapter("SELECT * FROM INVOICEITEM;", 
        conn);
      SqlDataAdapter daProducts = new 
        SqlDataAdapter("SELECT * FROM PRODUCT;", 
        conn);

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");
      daProducts.Fill(dataSet, "Products");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      customerTable    = dataSet.Tables["Customers"];
      invoiceTable     = dataSet.Tables["Invoices"];
      invoiceItemTable = dataSet.Tables["InvoiceItems"];
      productTable     = dataSet.Tables["Products"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };
      productTable.PrimaryKey = new DataColumn[] 
        { productTable.Columns["ProductID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        invoiceTable.Columns["InvoiceID"], 
        invoiceItemTable.Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        customerTable.Columns["CustomerID"], 
        invoiceTable.Columns["CustomerID"], 
        true);

      // Create the second Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "InvoiceItems_Products", 
        invoiceItemTable.Columns["ProductID"], 
        productTable.Columns["ProductID"], 
        false);

      // Add a few Expression Columns
      customerTable.Columns.Add("FullName", typeof(string), "LastName + ', ' + FirstName");
      invoiceItemTable.Columns.Add("Price", typeof(string), "Avg(Child.Price)");
      invoiceItemTable.Columns.Add("Total", typeof(string), "Quantity * Avg(Child.Price)");
      invoiceItemTable.Columns.Add("Description", typeof(string), "MAX(Child.Description)");
      invoiceTable.Columns.Add("Description", typeof(string), "InvoiceNumber + ': ' + InvoiceDate");

    }

    /// <summary>
    /// Simple Data Binding
    /// </summary>
    private void Example1()
    {
      // Bind the Textbox to the Product's Description
      txtDesc.DataBindings.Add("Text", productTable, "Description");

      // Bind the Value of the Check box to the InStock column
      chkInStock.DataBindings.Add("Checked", productTable, "InStock");
    }

    /// <summary>
    /// Complex  Binding to a List Based Control
    /// </summary>
    private void Example2()
    {
      // Bind the Products to the ListBox
      listProducts.DataSource = productTable;
      listProducts.DisplayMember = "Description";
      listProducts.ValueMember = "ProductID";
    }

    /// <summary>
    /// DataGrid Binding
    /// </summary>
    private void Example3()
    {
      // Bind the Grid to the ProductTable
      theGrid.SetDataBinding(productTable, "");

      // Could have used the following:
      // theGrid.SetDataBinding(dataSet, "Products");
    }

    /// <summary>
    /// DataGrid DataView Binding
    /// </summary>
    private void Example4()
    {
      // Create a DataView that is sorted by Price
      DataView sortedView = new DataView(productTable, 
        "", 
        "Price", 
        DataViewRowState.CurrentRows);

      // Set the DataBinding to the DataView
      theDataViewGrid.SetDataBinding(sortedView, "");
    }

    /// <summary>
    /// DataGrid Relational Binding
    /// </summary>
    private void Example5()
    {
      theDSGrid.SetDataBinding(customerTable, "");
    }

    /// <summary>
    /// Master-Detail-Detail Binding
    /// </summary>
    private void Example6()
    {
      // Bind the Master 
      parentGrid.SetDataBinding(customerTable, "");

      // Bind the Detail 
      childGrid.SetDataBinding(customerTable, "Customers_Invoices");
    
    }

    /// <summary>
    /// Master-Detail-Detail Binding
    /// </summary>
    private void Example7()
    {
      // Bind the master 
      gridMaster.SetDataBinding(customerTable, "");

      // Bind the Detail 
      gridDetail.SetDataBinding(customerTable, "Customers_Invoices");

      // Bind the Detail 
      gridInvoiceDetail.SetDataBinding(customerTable, "Customers_Invoices.Invoices_InvoiceItems");
    
    }

    /// <summary>
    /// Master-Detail Binding with CurrencyManager
    /// </summary>
    private void Example8()
    {
      // Bind the master controls
      txtCustName.DataBindings.Add("Text", customerTable, "FullName");
      txtAddress.DataBindings.Add("Text", customerTable, "Address");
      txtCity.DataBindings.Add("Text", customerTable, "City");
      txtState.DataBindings.Add("Text", customerTable, "State");
      txtZip.DataBindings.Add("Text", customerTable, "Zip");
      txtHomePhone.DataBindings.Add("Text", customerTable, "HomePhone");
      txtWorkPhone.DataBindings.Add("Text", customerTable, "BusinessPhone");

      // Bind the Invoices 
      listInvoices.DataSource = customerTable;
      listInvoices.DisplayMember = "Customers_Invoices.Description";

      // Bind the Detail 
      Detail6.SetDataBinding(customerTable, "Customers_Invoices.Invoices_InvoiceItems");

    }
    #endregion


    private void btnFirst_Click(object sender, System.EventArgs e)
    {
      BindingContext[customerTable].Position = 0;
    }

    private void btnPrev_Click(object sender, System.EventArgs e)
    {
      if (BindingContext[customerTable].Position != 0)
        BindingContext[customerTable].Position -= 1;
    }

    private void btnNext_Click(object sender, System.EventArgs e)
    {
      if (BindingContext[customerTable].Position < 
                  BindingContext[customerTable].Count - 1 )
        BindingContext[customerTable].Position += 1;
    }

    private void btnLast_Click(object sender, System.EventArgs e)
    {
      BindingContext[customerTable].Position = BindingContext[customerTable].Count - 1;
    }
  }
}
