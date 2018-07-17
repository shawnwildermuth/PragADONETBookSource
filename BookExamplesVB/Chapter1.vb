Imports System
Imports System.Runtime.InteropServices
Imports ADODB
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter1.
  ' </summary>
  Public Class Chapter1
    Inherits BaseChapter


    ' <summary>
    ' Classic ADO through Interop
    ' </summary>
    Public Sub Example2()
      ' Open our Connection
      Dim conn As New Connection()

      conn.Open("Provider=SQLOLEDB;Server=localhost;" + "Database=ADONET", "someuser", "", 0)
      ' Query the database
      Dim cmd As New Command()
      cmd.ActiveConnection = conn
      cmd.CommandText = "SELECT * FROM CUSTOMER"
      Dim recaffected As Object = Nothing
      Dim prms As New Object()
      Dim rs As _Recordset = cmd.Execute(recaffected, prms, 0)

      ' Dump all the records to the standard output
      While Not rs.EOF
        Dim x As Integer
        For x = 0 To rs.Fields.Count - 1
          Console.Write((rs.Fields(x).Value.ToString() + ":"))
        Next x
        Console.WriteLine("") ' Endline
        rs.MoveNext()
      End While

      ' Clean up
      conn.Close()
    End Sub 'Example2


    ' <summary>
    ' DataReader example
    ' </summary>
    Public Sub Example3()

      ' Open our Connection
      Dim conn As New OleDbConnection("Provider=SQLOLEDB;" + "Server=localhost;" + "Database=ADONET;" + "UID=someuser;")

      conn.Open()

      ' Query the database
      Dim cmd As New OleDbCommand()
      cmd.Connection = conn
      cmd.CommandText = "SELECT * FROM CUSTOMER"

      ' Execute the Command to create the DataReader
      Dim reader As OleDbDataReader = cmd.ExecuteReader()

      ' Dump all the records to the standard output
      While reader.Read()
        Dim x As Integer
        For x = 0 To reader.FieldCount - 1
          Console.Write(reader.GetValue(x).ToString())
        Next x
        Console.WriteLine("") ' Endline
      End While

      ' Clean up
      conn.Close()
    End Sub 'Example3


    ' <summary>
    ' Shorter Connection
    ' </summary>
    Public Sub Example4()
      ' Open our Connection
      Dim conn As New OleDbConnection("Provider=SQLOLEDB;" + "Server=localhost;" + "Database=ADONET;" + "UID=someuser;")

      ' Connection opened here
      conn.Open()

      ' Create DataSet and Command objects
      Dim cmdAuthors As New OleDbCommand("SELECT COUNT(*) FROM CUSTOMER", conn)

      ' Execute the command
      Dim count As Integer = CInt(cmdAuthors.ExecuteScalar())

      ' Closed this fast!
      conn.Close()
    End Sub 'Example4


    ' <summary>
    ' Using a DataSet
    ' </summary>
    Public Sub Example5()
      ' Open our Connection
      Dim conn As New OleDbConnection("Provider=SQLOLEDB;" + "Server=localhost;" + "Database=ADONET;" + "UID=someuser;")

      ' Open the connection
      conn.Open()

      ' Create Dataset and Command Objects
      Dim ds As New DataSet()
      Dim daAuthors As New OleDbDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Fill the DataSet
      daAuthors.Fill(ds)

      ' We can close the connection without any ramifications!
      conn.Close()

      ' Get the table out of the DataSet
      Dim tbl As DataTable = ds.Tables("Table")

      ' Walk all the rows
      Dim row As DataRow
      For Each row In tbl.Rows
        ' Walk all the fields in the row
        Dim val As [Object]
        For Each val In row.ItemArray
          Console.Write(val.ToString())
        Next val
        Console.WriteLine("") ' End of line
      Next row
    End Sub 'Example5


    ' <summary>
    ' Updating from DataSet
    ' </summary>
    Public Sub Example6()
      ' Create the connection
      Dim conn As New OleDbConnection("Provider=SQLOLEDB;" + "Server=localhost;" + "Database=ADONET;" + "UID=someuser;")

      ' Create DataSet and Command objects
      Dim ds As New DataSet()
      Dim daAuthors As New OleDbDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Create an OleDbCommandBuilder to wrap
      ' the DataAdapter to support dynamic
      ' generation of update/insert/delete
      ' commands
      Dim bldr As New OleDbCommandBuilder(daAuthors)

      ' Fill the DataSet
      daAuthors.Fill(ds)

      ' Get the table out of the DataSet
      Dim tbl As DataTable = ds.Tables("Table")

      ' Set up the primary key
      Dim colArr(1) As DataColumn
      colArr(0) = tbl.Columns(0)
      tbl.PrimaryKey = colArr

      ' Insert a row
      Dim rowVals(3) As Object
      rowVals(0) = Guid.NewGuid()
      rowVals(1) = "Greg"
      rowVals(2) = "Maddux"
      Dim insertedRow As DataRow = tbl.Rows.Add(rowVals)

      ' Delete a row
      tbl.Rows(0).Delete()

      ' Change a row
      tbl.Rows(1).BeginEdit()
      tbl.Rows(1)("FirstName") = "New Name"
      tbl.Rows(1).EndEdit()

      ' Save changes
      conn.Open()

      daAuthors.Update(ds)
    End Sub 'Example6


    ' <summary>
    ' OleDb Example
    ' </summary>
    Public Sub Example7()
      ' Create the connection
      Dim conn As New OleDbConnection("Provider=SQLOLEDB;" + "Server=localhost;" + "Database=ADONET;" + "UID=someuser;")

      ' Create DataSet and Command objects
      Dim ds As New DataSet()

      Dim daAuthors As New OleDbDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Fill the DataSet
      daAuthors.Fill(ds)

      ' Get the table out of the DataSet
      Dim tbl As DataTable = ds.Tables("Table")

      ' Walk all the rows
      Dim row As DataRow
      For Each row In tbl.Rows
        ' Walk all the fields in the row
        Dim val As [Object]
        For Each val In row.ItemArray
          Console.Write(val.ToString())
        Next val
        Console.WriteLine("") ' End of line
      Next row
    End Sub 'Example7


    ' <summary>
    ' SQL Server Example
    ' </summary>
    Public Sub Example8()
      ' Create the connection
      Dim conn As New SqlConnection()
      conn.ConnectionString = "Server=localhost;" + "Database=ADONET;" + "UserID=someuser;"

      ' Create DataSet and Command objects
      Dim ds As New DataSet()

      Dim daAuthors As New SqlDataAdapter("SELECT * FROM CUSTOMER", conn)

      ' Fill the DataSet
      daAuthors.Fill(ds)

      ' We can close the connection without any ramifications!
      conn.Close()

      ' Get the table out of the DataSet
      Dim tbl As DataTable = ds.Tables("Table")

      ' Walk all the rows
      Dim row As DataRow
      For Each row In tbl.Rows
        ' Walk all the fields in the row
        Dim val As [Object]
        For Each val In row.ItemArray
          Console.Write(val.ToString())
        Next val
        Console.WriteLine("") ' End of Line
      Next row
    End Sub 'Example8
  End Class 'Chapter1
End Namespace 'BookExamples