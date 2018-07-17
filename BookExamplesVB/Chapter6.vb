Imports System
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter6.
  ' </summary>
  Public Class Chapter6
    Inherits BaseChapter

    Public Sub Example1()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create the Invoice DataAdapter
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")
      daInvoices.Fill(dataSet, "Invoices")

      ' Show the Customer Name
      Console.WriteLine(dataSet.Tables("Customers").Rows(0)("FirstName").ToString())
      Console.WriteLine(dataSet.Tables("Customers").Rows(0)("LastName").ToString())
      Console.WriteLine(dataSet.Tables("Customers").Rows(0)("HomePhone").ToString())

      ' Change an Invoice Number with a string 
      ' this shouldn't work because InvoiceNumber expects an integer
      dataSet.Tables("Invoices").Rows(0)("InvoiceNumber") = "15234"
    End Sub 'Example1


    Public Sub Example2()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create the Invoice DataAdapter
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE", conn)

      ' Create your blank DataSet
      Dim dataSet As New CustomerTDS()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")
      daInvoices.Fill(dataSet, "Invoices")

      ' Show the Customer Name
      Console.WriteLine(dataSet.Customer(0).FirstName)
      Console.WriteLine(dataSet.Customer(0).LastName)
      Console.WriteLine(dataSet.Customer(0).HomePhone)
    End Sub 'Example2

    ' This will not compile because InvoiceNumber expects an integer
    'dataSet.Invoice[0].InvoiceNumber = "12345";


    Public Sub Example3()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create your blank DataSet
      Dim dataSet As New DataSet()

      ' Fill the DataSet with each DataAdapter
      daCustomers.Fill(dataSet, "Customers")

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

      ' Write out our xsd file to use to generate our typed DataSet
      dataSet.WriteXmlSchema("")
    End Sub 'Example3
    '
    'ToDo: Error processing original source shown below
    '
    '
    '------------------------------------^--- Bad escape sequence
    '
    'ToDo: Error processing original source shown below
    '
    '
    '-----------------------------------------------------^--- Illegal whitespace in constant
    '
    'ToDo: Error processing original source shown below
    '
    '
    '-------------------------------^--- Syntax error: ')' expected
    '
    'ToDo: Error processing original source shown below
    '
    '
    '-----------------------------------^--- Syntax error: ';' expected
    '
    'ToDo: Error processing original source shown below
    '
    '
    '-------------------------------------------------^--- Syntax error: ';' expected

    '
    'ToDo: Error processing original source shown below
    '
    '
    '-----^--- Syntax error: ';' expected

    Public Sub Example4()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create the Invoice DataAdapter
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE", conn)

      ' Create our New Typed DataAdapter
      Dim dataset As New CustomersObject()

      ' Use the DataAdapters to fill the DataSet
      daCustomers.Fill(dataset, "Customer")
      daInvoices.Fill(dataset, "Invoice")

      ' This will throw an exception because we're creating an Invoice
      ' Date in the future
      Dim invoice As CustomerTDS.InvoiceRow = dataset.Invoice.AddInvoiceRow(Guid.NewGuid(), _
      DateTime.Now.Add(New TimeSpan(4, 0, 0, 0)), "", "", "", dataset.Customer(0))
    End Sub 'Example4



    Public Sub Example5()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create the Invoice DataAdapter
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE", conn)

      ' Create our New Typed DataAdapter
      Dim dataset As New InheritedTDS()

      ' Use the DataAdapters to fill the DataSet
      daCustomers.Fill(dataset, "Customer")
      daInvoices.Fill(dataset, "Invoice")

      ' Make Sure We are getting the right DataTables
      Console.WriteLine("Number of Customers:        {0}", dataset.Customer.Count)
      Console.WriteLine("Number of Invoices:         {0}", dataset.Invoice.Count)
      Console.WriteLine("Type of DataRow (Invoices): {0}", dataset.Invoice.Rows(0).GetType().FullName)

      Form.TheGrid.DataSource = dataset
    End Sub 'Example5


    Public Sub Example6()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create a DataAdapter for each of the tables we're filling
      Dim daCustomers As New SqlDataAdapter("SELECT * FROM CUSTOMER;", conn)

      ' Create the Invoice DataAdapter
      Dim daInvoices As New SqlDataAdapter("SELECT * FROM INVOICE", conn)

      ' Create the DataSet
      Dim typedDS As New CustomerTDS()

      ' Use the DataAdapters to fill the DataSet
      daCustomers.Fill(typedDS, "Customer")
      daInvoices.Fill(typedDS, "Invoice")

      ' Show the address and # of invoices for each customer
      Dim custRow As CustomerTDS.CustomerRow
      For Each custRow In typedDS.Customer
        Console.WriteLine(custRow.FullName)
        Console.WriteLine(custRow.Address)
        Console.WriteLine("{0}, {1}  {2}", custRow.City, custRow.State, custRow.Zip)

        If custRow.IsHomePhoneNull() Then
          Console.WriteLine("{0} (hm)", (""))
        Else
          Console.WriteLine("{0} (hm)", custRow.HomePhone())
        End If

        If custRow.IsBusinessPhoneNull() Then
          Console.WriteLine("{0} (bus)", (""))
        Else
          Console.WriteLine("{0} (bus)", custRow.BusinessPhone())
        End If
        Console.WriteLine(("Invoices: " + custRow.GetChildRows("CustomerInvoice").Length))
        Console.WriteLine("")
      Next custRow
    End Sub 'Example6 
  End Class 'Chapter6
End Namespace 'BookExamples 