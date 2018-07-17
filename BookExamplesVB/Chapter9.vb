Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.IO
Imports System.Text


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter9.
  ' </summary>
  Public Class Chapter9
    Inherits BaseChapter


    ' <summary>
    ' DataSet output as XML
    ' </summary>
    Public Sub Example1()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Write out the XML File
      Console.WriteLine(dataSet.GetXml())

      Form.TheGrid.DataSource = customerTable
    End Sub 'Example1



    ' <summary>
    ' DataSet output as XML with Nested Relationships
    ' </summary>
    Public Sub Example2()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Set the Relations to be nested
      dataSet.Relations("Customers_Invoices").Nested = True
      dataSet.Relations("Invoices_InvoiceItems").Nested = True

      ' Write the XML File out
      Console.WriteLine(dataSet.GetXml())

      Form.TheGrid.DataSource = customerTable
    End Sub 'Example2



    ' <summary>
    ' DataSet output as XML with 
    ' DataColumn Formatting
    ' </summary>
    Public Sub Example3()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Set the Relations to be nested
      dataSet.Relations("Customers_Invoices").Nested = True
      dataSet.Relations("Invoices_InvoiceItems").Nested = True

      ' Set all columns to output as attributes
      Dim col As DataColumn
      For Each col In customerTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col

      For Each col In invoiceTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col

      For Each col In invoiceItemTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col
      ' Write the XML File out
      dataSet.WriteXml("test.xml")

      ' Read it and show it in the console
      Dim rdr As New StreamReader("test.xml", True)
      Console.WriteLine(rdr.ReadToEnd())
      rdr.Close()
    End Sub 'Example3



    ' <summary>
    ' DataSet output as XML with 
    ' Mixed DataColumn Formatting
    ' </summary>
    Public Sub Example4()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Set the Relations to be nested
      dataSet.Relations("Customers_Invoices").Nested = True
      dataSet.Relations("Invoices_InvoiceItems").Nested = True

      ' Set the ID columns to output as attributes
      customerTable.Columns("CustomerID").ColumnMapping = MappingType.Attribute
      invoiceTable.Columns("InvoiceID").ColumnMapping = MappingType.Attribute
      invoiceItemTable.Columns("InvoiceItemID").ColumnMapping = MappingType.Attribute

      ' Write the XML File out
      dataSet.WriteXml("test.xml")

      ' Read it and show it in the console
      Dim rdr As New StreamReader("test.xml", True)
      Console.WriteLine(rdr.ReadToEnd())
      rdr.Close()
    End Sub 'Example4



    ' <summary>
    ' DataSet output as XML Stream
    ' </summary>
    Public Sub Example5()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Set the Relations to be nested
      dataSet.Relations("Customers_Invoices").Nested = True
      dataSet.Relations("Invoices_InvoiceItems").Nested = True

      ' Write it out to a file
      dataSet.WriteXml("test.xml")

      ' Read it and show it in the console
      Dim rdr As New StreamReader("test.xml", True)
      Console.WriteLine(rdr.ReadToEnd())
      rdr.Close()
    End Sub 'Example5



    ' <summary>
    ' DataSet output as XML with Formatting
    ' </summary>
    Public Sub Example6()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Set the Relations to be nested
      dataSet.Relations("Customers_Invoices").Nested = True
      dataSet.Relations("Invoices_InvoiceItems").Nested = True

      ' Create a StringWriter to Stream into 
      Dim writer As New StreamWriter("test.xml")

      ' Create an XmlTextWriter to use to format the Xml
      Dim xmlWriter As New XmlTextWriter(writer)

      ' Change some options
      xmlWriter.Formatting = Formatting.Indented
      xmlWriter.Indentation = 3
      xmlWriter.QuoteChar = ControlChars.Quote

      ' Write the XML File out
      dataSet.WriteXml(xmlWriter)

      ' Close the Writer
      xmlWriter.Close()

      ' Read it and show it in the console
      Dim rdr As New StreamReader("test.xml", True)
      Console.WriteLine(rdr.ReadToEnd())
      rdr.Close()
    End Sub 'Example6



    ' <summary>
    ' DataSet output as XML with 
    ' Schema Inline
    ' </summary>
    Public Sub Example7()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Set the Relations to be nested
      dataSet.Relations("Customers_Invoices").Nested = True
      dataSet.Relations("Invoices_InvoiceItems").Nested = True

      ' Set all columns to output as attributes
      Dim col As DataColumn
      For Each col In customerTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col

      For Each col In invoiceTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col

      For Each col In invoiceItemTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col
      ' Create a StringWriter to Stream into 
      Dim writer As New StreamWriter("test.xml")

      ' Create an XmlTextWriter to use to format the Xml
      Dim xmlWriter As New XmlTextWriter(writer)
      xmlWriter.Formatting = Formatting.Indented

      ' Write the XML File out
      dataSet.WriteXml(xmlWriter, XmlWriteMode.WriteSchema)

      ' Close the Writer
      xmlWriter.Close()

      ' Read it and show it in the console
      Dim rdr As New StreamReader("test.xml", True)
      Console.WriteLine(rdr.ReadToEnd())
      rdr.Close()
    End Sub 'Example7



    ' <summary>
    ' DataSet output as XML with 
    ' as DiffGram
    ' </summary>
    Public Sub Example8()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Set the Relations to be nested
      dataSet.Relations("Customers_Invoices").Nested = True
      dataSet.Relations("Invoices_InvoiceItems").Nested = True

      ' Set all columns to output as attributes
      Dim col As DataColumn
      For Each col In customerTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col

      For Each col In invoiceTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col

      For Each col In invoiceItemTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col
      ' Change a couple rows
      invoiceItemTable.Rows(0)("Quantity") = 5

      ' Create a StringWriter to Stream ,into 
      Dim writer As New StreamWriter("test.xml")

      ' Create an XmlTextWriter to use to format the Xml
      Dim xmlWriter As New XmlTextWriter(writer)
      xmlWriter.Formatting = Formatting.Indented

      ' Get a DataSet of the Changes
      Dim dataSetChanges As DataSet = dataSet.GetChanges()

      ' Write the XML File out
      dataSetChanges.WriteXml(xmlWriter, XmlWriteMode.DiffGram)

      ' Close the Writer
      xmlWriter.Close()

      ' Read it and show it in the console
      Dim rdr As New StreamReader("test.xml", True)
      Console.WriteLine(rdr.ReadToEnd())
      rdr.Close()
    End Sub 'Example8



    ' <summary>
    ' DataSet output as XML with 
    ' namespaces
    ' </summary>
    Public Sub Example9()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Set the Relations to be nested
      dataSet.Relations("Customers_Invoices").Nested = True
      dataSet.Relations("Invoices_InvoiceItems").Nested = True

      ' Set all columns to output as attributes
      Dim col As DataColumn
      For Each col In customerTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col

      For Each col In invoiceTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col

      For Each col In invoiceItemTable.Columns
        col.ColumnMapping = MappingType.Attribute
      Next col
      ' Setup the XML Namespace and Prefix
      dataSet.Namespace = "ADONET"
      dataSet.Prefix = "an"

      ' Create a StringWriter to Stream ,into 
      Dim writer As New StreamWriter("test.xml")

      ' Create an XmlTextWriter to use to format the Xml
      Dim xmlWriter As New XmlTextWriter(writer)
      xmlWriter.Formatting = Formatting.Indented

      ' Write the XML File out
      dataSet.WriteXml(xmlWriter)

      ' Close the Writer
      xmlWriter.Close()

      ' Read it and show it in the console
      Dim rdr As New StreamReader("test.xml", True)
      Console.WriteLine(rdr.ReadToEnd())
      rdr.Close()
    End Sub 'Example9



    ' <summary>
    ' Filling a DataSet with XML
    ' </summary>
    Public Sub Example10()
      ' Fill the DataSet with XML
      Dim dataSet As New DataSet()
      dataSet.ReadXml("..\..\good.xml")

      Console.WriteLine(dataSet.GetXml())
    End Sub 'Example10



    ' <summary>
    ' Get the XML of a DataSet and
    ' Filling a new DataSet with it 
    ' </summary>
    Public Sub Example11()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Create a StringWriter to Stream ,into 
      Dim writer As New StreamWriter("test.xml")

      ' Create an XmlTextWriter to use to format the Xml
      Dim xmlWriter As New XmlTextWriter(writer)

      ' Write the XML File out
      dataSet.WriteXml(xmlWriter)

      ' Close the Writer
      xmlWriter.Close()

      ' Fill the new DataSet with XML
      Dim newDataSet As New DataSet()
      newDataSet.ReadXml("")

      ' Compare and report the result
      Dim areTheySame As Boolean = dataSet.GetXml() = newDataSet.GetXml()

      Console.WriteLine("Are they the same? {0}", areTheySame)
    End Sub 'Example11



    ' <summary>
    ' Get a DiffGram of a changed DataSet 
    ' and Merge it with another with changes 
    ' </summary>
    Public Sub Example12()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Create a StringWriter to Stream ,into 
      Dim writer As New StreamWriter("test.xml")

      ' Create an XmlTextWriter to use to format the Xml
      Dim xmlWriter As New XmlTextWriter(writer)

      ' Write the XML File out
      dataSet.WriteXml(xmlWriter, XmlWriteMode.WriteSchema)

      ' Close the Writer
      xmlWriter.Close()

      ' Fill the new DataSet with XML
      ' to make dataSet and newDataSet identical
      Dim newDataSet As New DataSet()
      newDataSet.ReadXml("")
      newDataSet.AcceptChanges()

      ' Change both datasets
      dataSet.Tables("Customers").Rows(0)("Zip") = "98765"
      newDataSet.Tables("Customers").Rows(1)("State") = "FL"

      ' Create Writer and Stream
      Dim newStream = New MemoryStream()
      Dim xmlNewWriter As New XmlTextWriter(CType(newStream, Stream), Nothing)
      xmlNewWriter.Formatting = Formatting.Indented

      ' Get DiffGrams of DataSet
      newDataSet.GetChanges().WriteXml(xmlNewWriter, XmlWriteMode.DiffGram)

      ' Write the DiffGram to the Console Window
      newStream.Position = 0
      Dim rdr As New StreamReader(CType(newStream, Stream))
      Console.WriteLine(rdr.ReadToEnd())

      ' Reset the Stream
      newStream.Position = 0

      ' Apply changes to dataSet
      dataSet.ReadXml(newStream, XmlReadMode.DiffGram)

      Form.TheGrid.DataSource = dataSet.Tables("Customers")
    End Sub 'Example12


    ' <summary>
    ' Save the XSD of a DataSet
    ' </summary>
    Public Sub Example13()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Create a StringWriter to Stream ,into 
      Dim writer As New StreamWriter("test.xsd")

      ' Create an XmlTextWriter to use to format the XSD
      Dim xmlWriter As New XmlTextWriter(writer)

      ' Write the XSD File out
      dataSet.WriteXmlSchema(xmlWriter)

      ' Close the Writer
      xmlWriter.Close()

      ' Make a new DataSet with the same 
      ' schema as our existing DataSet
      Dim newDataSet As New DataSet()
      newDataSet.ReadXmlSchema("")

      Form.TheGrid.DataSource = newDataSet.Tables("Customers")
    End Sub 'Example13


    ' <summary>
    ' Create an XmlDataDocument and 
    ' Show it's underlying XML Document
    ' </summary>
    Public Sub Example14()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Create an XmlDataDocument
      Dim dataDoc As New XmlDataDocument(dataSet)

      ' Do an XPath Query
      Dim node As XmlNode = dataDoc.SelectSingleNode("descendant::Invoices")

      ' Show the XML of the First Node found.
      Console.WriteLine(node.OuterXml)
    End Sub 'Example14


    ' <summary>
    ' Create an XmlDataDocument and Search it
    ' </summary>
    Public Sub Example15()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Create an XmlDataDocument
      Dim dataDoc As New XmlDataDocument(dataSet)

      ' Search it
      Dim node As XmlNode = dataDoc.SelectSingleNode("//Customers[FirstName = ""Tom""]")
      If Not (node Is Nothing) Then
        Console.WriteLine("Found:")
        Console.WriteLine(node.OuterXml)
      Else
        Console.WriteLine("No Nodes found")
      End If
    End Sub 'Example15


    ' <summary>
    ' Create an XmlDataDocument and 
    ' Transform it
    ' </summary>
    Public Sub Example16()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

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

      ' Create an XmlDataDocument
      Dim dataDoc As New XmlDataDocument(dataSet)

      ' Make a StringWriter to hold the results
      Dim writer As New StringWriter()

      ' Transform it
      Dim xslt As New XslTransform()
      xslt.Load("..\..\XmlDataDocSample.xsl")
      xslt.Transform(dataDoc, Nothing, writer) '

      ' Show the results
      Console.WriteLine(writer.ToString())
    End Sub 'Example16 
  End Class 'Chapter9
End Namespace 'BookExamples