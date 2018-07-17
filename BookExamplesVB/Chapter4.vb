Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter4.
  ' </summary>
  Public Class Chapter4
    Inherits BaseChapter

    Public Sub ExampleDialog()
      Dim ex As New Chapter4Example()
      ex.ShowDialog()
    End Sub 'ExampleDialog


    ' <summary>
    ' Using a DataReader
    ' </summary>
    Public Sub Example1()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM CUSTOMER"

      ' Get the reader object by executing the query
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Iterate through all the records
      While rdr.Read()
        Console.WriteLine(rdr(0))
      End While
    End Sub 'Example1



    ' <summary>
    ' Retrieving DataReader Columns
    ' </summary>
    Public Sub Example2()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM CUSTOMER"

      ' Get the reader object by executing the query
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Iterate through all the records
      While rdr.Read()
        Console.WriteLine(rdr(0)) ' These lines are identical
        Console.WriteLine(rdr("CustomerID")) ' in functionality
      End While
    End Sub 'Example2


    ' <summary>
    ' Type-Safe DataReader Access
    ' </summary>
    Public Sub Example3()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM CUSTOMER"

      ' Get the reader object by executing the query
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Iterate through all the records
      While rdr.Read()
        Console.WriteLine(CStr(rdr(0))) ' Identical
        Console.WriteLine(rdr.GetString(0)) ' Functionality
      End While
    End Sub 'Example3


    ' <summary>
    ' Using the System.Convert Class with the DataReader
    ' </summary>
    Public Sub Example4()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM PRODUCT"

      ' Get the reader object by executing the query
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Iterate through all the records
      While rdr.Read()
        Console.WriteLine(Convert.ToString(rdr("Price")))
      End While
    End Sub 'Example4


    ' <summary>
    ' Using GetOrdinal with Type-Safe Accessors
    ' </summary>
    Public Sub Example5()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM INVOICE"

      ' Get the reader object by executing the query
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Iterate through all the records
      While rdr.Read()
        ' These lines are identical in functionality
        Console.WriteLine(rdr.GetDateTime(rdr.GetOrdinal("InvoiceDate")))
        Console.WriteLine(CType(rdr("InvoiceDate"), DateTime))
      End While
    End Sub 'Example5


    ' <summary>
    ' Dealing with Null Values in a DataReader
    ' </summary>
    Public Sub Example6()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM INVOICE"

      ' Assumes that cmd is a SqlCommand
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      While rdr.Read()
        ' Write the field if the field is not null
        If Not rdr.IsDBNull(0) Then
          ' Write the first field
          Console.WriteLine(rdr.GetString(0))
        End If
      End While
    End Sub 'Example6


    ' <summary>
    ' Using the DataReader with Database Locks
    ' </summary>
    Public Sub Example10()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM INVOICE"

      ' Locks the records
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Does not lock the records
      Dim rdr2 As SqlDataReader = cmd.ExecuteReader(CommandBehavior.KeyInfo)
    End Sub 'Example10



    Public Sub Example11()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM CUSTOMER" + ControlChars.Lf + "SELECT * FROM INVOICE"

      ' Get the reader object by executing the query
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Do all result sets
      Do
        ' Iterate through all the records of the result
        While rdr.Read()
          Console.WriteLine(rdr(0))
        End While
      Loop While rdr.NextResult()
    End Sub 'Example11



    ' <summary>
    ' 
    ' </summary>
    Public Sub Example12()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the command object
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM CUSTOMER" + ControlChars.Lf + "SELECT * FROM INVOICE"

      ' Get the reader object by executing the query
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Do all Result Sets
      Do

        ' Get a DataTable of the schema from this Result Set
        Dim schema As DataTable = rdr.GetSchemaTable()

        ' Show the Result Set Header
        Console.WriteLine("Result Set")

        ' Dump the schema information
        Dim row As DataRow
        For Each row In schema.Rows
          Console.WriteLine("  Column:")
          Console.WriteLine("    {0} : ", row("ColumnName"))
          Console.WriteLine("      Type:        {0}", row("DataType"))
          Console.WriteLine("      IsUnique:    {0}", row("IsUnique"))
          Console.WriteLine("      AllowDBNull: {0}", row("AllowDBNull"))
        Next row
      Loop While rdr.NextResult()
    End Sub 'Example12
  End Class 'Chapter4 
End Namespace 'BookExamples
