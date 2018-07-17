Imports System
Imports System.Data
Imports System.Data.SqlClient


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for Chapter8.
  ' </summary>
  Public Class Chapter8
    Inherits BaseChapter


    ' <summary>
    ' Simple Optimistic Concurrency
    ' </summary>
    Public Sub Example1()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")

      ' Add a new Customer
      Dim newRow As DataRow = custTable.NewRow()
      newRow.BeginEdit()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Remlinger"
      newRow("FirstName") = "Mike"
      newRow("Address") = "10 Aaron Way"
      newRow("City") = "Atlanta"
      newRow("State") = "GA"
      newRow("Zip") = "30307"
      newRow("HomePhone") = "(404) 543-8765"
      newRow.EndEdit()
      custTable.Rows.Add(newRow)

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("Address") = "53 Peachtree Center"
      oldRow("Zip") = "30342"

      ' Delete a Customer
      Dim delRow As DataRow = custTable.Rows(1)
      delRow.Delete()

      ' Create a command-builder to generate the Inserts/Updates/Deletes
      Dim bldr As New SqlCommandBuilder(dataAdapter)

      ' Update the Database
      conn.Open()
      dataAdapter.Update(custTable)
      conn.Close()

      form.TheGrid.DataSource = custTable
    End Sub 'Example1



    ' <summary>
    ' Improving on the CommandBuilder Queries
    ' Insert Query Only
    ' </summary>
    Public Sub Example2()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Build the Insert Command
      Dim insQry As String = ""
      insQry += "INSERT INTO CUSTOMER( "
      insQry += "  CustomerID, FirstName,  LastName, "
      insQry += "  MiddleName, Address, Apartment, "
      insQry += "  City, State, Zip, HomePhone, "
      insQry += "  BusinessPhone, DOB, Discount) "
      insQry += "VALUES ( @CustomerID, @FirstName, "
      insQry += "  @LastName, @MiddleName, @Address, "
      insQry += "  @Apartment, @City, @State, @Zip, "
      insQry += "  @HomePhone, @BusinessPhone, @DOB, "
      insQry += "  @Discount )"

      Dim insCmd As SqlCommand = conn.CreateCommand()
      insCmd.CommandText = insQry

      ' Get a reference of the collection for simplification
      Dim insParams As SqlParameterCollection = insCmd.Parameters

      ' Build the Parameters
      insParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      insParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName")
      insParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName")
      insParams("@MiddleName").IsNullable = True
      insParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName")
      insParams("@LastName").IsNullable = True
      insParams.Add("@Address", SqlDbType.NVarChar, 50, "Address")
      insParams("@Address").IsNullable = True
      insParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment")
      insParams("@Apartment").IsNullable = True
      insParams.Add("@City", SqlDbType.NVarChar, 50, "City")
      insParams("@City").IsNullable = True
      insParams.Add("@State", SqlDbType.NChar, 2, "State")
      insParams("@State").IsNullable = True
      insParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip")
      insParams("@Zip").IsNullable = True
      insParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone")
      insParams("@HomePhone").IsNullable = True
      insParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone")
      insParams("@BusinessPhone").IsNullable = True
      insParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB")
      insParams("@DOB").IsNullable = True
      insParams.Add("@Discount", SqlDbType.Float, 8, "Discount")
      insParams("@Discount").IsNullable = True

      ' Assign the Insert Command to the DataAdapter
      dataAdapter.InsertCommand = insCmd

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")

      ' Add a new Customer
      Dim newRow As DataRow = custTable.NewRow()
      newRow.BeginEdit()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Remlinger"
      newRow("FirstName") = "Mike"
      newRow("Address") = "10 Aaron Way"
      newRow("City") = "Atlanta"
      newRow("State") = "GA"
      newRow("Zip") = "30307"
      newRow("HomePhone") = "(404) 543-8765"
      newRow.EndEdit()
      custTable.Rows.Add(newRow)

      Try
        ' Update the Database
        conn.Open()
        dataAdapter.Update(custTable)
        Console.Write("Successfully Updated the Database")
      Catch ex As SqlException
        Console.WriteLine(ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try
    End Sub 'Example2



    ' <summary>
    ' Improving on the CommandBuilder Queries
    ' Delete Query Only
    ' </summary>
    Public Sub Example3()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Build the Delete Command
      Dim delQry As String = ""
      delQry += "DELETE FROM CUSTOMER "
      delQry += "WHERE CustomerID = @CustomerID AND "
      delQry += "  Stamp = @Stamp"

      Dim delCmd As SqlCommand = conn.CreateCommand()
      delCmd.CommandText = delQry

      ' Get a reference of the collection for simplification
      Dim delParams As SqlParameterCollection = delCmd.Parameters

      ' Build the Parameters
      delParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      delParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp")

      ' Assign the Delete Command to the DataAdapter
      dataAdapter.DeleteCommand = delCmd

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")

      ' Delete a Customer
      Dim delRow As DataRow = custTable.Rows(1)
      delRow.Delete()

      Try
        ' Update the Database
        conn.Open()
        dataAdapter.Update(custTable)
        Console.Write("Successfully Updated the Database")
      Catch ex As SqlException
        Console.WriteLine(ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try
    End Sub 'Example3



    ' <summary>
    ' Improving on the CommandBuilder Queries
    ' Update Query Only
    ' </summary>
    Public Sub Example4()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Build the Update Command
      Dim updQry As String = ""
      updQry += "UPDATE CUSTOMER SET "
      updQry += "  CustomerID = @CustomerID, "
      updQry += "  FirstName = @FirstName, "
      updQry += "  LastName = @LastName, "
      updQry += "  MiddleName = @MiddleName, "
      updQry += "  Address = @Address, "
      updQry += "  Apartment = @Apartment, "
      updQry += "  City = @City, "
      updQry += "  State = @State, Zip = @Zip, "
      updQry += "  HomePhone = @HomePhone, "
      updQry += "  BusinessPhone = @BusinessPhone, "
      updQry += "  DOB = @DOB, "
      updQry += "  Discount = @Discount "
      updQry += "WHERE Stamp = @Stamp AND CustomerID = @CustomerID"
      updQry += ControlChars.Lf
      updQry += "SELECT @Stamp = Stamp FROM CUSTOMER "
      updQry += "WHERE CustomerID = @CustomerID"

      Dim updCmd As SqlCommand = conn.CreateCommand()
      updCmd.CommandText = updQry

      ' Get a reference of the collection for simplification
      Dim updParams As SqlParameterCollection = updCmd.Parameters

      ' Build the Parameters
      updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      updParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName")
      updParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName")
      updParams("@MiddleName").IsNullable = True
      updParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName")
      updParams("@LastName").IsNullable = True
      updParams.Add("@Address", SqlDbType.NVarChar, 50, "Address")
      updParams("@Address").IsNullable = True
      updParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment")
      updParams("@Apartment").IsNullable = True
      updParams.Add("@City", SqlDbType.NVarChar, 50, "City")
      updParams("@City").IsNullable = True
      updParams.Add("@State", SqlDbType.NChar, 2, "State")
      updParams("@State").IsNullable = True
      updParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip")
      updParams("@Zip").IsNullable = True
      updParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone")
      updParams("@HomePhone").IsNullable = True
      updParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone")
      updParams("@BusinessPhone").IsNullable = True
      updParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB")
      updParams("@DOB").IsNullable = True
      updParams.Add("@Discount", SqlDbType.Float, 8, "Discount")
      updParams("@Discount").IsNullable = True
      updParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp")
      updParams("@Stamp").SourceVersion = DataRowVersion.Original
      updParams("@Stamp").Direction = ParameterDirection.InputOutput

      ' Assign the Insert Command to the DataAdapter
      dataAdapter.UpdateCommand = updCmd

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("MiddleName") = "Andrew"

      Try
        ' Update the Database
        conn.Open()
        dataAdapter.Update(custTable)
        Console.Write("Successfully Updated the Database")
      Catch ex As SqlException
        Console.WriteLine(ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try
    End Sub 'Example4



    ' <summary>
    ' Improving on the CommandBuilder Queries
    ' All together
    ' </summary>
    Public Sub Example5()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Build the Insert Command
      Dim insQry As String = ""
      insQry += "INSERT INTO CUSTOMER( "
      insQry += "  CustomerID, FirstName,  LastName, "
      insQry += "  MiddleName, Address, Apartment, "
      insQry += "  City, State, Zip, HomePhone, "
      insQry += "  BusinessPhone, DOB, Discount) "
      insQry += "VALUES ( @CustomerID, @FirstName, "
      insQry += "  @LastName, @MiddleName, @Address, "
      insQry += "  @Apartment, @City, @State, @Zip, "
      insQry += "  @HomePhone, @BusinessPhone, @DOB, "
      insQry += "  @Discount )"

      Dim insCmd As SqlCommand = conn.CreateCommand()
      insCmd.CommandText = insQry

      ' Get a reference of the collection for simplification
      Dim insParams As SqlParameterCollection = insCmd.Parameters

      ' Build the Parameters
      insParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      insParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName")
      insParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName")
      insParams("@MiddleName").IsNullable = True
      insParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName")
      insParams("@LastName").IsNullable = True
      insParams.Add("@Address", SqlDbType.NVarChar, 50, "Address")
      insParams("@Address").IsNullable = True
      insParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment")
      insParams("@Apartment").IsNullable = True
      insParams.Add("@City", SqlDbType.NVarChar, 50, "City")
      insParams("@City").IsNullable = True
      insParams.Add("@State", SqlDbType.NChar, 2, "State")
      insParams("@State").IsNullable = True
      insParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip")
      insParams("@Zip").IsNullable = True
      insParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone")
      insParams("@HomePhone").IsNullable = True
      insParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone")
      insParams("@BusinessPhone").IsNullable = True
      insParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB")
      insParams("@DOB").IsNullable = True
      insParams.Add("@Discount", SqlDbType.Float, 8, "Discount")
      insParams("@Discount").IsNullable = True

      ' Assign the Insert Command to the DataAdapter
      dataAdapter.InsertCommand = insCmd

      ' Build the Delete Command
      Dim delQry As String = ""
      delQry += "DELETE FROM CUSTOMER "
      delQry += "WHERE CustomerID = @CustomerID AND "
      delQry += "  Stamp = @Stamp"

      Dim delCmd As SqlCommand = conn.CreateCommand()
      delCmd.CommandText = delQry

      ' Get a reference of the collection for simplification
      Dim delParams As SqlParameterCollection = delCmd.Parameters

      ' Build the Parameters
      delParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      delParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp")

      ' Assign the Delete Command to the DataAdapter
      dataAdapter.DeleteCommand = delCmd

      ' Build the Update Command
      Dim updQry As String = ""
      updQry += "UPDATE CUSTOMER SET "
      updQry += "  CustomerID = @CustomerID, "
      updQry += "  FirstName = @FirstName, "
      updQry += "  LastName = @LastName, "
      updQry += "  MiddleName = @MiddleName, "
      updQry += "  Address = @Address, "
      updQry += "  Apartment = @Apartment, "
      updQry += "  City = @City, "
      updQry += "  State = @State, Zip = @Zip, "
      updQry += "  HomePhone = @HomePhone, "
      updQry += "  BusinessPhone = @BusinessPhone, "
      updQry += "  DOB = @DOB, "
      updQry += "  Discount = @Discount "
      updQry += "WHERE Stamp = @Stamp AND CustomerID = @CustomerID"
      updQry += ControlChars.Lf
      updQry += "SELECT @Stamp = Stamp FROM CUSTOMER "
      updQry += "WHERE CustomerID = @CustomerID"

      Dim updCmd As SqlCommand = conn.CreateCommand()
      updCmd.CommandText = updQry

      ' Get a reference of the collection for simplification
      Dim updParams As SqlParameterCollection = updCmd.Parameters

      ' Build the Parameters
      updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      updParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName")
      updParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName")
      updParams("@MiddleName").IsNullable = True
      updParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName")
      updParams("@LastName").IsNullable = True
      updParams.Add("@Address", SqlDbType.NVarChar, 50, "Address")
      updParams("@Address").IsNullable = True
      updParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment")
      updParams("@Apartment").IsNullable = True
      updParams.Add("@City", SqlDbType.NVarChar, 50, "City")
      updParams("@City").IsNullable = True
      updParams.Add("@State", SqlDbType.NChar, 2, "State")
      updParams("@State").IsNullable = True
      updParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip")
      updParams("@Zip").IsNullable = True
      updParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone")
      updParams("@HomePhone").IsNullable = True
      updParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone")
      updParams("@BusinessPhone").IsNullable = True
      updParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB")
      updParams("@DOB").IsNullable = True
      updParams.Add("@Discount", SqlDbType.Float, 8, "Discount")
      updParams("@Discount").IsNullable = True
      updParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp")
      updParams("@Stamp").SourceVersion = DataRowVersion.Original
      updParams("@Stamp").Direction = ParameterDirection.InputOutput

      ' Assign the Insert Command to the DataAdapter
      dataAdapter.UpdateCommand = updCmd

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")

      ' Add a new Customer
      Dim newRow As DataRow = custTable.NewRow()
      newRow.BeginEdit()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Remlinger"
      newRow("FirstName") = "Mike"
      newRow("Address") = "10 Aaron Way"
      newRow("City") = "Atlanta"
      newRow("State") = "GA"
      newRow("Zip") = "30307"
      newRow("HomePhone") = "(404) 543-8765"
      newRow.EndEdit()
      custTable.Rows.Add(newRow)

      ' Delete a Customer
      Dim delRow As DataRow = custTable.Rows(1)
      delRow.Delete()

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("MiddleName") = "Andrew"

      Try
        ' Update the Database
        conn.Open()
        dataAdapter.Update(custTable)
        Console.Write("Successfully Updated the Database")
      Catch ex As SqlException
        Console.WriteLine(ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try
    End Sub 'Example5



    ' <summary>
    ' Optimistic Concurrency with DBConcurrencyException
    ' </summary>
    Public Sub Example6()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("Address") = "300 Main Street"

      ' Fake a change in the database
      Dim changeCmd As SqlCommand = conn.CreateCommand()
      changeCmd.CommandText = "UPDATE Customer SET Zip = '{0}'" + " WHERE CustomerID = '{1}'"

      ' Insert the ID into the CommandText 
      ' and increment the Zip by one to make this
      ' repeatable
      changeCmd.CommandText = String.Format(changeCmd.CommandText, Convert.ToInt32(oldRow("Zip")) + 1, oldRow("CustomerID"))

      ' Execute the change in the database
      conn.Open()
      changeCmd.ExecuteNonQuery()
      conn.Close()

      ' Create a command-builder to generate the Inserts/Updates/Deletes
      Dim bldr As New SqlCommandBuilder(dataAdapter)

      ' Update the Database
      Try
        conn.Open()
        dataAdapter.Update(custTable)
      Catch ex As DBConcurrencyException
        ' Found a concurrency issue, report it only
        Console.WriteLine("Concurrency Violation: {0}", ex.Message)
        If custTable.HasErrors Then
          Dim row As DataRow
          For Each row In custTable.GetErrors()
            Console.WriteLine("  Violation Row: (CustomerID: {0})", row("CustomerID"))
          Next row
        End If
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try
    End Sub 'Example6



    ' <summary>
    ' Optimistic Concurrency with DBConcurrencyException
    ' Handling the Concurrency Violation
    ' </summary>
    Public Sub Example7()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("MiddleName") = "Andrew"

      ' Fake a change in the database
      Dim changeCmd As SqlCommand = conn.CreateCommand()
      changeCmd.CommandText = "UPDATE Customer SET Zip = '{0}'" + " WHERE CustomerID = '{1}'"

      ' Insert the ID into the CommandText 
      ' and increment the Zip by one to make this
      ' repeatable
      changeCmd.CommandText = String.Format(changeCmd.CommandText, Convert.ToInt32(oldRow("Zip")) + 1, oldRow("CustomerID"))

      ' Execute the change in the database
      conn.Open()
      changeCmd.ExecuteNonQuery()
      conn.Close()

      ' Create a command-builder to generate the Inserts/Updates/Deletes
      Dim bldr As New SqlCommandBuilder(dataAdapter)

      ' Update the Database
      Try
        conn.Open()
        dataAdapter.Update(custTable)
        Console.WriteLine("Database Updated!")
      Catch ex As DBConcurrencyException
        ' Found a concurrency issue
        If custTable.HasErrors Then
          Dim row As DataRow
          For Each row In custTable.GetErrors()
            ' We can only resolve Update errors
            If row.RowState = DataRowState.Modified Then
              '//////////////////////////////////////////
              ' Make a new UpdateCommand 
              ' We should build a new update command
              ' to deal with our specific issue
              ' Save the old command (if there is one)
              Dim oldUpdateCmd As SqlCommand = Nothing
              If Not (dataAdapter.UpdateCommand Is Nothing) Then
                oldUpdateCmd = dataAdapter.UpdateCommand
              End If

              ' Create a new Command
              Dim updCmd As SqlCommand = conn.CreateCommand()

              ' Go through the changed rows and create a new 
              ' SQL Statement
              Dim updateSQL As String = "UPDATE CUSTOMER SET "
              Dim whereSQL As String = "WHERE "
              Dim updParams As SqlParameterCollection = updCmd.Parameters
              Dim x As Integer

              While x < row.ItemArray.Length
                If row(x, DataRowVersion.Original) <> row(x, DataRowVersion.Current) Then
                  ' Add the Parameter
                  Dim col As DataColumn = custTable.Columns(x)
                  updParams.Add("@" + col.ColumnName, Nothing)
                  updParams(("@" + col.ColumnName)).SourceColumn = col.ColumnName
                  updParams.Add("@old" + col.ColumnName, Nothing)
                  updParams(("@old" + col.ColumnName)).SourceColumn = col.ColumnName
                  updParams(("@old" + col.ColumnName)).SourceVersion = DataRowVersion.Original

                  ' Update the SQL Statements
                  updateSQL += String.Format("{0} = @{0} , ", col.ColumnName)
                  whereSQL += String.Format("(({0} = @old{0}) OR ({0} IS NULL)) AND ", col.ColumnName)
                End If
              End While

              ' Fixup the string and concatenate them
              If updateSQL.Substring((updateSQL.Length - 2)) = ", " And whereSQL.Substring((whereSQL.Length - 4)) = "AND " Then
                updateSQL = updateSQL.Substring(0, updateSQL.Length - 2)
                whereSQL += " CustomerID = @CustomerID"

                ' Add the CustomerID Parameter
                updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")

                ' Set the Command SQL
                updCmd.CommandText = updateSQL + whereSQL

                ' Set the UpdateCommand
                dataAdapter.UpdateCommand = updCmd

                ' Make an array of the one row and 
                ' Ask the DataAdapter to Update it
                Dim arrayDRs As DataRow() = {row}
                Try
                  dataAdapter.Update(arrayDRs)
                  Console.WriteLine("Database Updated! (After Row Level Collision Testing")
                Catch nestedEx As DBConcurrencyException
                  Console.WriteLine("Concurrency Violation: {0}", nestedEx.Message)
                  Console.WriteLine("  Row: State={0}, ID={1}", row("CustomerID"), row.RowState)
                Catch sqlex As SqlException
                  Console.WriteLine("SQL Exception: {0}", sqlex.Message)
                  Console.WriteLine("  Row: State={0}, ID={1}", row("CustomerID"), row.RowState)
                End Try

              Else
                Console.WriteLine("Concurrency Violation: {0}", ex.Message)
                Console.WriteLine("  Row: State={0}, ID={1}", row("CustomerID"), row.RowState)
              End If

              ' Reset the UpdateCommand
              dataAdapter.UpdateCommand = oldUpdateCmd
            Else
              ' Can't handle other types so report them
              Console.WriteLine("Concurrency Violation: {0}", ex.Message)
              Console.WriteLine("  Row: State={0}, ID={1}", row("CustomerID"), row.RowState)
            End If
          Next row
        End If
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try
    End Sub 'Example7


    ' <summary>
    ' Pessimistic Concurrency
    ' </summary>
    Public Sub Example8()

      ' Identify the Customer we want
      Dim custID As New Guid("11D59CB7-BF61-4540-9317-4F154D717796")

      ' T-SQL To get an individual customer
      ' (In a perfect world this should be 
      '  a stored procedure)
      Dim getSQL As String = ""
      getSQL += "/* Make Transactional */"
      getSQL += "BEGIN TRAN "
      getSQL += " "
      getSQL += "DECLARE @isCheckedOut bit "
      getSQL += "DECLARE @CustID varchar(38) "
      getSQL += "SELECT @CustID = '{0}'; "
      getSQL += " "
      getSQL += "/* Check to make sure it isn't already checked out */ "
      getSQL += "SELECT @isCheckedOut = CheckedOut FROM Customer  "
      getSQL += "  WHERE CustomerID = @CustID "
      getSQL += " "
      getSQL += "IF @isCheckedOut = 1 "
      getSQL += "BEGIN "
      getSQL += "  RAISERROR ('Customer already checked out',16,1) "
      getSQL += "  ROLLBACK TRAN "
      getSQL += "  RETURN  "
      getSQL += "END "
      getSQL += " "
      getSQL += "/* Check it out */ "
      getSQL += "UPDATE Customer SET CheckedOut = 1 "
      getSQL += "  WHERE CustomerID = @CustID "
      getSQL += " "
      getSQL += "/* Get the Customer */ "
      getSQL += "SELECT CustomerID, FirstName, LastName, MiddleName,  "
      getSQL += "       Address, Apartment, City, State, Zip,  "
      getSQL += "       HomePhone, BusinessPhone, DOB, Discount,  "
      getSQL += "       Stamp  "
      getSQL += "  FROM Customer  "
      getSQL += "  WHERE CustomerID = @CustID "
      getSQL += " "
      getSQL += "/* Since we could do it all, commit the transaction */ "
      getSQL += "COMMIT TRAN "

      ' Format the Query to include the Guid
      ' for the customerID
      getSQL = String.Format(getSQL, custID)

      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = getSQL

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      Try
        dataAdapter.Fill(dataSet, "Customers")
      Catch ex As SqlException
        Console.WriteLine("SqlException: {0}", ex.Message)
        Return
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables(0)

      ' Update the Customer with the new address
      Dim customer As DataRow = custTable.Rows(0)
      customer("Address") = "55 Peachtree Center"
      customer("Zip") = "30312"

      ' Create the Update Query
      ' In a perfect world, this should be a 
      ' Stored Procedure
      Dim updQry As String = ""
      updQry += "UPDATE CUSTOMER SET "
      updQry += "  CustomerID = @CustomerID, "
      updQry += "  FirstName = @FirstName, "
      updQry += "  LastName = @LastName, "
      updQry += "  MiddleName = @MiddleName, "
      updQry += "  Address = @Address, "
      updQry += "  Apartment = @Apartment, "
      updQry += "  City = @City, "
      updQry += "  State = @State, Zip = @Zip, "
      updQry += "  HomePhone = @HomePhone, "
      updQry += "  BusinessPhone = @BusinessPhone, "
      updQry += "  DOB = @DOB, "
      updQry += "  Discount = @Discount, "
      updQry += "  CheckedOut = 0 "
      updQry += "WHERE Stamp = @Stamp AND CustomerID = @CustomerID "
      updQry += "AND CheckedOut = 1"
      updQry += ControlChars.Lf
      updQry += "SELECT @Stamp = Stamp FROM CUSTOMER "
      updQry += "WHERE CustomerID = @CustomerID"

      Dim updCmd As SqlCommand = conn.CreateCommand()
      updCmd.CommandText = updQry

      ' Get a reference of the collection for simplification
      Dim updParams As SqlParameterCollection = updCmd.Parameters

      ' Build the Parameters
      updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      updParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName")
      updParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName")
      updParams("@MiddleName").IsNullable = True
      updParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName")
      updParams("@LastName").IsNullable = True
      updParams.Add("@Address", SqlDbType.NVarChar, 50, "Address")
      updParams("@Address").IsNullable = True
      updParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment")
      updParams("@Apartment").IsNullable = True
      updParams.Add("@City", SqlDbType.NVarChar, 50, "City")
      updParams("@City").IsNullable = True
      updParams.Add("@State", SqlDbType.NChar, 2, "State")
      updParams("@State").IsNullable = True
      updParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip")
      updParams("@Zip").IsNullable = True
      updParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone")
      updParams("@HomePhone").IsNullable = True
      updParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone")
      updParams("@BusinessPhone").IsNullable = True
      updParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB")
      updParams("@DOB").IsNullable = True
      updParams.Add("@Discount", SqlDbType.Float, 8, "Discount")
      updParams("@Discount").IsNullable = True
      updParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp")
      updParams("@Stamp").SourceVersion = DataRowVersion.Original
      updParams("@Stamp").Direction = ParameterDirection.InputOutput

      ' Set the Adapters Update Command
      dataAdapter.UpdateCommand = updCmd

      ' Update the Database
      Try
        conn.Open()
        dataAdapter.Update(custTable)
        Console.WriteLine("Finished updating the database")
      Catch ex As SqlException
        Console.WriteLine("SqlException: {0}", ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try

      ' Clear the DataSet Since we cannot change the checked-in Customer
      dataSet.Reset()
    End Sub 'Example8


    ' <summary>
    ' Destructive Concurrency
    ' </summary>
    Public Sub Example9()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"

      ' Build the Insert Command
      Dim insQry As String = ""
      insQry += "INSERT INTO CUSTOMER( "
      insQry += "  CustomerID, FirstName,  LastName, "
      insQry += "  MiddleName, Address, Apartment, "
      insQry += "  City, State, Zip, HomePhone, "
      insQry += "  BusinessPhone, DOB, Discount) "
      insQry += "VALUES ( @CustomerID, @FirstName, "
      insQry += "  @LastName, @MiddleName, @Address, "
      insQry += "  @Apartment, @City, @State, @Zip, "
      insQry += "  @HomePhone, @BusinessPhone, @DOB, "
      insQry += "  @Discount )"

      Dim insCmd As SqlCommand = conn.CreateCommand()
      insCmd.CommandText = insQry

      ' Get a reference of the collection for simplification
      Dim insParams As SqlParameterCollection = insCmd.Parameters

      ' Build the Parameters
      insParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      insParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName")
      insParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName")
      insParams("@MiddleName").IsNullable = True
      insParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName")
      insParams("@LastName").IsNullable = True
      insParams.Add("@Address", SqlDbType.NVarChar, 50, "Address")
      insParams("@Address").IsNullable = True
      insParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment")
      insParams("@Apartment").IsNullable = True
      insParams.Add("@City", SqlDbType.NVarChar, 50, "City")
      insParams("@City").IsNullable = True
      insParams.Add("@State", SqlDbType.NChar, 2, "State")
      insParams("@State").IsNullable = True
      insParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip")
      insParams("@Zip").IsNullable = True
      insParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone")
      insParams("@HomePhone").IsNullable = True
      insParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone")
      insParams("@BusinessPhone").IsNullable = True
      insParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB")
      insParams("@DOB").IsNullable = True
      insParams.Add("@Discount", SqlDbType.Float, 8, "Discount")
      insParams("@Discount").IsNullable = True

      ' Assign the Insert Command to the DataAdapter
      dataAdapter.InsertCommand = insCmd

      ' Build the Delete Command
      Dim delQry As String = ""
      delQry += "DELETE FROM CUSTOMER "
      delQry += "WHERE CustomerID = @CustomerID"

      Dim delCmd As SqlCommand = conn.CreateCommand()
      delCmd.CommandText = delQry

      ' Get a reference of the collection for simplification
      Dim delParams As SqlParameterCollection = delCmd.Parameters

      ' Build the Parameters
      delParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")

      ' Assign the Delete Command to the DataAdapter
      dataAdapter.DeleteCommand = delCmd

      ' Build the Update Command
      Dim updQry As String = ""
      updQry += "UPDATE CUSTOMER SET "
      updQry += "  CustomerID = @CustomerID, "
      updQry += "  FirstName = @FirstName, "
      updQry += "  LastName = @LastName, "
      updQry += "  MiddleName = @MiddleName, "
      updQry += "  Address = @Address, "
      updQry += "  Apartment = @Apartment, "
      updQry += "  City = @City, "
      updQry += "  State = @State, Zip = @Zip, "
      updQry += "  HomePhone = @HomePhone, "
      updQry += "  BusinessPhone = @BusinessPhone, "
      updQry += "  DOB = @DOB, "
      updQry += "  Discount = @Discount "
      updQry += "WHERE CustomerID = @CustomerID"

      Dim updCmd As SqlCommand = conn.CreateCommand()
      updCmd.CommandText = updQry

      ' Get a reference of the collection for simplification
      Dim updParams As SqlParameterCollection = updCmd.Parameters

      ' Build the Parameters
      updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID")
      updParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName")
      updParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName")
      updParams("@MiddleName").IsNullable = True
      updParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName")
      updParams("@LastName").IsNullable = True
      updParams.Add("@Address", SqlDbType.NVarChar, 50, "Address")
      updParams("@Address").IsNullable = True
      updParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment")
      updParams("@Apartment").IsNullable = True
      updParams.Add("@City", SqlDbType.NVarChar, 50, "City")
      updParams("@City").IsNullable = True
      updParams.Add("@State", SqlDbType.NChar, 2, "State")
      updParams("@State").IsNullable = True
      updParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip")
      updParams("@Zip").IsNullable = True
      updParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone")
      updParams("@HomePhone").IsNullable = True
      updParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone")
      updParams("@BusinessPhone").IsNullable = True
      updParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB")
      updParams("@DOB").IsNullable = True
      updParams.Add("@Discount", SqlDbType.Float, 8, "Discount")
      updParams("@Discount").IsNullable = True

      ' Assign the Insert Command to the DataAdapter
      dataAdapter.UpdateCommand = updCmd

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")

      ' Add a new Customer
      Dim newRow As DataRow = custTable.NewRow()
      newRow.BeginEdit()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Remlinger"
      newRow("FirstName") = "Mike"
      newRow("Address") = "10 Aaron Way"
      newRow("City") = "Atlanta"
      newRow("State") = "GA"
      newRow("Zip") = "30307"
      newRow("HomePhone") = "(404) 543-8765"
      newRow.EndEdit()
      custTable.Rows.Add(newRow)

      ' Delete a Customer
      Dim delRow As DataRow = custTable.Rows(1)
      delRow.Delete()

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("MiddleName") = "Andrew"

      Try
        ' Update the Database
        conn.Open()
        dataAdapter.Update(custTable)
        Console.Write("Successfully Updated the Database")
      Catch ex As SqlException
        Console.WriteLine(ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try
    End Sub 'Example9


    ' <summary>
    ' MultiTable Updates
    ' </summary>
    Public Sub Example10()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapters
      Dim custDA As New SqlDataAdapter()
      custDA.SelectCommand = conn.CreateCommand()
      custDA.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"
      Dim invDA As New SqlDataAdapter()
      invDA.SelectCommand = conn.CreateCommand()
      invDA.SelectCommand.CommandText = "SELECT * FROM INVOICE"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      custDA.Fill(dataSet, "Customers")
      invDA.Fill(dataSet, "Invoices")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")
      Dim invTable As DataTable = dataSet.Tables("Invoices")

      ' Setup the Relation
      Dim custCustIDColumn As DataColumn = custTable.Columns("CustomerID")
      Dim invCustIDColumn As DataColumn = invTable.Columns("CustomerID")
      dataSet.Relations.Add("rel", custCustIDColumn, invCustIDColumn, True)

      ' Add a new Customer
      Dim newRow As DataRow = custTable.NewRow()
      newRow.BeginEdit()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Remlinger"
      newRow("FirstName") = "Mike"
      newRow("Address") = "10 Aaron Way"
      newRow("City") = "Atlanta"
      newRow("State") = "GA"
      newRow("Zip") = "30307"
      newRow("HomePhone") = "(404) 543-8765"
      newRow.EndEdit()
      custTable.Rows.Add(newRow)

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("Address") = "53 Peachtree Center"
      oldRow("Zip") = "30342"

      ' Change an Invoice
      Dim oldInv As DataRow = oldRow.GetChildRows("rel")(0)
      oldInv("Terms") = "Net 10th"

      ' Delete a Customer
      Dim delRow As DataRow = custTable.Rows(1)
      delRow.Delete()

      ' Create a CommandBuilders to generate the Inserts/Updates/Deletes
      Dim custBldr As New SqlCommandBuilder(custDA)
      Dim invBldr As New SqlCommandBuilder(invDA)

      ' Update the Database
      Try
        conn.Open()
        ' Update the Children first since we only have a delete
        invDA.Update(invTable)
        custDA.Update(custTable)
      Catch ex As SqlException
        Console.WriteLine("Sql Error: {0}", ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try

      form.TheGrid.DataSource = custTable
    End Sub 'Example10


    ' <summary>
    ' MultiTable Updates with Separate Updates,
    ' Inserts and Deletes
    ' </summary>
    Public Sub Example11()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapters
      Dim custDA As New SqlDataAdapter()
      custDA.SelectCommand = conn.CreateCommand()
      custDA.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"
      Dim invDA As New SqlDataAdapter()
      invDA.SelectCommand = conn.CreateCommand()
      invDA.SelectCommand.CommandText = "SELECT * FROM INVOICE"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      custDA.Fill(dataSet, "Customers")
      invDA.Fill(dataSet, "Invoices")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")
      Dim invTable As DataTable = dataSet.Tables("Invoices")

      ' Setup the Relation
      Dim custCustIDColumn As DataColumn = custTable.Columns("CustomerID")
      Dim invCustIDColumn As DataColumn = invTable.Columns("CustomerID")
      dataSet.Relations.Add("rel", custCustIDColumn, invCustIDColumn, True)

      ' Add a new Customer
      Dim newRow As DataRow = custTable.NewRow()
      newRow.BeginEdit()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Remlinger"
      newRow("FirstName") = "Mike"
      newRow("Address") = "10 Aaron Way"
      newRow("City") = "Atlanta"
      newRow("State") = "GA"
      newRow("Zip") = "30307"
      newRow("HomePhone") = "(404) 543-8765"
      newRow.EndEdit()
      custTable.Rows.Add(newRow)

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("Address") = "53 Peachtree Center"
      oldRow("Zip") = "30342"

      ' Change an Invoice
      Dim oldInv As DataRow = oldRow.GetChildRows("rel")(0)
      oldInv("Terms") = "Net 10th"

      ' Delete a Customer
      Dim delRow As DataRow = custTable.Rows(1)
      delRow.Delete()

      ' Create a CommandBuilders to generate the Inserts/Updates/Deletes
      Dim custBldr As New SqlCommandBuilder(custDA)
      Dim invBldr As New SqlCommandBuilder(invDA)

      ' Update the Database
      Try
        conn.Open()

        ' Deletes
        ' Using reverse order to delete the children first
        invDA.Update(invTable.GetChanges(DataRowState.Deleted))
        custDA.Update(custTable.GetChanges(DataRowState.Deleted))

        ' Inserts and Updates 
        ' Using forward order to insert/update the parents first
        custDA.Update(custTable.GetChanges((DataRowState.Added Or DataRowState.Modified)))
        invDA.Update(invTable.GetChanges((DataRowState.Added Or DataRowState.Modified)))
      Catch ex As SqlException
        Console.WriteLine("Sql Error: {0}", ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try

      form.TheGrid.DataSource = custTable
    End Sub 'Example11



    ' <summary>
    ' MultiTable Updates with Separate Updates,
    ' Inserts and Deletes with Transactions
    ' </summary>
    Public Sub Example12()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapters
      Dim custDA As New SqlDataAdapter()
      custDA.SelectCommand = conn.CreateCommand()
      custDA.SelectCommand.CommandText = "SELECT * FROM CUSTOMER"
      Dim invDA As New SqlDataAdapter()
      invDA.SelectCommand = conn.CreateCommand()
      invDA.SelectCommand.CommandText = "SELECT * FROM INVOICE"

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      custDA.Fill(dataSet, "Customers")
      invDA.Fill(dataSet, "Invoices")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim custTable As DataTable = dataSet.Tables("Customers")
      Dim invTable As DataTable = dataSet.Tables("Invoices")

      ' Setup the Relation
      Dim custCustIDColumn As DataColumn = custTable.Columns("CustomerID")
      Dim invCustIDColumn As DataColumn = invTable.Columns("CustomerID")
      dataSet.Relations.Add("rel", custCustIDColumn, invCustIDColumn, True)

      ' Add a new Customer
      Dim newRow As DataRow = custTable.NewRow()
      newRow.BeginEdit()
      newRow("CustomerID") = Guid.NewGuid()
      newRow("LastName") = "Remlinger"
      newRow("FirstName") = "Mike"
      newRow("Address") = "10 Aaron Way"
      newRow("City") = "Atlanta"
      newRow("State") = "GA"
      newRow("Zip") = "30307"
      newRow("HomePhone") = "(404) 543-8765"
      newRow.EndEdit()
      custTable.Rows.Add(newRow)

      ' Change a Customer
      Dim oldRow As DataRow = custTable.Rows(0)
      oldRow("Address") = "53 Peachtree Center"
      oldRow("Zip") = "30342"

      ' Change an Invoice
      Dim oldInv As DataRow = oldRow.GetChildRows("rel")(0)
      oldInv("Terms") = "Net 10th"

      ' Delete a Customer
      Dim delRow As DataRow = custTable.Rows(1)
      delRow.Delete()

      ' Create a CommandBuilders to generate the Inserts/Updates/Deletes
      Dim custBldr As New SqlCommandBuilder(custDA)
      Dim invBldr As New SqlCommandBuilder(invDA)

      ' Update the Database
      Dim tx As SqlTransaction = Nothing
      Try
        conn.Open()

        ' Add a Transaction to the Select Command
        ' so that the CommandBuilder with propogate it
        ' to the other Commands
        tx = conn.BeginTransaction(IsolationLevel.Serializable)
        invDA.SelectCommand.Transaction = tx
        custDA.SelectCommand.Transaction = tx

        ' Deletes
        ' Using reverse order to delete the children first
        invDA.Update(invTable.GetChanges(DataRowState.Deleted))
        custDA.Update(custTable.GetChanges(DataRowState.Deleted))

        ' Inserts and Updates 
        ' Using forward order to insert/update the parents first
        custDA.Update(custTable.GetChanges((DataRowState.Added Or DataRowState.Modified)))
        invDA.Update(invTable.GetChanges((DataRowState.Added Or DataRowState.Modified)))

        ' If we've gotten this far, we should be able to 
        ' commit the transaction
        tx.Commit()
      Catch ex As SqlException
        Console.WriteLine("Sql Error: {0}", ex.Message)

        ' Rollback the Transaction if an error occurs
        If Not (tx Is Nothing) Then
          tx.Rollback()
        End If
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try

      form.TheGrid.DataSource = custTable
    End Sub 'Example12


    ' <summary>
    ' Retrieving Identity on Inserts
    ' </summary>
    Public Sub Example13()
      ' Create and Open the Connection
      Dim conn As New SqlConnection("server=localhost;" + "database=ADONET;" + "Integrated Security=true;")
      conn.Open()

      ' Create the DataAdapter
      Dim dataAdapter As New SqlDataAdapter()
      dataAdapter.SelectCommand = conn.CreateCommand()
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT"

      ' Build the Insert Command
      Dim insQry As String = ""
      insQry += "INSERT INTO PRODUCT( "
      insQry += "  Description, Vendor, Cost, Price) "
      insQry += "VALUES ( @Description, "
      insQry += "  @Vendor, @Cost, @Price) "
      insQry += ControlChars.Lf
      insQry += "SELECT @ProductID = @@IDENTITY"


      Dim insCmd As SqlCommand = conn.CreateCommand()
      insCmd.CommandText = insQry

      ' Get a reference of the collection for simplification
      Dim insParams As SqlParameterCollection = insCmd.Parameters

      ' Build the Parameters
      insParams.Add("@ProductID", SqlDbType.Int, 0, "ProductID")
      insParams("@ProductID").Direction = ParameterDirection.Output
      insParams.Add("@Description", SqlDbType.NVarChar, 255, "Description")
      insParams.Add("@Vendor", SqlDbType.NVarChar, 255, "Vendor")
      insParams.Add("@Cost", SqlDbType.Money, 0, "Cost")
      insParams.Add("@Price", SqlDbType.Money, 0, "Price")

      ' Assign the Insert Command to the DataAdapter
      dataAdapter.InsertCommand = insCmd

      ' Create the DataSet
      Dim dataSet As New DataSet()

      ' Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Products")

      ' Close the Connection
      conn.Close()

      ' Grab the DataTable for convinence
      Dim prodTable As DataTable = dataSet.Tables("Products")

      ' Add a new Customer
      Dim newRow As DataRow = prodTable.NewRow()
      newRow.BeginEdit()
      newRow("Description") = "Home Base Broom"
      newRow("Vendor") = "Smith's Hardware"
      newRow("Cost") = 12.54
      newRow("Price") = 15.0
      newRow.EndEdit()
      prodTable.Rows.Add(newRow)

      Try
        ' Update the Database
        conn.Open()
        dataAdapter.Update(prodTable)
        Console.Write("Successfully Updated the Database")
      Catch ex As SqlException
        Console.WriteLine(ex.Message)
      Finally
        If conn.State <> ConnectionState.Closed Then
          conn.Close()
        End If
      End Try

      form.TheGrid.DataSource = prodTable
    End Sub 'Example13
  End Class 'Chapter8
End Namespace 'BookExamples