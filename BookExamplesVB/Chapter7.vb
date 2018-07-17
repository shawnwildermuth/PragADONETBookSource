Imports System
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter7.
  ' </summary>
  Public Class Chapter7
    Inherits BaseChapter

    ' <summary>
    ' 
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

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Write the name of each customer to the 
      ' console using the Column Name
      Console.WriteLine("Customer List")
      Console.WriteLine("=============")
      Dim row As DataRow
      For Each row In dataTable.Rows
        Console.WriteLine("{0}, {1}", row("LastName"), row("FirstName"))
      Next row
    End Sub 'Example1


    ' <summary>
    ' 
    ' </summary>
    Public Sub Example2()
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

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Write the name of each customer to the 
      ' console using the Column Name
      Console.WriteLine("Customer List")
      Console.WriteLine("=============")
      Dim row As DataRow
      For Each row In dataTable.Rows
        Console.WriteLine("{0}, {1}", row("LastName"), row("FirstName"))
      Next row

      ' Write and empty line
      Console.WriteLine("")

      ' Write the name of each customer to the 
      ' console using the Column Ordinal Number
      Console.WriteLine("Customer List")
      Console.WriteLine("=============")

      For Each row In dataTable.Rows
        Console.WriteLine("{0}, {1}", row(1), row(2))
      Next row

      ' Get object references to the DataColumns
      Dim lastNameColumn As DataColumn = dataTable.Columns("LastName")
      Dim firstNameColumn As DataColumn = dataTable.Columns("FirstName")

      ' Write the name of each customer to the 
      ' console using the Column Ordinal Number
      Console.WriteLine("Customer List")
      Console.WriteLine("=============")

      For Each row In dataTable.Rows
        Console.WriteLine("{0}, {1}", row(lastNameColumn), row(firstNameColumn))
      Next row
    End Sub 'Example2


    Public Sub Example3()
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

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Write the name of each customer to the 
      ' console using the Column Name
      Console.WriteLine("Customer List")
      Console.WriteLine("=============")
      Dim row As DataRow
      For Each row In dataTable.Rows
        Console.WriteLine("{0}, {1}:", row("LastName"), row("FirstName"))
        Dim x As Integer

        While x < row.ItemArray.GetLength(0)
          Dim obj As Object = row.ItemArray(x)
          If obj.GetType().Equals(GetType(Guid)) Then
            Console.WriteLine("  {0} : {1} *Should be readonly*", obj.GetType().Name, obj)
          Else
            If obj.GetType().Equals(GetType(DBNull)) Then
              Console.WriteLine("  {0} : ColumnType: {1}", obj.GetType().Name, dataTable.Columns(x).DataType.Name)
            Else
              Console.WriteLine("  {0} : {1}", obj.GetType().Name, obj)
            End If
          End If
        End While
      Next row
    End Sub 'Example3


    ' <summary>
    ' Runtime Type-Safety
    ' </summary>
    Public Sub Example4()
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

      ' Get object reference of the first Row for simplified use
      Dim row As DataRow = dataSet.Tables(0).Rows(0)

      ' Set some valid values
      row("LastName") = "Millwood"
      row("FirstName") = "Kevin"

      ' Set a Double
      row("Discount") = 0.15

      ' Set a Date 
      ' (succeeds since this converts
      ' to a DateTime easily)
      row("DOB") = "04/24/1969"

      ' This would fail since the date is bad
      'row["DOB"] = "04/31/1969";
      ' Set a Bad Type
      ' (Fails since this string is incompatible with the float)
      row("Discount") = ".15"

      Dim value As Object
      For Each value In row.ItemArray
        Console.WriteLine("{0}", value)
      Next value
    End Sub 'Example4


    Public Sub Example5()
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

      ' Get object reference of the first Row for simplified use
      Dim row As DataRow = dataSet.Tables(0).Rows(0)

      ' Start the Edit
      row.BeginEdit()

      ' Set some valid values
      row("LastName") = "Millwood"
      row("FirstName") = "Kevin"

      ' Set a Double
      row("Discount") = 0.15

      ' End the Edit
      row.EndEdit()

      ' Start the Edit Again
      row.BeginEdit()

      ' Set a Date 
      ' (succeeds since this converts
      ' to a DateTime easily)
      row("DOB") = "04/24/1969"

      ' We want to revert, so we call CancelEdit()
      row.CancelEdit()

      form.TheGrid.DataSource = dataSet.Tables(0)
    End Sub 'Example5


    Public Sub Example6()
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

      ' Get object reference of the first Row for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Start the DataLoad
      ' (disabling constraints, notifications 
      ' and indexes)
      dataTable.BeginLoadData()

      ' Create a Row
      Dim row(dataTable.Columns.Count) As Object
      row(0) = Guid.NewGuid()
      row(1) = "Kevin"
      row(2) = "Millwood"

      ' Add it
      ' but, don't tell the row that its been 
      ' updated in the data store
      dataTable.LoadDataRow(row, False)

      ' Create a Row
      row = New Object(dataTable.Columns.Count) {}
      row(0) = Guid.NewGuid()
      row(1) = "Damian"
      row(2) = "Moss"

      ' Add it
      ' and, tell it to mark the row as already 
      ' updated in the data stored
      dataTable.LoadDataRow(row, True)

      ' Finish the Loading 
      ' (turning back on constraints, notifications 
      ' and indexes)
      dataTable.EndLoadData()

      form.TheGrid.DataSource = dataSet.Tables(0)
    End Sub 'Example6


    Public Sub Example7()
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

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Add a row by Creating a new DataRow
      Dim newRow As DataRow = dataTable.NewRow()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Millwood"
      newRow("FirstName") = "Kevin"
      dataTable.Rows.Add(newRow) ' <- Important!
      ' Add a row by appending an Item Array (of objects)
      Dim newValues(dataTable.Columns.Count) As Object
      newValues(0) = Guid.NewGuid()
      newValues(1) = "Damian"
      newValues(2) = "Moss"
      dataTable.Rows.Add(newValues) ' <- Important!
      ' Add a row by Creating a new DataRow
      Dim insertedRow As DataRow = dataTable.NewRow()
      insertedRow("CustomerID") = Guid.NewGuid()
      insertedRow("LastName") = "Marquis"
      insertedRow("FirstName") = "Jason"
      dataTable.Rows.InsertAt(insertedRow, 1) ' <- Important!
      form.TheGrid.DataSource = dataTable
    End Sub 'Example7


    Public Sub Example8()
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

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Add a row by Creating a new DataRow
      Dim newRow As DataRow = dataTable.NewRow()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Millwood"
      newRow("FirstName") = "Kevin"
      dataTable.Rows.Add(newRow) ' <- Important!
      ' Now let's Delete it
      dataTable.Rows.Remove(newRow)

      ' Get the First Row
      Dim row As DataRow = dataSet.Tables(0).Rows(0)

      ' Delete It!
      row.Delete()

      ' Now let's delete Row 2 by ordinal number
      dataTable.Rows.RemoveAt(1)

      form.TheGrid.DataSource = dataSet.Tables(0)
    End Sub 'Example8


    Public Sub Example9()
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

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Add a row 
      Dim newRow As DataRow = dataTable.NewRow()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Millwood"
      newRow("FirstName") = "Kevin"
      dataTable.Rows.Add(newRow) ' <- Important!
      ' Report the State
      Console.WriteLine("New Row State:" + ControlChars.Tab + ControlChars.Tab + "{0}", newRow.RowState)

      ' Get the First Row
      Dim deleteRow As DataRow = dataSet.Tables(0).Rows(0)

      ' Delete It!
      deleteRow.Delete()

      ' Report the State
      Console.WriteLine("Deleted Row State:" + ControlChars.Tab + ControlChars.Tab + "{0}", deleteRow.RowState)

      ' Get another row
      Dim changeRow As DataRow = dataSet.Tables(0).Rows(1)

      ' Change a value
      changeRow("DOB") = "04/24/1969"

      ' Report the State
      Console.WriteLine("Changed Row State:" + ControlChars.Tab + "{0}", changeRow.RowState)

      ' Get yet another row
      Dim unchangedRow As DataRow = dataSet.Tables(0).Rows(2)

      ' Report the State
      Console.WriteLine("Unchanged Row State:" + ControlChars.Tab + "{0}", unchangedRow.RowState)
    End Sub 'Example9


    Public Sub Example10()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create the customerAdapter
      Dim customerAdapter As New SqlDataAdapter()
      customerAdapter.SelectCommand = conn.CreateCommand()
      customerAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Create the InvoiceAdapter
      Dim invoiceAdapter As New SqlDataAdapter()
      invoiceAdapter.SelectCommand = conn.CreateCommand()
      invoiceAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICE"

      ' Create the itemAdapter
      Dim itemAdapter As New SqlDataAdapter()
      itemAdapter.SelectCommand = conn.CreateCommand()
      itemAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICEITEM"

      ' Create the itemAdapter
      Dim productAdapter As New SqlDataAdapter()
      productAdapter.SelectCommand = conn.CreateCommand()
      productAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      customerAdapter.Fill(dataSet, "Customers")
      invoiceAdapter.Fill(dataSet, "Invoices")
      itemAdapter.Fill(dataSet, "InvoiceItems")
      productAdapter.Fill(dataSet, "Products")

      ' Get the Columns to create the relations
      Dim custIDColumn As DataColumn = dataSet.Tables("Customers").Columns("CustomerID")
      Dim invCustIDColumn As DataColumn = dataSet.Tables("Invoices").Columns("CustomerID")
      Dim invIDColumn As DataColumn = dataSet.Tables("Invoices").Columns("invoiceID")
      Dim itemInvIDColumn As DataColumn = dataSet.Tables("InvoiceItems").Columns("invoiceID")
      Dim itemprodIDColumn As DataColumn = dataSet.Tables("InvoiceItems").Columns("ProductID")
      Dim prodIDColumn As DataColumn = dataSet.Tables("Products").Columns("ProductID")

      ' Setup relationships
      dataSet.Relations.Add("Customer_Invoice", custIDColumn, invCustIDColumn, True)
      dataSet.Relations.Add("Invoice_Item", invIDColumn, itemInvIDColumn, True)
      dataSet.Relations.Add("Item_Product", itemprodIDColumn, prodIDColumn, False)

      ' Walk throught the customers and 
      ' show all the invoices
      Dim custRow As DataRow
      For Each custRow In dataSet.Tables("Customers").Rows
        ' Write out Customer Name
        Console.WriteLine("{0}, {1}", custRow("LastName"), custRow("FirstName"))

        ' List Invoices
        Dim invoiceRows As DataRow() = custRow.GetChildRows("Customer_Invoice")
        Dim invRow As DataRow
        For Each invRow In invoiceRows
          Dim invoiceDate As String = CType(invRow("InvoiceDate"), DateTime).ToShortDateString()
          Console.WriteLine("  {0} : {1}", invRow("InvoiceNumber"), invoiceDate)
          Dim grandTotal As [Decimal] = 0

          ' Write out Invoice Items
          Dim itemRows As DataRow() = invRow.GetChildRows("Invoice_Item")
          Dim itemRow As DataRow
          For Each itemRow In itemRows
            Dim productRow As DataRow = itemRow.GetChildRows("Item_Product")(0)
            Dim quantity As Integer = CInt(itemRow("Quantity"))
            Dim total As [Decimal] = CType(productRow("Price"), [Decimal]) * quantity
            grandTotal += total
            Console.WriteLine("    {0} {1} @ {2:C} ea", productRow("Description"), quantity, total)
          Next itemRow
          Console.WriteLine("    Total: {0:C}", grandTotal)
        Next invRow
      Next custRow
    End Sub 'Example10


    Public Sub Example11()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet)

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Get a Count of the Rows in the default view
      Console.WriteLine("DefaultView Count: {0}", dataTable.DefaultView.Count)

      ' Create a new DataView
      Dim sortedView As New DataView(dataTable)
      sortedView.Sort = "Vendor"
    End Sub 'Example11


    Public Sub Example12()
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

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Sort by the LastName, Ascending order by default
      dataTable.DefaultView.Sort = "LastName"

      ' Sort by the LastName, Descending order
      dataTable.DefaultView.Sort = "LastName DESC"

      ' Sort by the LastName (Ascending), 
      ' and secondarily by FirstName (Descending)
      dataTable.DefaultView.Sort = "LastName, FirstName DESC"

      form.TheGrid.DataSource = dataTable.DefaultView
    End Sub 'Example12


    Public Sub Example13()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet)

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Set a filter to only see Rawlings Items
      dataTable.DefaultView.RowFilter = "Vendor = 'Rawlings'"

      ' Check count
      Console.WriteLine("Rawlings Products: {0}", dataTable.DefaultView.Count)

      form.TheGrid.DataSource = dataTable.DefaultView
    End Sub 'Example13


    Public Sub Example14()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet)

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Set a filter to see the original data
      ' (in modified rows, the original values 
      '  will be shown)
      dataTable.DefaultView.RowStateFilter = DataViewRowState.OriginalRows

      form.TheGrid.DataSource = dataTable.DefaultView
    End Sub 'Example14


    Public Sub Example15()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet)

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Find Rows that have Wilson as its vendor
      Dim rows As DataRow() = dataTable.Select("Vendor = 'Wilson'")
      Console.WriteLine("Simple Select Search:")

      ' Show them all
      Dim row As DataRow
      For Each row In rows
        Console.WriteLine("  Item: {0} - Vendor: {1}", row("ProductID"), row("Vendor"))
      Next row

      ' Find Rows with a compound expression
      Dim compoundRows As DataRow() = dataTable.Select("Vendor = 'Wilson' AND Price > 20.00")
      Console.WriteLine("Compound Select Search:")

      ' Show them all
      For Each row In compoundRows
        Console.WriteLine("  Item: {0} - Vendor: {1} - Price: {2}", row("ProductID"), row("Vendor"), row("Price"))
      Next row
    End Sub 'Example15



    Public Sub Example16()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create the customerAdapter
      Dim customerAdapter As New SqlDataAdapter()
      customerAdapter.SelectCommand = conn.CreateCommand()
      customerAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Create the InvoiceAdapter
      Dim invoiceAdapter As New SqlDataAdapter()
      invoiceAdapter.SelectCommand = conn.CreateCommand()
      invoiceAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICE"

      ' Create the itemAdapter
      Dim itemAdapter As New SqlDataAdapter()
      itemAdapter.SelectCommand = conn.CreateCommand()
      itemAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICEITEM"

      ' Create the itemAdapter
      Dim productAdapter As New SqlDataAdapter()
      productAdapter.SelectCommand = conn.CreateCommand()
      productAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      customerAdapter.Fill(dataSet, "Customers")
      invoiceAdapter.Fill(dataSet, "Invoices")
      itemAdapter.Fill(dataSet, "InvoiceItems")
      productAdapter.Fill(dataSet, "Products")

      ' Get the Columns to create the relations
      Dim custIDColumn As DataColumn = dataSet.Tables("Customers").Columns("CustomerID")
      Dim invCustIDColumn As DataColumn = dataSet.Tables("Invoices").Columns("CustomerID")
      Dim invIDColumn As DataColumn = dataSet.Tables("Invoices").Columns("invoiceID")
      Dim itemInvIDColumn As DataColumn = dataSet.Tables("InvoiceItems").Columns("invoiceID")
      Dim itemprodIDColumn As DataColumn = dataSet.Tables("InvoiceItems").Columns("ProductID")
      Dim prodIDColumn As DataColumn = dataSet.Tables("Products").Columns("ProductID")

      ' Setup relationships
      dataSet.Relations.Add("Customer_Invoice", custIDColumn, invCustIDColumn, True)
      dataSet.Relations.Add("Invoice_Item", invIDColumn, itemInvIDColumn, True)
      dataSet.Relations.Add("Item_Product", itemprodIDColumn, prodIDColumn, False)

      ' Search for Customers who's address is in Georgia
      Dim gaCusts As DataRow() = dataSet.Tables("Customers").Select("State = 'GA'")

      ' Create a new DataSet 
      Dim newDataSet As New DataSet()

      ' Copy the schema from the old DataSet to a stream
      Dim strm As New MemoryStream()
      dataSet.WriteXmlSchema(strm)

      ' Reset the Stream so we can read it
      strm.Position = 0

      ' Read in the schema to the new DataSet
      newDataSet.ReadXmlSchema(strm)

      ' Copy the Rows into the new DataSet
      newDataSet.Merge(gaCusts)
    End Sub 'Example16


    Public Sub Example17()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet)

      ' Get object reference of the Table for simplified use
      Dim dataTable As DataTable = dataSet.Tables(0)

      ' Set a Sort Order
      dataTable.DefaultView.Sort = "Vendor"

      ' Find the Wilson Product
      Dim found As Integer = dataTable.DefaultView.Find("Wilson")
      Console.WriteLine("Vendor: {0}", dataTable.DefaultView(found)("Vendor"))

      ' Find all Rawlings Products
      Dim rows As DataRowView() = dataTable.DefaultView.FindRows("Rawlings")
      Console.WriteLine("Rawlings count: {0}", rows.Length)

      ' Set a compound Sort Order
      dataTable.DefaultView.Sort = "Vendor, Price DESC"

      ' Find the compound criteria product
      Dim criteria() As Object = {"Wilson", 29.99}
      found = dataTable.DefaultView.Find(criteria)
      Console.WriteLine("Compound Vendor Search: {0}", dataTable.DefaultView(found)("Vendor"))
    End Sub 'Example17



    Public Sub Example18()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")

      ' Create the customerAdapter
      Dim customerAdapter As New SqlDataAdapter()
      customerAdapter.SelectCommand = conn.CreateCommand()
      customerAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Create the InvoiceAdapter
      Dim invoiceAdapter As New SqlDataAdapter()
      invoiceAdapter.SelectCommand = conn.CreateCommand()
      invoiceAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICE"

      ' Create the itemAdapter
      Dim itemAdapter As New SqlDataAdapter()
      itemAdapter.SelectCommand = conn.CreateCommand()
      itemAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICEITEM"

      ' Create the itemAdapter
      Dim productAdapter As New SqlDataAdapter()
      productAdapter.SelectCommand = conn.CreateCommand()
      productAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Create the DataSets
      Dim mainDataSet As New DataSet()
      Dim secondDataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      customerAdapter.Fill(mainDataSet, "Customers")
      invoiceAdapter.Fill(mainDataSet, "Invoices")
      itemAdapter.Fill(secondDataSet, "InvoiceItems")
      productAdapter.Fill(secondDataSet, "Products")

      ' Merge two DataSets together (where they have the same schema)
      mainDataSet.Merge(secondDataSet)

      ' Merge two DataSets together (where they have the same schema)
      mainDataSet.Merge(secondDataSet.Tables("Products"))

      ' Merge changes from o0ne DataSet into another where they both have 
      ' the same schema
      mainDataSet.Merge(secondDataSet.GetChanges())

      ' Merge changes from o0ne DataSet into another where they both have 
      ' the same schema
      mainDataSet.Merge(secondDataSet.Tables("Products").GetChanges())

      ' Merge two DataSets with dissimilar Schema
      mainDataSet.Merge(secondDataSet, False, MissingSchemaAction.AddWithKey)

      ' Merge a DataTable into a DataSet where the Table does not exist
      mainDataSet.Merge(secondDataSet.Tables("Products"), False, MissingSchemaAction.AddWithKey)
    End Sub 'Example18 
  End Class 'Chapter7 
End Namespace 'BookExamples
