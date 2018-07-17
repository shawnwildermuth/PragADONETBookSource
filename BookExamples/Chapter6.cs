using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BookExamples
{
	/// <summary>
	/// Summary description for Chapter6.
	/// </summary>
	public class Chapter6 : BaseChapter
	{
    public void Example1()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter daCustomers = new SqlDataAdapter("SELECT * FROM CUSTOMER;", conn);

      // Create the Invoice DataAdapter
      SqlDataAdapter daInvoices = new SqlDataAdapter("SELECT * FROM INVOICE", conn);

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");

      // Show the Customer Name
      Console.WriteLine(dataSet.Tables["Customers"].Rows[0]["FirstName"].ToString());
      Console.WriteLine(dataSet.Tables["Customers"].Rows[0]["LastName"].ToString());
      Console.WriteLine(dataSet.Tables["Customers"].Rows[0]["HomePhone"].ToString());

      // Change an Invoice Number with a string 
      // this shouldn't work because InvoiceNumber expects an integer
      dataSet.Tables["Invoices"].Rows[0]["InvoiceNumber"] = "15234";

    }

    public void Example2()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter daCustomers = new SqlDataAdapter("SELECT * FROM CUSTOMER;", conn);

      // Create the Invoice DataAdapter
      SqlDataAdapter daInvoices = new SqlDataAdapter("SELECT * FROM INVOICE", conn);

      // Create your blank DataSet
      CustomerTDS dataSet = new CustomerTDS();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");

      // Show the Customer Name
      Console.WriteLine(dataSet.Customer[0].FirstName);
      Console.WriteLine(dataSet.Customer[0].LastName);
      Console.WriteLine(dataSet.Customer[0].HomePhone);

      // This will not compile because InvoiceNumber expects an integer
      //dataSet.Invoice[0].InvoiceNumber = "12345";

    }
    

    public void Example3()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter daCustomers = new 
        SqlDataAdapter("SELECT * FROM CUSTOMER;", 
        conn);

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");

      // Grab our DataTable for simplicity
      DataTable customersTable = dataSet.Tables["Customers"];

      // Improve the schema
      customersTable.Columns["CustomerID"].ReadOnly = true;
      customersTable.Columns["CustomerID"].Unique = true;
      customersTable.Columns["LastName"].MaxLength = 50;
      customersTable.Columns["LastName"].AllowDBNull = false;
      customersTable.Columns["FirstName"].MaxLength = 50;
      customersTable.Columns["FirstName"].AllowDBNull = false;
      customersTable.Columns["MiddleName"].MaxLength = 50;
      customersTable.Columns["State"].DefaultValue = "MA";
      customersTable.Columns["State"].MaxLength = 2;
      customersTable.Columns["HomePhone"].Unique = true;

      // Write out our xsd file to use to generate our typed DataSet
      dataSet.WriteXmlSchema(@"c:\CustomerDS.xsd");

    }  
      
    public void Example4()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter daCustomers = new SqlDataAdapter("SELECT * FROM CUSTOMER;", conn);

      // Create the Invoice DataAdapter
      SqlDataAdapter daInvoices = new SqlDataAdapter("SELECT * FROM INVOICE", conn);

      // Create our New Typed DataAdapter
      CustomersObject dataset = new CustomersObject();

      // Use the DataAdapters to fill the DataSet
      daCustomers.Fill(dataset, "Customer");
      daInvoices.Fill(dataset, "Invoice");

      // This will throw an exception because we're creating an Invoice
      // Date in the future
      CustomerTDS.InvoiceRow invoice = 
        dataset.Invoice.AddInvoiceRow(Guid.NewGuid(),
                                      DateTime.Now + new TimeSpan(4,0,0,0),
                                      "",
                                      "",
                                      "",
                                      dataset.Customer[0]);
      
    }

    public void Example5()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter daCustomers = new SqlDataAdapter("SELECT * FROM CUSTOMER;", conn);

      // Create the Invoice DataAdapter
      SqlDataAdapter daInvoices = new SqlDataAdapter("SELECT * FROM INVOICE", conn);

      // Create our New Typed DataAdapter
      InheritedTDS dataset = new InheritedTDS();

      // Use the DataAdapters to fill the DataSet
      daCustomers.Fill(dataset, "Customer");
      daInvoices.Fill(dataset, "Invoice");

      // Make Sure We are getting the right DataTables
      Console.WriteLine("Number of Customers:        {0}", dataset.Customer.Count);
      Console.WriteLine("Number of Invoices:         {0}", dataset.Invoice.Count);
      Console.WriteLine("Type of DataRow (Invoices): {0}", dataset.Invoice.Rows[0].GetType().FullName );

      form.TheGrid.DataSource = dataset;
      
    }

    public void Example6()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter daCustomers = new SqlDataAdapter("SELECT * FROM CUSTOMER;", conn);

      // Create the Invoice DataAdapter
      SqlDataAdapter daInvoices = new SqlDataAdapter("SELECT * FROM INVOICE", conn);

      // Create the DataSet
      CustomerTDS typedDS = new CustomerTDS();

      // Use the DataAdapters to fill the DataSet
      daCustomers.Fill(typedDS, "Customer");
      daInvoices.Fill(typedDS, "Invoice");

      // Show the address and # of invoices for each customer
      foreach(CustomerTDS.CustomerRow custRow in typedDS.Customer)
      {
        Console.WriteLine(custRow.FullName);
        Console.WriteLine(custRow.Address);
        Console.WriteLine("{0}, {1}  {2}",custRow.City, custRow.State, custRow.Zip);
        Console.WriteLine("{0} (hm)", custRow.IsHomePhoneNull() ? "" : custRow.HomePhone);
        Console.WriteLine("{0} (bus)", custRow.IsBusinessPhoneNull() ? "" : custRow.BusinessPhone);
        Console.WriteLine("Invoices: " + custRow.GetChildRows("CustomerInvoice").Length);
        Console.WriteLine("");
      }
 
    }
  
  }
}
