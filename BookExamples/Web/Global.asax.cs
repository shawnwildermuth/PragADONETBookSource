using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;

namespace BookExamples 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		public Global()
		{
			InitializeComponent();
      InitializeData();
    }	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
      Session.Add("productTable",     productTable);
      Session.Add("customerTable",    customerTable);
      Session.Add("invoiceTable",     invoiceTable);
      Session.Add("invoiceItemTable", invoiceItemTable);
      Session.Add("dataSet",          dataSet);
    }

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion

    private DataSet   dataSet;
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
      dataSet = new DataSet();

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
  
  }
}

