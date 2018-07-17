Imports System
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Namespace BookExamples
    _

  Public Class Chapter5
    Inherits BaseChapter


    ' <summary>
    ' Hello DataSet
    ' </summary>
    Public Sub Example1()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet)

      ' Attach to the DataGrid
      form.TheGrid.DataSource = dataSet
    End Sub 'Example1


    ' <summary>
    ' Hello DataSet version 2
    ' </summary>
    Public Sub Example2()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a Command Object to query the entire Authors Table
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM CUSTOMER"

      ' Create a DataAdapter for use with Filling a DataSet
      Dim dataAdapter As New SqlDataAdapter(cmd)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill it with the Data Adapter
      dataAdapter.Fill(dataSet)

      ' Close the Connection
      conn.Close()

      ' Attach to the DataGrid
      form.TheGrid.DataSource = dataSet
    End Sub 'Example2


    ' <summary>
    ' 
    ' </summary>
    Public Sub Example3()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a Query String
      ' In order to get all tables, we are using a batch query that
      ' returns multiple resultsets
      Dim query As String = "SELECT * FROM CUSTOMER;"
      query += "SELECT * FROM INVOICE;"
      query += "SELECT * FROM INVOICEITEM;"

      ' Create a DataAdapter to retrieve the data
      Dim dataAdapter As New SqlDataAdapter(query, conn)

      ' Create and Fill the DataSet
      Dim dataSet As New DataSet()
      dataAdapter.Fill(dataSet)

      ' Close the Connection
      conn.Close()

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example3


    Public Sub Example4()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE;", conn)
      Dim daInvoiceItems As New SqlDataAdapter("SELECT * FROM INVOICEITEM;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter 
      ' and assign the DataTable Name
      daCustomers.Fill(dataSet, "Customers")
      daInvoices.Fill(dataSet, "Invoices")
      daInvoiceItems.Fill(dataSet, "InvoiceItems")

      ' Close the Connection
      conn.Close()

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example4


    Public Sub Example5()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a batch query of the tables we're filling
      Dim dataAdapter As New SqlDataAdapter("SELECT * FROM CUSTOMER;" + "SELECT * FROM INVOICE;" + "SELECT * FROM INVOICEITEM;", conn)

      ' Setup Table Mappings
      dataAdapter.TableMappings.Add("Table", "Customers")
      dataAdapter.TableMappings.Add("Table1", "Invoices")
      dataAdapter.TableMappings.Add("Table2", "InvoiceItems")

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      dataAdapter.Fill(dataSet)

      ' Close the Connection
      conn.Close()

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example5


    Public Sub Example6()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a batch query of the tables we're filling
      Dim dataAdapter As New SqlDataAdapter("SELECT * FROM CUSTOMER;" + "SELECT * FROM INVOICE;" + "SELECT * FROM INVOICEITEM;", conn)

      ' Setup Table Mappings
      dataAdapter.TableMappings.Add("ADONET", "Customers")
      dataAdapter.TableMappings.Add("ADONET1", "Invoices")
      dataAdapter.TableMappings.Add("ADONET2", "InvoiceItems")

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet while using the temporary Name
      dataAdapter.Fill(dataSet, "ADONET")

      ' Close the Connection
      conn.Close()

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example6


    Public Sub Example7()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim dataAdapter As New SqlDataAdapter("SELECT * FROM CUSTOMER;" + "SELECT * FROM INVOICE;" + "SELECT * FROM INVOICEITEM;", conn)

      ' Setup Table Mappings
      dataAdapter.TableMappings.Add("ADONET", "Customers")
      dataAdapter.TableMappings.Add("ADONET1", "Invoices")
      dataAdapter.TableMappings.Add("ADONET2", "InvoiceItems")

      ' Setup Column Mappings
      dataAdapter.TableMappings("ADONET").ColumnMappings.Add("CustomerID", "ID")
      dataAdapter.TableMappings("ADONET1").ColumnMappings.Add("InvoiceID", "ID")
      dataAdapter.TableMappings("ADONET2").ColumnMappings.Add("InvoiceItemID", "ID")

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      dataAdapter.Fill(dataSet, "ADONET")

      ' Close the Connection
      conn.Close()

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example7


    Public Sub Example8()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim dataAdapter As New SqlDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Add a no-op DataTableMapping
      dataAdapter.TableMappings.Add("CUSTOMER", "Customers")

      ' Setup Column Mappings
      dataAdapter.TableMappings("Customers").ColumnMappings.Add("CustomerID", "ID")

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example8


    Public Sub Example9()
      ' Fill the DataSet straight from a file or url
      Dim dataSet As New DataSet()
      'dataSet.ReadXml(@"c:\test.xml");  // Uncomment when you change the file to something that exists
      ' Fill the DataSet from a TextReader 
      ' (from which StringReader derives)
      Dim dsTextReader As New DataSet()
      Dim textReader As New StringReader("<xml><foo>hello</foo></xml>")
      dsTextReader.ReadXml(textReader)
      textReader.Close()

      ' Fill the DataSet from an XmlReader 
      ' (from which XmlTextReader is derived)
      Dim dsXmlReader As New DataSet()
      'XmlTextReader xmlReader = new XmlTextReader(@"c:\test.xml"); // Uncomment when you change the file to something that exists
      'dsXmlReader.ReadXml(xmlReader);
      'xmlReader.Close();
      ' Fill the DataSet from a Stream 
      ' (from which FileStream is derived)
      Dim dsStream As New DataSet()
      'FileStream fs = new FileStream(@"c:\test.xml", FileMode.Open); // Uncomment when you change the file to something that exists
      'dsXmlReader.ReadXml(fs);
      'fs.Close();
      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example9



    ' <summary>
    ' 
    ' </summary>
    Public Sub Example10()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a Query String
      ' In order to get all tables, we are using a batch query that
      ' returns multiple resultsets
      Dim query As String = ""
      query += "SELECT * FROM CUSTOMER;"
      query += "SELECT * FROM INVOICE;"
      query += "SELECT * FROM INVOICEITEM;"

      ' Create a DataAdapter to retrieve the data
      Dim dataAdapter As New SqlDataAdapter(query, conn)

      ' Create and Fill the DataSet from teh Database
      Dim dataSet As New DataSet()

      ' Add our Database Data
      dataAdapter.Fill(dataSet)

      ' Add the XML Data to the DataSet
      dataSet.ReadXml("..\..\products.xml") ', XmlReadMode.InferSchema);

      Form.TheGrid.DataSource = dataSet
    End Sub 'Example10


    ' <summary>
    ' 
    ' </summary>
    Public Sub Example11()
      ' Create our DataSet instance
      Dim dataSet As New DataSet()

      ' Ask the DataSet's Tables collection for a new DataTable object
      Dim dataTable As DataTable = dataSet.Tables.Add("Pitchers")

      ' Add some columns (schema information)
      dataTable.Columns.Add("pitcher_id", System.Type.GetType("System.Int64"))
      dataTable.Columns.Add("lname", System.Type.GetType("System.String"))
      dataTable.Columns.Add("fname", System.Type.GetType("System.String"))

      ' Add some data
      Dim aSmoltz As Object() = {1, "Smoltz", "John"}
      Dim aMaddux As Object() = {1, "Maddux", "Greg"}
      Dim aGlavine As Object() = {1, "Glavine", "Tom"}
      dataTable.Rows.Add(aSmoltz)
      dataTable.Rows.Add(aMaddux)
      dataTable.Rows.Add(aGlavine)

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example11


    Public Sub Example12()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE;", conn)
      Dim daInvoiceItems As New SqlDataAdapter("SELECT * FROM INVOICEITEM;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")
      daInvoices.Fill(dataSet, "Invoices")
      daInvoiceItems.Fill(dataSet, "InvoiceItems")

      ' Close the Connection
      conn.Close()

      ' Grab our Tables for simplicity
      Dim customerTable As DataTable = dataSet.Tables("Customers")
      Dim invoiceTable As DataTable = dataSet.Tables("Invoices")
      Dim invoiceItemTable As DataTable = dataSet.Tables("InvoiceItems")

      ' Set up PrimaryKeys
      customerTable.PrimaryKey = New DataColumn() {customerTable.Columns("CustomerID")}
      invoiceTable.PrimaryKey = New DataColumn() {invoiceTable.Columns("InvoiceID")}
      invoiceItemTable.PrimaryKey = New DataColumn() {invoiceItemTable.Columns("InvoiceItemID")}

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example12


    ' <summary>
    ' DataSet with PrimaryKeys and Relations
    ' </summary>
    Public Sub Example13()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE;", conn)
      Dim daInvoiceItems As New SqlDataAdapter("SELECT * FROM INVOICEITEM;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")
      daInvoices.Fill(dataSet, "Invoices")
      daInvoiceItems.Fill(dataSet, "InvoiceItems")

      ' Close the Connection
      conn.Close()

      ' Grab our Tables for simplicity
      Dim customerTable As DataTable = dataSet.Tables("Customers")
      Dim invoiceTable As DataTable = dataSet.Tables("Invoices")
      Dim invoiceItemTable As DataTable = dataSet.Tables("InvoiceItems")

      ' Set up PrimaryKeys
      customerTable.PrimaryKey = New DataColumn() {customerTable.Columns("CustomerID")}
      invoiceTable.PrimaryKey = New DataColumn() {invoiceTable.Columns("InvoiceID")}
      invoiceItemTable.PrimaryKey = New DataColumn() {invoiceItemTable.Columns("InvoiceItemID")}

      ' Setup Relations
      ' Create the first Relationship (Between INVOICE and INVOICEITEM)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("Invoices_InvoiceItems", dataSet.Tables("Invoices").Columns("InvoiceID"), dataSet.Tables("InvoiceItems").Columns("InvoiceID"), True)

      ' Create the first Relationship (Between CUSTOMER and INVOICE)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("Customers_Invoices", dataSet.Tables("Customers").Columns("CustomerID"), dataSet.Tables("Invoices").Columns("CustomerID"), True)

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example13


    Public Sub Example14()
    End Sub 'Example14


    Public Sub Example15()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE;", conn)
      Dim daInvoiceItems As New SqlDataAdapter("SELECT * FROM INVOICEITEM;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")
      daInvoices.Fill(dataSet, "Invoices")
      daInvoiceItems.Fill(dataSet, "InvoiceItems")

      ' Close the Connection
      conn.Close()

      ' Grab our Tables for simplicity
      Dim customerTable As DataTable = dataSet.Tables("Customers")
      Dim invoiceTable As DataTable = dataSet.Tables("Invoices")
      Dim invoiceItemTable As DataTable = dataSet.Tables("InvoiceItems")

      ' Set up PrimaryKeys
      customerTable.PrimaryKey = New DataColumn() {customerTable.Columns("CustomerID")}
      invoiceTable.PrimaryKey = New DataColumn() {invoiceTable.Columns("InvoiceID")}
      invoiceItemTable.PrimaryKey = New DataColumn() {invoiceItemTable.Columns("InvoiceItemID")}

      ' Setup Relations
      ' Create the first Relationship (Between INVOICE and INVOICEITEM)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("Invoices_InvoiceItems", dataSet.Tables("Invoices").Columns("InvoiceID"), dataSet.Tables("InvoiceItems").Columns("InvoiceID"), True)

      ' Create the first Relationship (Between CUSTOMER and INVOICE)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("Customers_Invoices", dataSet.Tables("Customers").Columns("CustomerID"), dataSet.Tables("Invoices").Columns("CustomerID"), True)

      ' Dump the contents of each DataTable's Constraints
      Dim tbl As DataTable
      For Each tbl In dataSet.Tables
        Console.WriteLine("Table: {0}", tbl.TableName)
        Dim con As Constraint
        For Each con In tbl.Constraints
          Console.WriteLine("  Name: {0}  ", con.ConstraintName)
          If TypeOf con Is UniqueConstraint Then
            Console.WriteLine("    UNIQUECONSTRAINT")
            Dim u As UniqueConstraint = con
            Console.WriteLine("    Is on Primary Key: {0}", u.IsPrimaryKey)
            DumpColumns("Columns", u.Columns, "      ")
          Else
            If TypeOf con Is ForeignKeyConstraint Then
              Console.WriteLine("    FOREIGNKEYCONSTRAINT")
              Dim f As ForeignKeyConstraint = con
              Console.WriteLine("    Related Table: {0}", f.RelatedTable.TableName)
              DumpColumns("Columns", f.Columns, "      ")
              DumpColumns("Related Columns", f.RelatedColumns, "      ")
              Console.WriteLine("      Delete Rule:      {0}", f.DeleteRule)
              Console.WriteLine("      Update Rule:      {0}", f.UpdateRule)
              Console.WriteLine("      AcceptRejectRule: {0}", f.AcceptRejectRule)
            Else
              Console.WriteLine("    UNKNOWN TYPE")
            End If
          End If
        Next con
      Next tbl
    End Sub 'Example15

    Private Sub DumpColumns(ByVal title As String, ByVal cols() As DataColumn, ByVal indent As String)
      Console.WriteLine("{0}{1}", indent, title)
      Dim col As DataColumn
      For Each col In cols
        Console.WriteLine("{0}  Column: {1}", indent, col.ColumnName)
      Next col
    End Sub 'DumpColumns


    Public Sub Example16()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE;", conn)
      Dim daInvoiceItems As New SqlDataAdapter("SELECT * FROM INVOICEITEM;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")
      daInvoices.Fill(dataSet, "Invoices")
      daInvoiceItems.Fill(dataSet, "InvoiceItems")

      ' Close the Connection
      conn.Close()

      ' Grab our Tables for simplicity
      Dim customerTable As DataTable = dataSet.Tables("Customers")
      Dim invoiceTable As DataTable = dataSet.Tables("Invoices")
      Dim invoiceItemTable As DataTable = dataSet.Tables("InvoiceItems")

      ' Set up PrimaryKeys
      customerTable.PrimaryKey = New DataColumn() {customerTable.Columns("CustomerID")}
      invoiceTable.PrimaryKey = New DataColumn() {invoiceTable.Columns("InvoiceID")}
      invoiceItemTable.PrimaryKey = New DataColumn() {invoiceItemTable.Columns("InvoiceItemID")}

      ' Setup Relations
      ' Create the first Relationship (Between INVOICE and INVOICEITEM)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("Invoices_InvoiceItems", dataSet.Tables("Invoices").Columns("InvoiceID"), dataSet.Tables("InvoiceItems").Columns("InvoiceID"), True)

      ' Create the first Relationship (Between CUSTOMER and INVOICE)
      ' We tell the relation to setup a Constraint to make sure the
      ' Relationship is created on a unique key
      dataSet.Relations.Add("Customers_Invoices", dataSet.Tables("Customers").Columns("CustomerID"), dataSet.Tables("Invoices").Columns("CustomerID"), True)
      ' Create a UniqueConstraint to make sure all 
      ' LastName/FirstName combo’s are unique
      ' Create an array of Columns with LastName/FirstName
      Dim uniqueCols() As DataColumn = {customerTable.Columns("LastName"), customerTable.Columns("FirstName")}

      ' Create the Unique Constraint
      customerTable.Constraints.Add("UniqueNamesPlease", uniqueCols, False)

      ' Close the Connection
      conn.Close()

      ' Attach to the DataGrid
      Form.TheGrid.DataSource = dataSet
    End Sub 'Example16


    Public Sub Example17()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Add a new handler to catch events for changes (For Row and Column)
      ' (This is like a trigger)
      AddHandler dataSet.Tables(0).RowChanged, AddressOf RowIsChanged
      AddHandler dataSet.Tables(0).ColumnChanged, AddressOf ColumnIsChanged

      ' Change a row to see the event fired
      dataSet.Tables(0).Rows(0)("LastName") = "FooBar"
    End Sub 'Example17


    Public Sub RowIsChanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
      Console.WriteLine("After Row changed:  Action {0}, Row Value: {1}", e.Action, e.Row("LastName"))
    End Sub 'RowIsChanged


    Public Sub ColumnIsChanged(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
      Console.WriteLine("After Column Changed: LastName={0}; Column={1}; original LastName={2}", e.Row("LastName"), e.Column.ColumnName, e.Row("LastName", DataRowVersion.Original))
    End Sub 'ColumnIsChanged


    Public Sub Example18()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab our DataTable for simplicity
      Dim customersTable As DataTable = dataSet.Tables("Customers")

      ' Dump the Column Schema
      Dim col As DataColumn
      For Each col In customersTable.Columns
        Console.WriteLine("{0}", col.ColumnName)
        Console.WriteLine("  Type:" + ControlChars.Tab + ControlChars.Tab + "{0}", col.DataType.Name)
        Console.WriteLine("  Default:" + ControlChars.Tab + "{0}", col.DefaultValue)
        Console.WriteLine("  ReadOnly?:" + ControlChars.Tab + "{0}", col.ReadOnly)
        Console.WriteLine("  Unique?:" + ControlChars.Tab + "{0}", col.Unique)
        Console.WriteLine("  Max Length:" + ControlChars.Tab + "{0}", col.MaxLength)
        Console.WriteLine("  Allow Null:" + ControlChars.Tab + "{0}", col.AllowDBNull)
      Next col
    End Sub 'Example18


    Public Sub Example19()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab our DataTable for simplicity
      Dim customersTable As DataTable = dataSet.Tables("Customers")

      ' Improve the schema
      customersTable.Columns("CustomerID").ReadOnly = True
      customersTable.Columns("CustomerID").Unique = True
      customersTable.Columns("LastName").MaxLength = 50
      customersTable.Columns("LastName").AllowDBNull = False
      customersTable.Columns("FirstName").MaxLength = 50
      customersTable.Columns("FirstName").AllowDBNull = False
      customersTable.Columns("MiddleName").MaxLength = 50
      customersTable.Columns("State").DefaultValue = "MA"
      customersTable.Columns("State").MaxLength = 2
      customersTable.Columns("HomePhone").Unique = True

      ' Dump the Column Schema
      Dim col As DataColumn
      For Each col In customersTable.Columns
        Console.WriteLine("{0}", col.ColumnName)
        Console.WriteLine("  Type:" + ControlChars.Tab + ControlChars.Tab + "{0}", col.DataType.Name)
        Console.WriteLine("  Default:" + ControlChars.Tab + "{0}", col.DefaultValue)
        Console.WriteLine("  ReadOnly?:" + ControlChars.Tab + "{0}", col.ReadOnly)
        Console.WriteLine("  Unique?:" + ControlChars.Tab + "{0}", col.Unique)
        Console.WriteLine("  Max Length:" + ControlChars.Tab + "{0}", col.MaxLength)
        Console.WriteLine("  Allow Null:" + ControlChars.Tab + "{0}", col.AllowDBNull)
      Next col
    End Sub 'Example19


    Public Sub Example20()

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Create our DataTable 
      Dim dataTable As DataTable = dataSet.Tables.Add("AutoInc")

      ' Create a new integer column
      ' (AutoIncrement columns *must* be of type integer
      Dim autoIncColumn As DataColumn = dataTable.Columns.Add("TheKey", GetType(Integer))

      ' Set the Column to be an AutoIncremented Column
      autoIncColumn.AutoIncrement = True

      ' Specify the Seed (or starting number)
      autoIncColumn.AutoIncrementSeed = 1

      ' Specify the Step 
      ' (or the amount to increment from the seed for every 
      '  new entry in the column)
      autoIncColumn.AutoIncrementStep = 1
    End Sub 'Example20


    Public Sub Example21()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim daItems As New SqlDataAdapter("SELECT Description, " + "       Vendor, " + "       Price, " + "       Quantity, " + "       Discount " + "FROM InvoiceItem " + "JOIN Product on " + " InvoiceItem.ProductID = Product.ProductID", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daItems.Fill(dataSet, "Items")

      ' Close the Connection
      conn.Close()

      ' Create an Expression Column
      Dim exColumn As New DataColumn("LineTotal")
      exColumn.DataType = GetType(Single)
      exColumn.Expression = "((Price - (Price * Discount)) * Quantity)"

      ' Add the Column to the Data
      dataSet.Tables("Items").Columns.Add(exColumn)

      ' Bind to the Grid
      Form.TheGrid.DataSource = dataSet.Tables("Items")
    End Sub 'Example21


    Public Sub Example22()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim dataAdapter As New SqlDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Tell the DataAdapter to throw an error if it finds missing schema
      dataAdapter.MissingSchemaAction = MissingSchemaAction.Error

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' An error will be thrown when we attempt to fill the DataSet
      ' since the DataSet is empty
      dataAdapter.Fill(dataSet, "Customers")
    End Sub 'Example22


    Public Sub Example23()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim dataAdapter As New SqlDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Tell the DataAdapter to Add the Schema and include the Primary Key information
      dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Create a new DataTable in the DataSet and call it "Customers"
      dataAdapter.FillSchema(dataSet, SchemaType.Mapped, "Customers")
    End Sub 'Example23


    Public Sub Example24()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")


      ' Create a DataAdapter for each of the tables we're filling
      Dim dataAdapter As New SqlDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Tell the DataAdapter to throw an error if it finds missing schema
      dataAdapter.MissingSchemaAction = MissingSchemaAction.Error

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the Schema from an XSD file
      dataSet.ReadXmlSchema("..\..\customer.xsd")

      ' No Error should be thrown since our customer.xsd should contain 
      ' an accurate schema for Customers
      dataAdapter.Fill(dataSet, "Customers") '

    End Sub 'Example24


    Public Sub Example25()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + _
                                    "database=ADONET;" + _
                                    "Integrated Security=true;")

      ' Create a DataAdapter for the Customer Table
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")

      ' Grab our Table for simplicity
      Dim customerTable As DataTable = dataSet.Tables("Customers")

      ' Add a Duplicate Row Before we set the PrimaryKey to 
      ' allow us to handle the error
      customerTable.Rows.Add(customerTable.Rows(0).ItemArray)

      Try
        ' Set up PrimaryKey
        customerTable.PrimaryKey = New DataColumn() {customerTable.Columns("CustomerID")}
      Catch ex As ArgumentException
        ' Show the error.  If we get this exception, we can be pretty certain it is
        ' because the PrimaryKey DataColumn(s) is(are) not unique.
        Console.WriteLine("Column(s) in the PrimaryKey are not unique.")
        Console.WriteLine("  Exception Thrown:  {0}", ex.Message)
      End Try
    End Sub 'Example25


    Public Sub InvoiceLister()
      Dim dlg As New InvoiceLister()
      dlg.ShowDialog(Form)
    End Sub 'InvoiceLister
  End Class 'Chapter5
    _ 

  Class PragmaticDataSet
    Inherits DataSet

    Public Sub New()
    End Sub 'New
  End Class 'PragmaticDataSet ' Create your Schema here
End Namespace 'BookExamples

'...
