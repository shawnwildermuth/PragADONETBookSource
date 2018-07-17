using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Text;
      
namespace BookExamples
{
	/// <summary>
	/// Summary description for Chapter9.
	/// </summary>
	public class Chapter9 : BaseChapter
	{
    
    /// <summary>
    /// DataSet output as XML
    /// </summary>
    public void Example1()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Write out the XML File
      Console.WriteLine(dataSet.GetXml());

      form.TheGrid.DataSource = customerTable;
    }

    
    /// <summary>
    /// DataSet output as XML with Nested Relationships
    /// </summary>
    public void Example2()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Set the Relations to be nested
      dataSet.Relations["Customers_Invoices"].Nested = true;
      dataSet.Relations["Invoices_InvoiceItems"].Nested = true;

      // Write the XML File out
      Console.WriteLine(dataSet.GetXml());

      form.TheGrid.DataSource = customerTable;
    }

    
    /// <summary>
    /// DataSet output as XML with 
    /// DataColumn Formatting
    /// </summary>
    public void Example3()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Set the Relations to be nested
      dataSet.Relations["Customers_Invoices"].Nested = true;
      dataSet.Relations["Invoices_InvoiceItems"].Nested = true;

      // Set all columns to output as attributes
      foreach(DataColumn col in customerTable.Columns)
        col.ColumnMapping = MappingType.Attribute;
      foreach(DataColumn col in invoiceTable.Columns)
        col.ColumnMapping = MappingType.Attribute;
      foreach(DataColumn col in invoiceItemTable.Columns)
        col.ColumnMapping = MappingType.Attribute;

      // Write the XML File out
      dataSet.WriteXml("test.xml");

      // Read it and show it in the console
      StreamReader rdr = new StreamReader("test.xml", true);
      Console.WriteLine(rdr.ReadToEnd());
      rdr.Close();
    }

    
    /// <summary>
    /// DataSet output as XML with 
    /// Mixed DataColumn Formatting
    /// </summary>
    public void Example4()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Set the Relations to be nested
      dataSet.Relations["Customers_Invoices"].Nested = true;
      dataSet.Relations["Invoices_InvoiceItems"].Nested = true;

      // Set the ID columns to output as attributes
      customerTable.Columns["CustomerID"].ColumnMapping = MappingType.Attribute;
      invoiceTable.Columns["InvoiceID"].ColumnMapping = MappingType.Attribute;
      invoiceItemTable.Columns["InvoiceItemID"].ColumnMapping = MappingType.Attribute;

      // Write the XML File out
      dataSet.WriteXml("test.xml");

      // Read it and show it in the console
      StreamReader rdr = new StreamReader("test.xml", true);
      Console.WriteLine(rdr.ReadToEnd());
      rdr.Close();
    }


    /// <summary>
    /// DataSet output as XML Stream
    /// </summary>
    public void Example5()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Set the Relations to be nested
      dataSet.Relations["Customers_Invoices"].Nested = true;
      dataSet.Relations["Invoices_InvoiceItems"].Nested = true;

      // Write it out to a file
      dataSet.WriteXml("test.xml");

      // Read it and show it in the console
      StreamReader rdr = new StreamReader("test.xml", true);
      Console.WriteLine(rdr.ReadToEnd());
      rdr.Close();
    
    }

    
    /// <summary>
    /// DataSet output as XML with Formatting
    /// </summary>
    public void Example6()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Set the Relations to be nested
      dataSet.Relations["Customers_Invoices"].Nested = true;
      dataSet.Relations["Invoices_InvoiceItems"].Nested = true;

    // Create a StringWriter to Stream into 
    StreamWriter writer = new StreamWriter("test.xml");

    // Create an XmlTextWriter to use to format the Xml
    XmlTextWriter xmlWriter = new XmlTextWriter(writer);

    // Change some options
    xmlWriter.Formatting = Formatting.Indented;
    xmlWriter.Indentation = 3;
    xmlWriter.QuoteChar = '"';

    // Write the XML File out
    dataSet.WriteXml(xmlWriter);

    // Close the Writer
    xmlWriter.Close();

      // Read it and show it in the console
      StreamReader rdr = new StreamReader("test.xml", true);
      Console.WriteLine(rdr.ReadToEnd());
      rdr.Close();
    }

    
    /// <summary>
    /// DataSet output as XML with 
    /// Schema Inline
    /// </summary>
    public void Example7()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Set the Relations to be nested
      dataSet.Relations["Customers_Invoices"].Nested = true;
      dataSet.Relations["Invoices_InvoiceItems"].Nested = true;

      // Set all columns to output as attributes
      foreach(DataColumn col in customerTable.Columns)
        col.ColumnMapping = MappingType.Attribute;
      foreach(DataColumn col in invoiceTable.Columns)
        col.ColumnMapping = MappingType.Attribute;
      foreach(DataColumn col in invoiceItemTable.Columns)
        col.ColumnMapping = MappingType.Attribute;

      // Create a StringWriter to Stream into 
      StreamWriter writer = new StreamWriter("test.xml");

      // Create an XmlTextWriter to use to format the Xml
      XmlTextWriter xmlWriter = new XmlTextWriter(writer);
      xmlWriter.Formatting = Formatting.Indented;

      // Write the XML File out
      dataSet.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);

      // Close the Writer
      xmlWriter.Close();

      // Read it and show it in the console
      StreamReader rdr = new StreamReader("test.xml", true);
      Console.WriteLine(rdr.ReadToEnd());
      rdr.Close();
    }


    /// <summary>
  /// DataSet output as XML with 
  /// as DiffGram
  /// </summary>
    public void Example8()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Set the Relations to be nested
      dataSet.Relations["Customers_Invoices"].Nested = true;
      dataSet.Relations["Invoices_InvoiceItems"].Nested = true;

      // Set all columns to output as attributes
      foreach(DataColumn col in customerTable.Columns)
        col.ColumnMapping = MappingType.Attribute;
      foreach(DataColumn col in invoiceTable.Columns)
        col.ColumnMapping = MappingType.Attribute;
      foreach(DataColumn col in invoiceItemTable.Columns)
        col.ColumnMapping = MappingType.Attribute;

      // Change a couple rows
      invoiceItemTable.Rows[0]["Quantity"] = 5;

      // Create a StringWriter to Stream ,into 
      StreamWriter writer = new StreamWriter("test.xml");

      // Create an XmlTextWriter to use to format the Xml
      XmlTextWriter xmlWriter = new XmlTextWriter(writer);
      xmlWriter.Formatting = Formatting.Indented;

      // Get a DataSet of the Changes
      DataSet dataSetChanges = dataSet.GetChanges();

      // Write the XML File out
      dataSetChanges.WriteXml(xmlWriter, XmlWriteMode.DiffGram);

      // Close the Writer
      xmlWriter.Close();

      // Read it and show it in the console
      StreamReader rdr = new StreamReader("test.xml", true);
      Console.WriteLine(rdr.ReadToEnd());
      rdr.Close();
    }


    /// <summary>
    /// DataSet output as XML with 
    /// namespaces
    /// </summary>
    public void Example9()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Set the Relations to be nested
      dataSet.Relations["Customers_Invoices"].Nested = true;
      dataSet.Relations["Invoices_InvoiceItems"].Nested = true;

      // Set all columns to output as attributes
      foreach(DataColumn col in customerTable.Columns)
        col.ColumnMapping = MappingType.Attribute;
      foreach(DataColumn col in invoiceTable.Columns)
        col.ColumnMapping = MappingType.Attribute;
      foreach(DataColumn col in invoiceItemTable.Columns)
        col.ColumnMapping = MappingType.Attribute;

      // Setup the XML Namespace and Prefix
      dataSet.Namespace = "ADONET";
      dataSet.Prefix = "an";

      // Create a StringWriter to Stream ,into 
      StreamWriter writer = new StreamWriter("test.xml");

      // Create an XmlTextWriter to use to format the Xml
      XmlTextWriter xmlWriter = new XmlTextWriter(writer);
      xmlWriter.Formatting = Formatting.Indented;

      // Write the XML File out
      dataSet.WriteXml(xmlWriter);

      // Close the Writer
      xmlWriter.Close();

      // Read it and show it in the console
      StreamReader rdr = new StreamReader("test.xml", true);
      Console.WriteLine(rdr.ReadToEnd());
      rdr.Close();
    }


    /// <summary>
    /// Filling a DataSet with XML
    /// </summary>
    public void Example10()
    {
      // Fill the DataSet with XML
      DataSet dataSet = new DataSet();
      dataSet.ReadXml(@"..\..\good.xml");

      Console.WriteLine(dataSet.GetXml());

    }

    
    /// <summary>
    /// Get the XML of a DataSet and
    /// Filling a new DataSet with it 
    /// </summary>
    public void Example11()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Create a StringWriter to Stream ,into 
      StreamWriter writer = new StreamWriter("test.xml");

      // Create an XmlTextWriter to use to format the Xml
      XmlTextWriter xmlWriter = new XmlTextWriter(writer);

      // Write the XML File out
      dataSet.WriteXml(xmlWriter);

      // Close the Writer
      xmlWriter.Close();

      // Fill the new DataSet with XML
      DataSet newDataSet = new DataSet();
      newDataSet.ReadXml(@"test.xml");

      // Compare and report the result
      bool areTheySame = dataSet.GetXml() == newDataSet.GetXml();

      Console.WriteLine("Are they the same? {0}", areTheySame);

    }


    /// <summary>
    /// Get a DiffGram of a changed DataSet 
    /// and Merge it with another with changes 
    /// </summary>
    public void Example12()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Create a StringWriter to Stream ,into 
      StreamWriter writer = new StreamWriter("test.xml");

      // Create an XmlTextWriter to use to format the Xml
      XmlTextWriter xmlWriter = new XmlTextWriter(writer);

      // Write the XML File out
      dataSet.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);

      // Close the Writer
      xmlWriter.Close();

      // Fill the new DataSet with XML
      // to make dataSet and newDataSet identical
      DataSet newDataSet = new DataSet();
      newDataSet.ReadXml(@"test.xml", XmlReadMode.ReadSchema);
      newDataSet.AcceptChanges();

      // Change both datasets
      dataSet.Tables["Customers"].Rows[0]["Zip"] = "98765";
      newDataSet.Tables["Customers"].Rows[1]["State"] = "FL";

      // Create Writer and Stream
      Stream newStream = new MemoryStream() as Stream;
      XmlTextWriter xmlNewWriter = new XmlTextWriter(newStream, null);
      xmlNewWriter.Formatting = Formatting.Indented;

      // Get DiffGrams of DataSet
      newDataSet.GetChanges().WriteXml(xmlNewWriter, XmlWriteMode.DiffGram);

      // Write the DiffGram to the Console Window
      newStream.Position = 0;
      StreamReader rdr = new StreamReader(newStream);
      Console.WriteLine(rdr.ReadToEnd());

      // Reset the Stream
      newStream.Position = 0;

      // Apply changes to dataSet
      dataSet.ReadXml(newStream, XmlReadMode.DiffGram);

      form.TheGrid.DataSource = dataSet.Tables["Customers"];

    }

    /// <summary>
    /// Save the XSD of a DataSet
    /// </summary>
    public void Example13()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Create a StringWriter to Stream ,into 
      StreamWriter writer = new StreamWriter("test.xsd");

      // Create an XmlTextWriter to use to format the XSD
      XmlTextWriter xmlWriter = new XmlTextWriter(writer);

      // Write the XSD File out
      dataSet.WriteXmlSchema(xmlWriter);

      // Close the Writer
      xmlWriter.Close();

      // Make a new DataSet with the same 
      // schema as our existing DataSet
      DataSet newDataSet = new DataSet();
      newDataSet.ReadXmlSchema(@"test.xsd");

      form.TheGrid.DataSource = newDataSet.Tables["Customers"];
    }

    /// <summary>
    /// Create an XmlDataDocument and 
    /// Show it's underlying XML Document
    /// </summary>
    public void Example14()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Create an XmlDataDocument
      XmlDataDocument dataDoc = new XmlDataDocument(dataSet);

      // Do an XPath Query
      XmlNode node = dataDoc.SelectSingleNode("descendant::Invoices");

      // Show the XML of the First Node found.
      Console.WriteLine(node.OuterXml);

    }

    /// <summary>
    /// Create an XmlDataDocument and Search it
    /// </summary>
    public void Example15()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Create an XmlDataDocument
      XmlDataDocument dataDoc = new XmlDataDocument(dataSet);

      // Search it
      XmlNode node = dataDoc.SelectSingleNode("//Customers[FirstName = \"Tom\"]");
      if (node != null)
      {
        Console.WriteLine("Found:");
        Console.WriteLine(node.OuterXml);
      }
      else
      {
        Console.WriteLine("No Nodes found");
      }

    }

    /// <summary>
    /// Create an XmlDataDocument and 
    /// Transform it
    /// </summary>
    public void Example16()
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

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Grab our Tables for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];
      DataTable invoiceTable     = dataSet.Tables["Invoices"];
      DataTable invoiceItemTable = dataSet.Tables["InvoiceItems"];

      // Set up PrimaryKeys
      customerTable.PrimaryKey = new DataColumn[] 
        { customerTable.Columns["CustomerID"] };
      invoiceTable.PrimaryKey = new DataColumn[] 
        { invoiceTable.Columns["InvoiceID"] };
      invoiceItemTable.PrimaryKey = new DataColumn[] 
        { invoiceItemTable.Columns["InvoiceItemID"] };

      // Setup Relations
      // Create the first Relationship (Between INVOICE and INVOICEITEM)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Invoices_InvoiceItems", 
        dataSet.Tables["Invoices"].Columns["InvoiceID"], 
        dataSet.Tables["InvoiceItems"].Columns["InvoiceID"], 
        true);

      // Create the first Relationship (Between CUSTOMER and INVOICE)
      // We tell the relation to setup a Constraint to make sure the
      // Relationship is created on a unique key
      dataSet.Relations.Add( "Customers_Invoices", 
        dataSet.Tables["Customers"].Columns["CustomerID"], 
        dataSet.Tables["Invoices"].Columns["CustomerID"], 
        true);

      // Create an XmlDataDocument
      XmlDataDocument dataDoc = new XmlDataDocument(dataSet);

      // Make a StringWriter to hold the results
      StringWriter writer = new StringWriter();

      // Transform it
      XslTransform xslt = new XslTransform();
      xslt.Load(@"..\..\XmlDataDocSample.xsl");
      xslt.Transform(dataDoc, null, writer);

      // Show the results
      Console.WriteLine(writer.ToString());

    }
  }
}
