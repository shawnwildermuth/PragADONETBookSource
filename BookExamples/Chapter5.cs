using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BookExamples
{

	public class Chapter5 : BaseChapter
	{

    /// <summary>
    /// Hello DataSet
    /// </summary>
    public void Example1()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    /// <summary>
    /// Hello DataSet version 2
    /// </summary>
    public void Example2()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a Command Object to query the entire Authors Table
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM CUSTOMER";

      // Create a DataAdapter for use with Filling a DataSet
      SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill it with the Data Adapter
      dataAdapter.Fill(dataSet);

      // Close the Connection
      conn.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Example3()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a Query String
      // In order to get all tables, we are using a batch query that
      // returns multiple resultsets
      string query = "SELECT * FROM CUSTOMER;";
      query += "SELECT * FROM INVOICE;";
      query += "SELECT * FROM INVOICEITEM;";

      // Create a DataAdapter to retrieve the data
      SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

      // Create and Fill the DataSet
      DataSet dataSet = new DataSet();
      dataAdapter.Fill(dataSet);

      // Close the Connection
      conn.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    public void Example4()
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
      SqlDataAdapter daInvoices = new 
        SqlDataAdapter("SELECT * FROM INVOICE;", 
        conn);
      SqlDataAdapter daInvoiceItems = new 
        SqlDataAdapter("SELECT * FROM INVOICEITEM;", 
        conn);

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter 
      // and assign the DataTable Name
      daCustomers.Fill(dataSet, "Customers");
      daInvoices.Fill(dataSet, "Invoices");
      daInvoiceItems.Fill(dataSet, "InvoiceItems");

      // Close the Connection
      conn.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    public void Example5()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a batch query of the tables we're filling
      SqlDataAdapter dataAdapter = new SqlDataAdapter(
        "SELECT * FROM CUSTOMER;" + 
        "SELECT * FROM INVOICE;" + 
        "SELECT * FROM INVOICEITEM;", 
        conn);

      // Setup Table Mappings
      dataAdapter.TableMappings.Add("Table", "Customers");
      dataAdapter.TableMappings.Add("Table1", "Invoices");
      dataAdapter.TableMappings.Add("Table2", "InvoiceItems");

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      dataAdapter.Fill(dataSet);

      // Close the Connection
      conn.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    public void Example6()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a batch query of the tables we're filling
      SqlDataAdapter dataAdapter = new SqlDataAdapter(
        "SELECT * FROM CUSTOMER;" + 
        "SELECT * FROM INVOICE;" + 
        "SELECT * FROM INVOICEITEM;", 
        conn);

      // Setup Table Mappings
      dataAdapter.TableMappings.Add("ADONET", "Customers");
      dataAdapter.TableMappings.Add("ADONET1", "Invoices");
      dataAdapter.TableMappings.Add("ADONET2", "InvoiceItems");

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet while using the temporary Name
      dataAdapter.Fill(dataSet, "ADONET");

      // Close the Connection
      conn.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    public void Example7()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter dataAdapter = new SqlDataAdapter(
        "SELECT * FROM CUSTOMER;" + 
        "SELECT * FROM INVOICE;" + 
        "SELECT * FROM INVOICEITEM;", 
        conn);

      // Setup Table Mappings
      dataAdapter.TableMappings.Add("ADONET", "Customers");
      dataAdapter.TableMappings.Add("ADONET1", "Invoices");
      dataAdapter.TableMappings.Add("ADONET2", "InvoiceItems");

      // Setup Column Mappings
      dataAdapter.TableMappings["ADONET"].ColumnMappings.Add("CustomerID", "ID");
      dataAdapter.TableMappings["ADONET1"].ColumnMappings.Add("InvoiceID", "ID");
      dataAdapter.TableMappings["ADONET2"].ColumnMappings.Add("InvoiceItemID", "ID");

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      dataAdapter.Fill(dataSet, "ADONET");

      // Close the Connection
      conn.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    public void Example8()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter dataAdapter = new SqlDataAdapter(
        "SELECT * FROM CUSTOMER",
        conn);

      // Add a no-op DataTableMapping
      dataAdapter.TableMappings.Add("CUSTOMER", "Customers");

      // Setup Column Mappings
      dataAdapter.TableMappings["Customers"].ColumnMappings.Add("CustomerID", "ID");

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }
  
    public void Example9()
    {
      // Fill the DataSet straight from a file or url
      DataSet dataSet = new DataSet();
      //dataSet.ReadXml(@"c:\test.xml");  // Uncomment when you change the file to something that exists

      // Fill the DataSet from a TextReader 
      // (from which StringReader derives)
      DataSet dsTextReader = new DataSet();
      StringReader textReader = 
        new StringReader("<xml><foo>hello</foo></xml>");
      dsTextReader.ReadXml(textReader);
      textReader.Close();

      // Fill the DataSet from an XmlReader 
      // (from which XmlTextReader is derived)
      DataSet dsXmlReader = new DataSet();
      //XmlTextReader xmlReader = new XmlTextReader(@"c:\test.xml"); // Uncomment when you change the file to something that exists
      //dsXmlReader.ReadXml(xmlReader);
      //xmlReader.Close();

      // Fill the DataSet from a Stream 
      // (from which FileStream is derived)
      DataSet dsStream = new DataSet();
      //FileStream fs = new FileStream(@"c:\test.xml", FileMode.Open); // Uncomment when you change the file to something that exists
      //dsXmlReader.ReadXml(fs);
      //fs.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }


    /// <summary>
    /// 
    /// </summary>
    public void Example10()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a Query String
      // In order to get all tables, we are using a batch query that
      // returns multiple resultsets
      string query = "";
      query += "SELECT * FROM CUSTOMER;";
      query += "SELECT * FROM INVOICE;";
      query += "SELECT * FROM INVOICEITEM;";

      // Create a DataAdapter to retrieve the data
      SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

      // Create and Fill the DataSet from teh Database
      DataSet dataSet = new DataSet();

      // Add our Database Data
      dataAdapter.Fill(dataSet);

      // Add the XML Data to the DataSet
      dataSet.ReadXml(@"..\..\products.xml");//, XmlReadMode.InferSchema);

      form.TheGrid.DataSource = dataSet;

    }

    /// <summary>
    /// 
    /// </summary>
    public void Example11()
    {
      // Create our DataSet instance
      DataSet dataSet = new DataSet();

      // Ask the DataSet's Tables collection for a new DataTable object
      DataTable dataTable = dataSet.Tables.Add("Pitchers");

      // Add some columns (schema information)
      dataTable.Columns.Add("pitcher_id", 
        System.Type.GetType("System.Int64"));
      dataTable.Columns.Add("lname",
        System.Type.GetType("System.String"));
      dataTable.Columns.Add("fname", 
        System.Type.GetType("System.String"));

      // Add some data
      object[] aSmoltz = {1, "Smoltz", "John"};
      object[] aMaddux = {1, "Maddux", "Greg"};
      object[] aGlavine = {1, "Glavine", "Tom"};
      dataTable.Rows.Add( aSmoltz );
      dataTable.Rows.Add( aMaddux );
      dataTable.Rows.Add( aGlavine );

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    public void Example12()
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

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    /// <summary>
    /// DataSet with PrimaryKeys and Relations
    /// </summary>
    public void Example13()
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

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    public void Example14()
    {
    }

    public void Example15()
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

      // Dump the contents of each DataTable's Constraints
      foreach (DataTable tbl in dataSet.Tables)
      {
        Console.WriteLine("Table: {0}", tbl.TableName);
        foreach (Constraint con in tbl.Constraints)
        {
          Console.WriteLine("  Name: {0}  ", con.ConstraintName);
          if (con is UniqueConstraint)
          {
            Console.WriteLine("    UNIQUECONSTRAINT");
            UniqueConstraint u = con as UniqueConstraint;
            Console.WriteLine("    Is on Primary Key: {0}",
              u.IsPrimaryKey);
            DumpColumns("Columns",u.Columns, "      ");
          }
          else if (con is ForeignKeyConstraint)
          {
            Console.WriteLine("    FOREIGNKEYCONSTRAINT");
            ForeignKeyConstraint f = con as ForeignKeyConstraint;
            Console.WriteLine("    Related Table: {0}", 
              f.RelatedTable.TableName);
            DumpColumns("Columns", f.Columns, "      ");
            DumpColumns("Related Columns", f.RelatedColumns, "      ");
            Console.WriteLine("      Delete Rule:      {0}",
              f.DeleteRule);
            Console.WriteLine("      Update Rule:      {0}", 
              f.UpdateRule);
            Console.WriteLine("      AcceptRejectRule: {0}", 
              f.AcceptRejectRule);
          }
          else
          {
            Console.WriteLine("    UNKNOWN TYPE");
          }
        }
      }
    }

    private void DumpColumns(string title, 
      DataColumn[] cols, 
      string indent)
    {
      Console.WriteLine("{0}{1}",indent, title);
      foreach (DataColumn col in cols)
      {
        Console.WriteLine("{0}  Column: {1}", indent, col.ColumnName);
      }
    }

    public void Example16()
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
      // Create a UniqueConstraint to make sure all 
      // LastName/FirstName combo’s are unique

      // Create an array of Columns with LastName/FirstName
      DataColumn[] uniqueCols = new DataColumn[] 
        { customerTable.Columns["LastName"], 
          customerTable.Columns["FirstName"] };

      // Create the Unique Constraint
      customerTable.Constraints.Add("UniqueNamesPlease", uniqueCols, false);

      // Close the Connection
      conn.Close();

      // Attach to the DataGrid
      form.TheGrid.DataSource = dataSet;
    }

    public void Example17()
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

      // Close the Connection
      conn.Close();

      // Add a new handler to catch events for changes (For Row and Column)
      // (This is like a trigger)
      dataSet.Tables[0].RowChanged += new DataRowChangeEventHandler(RowIsChanged);
      dataSet.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(ColumnIsChanged);

      // Change a row to see the event fired
      dataSet.Tables[0].Rows[0]["LastName"] = "FooBar";

    }

    public void RowIsChanged(object sender, DataRowChangeEventArgs e)
    {
      Console.WriteLine("After Row changed:  Action {0}, Row Value: {1}", e.Action, e.Row["LastName"]);
    }

    public void ColumnIsChanged(object sender, DataColumnChangeEventArgs e)
    {
      Console.WriteLine( "After Column Changed: LastName={0}; Column={1}; original LastName={2}", 
        e.Row["LastName"], e.Column.ColumnName, e.Row["LastName", DataRowVersion.Original] );
    }

    public void Example18()
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

      // Close the Connection
      conn.Close();

      // Grab our DataTable for simplicity
      DataTable customersTable = dataSet.Tables["Customers"];

      // Dump the Column Schema
      foreach (DataColumn col in customersTable.Columns)
      {
        Console.WriteLine("{0}",               col.ColumnName    );
        Console.WriteLine("  Type:\t\t{0}",    col.DataType.Name );
        Console.WriteLine("  Default:\t{0}",   col.DefaultValue  );
        Console.WriteLine("  ReadOnly?:\t{0}", col.ReadOnly      );
        Console.WriteLine("  Unique?:\t{0}",   col.Unique        );
        Console.WriteLine("  Max Length:\t{0}",col.MaxLength     );
        Console.WriteLine("  Allow Null:\t{0}",col.AllowDBNull   );
      }

    }

    public void Example19()
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

      // Close the Connection
      conn.Close();

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

      // Dump the Column Schema
      foreach (DataColumn col in customersTable.Columns)
      {
        Console.WriteLine("{0}",               col.ColumnName    );
        Console.WriteLine("  Type:\t\t{0}",    col.DataType.Name );
        Console.WriteLine("  Default:\t{0}",   col.DefaultValue  );
        Console.WriteLine("  ReadOnly?:\t{0}", col.ReadOnly      );
        Console.WriteLine("  Unique?:\t{0}",   col.Unique        );
        Console.WriteLine("  Max Length:\t{0}",col.MaxLength     );
        Console.WriteLine("  Allow Null:\t{0}",col.AllowDBNull   );
      }

    }

    public void Example20()
    {

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Create our DataTable 
      DataTable dataTable = dataSet.Tables.Add("AutoInc");

      // Create a new integer column
      // (AutoIncrement columns *must* be of type integer
      DataColumn autoIncColumn = dataTable.Columns.Add("TheKey", typeof(int));

      // Set the Column to be an AutoIncremented Column
      autoIncColumn.AutoIncrement = true;

      // Specify the Seed (or starting number)
      autoIncColumn.AutoIncrementSeed = 1;

      // Specify the Step 
      // (or the amount to increment from the seed for every 
      //  new entry in the column)
      autoIncColumn.AutoIncrementStep = 1;

    }
 
    public void Example21()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter daItems = new 
        SqlDataAdapter("SELECT Description, " +
                        "       Vendor, " +
                        "       Price, " +
                        "       Quantity, " +
                        "       Discount " +
                        "FROM InvoiceItem " +
                        "JOIN Product on " + 
                        " InvoiceItem.ProductID = Product.ProductID",
                        conn);

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daItems.Fill(dataSet, "Items");

      // Close the Connection
      conn.Close();

      // Create an Expression Column
      DataColumn exColumn = new DataColumn("LineTotal");
      exColumn.DataType = typeof(float);
      exColumn.Expression = "((Price - (Price * Discount)) * Quantity)";

      // Add the Column to the Data
      dataSet.Tables["Items"].Columns.Add(exColumn);

      // Bind to the Grid
      form.TheGrid.DataSource = dataSet.Tables["Items"];
    }

    public void Example22()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM CUSTOMER",conn);

      // Tell the DataAdapter to throw an error if it finds missing schema
      dataAdapter.MissingSchemaAction = MissingSchemaAction.Error;

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // An error will be thrown when we attempt to fill the DataSet
      // since the DataSet is empty
      dataAdapter.Fill(dataSet, "Customers");

    }

    public void Example23()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM CUSTOMER",conn);

      // Tell the DataAdapter to Add the Schema and include the Primary Key information
      dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Create a new DataTable in the DataSet and call it "Customers"
      dataAdapter.FillSchema(dataSet, SchemaType.Mapped, "Customers");

    }

    public void Example24()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
       

      // Create a DataAdapter for each of the tables we're filling
      SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM CUSTOMER",conn);

      // Tell the DataAdapter to throw an error if it finds missing schema
      dataAdapter.MissingSchemaAction = MissingSchemaAction.Error;

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the Schema from an XSD file
      dataSet.ReadXmlSchema(@"..\..\customer.xsd");

      // No Error should be thrown since our customer.xsd should contain 
      // an accurate schema for Customers
      dataAdapter.Fill(dataSet, "Customers");

    }

    public void Example25()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create a DataAdapter for the Customer Table
      SqlDataAdapter daCustomers = new SqlDataAdapter("SELECT * FROM CUSTOMER", 
                                                        conn);

      // Create your blank DataSet
      DataSet dataSet = new DataSet();

      // Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers");

      // Grab our Table for simplicity
      DataTable customerTable    = dataSet.Tables["Customers"];

      // Add a Duplicate Row Before we set the PrimaryKey to 
      // allow us to handle the error
      customerTable.Rows.Add(customerTable.Rows[0].ItemArray);

      try
      {
        // Set up PrimaryKey
        customerTable.PrimaryKey = new DataColumn[] { customerTable.Columns["CustomerID"] };
      }
      catch (ArgumentException ex)
      {
        // Show the error.  If we get this exception, we can be pretty certain it is
        // because the PrimaryKey DataColumn(s) is(are) not unique.
        Console.WriteLine("Column(s) in the PrimaryKey are not unique.");
        Console.WriteLine("  Exception Thrown:  {0}", ex.Message);
      }
    }

    public void InvoiceLister()
    {
      InvoiceLister dlg = new InvoiceLister();
      dlg.ShowDialog(form);
    }

  }

  class PragmaticDataSet : DataSet
  {
    public PragmaticDataSet()
    {
      // Create your Schema here
    }

    ///...

  }
}