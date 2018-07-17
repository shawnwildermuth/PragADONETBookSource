Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports Microsoft.Win32


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter2.
  ' </summary>
  Public Class Chapter2
    Inherits BaseChapter


    ' <summary>
    ' 
    ' </summary>
    Public Sub Example1()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")

      ' Open the connection
      conn.Open()

      ' Create the command object
      Dim cmd As New SqlCommand("SELECT * FROM Customers", conn)

      ' Execute the query
      Dim reader As SqlDataReader = cmd.ExecuteReader()

      ' Dump the results to the console
      While reader.Read()
        Console.WriteLine((reader("FirstName") + " " + reader("LastName")))
      End While

      ' Close the connection
      conn.Close()
    End Sub 'Example1


    ' <summary>
    ' Reusable Connections
    ' </summary>
    Public Sub Example2()
      ' Create and set up the server
      Dim conn As New SqlConnection("Server=localhost;" + "Database=ADONET;" + "Integrated Security=true;")

      ' Use the connection
      Dim cmd As New SqlCommand("SELECT COUNT(CustomerID)" + " FROM Customer", conn)

      ' Open the Connection
      conn.Open()

      ' Execute a command
      Dim result As Integer = CInt(cmd.ExecuteScalar())

      ' Close the Connection
      conn.Close()

      ' Do some work with the data retrieved
      ' ...
      ' Change the command information
      cmd.CommandText = "SELECT MAX(Discount)" + " FROM Customer;"

      ' Reopen the Connection
      conn.Open()

      ' Execute the new work
      Dim maxDiscount As Single = CSng(cmd.ExecuteScalar())

      ' Close the Connection
      conn.Close()
    End Sub 'Example2


    ' <summary>
    ' 
    ' </summary>
    Public Sub Example3()
      ' Create and setup the server
      Dim conn As New SqlConnection()
      conn.ConnectionString = "Server=localhost;" + "Database=ADONET;" + "Integrated Security=True;" + "ConnectionTimeout=5;"

      ' Use the connection
      Dim cmd As New SqlCommand("SELECT COUNT(au_id) FROM CUSTOMER;")
      cmd.Connection = conn

      ' Open the Connection
      conn.Open()

      ' Execute a command
      Dim result As Integer = CInt(cmd.ExecuteScalar())

      ' Change the Database that we're using
      conn.ChangeDatabase("master")

      ' Change the Command information
      cmd.CommandText = "SELECT COUNT(name) FROM dbo.sysdatabases;"

      ' Execute the new work
      Dim nDatabases As Integer = Convert.ToInt32(cmd.ExecuteScalar())

      ' Close the Connection
      conn.Close()

      ' Clean up our Resources
      conn.Dispose()
    End Sub 'Example3


    ' <summary>
    ' 
    ' </summary>
    Public Sub Example5()
      ' Create Connection
      Dim conn As New OleDbConnection()

      conn.ConnectionString = "Provider=SQLOLEDB.1;" + _
                              "Server=localhost;" + _
                              "Database=Northwind;" + _
                              "Integrated Security=SSPI;"

      ' Set Events
      AddHandler conn.InfoMessage, New OleDbInfoMessageEventHandler(AddressOf ConnInfo)
      AddHandler conn.StateChange, New StateChangeEventHandler(AddressOf ConnChange)

      ' Open Database
      conn.Open()

      ' Create the Command Object
      Dim cmd As OleDbCommand = conn.CreateCommand()

      cmd.CommandText = "SELECT * from [Order Details];" + "SELECT * from orders;"

      ' Get the Reader Object by Executing the Query
      Dim rdr As OleDbDataReader = cmd.ExecuteReader()

      ' Dump All Results
      Do
        Console.WriteLine("Result:")

        ' Iterate through all the records of the result
        While rdr.Read()
          Console.WriteLine(rdr(0))
        End While
      Loop While rdr.NextResult()
    End Sub 'Example5



    ' Info Event Handler
    Sub ConnInfo(ByVal sender As Object, ByVal e As OleDbInfoMessageEventArgs)
      Console.WriteLine(("Connection Info Message:" + e.Message))
    End Sub 'ConnInfo


    ' State Change Event Handler
    Sub ConnChange(ByVal sender As Object, ByVal e As StateChangeEventArgs)
      Console.WriteLine(("Connection State Changed: From: " + e.OriginalState.ToString() + " to " + e.CurrentState.ToString()))
    End Sub 'ConnChange


    ' <summary>
    ' 
    ' </summary>
    Public Sub Example9()
      ' Connect to the database
      Dim conn As New OleDbConnection()

      conn.ConnectionString = "Provider=SQLOLEDB;" + "Server=localhost;" + "Database=ADONET;" + "Integrated Security=SSPI;"

      conn.Open()

      ' Create a DataSet
      Dim ds As New DataSet()

      ' Get the tables in the database
      ds.Tables.Add(conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"}))

      ' Add a new table to the DataSet per table in the database
      Dim row As DataRow
      For Each row In ds.Tables(0).Rows
        ' Get a Table with the Columns of each table
        Dim tbl As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, row("TABLE_NAME"), Nothing})

        ' Change the TableName (since it will be named Columns 
        ' and we can't add multiple tables with the same name)
        tbl.TableName = row("TABLE_NAME").ToString()

        ' Add to it DataSet
        ds.Tables.Add(tbl)
      Next row
    End Sub 'Example9



    ' <summary>
    ' 
    ' </summary>
    Public Function Example10() As Integer
      Dim nResult As Integer = 0

      Try
        ' Try to call SomeFunction() to get the nResult
        SomeFunction()
      Catch exception As SqlException
        ' Whoops . . . if we got here, we must have a 
        ' problem with our SQL provider so show the user 
        ' what the error was and tell them that it is a 
        ' SQL provider error
        MessageBox.Show(("SQL Provider Error: " + exception.Message))
      Catch exception As Exception
        ' Whoops . . . if we got here, we must have a 
        ' problem, so show the user what the error was
        MessageBox.Show(exception.Message)
      Finally
        ' This gets called whether an exception was
        ' thrown or not
        nResult = -1
      End Try

      Return nResult
    End Function 'Example10


    Public Sub SomeFunction()
      Throw New Exception("Foo")
    End Sub 'SomeFunction


    ' <summary>
    ' 
    ' </summary>
    Public Sub Example11()
      Dim conn As New SqlConnection("Server=localhost;" + "Integrated Security=true")
      Try
        conn.Open()

        Dim cmd As New SqlCommand("SELECT * FROM Teams", conn)

        Dim reader As SqlDataReader = cmd.ExecuteReader()

        While reader.Read()
          Console.WriteLine((reader.GetString(2) + " " + reader.GetString(1)))
        End While
      Catch ex As Exception
        Console.WriteLine(("An Error Occurred: " + ex.Message))
      Finally
        ' Close the connection if it was opened
        ' correctly.
        If conn.State = ConnectionState.Open Then
          conn.Close()
        End If
      End Try
    End Sub 'Example11


    ' <summary>
    ' 
    ' </summary>
    Public Function Example12() As Integer
      Dim nResult As Integer = 0
      Try
        ' Try to call SomeFunction() to get the nResult
        SomeFunction()
      Catch ex As SqlException
        Dim [error] As String = ""

        ' Get the exception's message
        [error] += ex.Message + ControlChars.Lf

        ' Tack on each of the errors
        Dim err As SqlError
        For Each err In ex.Errors
          [error] += err.Message + ControlChars.Lf
        Next err

        ' Whoops . . . if we got here, we must have a 
        ' problem with our SQL provider so show the user 
        ' what the error was and tell them that it is a 
        ' SQL provider error
        MessageBox.Show(("SQL Provider Error: " + [error]))
      Finally
        ' This gets called whether an exception was
        ' thrown or not
        nResult = -1
      End Try

      Return nResult
    End Function 'Example12
  End Class 'Chapter2
    _ 

  '
  '
  ' Example Usage:
  '
  '   ODBCPooling.Enable();
  '

  Public Class ODBCPooling

    <System.Runtime.InteropServices.DllImport("odbc32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared _
      Function SQLSetEnvAttr(ByVal Environment As Long, _
                             ByVal EnvAttribute As Long, _
                             ByVal ValuePtr As Long, _
                             ByVal StringLength As Long) As Integer
    End Function

    Private Shared SQL_ATTR_CONNECTION_POOLING As Long = 201
    Private Shared SQL_CP_ONE_PER_DRIVER As Long = 1
    Private Shared SQL_IS_INTEGER As Long = -6
    Private Shared SQL_CP_OFF As Long = 0

    Shared Function Enable() As Integer
      Return SQLSetEnvAttr(0, SQL_ATTR_CONNECTION_POOLING, SQL_CP_ONE_PER_DRIVER, SQL_IS_INTEGER)
    End Function 'Enable


    Shared Function Disable() As Integer
      Return SQLSetEnvAttr(0, SQL_ATTR_CONNECTION_POOLING, SQL_CP_OFF, SQL_IS_INTEGER)
    End Function 'Disable
  End Class 'ODBCPooling
    _

  Public Class ConnectionFactory


    Public Overloads Shared Function CreateOleDbConnection() As OleDbConnection
      Return CreateOleDbConnection("ADONET")
    End Function 'CreateOleDbConnection


    Public Overloads Shared Function CreateOleDbConnection(ByVal sDatabase As String) As OleDbConnection
      Dim conn As New OleDbConnection()

      ' Set the Connection string
      conn.ConnectionString = "Provider=SQLOLEDB.1;" + "Data Source=localhost;" + "Database=" + sDatabase + ";" + "UID=sa;" + "Pwd=password;" + "ConnectionTimeout=5;"

      Return conn
    End Function 'CreateOleDbConnection
  End Class 'ConnectionFactory
    _

  Public Class DynamicConnectionFactory

    Public Shared Function CreateRegisteredConnection() As OleDbConnection
      Try
        ' You could store the connection string information 
        ' in the Registry, app.config, or even machine.config
        ' Get it from the Registry
        Dim sKey As String = "Software\AW\ADO.NET\Chapter2\ConnFactory"

        Dim fac As RegistryKey = Registry.LocalMachine.OpenSubKey(sKey)

        Dim sSrc As String = fac.GetValue("Data Source").ToString()
        Dim sDB As String = fac.GetValue("Database").ToString()
        Dim sUID As String = fac.GetValue("Database").ToString()
        Dim sPwd As String = fac.GetValue("Pwd").ToString()

        ' Create a new connection
        Dim conn As New OleDbConnection()

        ' Set the connection string
        conn.ConnectionString = "Provider=SQLOLEDB.1;" + "Data Source=" + sSrc + ";Database=" + sDB + ";UID=" + sUID + ";Pwd=" + sPwd + ";ConnectionTimeout=5;"

        fac.Close()
        Return conn
      Catch
      End Try
    End Function 'CreateRegisteredConnection ' ...
  End Class 'DynamicConnectionFactory
End Namespace 'BookExamples

