Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Text
Imports System.Xml


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter3.
  ' </summary>
  Public Class Chapter3
    Inherits BaseChapter


    ' <summary>
    ' Creating a Command
    ' </summary>
    Public Sub Example1()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      '...
      Dim cmd As New SqlCommand()
      cmd.Connection = conn
      cmd.CommandText = "SELECT * FROM Customer;"
    End Sub 'Example1


    ' <summary>
    ' Creating a Command froma  Connection
    ' </summary>
    Public Sub Example2()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      '...
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM Customer;"
    End Sub 'Example2


    ' <summary>
    ' Specifying the Command Type
    ' </summary>
    Public Sub Example3()
      ' Create the connection
      Dim sqlconn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      '...
      Dim sqlcmd As SqlCommand = sqlconn.CreateCommand()

      ' You could set the CommandText to text, but it is 
      ' unnecessary
      sqlcmd.CommandText = "SELECT * FROM Customer;"

      Dim odbconn As New OleDbConnection()

      '...
      Dim odbcmd As OleDbCommand = odbconn.CreateCommand()
      odbcmd.CommandType = CommandType.StoredProcedure

      odbcmd.CommandText = "spMyStoredProc"
    End Sub 'Example3


    ' <summary>
    ' Using Execute Reader
    ' </summary>
    Public Sub Example4()
      ' ...
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      Dim sqlcmd As SqlCommand = conn.CreateCommand()

      Dim sqlrdr As SqlDataReader = sqlcmd.ExecuteReader()

      While sqlrdr.Read()
      End While
      '...

      '...
      Dim odbconn As New OleDbConnection()
      Dim odbcmd As OleDbCommand = odbconn.CreateCommand()

      Dim odbrdr As OleDbDataReader = odbcmd.ExecuteReader()

      While odbrdr.Read()
      End While
    End Sub 'Example4
    '...


    ' <summary>
    ' Using ExecuteXmlReader()
    ' </summary>
    Public Sub Example5()
      ' Create the connection
      Dim sqlconn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      '...
      Dim sqlcmd As SqlCommand = sqlconn.CreateCommand()
      sqlcmd.CommandType = CommandType.Text
      sqlcmd.CommandText = "SELECT * FROM Customer FOR XML AUTO;"

      '...
      Dim xml As XmlReader = sqlcmd.ExecuteXmlReader()
    End Sub 'Example5


    ' <summary>
    ' Using Parameters
    ' </summary>
    Public Sub Example6()
      ' Connect to the database
      Dim conn As New SqlConnection("Server=localhost;Database=master;" & _
      "Integrated Security=true;")
      conn.Open()

      ' Create the command for the stored procedure
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "sp_stored_procedures"
      cmd.CommandType = CommandType.StoredProcedure

      ' Set up the parameters
      Dim param As New SqlParameter("@RETURN", SqlDbType.Int)
      param.Direction = ParameterDirection.ReturnValue
      cmd.Parameters.Add(param)

      param = New SqlParameter("@sp_name", SqlDbType.NVarChar)
      param.Direction = ParameterDirection.Input
      cmd.Parameters.Add(param)

      param = New SqlParameter("@sp_owner", SqlDbType.NVarChar)
      param.Direction = ParameterDirection.Input
      param.Value = "dbo"
      cmd.Parameters.Add(param)

      param = New SqlParameter("@sp_qualifier", SqlDbType.NVarChar)
      param.Direction = ParameterDirection.Input
      cmd.Parameters.Add(param)

      ' Execute the stored procedure
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Run through the records and show 
      ' the stored procedure names 
      While rdr.Read()
        Console.WriteLine("Proc: {0}", rdr("PROCEDURE_NAME"))
      End While

      ' Clean up
      conn.Dispose()
    End Sub 'Example6


    ' <summary>
    ' Creating Parameters
    ' </summary>
    Public Sub Example7()
      ' ...
      Dim _cmd As New SqlCommand()

      ' The verbose way
      Dim param As New SqlParameter()
      param.ParameterName = "@RETURN_VALUE"
      param.DbType = DbType.Int32
      param.Direction = ParameterDirection.ReturnValue
      _cmd.Parameters.Add(param)

      ' The concise way
      _cmd.Parameters.Add("@RETURN_VALUE", DbType.Int32).Direction = ParameterDirection.ReturnValue
    End Sub 'Example7



    ' <summary>
    ' Using Stored Procedure Wrapper
    ' </summary>
    Public Sub Example9()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      conn.Open()

      ' Create the stored procedure wrapper
      Dim sp As New spAddMember(conn)

      ' Call the procedure
      sp.Execute("Maddux", "Greg", "123 Main Street", "Atlanta", "GA", "30307", "404-555-1212", "404-555-1213")

      ' If the query worked, then get the key
      Dim key As Int32
      If sp.RETURN_VALUE = 0 Then
        key = sp.Key
      End If
    End Sub 'Example9


    ' <summary>
    ' Calling Wrapper Stored Procedure's Parameters
    ' </summary>
    Public Sub Example10()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      conn.Open()

      ' Create the stored procedure wrapper
      Dim sp As New spAddMember(conn)

      ' Add the member variables
      sp.FirstName = "Greg"
      sp.LastName = "Maddux"
      sp.Address = "123 Main Street"
      sp.City = "Atlanta"
      sp.State = "GA"
      sp.Zip = "30307"
      sp.Phone = "404-555-1212"
      sp.Fax = "404-555-1213"

      ' Execute the stored procedure
      sp.Command.ExecuteNonQuery()

      ' If the query worked, then get the key
      Dim key As Int32
      If sp.RETURN_VALUE = 0 Then
        key = sp.Key
      End If
    End Sub 'Example10


    ' <summary>
    ' Calling Parameterized Queries
    ' </summary>
    Public Sub Example11()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand()

      ' Our CustomerID
      Dim custID As Integer = 12345

      ' Create the Command with a string.Format()
      cmd.CommandText = String.Format("SELECT * FROM Customer WHERE CustomerID = {0}", custID)

      ' Or with a StringBuilder
      Dim bldr As New StringBuilder()
      bldr.Append("SELECT * FROM Customer WHERE CustomerID = ")
      bldr.Append(custID)
      cmd.CommandText = bldr.ToString()
    End Sub 'Example11


    ' <summary>
    ' Calling a Query without Using Parameters
    ' </summary>
    Public Sub Example12()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      Dim cmd As SqlCommand = conn.CreateCommand()

      ' Our CustomerID
      Dim custID As Integer = 12345

      ' Create the command with a string.Format()
      cmd.CommandText = String.Format("SELECT * FROM Customer WHERE CustomerID = {0}", custID)

      ' Or with a StringBuilder
      Dim bldr As New StringBuilder()
      bldr.Append("SELECT * FROM Customer WHERE CustomerID = ")
      bldr.Append(custID)

      cmd.CommandText = bldr.ToString()
    End Sub 'Example12


    ' <summary>
    ' Calling a Stored Procedure without Parameter Objects
    ' </summary>
    Public Sub Example13()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      conn.Open()

      ' Create the command for the stored procedure
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "EXEC sp_stored_procedures NULL, 'dbo', NULL"

      ' Execute the stored procedure
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      '...
      ' Clean up
      conn.Close()
    End Sub 'Example13


    ' We can call this method to call the statement and let us
    ' know if it was committed or not
    Function RunCommand(ByVal conn As SqlConnection, ByVal sqlStatement As String) As Boolean
      ' Create the command
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = sqlStatement

      ' Set up the return parameter
      cmd.Parameters.Add("@RETURN", DbType.Int32).Direction = ParameterDirection.ReturnValue
      ' Open the connection
      conn.Open()

      ' Execute the command
      cmd.ExecuteScalar()

      ' Close the connection
      conn.Close()

      ' if result is zero, we committed so return true
      Dim result As Integer = CInt(cmd.Parameters("@RETURN").Value)
      Return result = 0
    End Function 'RunCommand



    ' <summary>
    ' Using a Transaction
    ' </summary>
    Public Sub Example15()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")

      conn.Open()

      ' Create the command
      Dim cmd As SqlCommand = conn.CreateCommand()

      ' Create the transaction
      cmd.Transaction = conn.BeginTransaction()

      Try
        ' Add the customer
        cmd.CommandText = "INSERT INTO Customer " & _
                          "   (CustomerID, LastName, FirstName, " & _
                          "    Phone, Zip) " & _
                          " VALUES (newid(), " & _
                          "         'Smoltz', 'John', '503-432-4565', " & _
                          "         '12345');"
        cmd.ExecuteNonQuery()

        ' Add the invoice
        cmd.CommandText = "INSERT INTO Invoice " & _
                          "  (InvoiceID, InvoiceNumber, " & _
                          "   InvoiceDate, Terms) " & _
                          "VALUES (newid(), '123456', " & _
                          "        '05/01/2001', 'Net 20');"
        cmd.ExecuteNonQuery()

        ' If we got this far then commit it
        cmd.Transaction.Commit()
      Catch ex As Exception
        cmd.Transaction.Rollback()
        Console.WriteLine(("Command failed: " + ex.Message + ControlChars.Lf + "Transaction Rolled back"))
      End Try
    End Sub 'Example15



    ' <summary>
    ' Rolling Back a Transaction
    ' </summary>
    Public Sub Example16()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")
      conn.Open()

      ' Create the command
      Dim cmd As SqlCommand = conn.CreateCommand()

      ' Create the transaction
      cmd.Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted)

      Try
        ' Add the customer
        cmd.CommandText = "INSERT INTO Customer " & _
                          "  (CustomerID, LastName, FirstName, Phone, Zip) " & _
                          "VALUES (newid(), 'Smoltz', 'John', " & _
                          "  '503-432-4565', '12345');"
        cmd.ExecuteNonQuery()

        ' Create a SavePoint
        cmd.Transaction.Save("New Customer")

        Try

          ' Add the invoice
          cmd.CommandText = "INSERT INTO Invoice " & _
                            "  (InvoiceID, InvoiceNumber, InvoiceDate, Terms) " & _
                            "VALUES (newid(), '123456', '05/01/2001', " & _
                            "  'Net 20');"
          cmd.ExecuteNonQuery()

        Catch
          ' Roll back to after saving of the new customer
          cmd.Transaction.Rollback("New Customer")
        End Try

        ' If we got this far then commit it
        cmd.Transaction.Commit()

      Catch ex As Exception

        cmd.Transaction.Rollback()
        Console.WriteLine("Command failed: {0}" & _
                          ControlChars.Lf & _
                          "Transaction Rolled back", _
                           ex.Message)

      End Try

    End Sub 'Example16

    ' <summary>
    ' Executing a Query without Batching
    ' </summary>
    Public Sub Example17()
      Dim sQuery1 As String = "INSERT INTO Customer " & _
      "(CustomerID, LastName, FirstName, Phone, Zip) " & _
      "VALUES (newid(), 'Smoltz', 'John', " & _
      "'503-432-4565', '12345');"

      Dim sQuery2 As String = "INSERT INTO Customer " & _
      "(CustomerID, LastName, FirstName, Phone, Zip) " & _
      "VALUES (newid(), 'Maddux', 'Greg', " & _
      "'503-432-4566', '12345');"

      ' Create the connection
      Dim sqlconn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")
      sqlconn.Open()

      '...
      Dim sqlcmd As SqlCommand = sqlconn.CreateCommand()
      sqlcmd.CommandType = CommandType.Text

      ' First query
      sqlcmd.CommandText = sQuery1
      sqlcmd.ExecuteNonQuery()

      ' Second query
      sqlcmd.CommandText = sQuery2
      sqlcmd.ExecuteNonQuery()
    End Sub 'Example17


    ' <summary>
    ' Executing a Batch Query
    ' </summary>
    Public Sub Example18()
      Dim sQuery As String = "INSERT INTO Customer " & _
      "(CustomerID, LastName, FirstName, Phone, Zip) " & _
      "VALUES (newid(), 'Smoltz', 'John', " & _
      "'503-432-4565', '12345'); " & _
      "INSERT INTO Customer " & _
      "(CustomerID, LastName, FirstName, Phone, Zip) " & _
      "VALUES (newid(), 'Maddux', 'Greg', " & _
      "'503-432-4566', '12345');"

      ' Create the connection
      Dim sqlconn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")
      sqlconn.Open()

      Dim sqlcmd As SqlCommand = sqlconn.CreateCommand()
      sqlcmd.CommandType = CommandType.Text

      ' Batch query
      sqlcmd.CommandText = sQuery

      sqlcmd.ExecuteNonQuery()
    End Sub 'Example18


    ' <summary>
    ' Retrieving Multiple Result Sets with a DataReader
    ' </summary>
    Public Sub Example19()
      ' Create the connection
      Dim conn As New SqlConnection("Server=localhost;" & _
      "Database=ADONET;" & _
      "Integrated Security=true;")
      conn.Open()

      ' Create a command with two selects to return 
      ' two Result Sets 
      Dim cmd As SqlCommand = conn.CreateCommand()
      cmd.CommandText = "SELECT * FROM Customer; " & _
      "SELECT * FROM Invoice;"

      ' Get a DataReader to go through the ResultSets 
      Dim rdr As SqlDataReader = cmd.ExecuteReader()

      ' Go through each row and ResultSet
      Do
        ' while we have more rows in a ResultSet 
        While rdr.Read()
          Console.WriteLine(rdr(0))
        End While
      Loop While rdr.NextResult() ' Move to the next one and do it again 
    End Sub 'Example19 ' After we're through the first ResultSet 
  End Class 'Chapter3



  Public Class spAddMember
    Implements IDisposable

    Public Sub New(ByVal conn As SqlConnection)
      ConstructCommand()
      _cmd.Connection = conn
    End Sub 'New


    Public ReadOnly Property Command() As SqlCommand
      Get
        Return _cmd
      End Get
    End Property


    Public Function Execute(ByVal firstName As String, _
                            ByVal lastName As String, _
                            ByVal address As String, _
                            ByVal city As String, _
                            ByVal state As String, _
                            ByVal zip As String, _
                            ByVal phone As String, _
                            ByVal fax As String) As Int32
      firstName = firstName
      lastName = lastName
      address = address
      city = city
      state = state
      zip = zip
      phone = phone
      Fax = Fax
      _cmd.ExecuteNonQuery()
      Return RETURN_VALUE
    End Function 'Execute


    ' IDisposable
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
      _cmd.Dispose()
    End Sub 'Dispose

    ' Parameter Access

    Public ReadOnly Property RETURN_VALUE() As Int32
      Get
        Return CType(_cmd.Parameters("@RETURN_VALUE").Value, Int32)
      End Get
    End Property


    Public WriteOnly Property FirstName() As [String]
      Set(ByVal Value As [String])
        _cmd.Parameters("@FirstName").Value = Value
      End Set
    End Property


    Public WriteOnly Property LastName() As [String]
      Set(ByVal Value As [String])
        _cmd.Parameters("@LastName").Value = Value
      End Set
    End Property


    Public WriteOnly Property Address() As [String]
      Set(ByVal Value As [String])
        _cmd.Parameters("@Address").Value = Value
      End Set
    End Property


    Public WriteOnly Property City() As [String]
      Set(ByVal Value As [String])
        _cmd.Parameters("@City").Value = Value
      End Set
    End Property


    Public WriteOnly Property State() As [String]
      Set(ByVal Value As [String])
        _cmd.Parameters("@State").Value = Value
      End Set
    End Property


    Public WriteOnly Property Zip() As [String]
      Set(ByVal Value As [String])
        _cmd.Parameters("@Zip").Value = Value
      End Set
    End Property


    Public WriteOnly Property Phone() As [String]
      Set(ByVal Value As [String])
        _cmd.Parameters("@Phone").Value = Value
      End Set
    End Property


    Public WriteOnly Property Fax() As [String]
      Set(ByVal Value As [String])
        _cmd.Parameters("@Fax").Value = Value
      End Set
    End Property


    Public ReadOnly Property Key() As Int32
      Get
        Return CType(_cmd.Parameters("@Key").Value, Int32)
      End Get
    End Property


    ' Protected member that constructs the command object
    Protected Sub ConstructCommand()
      _cmd = New SqlCommand("spAddMember")
      _cmd.CommandType = CommandType.StoredProcedure

      ' RETURN_VALUE parameter
      Dim _RETURN_VALUE As New SqlParameter()
      _RETURN_VALUE.ParameterName = "@RETURN_VALUE"
      _RETURN_VALUE.DbType = DbType.Int32
      _RETURN_VALUE.Direction = ParameterDirection.ReturnValue
      _RETURN_VALUE.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_RETURN_VALUE)

      ' FirstName parameter
      Dim _FirstName As New SqlParameter()
      _FirstName.ParameterName = "@FirstName"
      _FirstName.DbType = DbType.String
      _FirstName.Direction = ParameterDirection.Input
      _FirstName.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_FirstName)

      ' LastName parameter
      Dim _LastName As New SqlParameter()
      _LastName.ParameterName = "@LastName"
      _LastName.DbType = DbType.String
      _LastName.Direction = ParameterDirection.Input
      _LastName.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_LastName)

      ' Address parameter
      Dim _Address As New SqlParameter()
      _Address.ParameterName = "@Address"
      _Address.DbType = DbType.String
      _Address.Direction = ParameterDirection.Input
      _Address.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_Address)

      ' City parameter
      Dim _City As New SqlParameter()
      _City.ParameterName = "@City"
      _City.DbType = DbType.String
      _City.Direction = ParameterDirection.Input
      _City.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_City)

      ' State parameter
      Dim _State As New SqlParameter()
      _State.ParameterName = "@State"
      _State.DbType = DbType.String
      _State.Direction = ParameterDirection.Input
      _State.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_State)

      ' Zip parameter
      Dim _Zip As New SqlParameter()
      _Zip.ParameterName = "@Zip"
      _Zip.DbType = DbType.String
      _Zip.Direction = ParameterDirection.Input
      _Zip.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_Zip)

      ' Phone parameter
      Dim _Phone As New SqlParameter()
      _Phone.ParameterName = "@Phone"
      _Phone.DbType = DbType.String
      _Phone.Direction = ParameterDirection.Input
      _Phone.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_Phone)

      ' Fax parameter
      Dim _Fax As New SqlParameter()
      _Fax.ParameterName = "@Fax"
      _Fax.DbType = DbType.String
      _Fax.Direction = ParameterDirection.Input
      _Fax.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_Fax)

      ' Key parameter
      Dim _Key As New SqlParameter()
      _Key.ParameterName = "@Key"
      _Key.DbType = DbType.Int32
      _Key.Direction = ParameterDirection.Output
      _Key.SourceVersion = DataRowVersion.Current
      _cmd.Parameters.Add(_Key)
    End Sub 'ConstructCommand

    ' Data members
    Protected _cmd As SqlCommand
  End Class 'spAddMember 
End Namespace 'BookExamples

