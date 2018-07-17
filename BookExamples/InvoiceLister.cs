using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BookExamples
{

  public class InvoiceLister : System.Windows.Forms.Form
  {

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtLast;
    private System.Windows.Forms.TextBox txtFirst;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtCity;
    private System.Windows.Forms.TextBox txtState;
    private System.Windows.Forms.TextBox txtZip;
    private CustomerList customers;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.ListView lstInvoices;
    private System.Windows.Forms.ComboBox cbCustomers;
    private System.Windows.Forms.ColumnHeader InvoiceNumber;
    private System.Windows.Forms.ColumnHeader InvoiceDate;
    private System.Windows.Forms.ColumnHeader Terms;
    private System.Windows.Forms.ColumnHeader PO;
    private System.Windows.Forms.ColumnHeader FOB;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public InvoiceLister()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      SqlConnection conn = new SqlConnection("Server=localhost;Database=ADONET;Integrated Security=true;");
      try
      {
        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT Customer.CustomerID, LastName, FirstName, HomePhone, Address, City, State, Zip, " +
          "       InvoiceID, InvoiceNumber, InvoiceDate, Terms, PO, FOB " +
          "  FROM Customer " +
          "  JOIN Invoice on Customer.CustomerID = Invoice.CustomerID " +
          "  ORDER BY LastName";

        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.KeyInfo);
        customers = new CustomerList(rdr);
        rdr.Close();
        cmd.Dispose();
        conn.Dispose();

        // Fill the combobox
        cbCustomers.Items.AddRange(customers.ToArray());

        // Set the selected to the first item
        cbCustomers.SelectedIndex = 0;

      }
      catch (SqlException ex)
      {
        MessageBox.Show("Fatal SQL Error: " + ex.Message);
      }

  
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
      this.txtCity = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtPhone = new System.Windows.Forms.TextBox();
      this.lstInvoices = new System.Windows.Forms.ListView();
      this.InvoiceNumber = new System.Windows.Forms.ColumnHeader();
      this.InvoiceDate = new System.Windows.Forms.ColumnHeader();
      this.Terms = new System.Windows.Forms.ColumnHeader();
      this.txtZip = new System.Windows.Forms.TextBox();
      this.txtState = new System.Windows.Forms.TextBox();
      this.txtAddress = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtFirst = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtLast = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cbCustomers = new System.Windows.Forms.ComboBox();
      this.PO = new System.Windows.Forms.ColumnHeader();
      this.FOB = new System.Windows.Forms.ColumnHeader();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtCity
      // 
      this.txtCity.Location = new System.Drawing.Point(80, 72);
      this.txtCity.Name = "txtCity";
      this.txtCity.ReadOnly = true;
      this.txtCity.Size = new System.Drawing.Size(200, 20);
      this.txtCity.TabIndex = 0;
      this.txtCity.Text = "";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                            this.label5,
                                                                            this.txtPhone,
                                                                            this.lstInvoices,
                                                                            this.txtZip,
                                                                            this.txtState,
                                                                            this.txtCity,
                                                                            this.txtAddress,
                                                                            this.label4,
                                                                            this.txtFirst,
                                                                            this.label3,
                                                                            this.txtLast,
                                                                            this.label2});
      this.groupBox1.Location = new System.Drawing.Point(88, 40);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(456, 272);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Info";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(16, 96);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(64, 16);
      this.label5.TabIndex = 1;
      this.label5.Text = "Phone:";
      // 
      // txtPhone
      // 
      this.txtPhone.Location = new System.Drawing.Point(80, 96);
      this.txtPhone.Name = "txtPhone";
      this.txtPhone.ReadOnly = true;
      this.txtPhone.Size = new System.Drawing.Size(144, 20);
      this.txtPhone.TabIndex = 0;
      this.txtPhone.Text = "";
      // 
      // lstInvoices
      // 
      this.lstInvoices.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.lstInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                  this.InvoiceNumber,
                                                                                  this.InvoiceDate,
                                                                                  this.PO,
                                                                                  this.FOB,
                                                                                  this.Terms});
      this.lstInvoices.Location = new System.Drawing.Point(8, 144);
      this.lstInvoices.Name = "lstInvoices";
      this.lstInvoices.Size = new System.Drawing.Size(440, 120);
      this.lstInvoices.TabIndex = 3;
      this.lstInvoices.View = System.Windows.Forms.View.Details;
      // 
      // InvoiceNumber
      // 
      this.InvoiceNumber.Text = "#";
      this.InvoiceNumber.Width = 40;
      // 
      // InvoiceDate
      // 
      this.InvoiceDate.Text = "Date";
      this.InvoiceDate.Width = 80;
      // 
      // Terms
      // 
      this.Terms.Text = "Terms";
      this.Terms.Width = 200;
      // 
      // txtZip
      // 
      this.txtZip.Location = new System.Drawing.Point(352, 72);
      this.txtZip.Name = "txtZip";
      this.txtZip.ReadOnly = true;
      this.txtZip.Size = new System.Drawing.Size(88, 20);
      this.txtZip.TabIndex = 0;
      this.txtZip.Text = "";
      // 
      // txtState
      // 
      this.txtState.Location = new System.Drawing.Point(288, 72);
      this.txtState.Name = "txtState";
      this.txtState.ReadOnly = true;
      this.txtState.Size = new System.Drawing.Size(64, 20);
      this.txtState.TabIndex = 0;
      this.txtState.Text = "";
      // 
      // txtAddress
      // 
      this.txtAddress.Location = new System.Drawing.Point(80, 48);
      this.txtAddress.Name = "txtAddress";
      this.txtAddress.ReadOnly = true;
      this.txtAddress.Size = new System.Drawing.Size(368, 20);
      this.txtAddress.TabIndex = 0;
      this.txtAddress.Text = "";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(16, 48);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(64, 16);
      this.label4.TabIndex = 1;
      this.label4.Text = "Address:";
      // 
      // txtFirst
      // 
      this.txtFirst.Location = new System.Drawing.Point(304, 24);
      this.txtFirst.Name = "txtFirst";
      this.txtFirst.ReadOnly = true;
      this.txtFirst.Size = new System.Drawing.Size(144, 20);
      this.txtFirst.TabIndex = 0;
      this.txtFirst.Text = "";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(240, 24);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(64, 16);
      this.label3.TabIndex = 1;
      this.label3.Text = "First Name:";
      // 
      // txtLast
      // 
      this.txtLast.Location = new System.Drawing.Point(80, 24);
      this.txtLast.Name = "txtLast";
      this.txtLast.ReadOnly = true;
      this.txtLast.Size = new System.Drawing.Size(144, 20);
      this.txtLast.TabIndex = 0;
      this.txtLast.Text = "";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(16, 24);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "Last Name:";
      this.label2.Click += new System.EventHandler(this.label2_Click);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(8, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Customer:";
      // 
      // cbCustomers
      // 
      this.cbCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCustomers.DropDownWidth = 208;
      this.cbCustomers.Location = new System.Drawing.Point(88, 15);
      this.cbCustomers.Name = "cbCustomers";
      this.cbCustomers.Size = new System.Drawing.Size(208, 21);
      this.cbCustomers.TabIndex = 0;
      this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbAuthors_SelectedIndexChanged);
      // 
      // PO
      // 
      this.PO.Text = "PO";
      // 
      // FOB
      // 
      this.FOB.Text = "FOB";
      // 
      // InvoiceLister
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(552, 318);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.groupBox1,
                                                                  this.label1,
                                                                  this.cbCustomers});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InvoiceLister";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Customer Invoice Lister";
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);

    }
		#endregion

    private void label2_Click(object sender, System.EventArgs e)
    {

    }

    private void cbAuthors_SelectedIndexChanged(object sender, System.EventArgs e)
    {

      // When the user selects and customer, fill in the form
      Customer customer = cbCustomers.SelectedItem as Customer;
      if (customer != null)
      {
        txtLast.Text = customer.LastName;
        txtFirst.Text = customer.FirstName;
        txtAddress.Text = customer.Address;
        txtCity.Text = customer.City;
        txtState.Text = customer.State;
        txtZip.Text = customer.Zip;
        txtPhone.Text = customer.HomePhone;
        AddBooks(customer.Invoices);

      }

    }

    private void AddBooks(InvoiceList invs)
    {
  
      // Clear the Items in the list (lstBooks.Clear() would clear the columns too)      
      lstInvoices.Items.Clear();

      // Go through each book and add an item to the ListView
      foreach (Invoice inv in invs)
      {
        lstInvoices.Items.Add(new ListViewItem(inv.ToStringArray()));
      }

    }

  }

}
