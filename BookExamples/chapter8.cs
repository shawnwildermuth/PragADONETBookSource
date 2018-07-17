using System;
using System.Data;
using System.Data.SqlClient;

namespace BookExamples
{
	/// <summary>
	/// Summary description for Chapter8.
	/// </summary>
	public class Chapter8 : BaseChapter
	{

    /// <summary>
    /// Simple Optimistic Concurrency
    /// </summary>
    public void Example1()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];

      // Add a new Customer
      DataRow newRow = custTable.NewRow();
      newRow.BeginEdit();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Remlinger";
      newRow["FirstName"] = "Mike";
      newRow["Address"] = "10 Aaron Way";
      newRow["City"] = "Atlanta";
      newRow["State"] = "GA";
      newRow["Zip"] = "30307";
      newRow["HomePhone"] = "(404) 543-8765";
      newRow.EndEdit();
      custTable.Rows.Add(newRow);

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["Address"] = "53 Peachtree Center";
      oldRow["Zip"] = "30342";

      // Delete a Customer
      DataRow delRow = custTable.Rows[1];
      delRow.Delete();

      // Create a command-builder to generate the Inserts/Updates/Deletes
      SqlCommandBuilder bldr = new SqlCommandBuilder(dataAdapter);

      // Update the Database
      conn.Open();
      dataAdapter.Update(custTable);
      conn.Close();
      
      form.TheGrid.DataSource = custTable;
    }


    /// <summary>
    /// Improving on the CommandBuilder Queries
    /// Insert Query Only
    /// </summary>
    public void Example2()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Build the Insert Command
      string insQry = "";
      insQry += "INSERT INTO CUSTOMER( ";
      insQry += "  CustomerID, FirstName,  LastName, ";
      insQry += "  MiddleName, Address, Apartment, ";
      insQry += "  City, State, Zip, HomePhone, ";
      insQry += "  BusinessPhone, DOB, Discount) ";
      insQry += "VALUES ( @CustomerID, @FirstName, ";
      insQry += "  @LastName, @MiddleName, @Address, ";
      insQry += "  @Apartment, @City, @State, @Zip, ";
      insQry += "  @HomePhone, @BusinessPhone, @DOB, ";
      insQry += "  @Discount )";

      SqlCommand insCmd = conn.CreateCommand();
      insCmd.CommandText = insQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection insParams = insCmd.Parameters;

      // Build the Parameters
      insParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      insParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
      insParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
      insParams["@MiddleName"].IsNullable = true;
      insParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
      insParams["@LastName"].IsNullable = true;
      insParams.Add("@Address", SqlDbType.NVarChar, 50, "Address");
      insParams["@Address"].IsNullable = true;
      insParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment");
      insParams["@Apartment"].IsNullable = true;
      insParams.Add("@City", SqlDbType.NVarChar, 50, "City");
      insParams["@City"].IsNullable = true;
      insParams.Add("@State", SqlDbType.NChar, 2, "State");
      insParams["@State"].IsNullable = true;
      insParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip");
      insParams["@Zip"].IsNullable = true;
      insParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone");
      insParams["@HomePhone"].IsNullable = true;
      insParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone");
      insParams["@BusinessPhone"].IsNullable = true;
      insParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB");
      insParams["@DOB"].IsNullable = true;
      insParams.Add("@Discount", SqlDbType.Float, 8, "Discount");
      insParams["@Discount"].IsNullable = true;

      // Assign the Insert Command to the DataAdapter
      dataAdapter.InsertCommand = insCmd;

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];

      // Add a new Customer
      DataRow newRow = custTable.NewRow();
      newRow.BeginEdit();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Remlinger";
      newRow["FirstName"] = "Mike";
      newRow["Address"] = "10 Aaron Way";
      newRow["City"] = "Atlanta";
      newRow["State"] = "GA";
      newRow["Zip"] = "30307";
      newRow["HomePhone"] = "(404) 543-8765";
      newRow.EndEdit();
      custTable.Rows.Add(newRow);

      try
      {
        // Update the Database
        conn.Open();
        dataAdapter.Update(custTable);
        Console.Write("Successfully Updated the Database");
      }
      catch (SqlException ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
    }


    /// <summary>
    /// Improving on the CommandBuilder Queries
    /// Delete Query Only
    /// </summary>
    public void Example3()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Build the Delete Command
      string delQry = "";
      delQry += "DELETE FROM CUSTOMER ";
      delQry += "WHERE CustomerID = @CustomerID AND ";
      delQry += "  Stamp = @Stamp";

      SqlCommand delCmd = conn.CreateCommand();
      delCmd.CommandText = delQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection delParams = delCmd.Parameters;

      // Build the Parameters
      delParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      delParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp");

      // Assign the Delete Command to the DataAdapter
      dataAdapter.DeleteCommand = delCmd;

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];

      // Delete a Customer
      DataRow delRow = custTable.Rows[1];
      delRow.Delete();

      try
      {
        // Update the Database
        conn.Open();
        dataAdapter.Update(custTable);
        Console.Write("Successfully Updated the Database");
      }
      catch (SqlException ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
    }


    /// <summary>
    /// Improving on the CommandBuilder Queries
    /// Update Query Only
    /// </summary>
    public void Example4()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Build the Update Command
      string updQry = "";
      updQry += "UPDATE CUSTOMER SET ";
      updQry += "  CustomerID = @CustomerID, ";
      updQry += "  FirstName = @FirstName, ";       
      updQry += "  LastName = @LastName, ";
      updQry += "  MiddleName = @MiddleName, ";       
      updQry += "  Address = @Address, ";
      updQry += "  Apartment = @Apartment, ";       
      updQry += "  City = @City, "; 
      updQry += "  State = @State, Zip = @Zip, ";       
      updQry += "  HomePhone = @HomePhone, ";
      updQry += "  BusinessPhone = @BusinessPhone, ";       
      updQry += "  DOB = @DOB, "; 
      updQry += "  Discount = @Discount ";
      updQry += "WHERE Stamp = @Stamp AND CustomerID = @CustomerID"; 
      updQry += "\n";
      updQry += "SELECT @Stamp = Stamp FROM CUSTOMER ";
      updQry += "WHERE CustomerID = @CustomerID";

      SqlCommand updCmd = conn.CreateCommand();
      updCmd.CommandText = updQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection updParams = updCmd.Parameters;

      // Build the Parameters
      updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      updParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
      updParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
      updParams["@MiddleName"].IsNullable = true;
      updParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
      updParams["@LastName"].IsNullable = true;
      updParams.Add("@Address", SqlDbType.NVarChar, 50, "Address");
      updParams["@Address"].IsNullable = true;
      updParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment");
      updParams["@Apartment"].IsNullable = true;
      updParams.Add("@City", SqlDbType.NVarChar, 50, "City");
      updParams["@City"].IsNullable = true;
      updParams.Add("@State", SqlDbType.NChar, 2, "State");
      updParams["@State"].IsNullable = true;
      updParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip");
      updParams["@Zip"].IsNullable = true;
      updParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone");
      updParams["@HomePhone"].IsNullable = true;
      updParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone");
      updParams["@BusinessPhone"].IsNullable = true;
      updParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB");
      updParams["@DOB"].IsNullable = true;
      updParams.Add("@Discount", SqlDbType.Float, 8, "Discount");
      updParams["@Discount"].IsNullable = true;
      updParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp");
      updParams["@Stamp"].SourceVersion = DataRowVersion.Original;
      updParams["@Stamp"].Direction = ParameterDirection.InputOutput;

      // Assign the Insert Command to the DataAdapter
      dataAdapter.UpdateCommand = updCmd;

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["MiddleName"] = "Andrew";

      try
      {
        // Update the Database
        conn.Open();
        dataAdapter.Update(custTable);
        Console.Write("Successfully Updated the Database");
      }
      catch (SqlException ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
    }


    /// <summary>
    /// Improving on the CommandBuilder Queries
    /// All together
    /// </summary>
    public void Example5()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Build the Insert Command
      string insQry = "";
      insQry += "INSERT INTO CUSTOMER( ";
      insQry += "  CustomerID, FirstName,  LastName, ";
      insQry += "  MiddleName, Address, Apartment, ";
      insQry += "  City, State, Zip, HomePhone, ";
      insQry += "  BusinessPhone, DOB, Discount) ";
      insQry += "VALUES ( @CustomerID, @FirstName, ";
      insQry += "  @LastName, @MiddleName, @Address, ";
      insQry += "  @Apartment, @City, @State, @Zip, ";
      insQry += "  @HomePhone, @BusinessPhone, @DOB, ";
      insQry += "  @Discount )";

      SqlCommand insCmd = conn.CreateCommand();
      insCmd.CommandText = insQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection insParams = insCmd.Parameters;

      // Build the Parameters
      insParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      insParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
      insParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
      insParams["@MiddleName"].IsNullable = true;
      insParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
      insParams["@LastName"].IsNullable = true;
      insParams.Add("@Address", SqlDbType.NVarChar, 50, "Address");
      insParams["@Address"].IsNullable = true;
      insParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment");
      insParams["@Apartment"].IsNullable = true;
      insParams.Add("@City", SqlDbType.NVarChar, 50, "City");
      insParams["@City"].IsNullable = true;
      insParams.Add("@State", SqlDbType.NChar, 2, "State");
      insParams["@State"].IsNullable = true;
      insParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip");
      insParams["@Zip"].IsNullable = true;
      insParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone");
      insParams["@HomePhone"].IsNullable = true;
      insParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone");
      insParams["@BusinessPhone"].IsNullable = true;
      insParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB");
      insParams["@DOB"].IsNullable = true;
      insParams.Add("@Discount", SqlDbType.Float, 8, "Discount");
      insParams["@Discount"].IsNullable = true;

      // Assign the Insert Command to the DataAdapter
      dataAdapter.InsertCommand = insCmd;

      // Build the Delete Command
      string delQry = "";
      delQry += "DELETE FROM CUSTOMER ";
      delQry += "WHERE CustomerID = @CustomerID AND ";
      delQry += "  Stamp = @Stamp";

      SqlCommand delCmd = conn.CreateCommand();
      delCmd.CommandText = delQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection delParams = delCmd.Parameters;

      // Build the Parameters
      delParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      delParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp");

      // Assign the Delete Command to the DataAdapter
      dataAdapter.DeleteCommand = delCmd;

      // Build the Update Command
      string updQry = "";
      updQry += "UPDATE CUSTOMER SET ";
      updQry += "  CustomerID = @CustomerID, ";
      updQry += "  FirstName = @FirstName, ";       
      updQry += "  LastName = @LastName, ";
      updQry += "  MiddleName = @MiddleName, ";       
      updQry += "  Address = @Address, ";
      updQry += "  Apartment = @Apartment, ";       
      updQry += "  City = @City, "; 
      updQry += "  State = @State, Zip = @Zip, ";       
      updQry += "  HomePhone = @HomePhone, ";
      updQry += "  BusinessPhone = @BusinessPhone, ";       
      updQry += "  DOB = @DOB, "; 
      updQry += "  Discount = @Discount ";
      updQry += "WHERE Stamp = @Stamp AND CustomerID = @CustomerID"; 
      updQry += "\n";
      updQry += "SELECT @Stamp = Stamp FROM CUSTOMER ";
      updQry += "WHERE CustomerID = @CustomerID";

      SqlCommand updCmd = conn.CreateCommand();
      updCmd.CommandText = updQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection updParams = updCmd.Parameters;

      // Build the Parameters
      updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      updParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
      updParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
      updParams["@MiddleName"].IsNullable = true;
      updParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
      updParams["@LastName"].IsNullable = true;
      updParams.Add("@Address", SqlDbType.NVarChar, 50, "Address");
      updParams["@Address"].IsNullable = true;
      updParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment");
      updParams["@Apartment"].IsNullable = true;
      updParams.Add("@City", SqlDbType.NVarChar, 50, "City");
      updParams["@City"].IsNullable = true;
      updParams.Add("@State", SqlDbType.NChar, 2, "State");
      updParams["@State"].IsNullable = true;
      updParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip");
      updParams["@Zip"].IsNullable = true;
      updParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone");
      updParams["@HomePhone"].IsNullable = true;
      updParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone");
      updParams["@BusinessPhone"].IsNullable = true;
      updParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB");
      updParams["@DOB"].IsNullable = true;
      updParams.Add("@Discount", SqlDbType.Float, 8, "Discount");
      updParams["@Discount"].IsNullable = true;
      updParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp");
      updParams["@Stamp"].SourceVersion = DataRowVersion.Original;
      updParams["@Stamp"].Direction = ParameterDirection.InputOutput;

      // Assign the Insert Command to the DataAdapter
      dataAdapter.UpdateCommand = updCmd;

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];

      // Add a new Customer
      DataRow newRow = custTable.NewRow();
      newRow.BeginEdit();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Remlinger";
      newRow["FirstName"] = "Mike";
      newRow["Address"] = "10 Aaron Way";
      newRow["City"] = "Atlanta";
      newRow["State"] = "GA";
      newRow["Zip"] = "30307";
      newRow["HomePhone"] = "(404) 543-8765";
      newRow.EndEdit();
      custTable.Rows.Add(newRow);

      // Delete a Customer
      DataRow delRow = custTable.Rows[1];
      delRow.Delete();

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["MiddleName"] = "Andrew";

      try
      {
        // Update the Database
        conn.Open();
        dataAdapter.Update(custTable);
        Console.Write("Successfully Updated the Database");
      }
      catch (SqlException ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
    }


    /// <summary>
    /// Optimistic Concurrency with DBConcurrencyException
    /// </summary>
    public void Example6()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["Address"] = "300 Main Street";

      // Fake a change in the database
      SqlCommand changeCmd = conn.CreateCommand();
      changeCmd.CommandText = "UPDATE Customer SET Zip = '{0}'" + 
        " WHERE CustomerID = '{1}'";

      // Insert the ID into the CommandText 
      // and increment the Zip by one to make this
      // repeatable
      changeCmd.CommandText = string.Format(changeCmd.CommandText, 
        Convert.ToInt32(oldRow["Zip"]) + 1,
        oldRow["CustomerID"]);

      // Execute the change in the database
      conn.Open();
      changeCmd.ExecuteNonQuery();
      conn.Close();

      // Create a command-builder to generate the Inserts/Updates/Deletes
      SqlCommandBuilder bldr = new SqlCommandBuilder(dataAdapter);

      // Update the Database
      try
      {
        conn.Open();
        dataAdapter.Update(custTable);
      }
      catch (DBConcurrencyException ex)
      {
        // Found a concurrency issue, report it only
        Console.WriteLine("Concurrency Violation: {0}", ex.Message);
        if (custTable.HasErrors)
        {
          foreach (DataRow row in custTable.GetErrors())
          {
            Console.WriteLine("  Violation Row: (CustomerID: {0})", 
              row["CustomerID"]);
          }
        }
      }      
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
      
    }


    /// <summary>
    /// Optimistic Concurrency with DBConcurrencyException
    /// Handling the Concurrency Violation
    /// </summary>
    public void Example7()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["MiddleName"] = "Andrew";

      // Fake a change in the database
      SqlCommand changeCmd = conn.CreateCommand();
      changeCmd.CommandText = "UPDATE Customer SET Zip = '{0}'" + 
        " WHERE CustomerID = '{1}'";

      // Insert the ID into the CommandText 
      // and increment the Zip by one to make this
      // repeatable
      changeCmd.CommandText = string.Format(changeCmd.CommandText, 
        Convert.ToInt32(oldRow["Zip"]) + 1,
        oldRow["CustomerID"]);

      // Execute the change in the database
      conn.Open();
      changeCmd.ExecuteNonQuery();
      conn.Close();

      // Create a command-builder to generate the Inserts/Updates/Deletes
      SqlCommandBuilder bldr = new SqlCommandBuilder(dataAdapter);

      // Update the Database
      try
      {
        conn.Open();
        dataAdapter.Update(custTable);
        Console.WriteLine("Database Updated!");
      }
      catch (DBConcurrencyException ex)
      {
        // Found a concurrency issue
        if (custTable.HasErrors)
        {
          foreach (DataRow row in custTable.GetErrors())
          {
            // We can only resolve Update errors
            if (row.RowState == DataRowState.Modified)
            {
              /////////////////////////////////////////////
              // Make a new UpdateCommand 
              // We should build a new update command
              // to deal with our specific issue
              
              // Save the old command (if there is one)
              SqlCommand oldUpdateCmd = null;
              if (dataAdapter.UpdateCommand != null)
              {
                oldUpdateCmd = dataAdapter.UpdateCommand;
              }
              
              // Create a new Command
              SqlCommand updCmd = conn.CreateCommand();
              
              // Go through the changed rows and create a new 
              // SQL Statement
              string updateSQL = "UPDATE CUSTOMER SET ";
              string whereSQL = "WHERE ";
              SqlParameterCollection updParams = updCmd.Parameters;
              for (int x = 0; x < row.ItemArray.Length; ++x)
              {
                if (row[x, DataRowVersion.Original] != row[x, DataRowVersion.Current])
                {
                  // Add the Parameter
                  DataColumn col = custTable.Columns[x];
                  updParams.Add("@" + col.ColumnName, null);
                  updParams["@" + col.ColumnName].SourceColumn = col.ColumnName;
                  updParams.Add("@old" + col.ColumnName, null);
                  updParams["@old" + col.ColumnName].SourceColumn = col.ColumnName;
                  updParams["@old" + col.ColumnName].SourceVersion = DataRowVersion.Original;
                  
                  // Update the SQL Statements
                  updateSQL += string.Format("{0} = @{0} , ", col.ColumnName);
                  whereSQL += string.Format("(({0} = @old{0}) OR ({0} IS NULL)) AND ", col.ColumnName);
                }
              }
              
              // Fixup the string and concatenate them
              if (updateSQL.Substring(updateSQL.Length - 2) == ", " &&
                whereSQL.Substring(whereSQL.Length - 4) == "AND ")
              {
                updateSQL = updateSQL.Substring(0, updateSQL.Length - 2);
                whereSQL += " CustomerID = @CustomerID";

                // Add the CustomerID Parameter
                updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");

                // Set the Command SQL
                updCmd.CommandText = updateSQL + whereSQL;

                // Set the UpdateCommand
                dataAdapter.UpdateCommand = updCmd;

                // Make an array of the one row and 
                // Ask the DataAdapter to Update it
                DataRow[] arrayDRs = {row};
                try
                {
                  dataAdapter.Update(arrayDRs);
                  Console.WriteLine("Database Updated! (After Row Level Collision Testing");
                }
                catch (DBConcurrencyException nestedEx)
                {
                  Console.WriteLine("Concurrency Violation: {0}", nestedEx.Message);
                  Console.WriteLine("  Row: State={0}, ID={1}", row["CustomerID"], row.RowState);
                }
                catch (SqlException sqlex)
                {
                  Console.WriteLine("SQL Exception: {0}", sqlex.Message);
                  Console.WriteLine("  Row: State={0}, ID={1}", row["CustomerID"], row.RowState);
                }

              }
              else
              {
                Console.WriteLine("Concurrency Violation: {0}", ex.Message);
                Console.WriteLine("  Row: State={0}, ID={1}", row["CustomerID"], row.RowState);
              }
              
              // Reset the UpdateCommand
              dataAdapter.UpdateCommand = oldUpdateCmd;
            }
            else
            {
              // Can't handle other types so report them
              Console.WriteLine("Concurrency Violation: {0}", ex.Message);
              Console.WriteLine("  Row: State={0}, ID={1}", row["CustomerID"], row.RowState);
            }
          }
        }
      }      
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
      
    }

    /// <summary>
    /// Pessimistic Concurrency
    /// </summary>
    public void Example8()
    {

      // Identify the Customer we want
      Guid custID = new Guid("11D59CB7-BF61-4540-9317-4F154D717796");

      // T-SQL To get an individual customer
      // (In a perfect world this should be 
      //  a stored procedure)
      string getSQL = "";
      getSQL += "/* Make Transactional */";
      getSQL += "BEGIN TRAN ";
      getSQL += " ";
      getSQL += "DECLARE @isCheckedOut bit ";
      getSQL += "DECLARE @CustID varchar(38) ";
      getSQL += "SELECT @CustID = '{0}'; ";
      getSQL += " ";
      getSQL += "/* Check to make sure it isn't already checked out */ ";
      getSQL += "SELECT @isCheckedOut = CheckedOut FROM Customer  ";
      getSQL += "  WHERE CustomerID = @CustID ";
      getSQL += " ";
      getSQL += "IF @isCheckedOut = 1 ";
      getSQL += "BEGIN ";
      getSQL += "  RAISERROR ('Customer already checked out',16,1) ";
      getSQL += "  ROLLBACK TRAN ";
      getSQL += "  RETURN  ";
      getSQL += "END ";
      getSQL += " ";
      getSQL += "/* Check it out */ ";
      getSQL += "UPDATE Customer SET CheckedOut = 1 ";
      getSQL += "  WHERE CustomerID = @CustID ";
      getSQL += " ";
      getSQL += "/* Get the Customer */ ";
      getSQL += "SELECT CustomerID, FirstName, LastName, MiddleName,  ";
      getSQL += "       Address, Apartment, City, State, Zip,  ";
      getSQL += "       HomePhone, BusinessPhone, DOB, Discount,  ";
      getSQL += "       Stamp  ";
      getSQL += "  FROM Customer  ";
      getSQL += "  WHERE CustomerID = @CustID ";
      getSQL += " ";
      getSQL += "/* Since we could do it all, commit the transaction */ ";
      getSQL += "COMMIT TRAN ";

      // Format the Query to include the Guid
      // for the customerID
      getSQL = string.Format(getSQL, custID);

      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = getSQL;

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      try
      {
        dataAdapter.Fill(dataSet, "Customers");
      }
      catch (SqlException ex)
      {
        Console.WriteLine("SqlException: {0}", ex.Message);
        return;
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables[0];

      // Update the Customer with the new address
      DataRow customer = custTable.Rows[0];
      customer["Address"] = "55 Peachtree Center";
      customer["Zip"] = "30312";

      // Create the Update Query
      // In a perfect world, this should be a 
      // Stored Procedure
      string updQry = "";
      updQry += "UPDATE CUSTOMER SET ";
      updQry += "  CustomerID = @CustomerID, ";
      updQry += "  FirstName = @FirstName, ";       
      updQry += "  LastName = @LastName, ";
      updQry += "  MiddleName = @MiddleName, ";       
      updQry += "  Address = @Address, ";
      updQry += "  Apartment = @Apartment, ";       
      updQry += "  City = @City, "; 
      updQry += "  State = @State, Zip = @Zip, ";       
      updQry += "  HomePhone = @HomePhone, ";
      updQry += "  BusinessPhone = @BusinessPhone, ";       
      updQry += "  DOB = @DOB, "; 
      updQry += "  Discount = @Discount, ";
      updQry += "  CheckedOut = 0 ";
      updQry += "WHERE Stamp = @Stamp AND CustomerID = @CustomerID ";
      updQry += "AND CheckedOut = 1"; 
      updQry += "\n";
      updQry += "SELECT @Stamp = Stamp FROM CUSTOMER ";
      updQry += "WHERE CustomerID = @CustomerID";

      SqlCommand updCmd = conn.CreateCommand();
      updCmd.CommandText = updQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection updParams = updCmd.Parameters;

      // Build the Parameters
      updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      updParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
      updParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
      updParams["@MiddleName"].IsNullable = true;
      updParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
      updParams["@LastName"].IsNullable = true;
      updParams.Add("@Address", SqlDbType.NVarChar, 50, "Address");
      updParams["@Address"].IsNullable = true;
      updParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment");
      updParams["@Apartment"].IsNullable = true;
      updParams.Add("@City", SqlDbType.NVarChar, 50, "City");
      updParams["@City"].IsNullable = true;
      updParams.Add("@State", SqlDbType.NChar, 2, "State");
      updParams["@State"].IsNullable = true;
      updParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip");
      updParams["@Zip"].IsNullable = true;
      updParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone");
      updParams["@HomePhone"].IsNullable = true;
      updParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone");
      updParams["@BusinessPhone"].IsNullable = true;
      updParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB");
      updParams["@DOB"].IsNullable = true;
      updParams.Add("@Discount", SqlDbType.Float, 8, "Discount");
      updParams["@Discount"].IsNullable = true;
      updParams.Add("@Stamp", SqlDbType.Timestamp, 0, "Stamp");
      updParams["@Stamp"].SourceVersion = DataRowVersion.Original;
      updParams["@Stamp"].Direction = ParameterDirection.InputOutput;

      // Set the Adapters Update Command
      dataAdapter.UpdateCommand = updCmd;

      // Update the Database
      try
      {
        conn.Open();
        dataAdapter.Update(custTable);
        Console.WriteLine("Finished updating the database");
      }
      catch (SqlException ex)
      {
        Console.WriteLine("SqlException: {0}", ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }

      // Clear the DataSet Since we cannot change the checked-in Customer
      dataSet.Reset();

    }

    /// <summary>
    /// Destructive Concurrency
    /// </summary>
    public void Example9()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Build the Insert Command
      string insQry = "";
      insQry += "INSERT INTO CUSTOMER( ";
      insQry += "  CustomerID, FirstName,  LastName, ";
      insQry += "  MiddleName, Address, Apartment, ";
      insQry += "  City, State, Zip, HomePhone, ";
      insQry += "  BusinessPhone, DOB, Discount) ";
      insQry += "VALUES ( @CustomerID, @FirstName, ";
      insQry += "  @LastName, @MiddleName, @Address, ";
      insQry += "  @Apartment, @City, @State, @Zip, ";
      insQry += "  @HomePhone, @BusinessPhone, @DOB, ";
      insQry += "  @Discount )";

      SqlCommand insCmd = conn.CreateCommand();
      insCmd.CommandText = insQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection insParams = insCmd.Parameters;

      // Build the Parameters
      insParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      insParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
      insParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
      insParams["@MiddleName"].IsNullable = true;
      insParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
      insParams["@LastName"].IsNullable = true;
      insParams.Add("@Address", SqlDbType.NVarChar, 50, "Address");
      insParams["@Address"].IsNullable = true;
      insParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment");
      insParams["@Apartment"].IsNullable = true;
      insParams.Add("@City", SqlDbType.NVarChar, 50, "City");
      insParams["@City"].IsNullable = true;
      insParams.Add("@State", SqlDbType.NChar, 2, "State");
      insParams["@State"].IsNullable = true;
      insParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip");
      insParams["@Zip"].IsNullable = true;
      insParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone");
      insParams["@HomePhone"].IsNullable = true;
      insParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone");
      insParams["@BusinessPhone"].IsNullable = true;
      insParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB");
      insParams["@DOB"].IsNullable = true;
      insParams.Add("@Discount", SqlDbType.Float, 8, "Discount");
      insParams["@Discount"].IsNullable = true;

      // Assign the Insert Command to the DataAdapter
      dataAdapter.InsertCommand = insCmd;

      // Build the Delete Command
      string delQry = "";
      delQry += "DELETE FROM CUSTOMER ";
      delQry += "WHERE CustomerID = @CustomerID";

      SqlCommand delCmd = conn.CreateCommand();
      delCmd.CommandText = delQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection delParams = delCmd.Parameters;

      // Build the Parameters
      delParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");

      // Assign the Delete Command to the DataAdapter
      dataAdapter.DeleteCommand = delCmd;

      // Build the Update Command
      string updQry = "";
      updQry += "UPDATE CUSTOMER SET ";
      updQry += "  CustomerID = @CustomerID, ";
      updQry += "  FirstName = @FirstName, ";       
      updQry += "  LastName = @LastName, ";
      updQry += "  MiddleName = @MiddleName, ";       
      updQry += "  Address = @Address, ";
      updQry += "  Apartment = @Apartment, ";       
      updQry += "  City = @City, "; 
      updQry += "  State = @State, Zip = @Zip, ";       
      updQry += "  HomePhone = @HomePhone, ";
      updQry += "  BusinessPhone = @BusinessPhone, ";       
      updQry += "  DOB = @DOB, "; 
      updQry += "  Discount = @Discount ";
      updQry += "WHERE CustomerID = @CustomerID"; 

      SqlCommand updCmd = conn.CreateCommand();
      updCmd.CommandText = updQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection updParams = updCmd.Parameters;

      // Build the Parameters
      updParams.Add("@CustomerID", SqlDbType.UniqueIdentifier, 0, "CustomerID");
      updParams.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
      updParams.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
      updParams["@MiddleName"].IsNullable = true;
      updParams.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
      updParams["@LastName"].IsNullable = true;
      updParams.Add("@Address", SqlDbType.NVarChar, 50, "Address");
      updParams["@Address"].IsNullable = true;
      updParams.Add("@Apartment", SqlDbType.NVarChar, 50, "Apartment");
      updParams["@Apartment"].IsNullable = true;
      updParams.Add("@City", SqlDbType.NVarChar, 50, "City");
      updParams["@City"].IsNullable = true;
      updParams.Add("@State", SqlDbType.NChar, 2, "State");
      updParams["@State"].IsNullable = true;
      updParams.Add("@Zip", SqlDbType.NVarChar, 10, "Zip");
      updParams["@Zip"].IsNullable = true;
      updParams.Add("@HomePhone", SqlDbType.NVarChar, 14, "HomePhone");
      updParams["@HomePhone"].IsNullable = true;
      updParams.Add("@BusinessPhone", SqlDbType.NVarChar, 14, "BusinessPhone");
      updParams["@BusinessPhone"].IsNullable = true;
      updParams.Add("@DOB", SqlDbType.DateTime, 0, "DOB");
      updParams["@DOB"].IsNullable = true;
      updParams.Add("@Discount", SqlDbType.Float, 8, "Discount");
      updParams["@Discount"].IsNullable = true;

      // Assign the Insert Command to the DataAdapter
      dataAdapter.UpdateCommand = updCmd;

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Customers");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];

      // Add a new Customer
      DataRow newRow = custTable.NewRow();
      newRow.BeginEdit();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Remlinger";
      newRow["FirstName"] = "Mike";
      newRow["Address"] = "10 Aaron Way";
      newRow["City"] = "Atlanta";
      newRow["State"] = "GA";
      newRow["Zip"] = "30307";
      newRow["HomePhone"] = "(404) 543-8765";
      newRow.EndEdit();
      custTable.Rows.Add(newRow);

      // Delete a Customer
      DataRow delRow = custTable.Rows[1];
      delRow.Delete();

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["MiddleName"] = "Andrew";

      try
      {
        // Update the Database
        conn.Open();
        dataAdapter.Update(custTable);
        Console.Write("Successfully Updated the Database");
      }
      catch (SqlException ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
    }

    /// <summary>
    /// MultiTable Updates
    /// </summary>
    public void Example10()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapters
      SqlDataAdapter custDA = new SqlDataAdapter();
      custDA.SelectCommand = conn.CreateCommand();
      custDA.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";
      SqlDataAdapter invDA = new SqlDataAdapter();
      invDA.SelectCommand = conn.CreateCommand();
      invDA.SelectCommand.CommandText = "SELECT * FROM INVOICE";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      custDA.Fill(dataSet, "Customers");
      invDA.Fill(dataSet, "Invoices");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];
      DataTable invTable = dataSet.Tables["Invoices"];

      // Setup the Relation
      DataColumn custCustIDColumn = custTable.Columns["CustomerID"];
      DataColumn invCustIDColumn = invTable.Columns["CustomerID"];
      dataSet.Relations.Add("rel", custCustIDColumn, invCustIDColumn, true);

      // Add a new Customer
      DataRow newRow = custTable.NewRow();
      newRow.BeginEdit();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Remlinger";
      newRow["FirstName"] = "Mike";
      newRow["Address"] = "10 Aaron Way";
      newRow["City"] = "Atlanta";
      newRow["State"] = "GA";
      newRow["Zip"] = "30307";
      newRow["HomePhone"] = "(404) 543-8765";
      newRow.EndEdit();
      custTable.Rows.Add(newRow);

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["Address"] = "53 Peachtree Center";
      oldRow["Zip"] = "30342";

      // Change an Invoice
      DataRow oldInv = oldRow.GetChildRows("rel")[0];
      oldInv["Terms"] = "Net 10th";

      // Delete a Customer
      DataRow delRow = custTable.Rows[1];
      delRow.Delete();

      // Create a CommandBuilders to generate the Inserts/Updates/Deletes
      SqlCommandBuilder custBldr = new SqlCommandBuilder(custDA);
      SqlCommandBuilder invBldr = new SqlCommandBuilder(invDA);

      // Update the Database
      try
      {
        conn.Open();
        // Update the Children first since we only have a delete
        invDA.Update(invTable);
        custDA.Update(custTable);
      }
      catch (SqlException ex)
      {
        Console.WriteLine("Sql Error: {0}", ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
      
      form.TheGrid.DataSource = custTable;
    }

    /// <summary>
    /// MultiTable Updates with Separate Updates,
    /// Inserts and Deletes
    /// </summary>
    public void Example11()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapters
      SqlDataAdapter custDA = new SqlDataAdapter();
      custDA.SelectCommand = conn.CreateCommand();
      custDA.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";
      SqlDataAdapter invDA = new SqlDataAdapter();
      invDA.SelectCommand = conn.CreateCommand();
      invDA.SelectCommand.CommandText = "SELECT * FROM INVOICE";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      custDA.Fill(dataSet, "Customers");
      invDA.Fill(dataSet, "Invoices");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];
      DataTable invTable = dataSet.Tables["Invoices"];

      // Setup the Relation
      DataColumn custCustIDColumn = custTable.Columns["CustomerID"];
      DataColumn invCustIDColumn = invTable.Columns["CustomerID"];
      dataSet.Relations.Add("rel", custCustIDColumn, invCustIDColumn, true);

      // Add a new Customer
      DataRow newRow = custTable.NewRow();
      newRow.BeginEdit();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Remlinger";
      newRow["FirstName"] = "Mike";
      newRow["Address"] = "10 Aaron Way";
      newRow["City"] = "Atlanta";
      newRow["State"] = "GA";
      newRow["Zip"] = "30307";
      newRow["HomePhone"] = "(404) 543-8765";
      newRow.EndEdit();
      custTable.Rows.Add(newRow);

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["Address"] = "53 Peachtree Center";
      oldRow["Zip"] = "30342";

      // Change an Invoice
      DataRow oldInv = oldRow.GetChildRows("rel")[0];
      oldInv["Terms"] = "Net 10th";

      // Delete a Customer
      DataRow delRow = custTable.Rows[1];
      delRow.Delete();

      // Create a CommandBuilders to generate the Inserts/Updates/Deletes
      SqlCommandBuilder custBldr = new SqlCommandBuilder(custDA);
      SqlCommandBuilder invBldr = new SqlCommandBuilder(invDA);

      // Update the Database
      try
      {
        conn.Open();

        // Deletes
        // Using reverse order to delete the children first
        invDA.Update(invTable.GetChanges(DataRowState.Deleted));
        custDA.Update(custTable.GetChanges(DataRowState.Deleted));

        // Inserts and Updates 
        // Using forward order to insert/update the parents first
        custDA.Update(custTable.GetChanges(DataRowState.Added | DataRowState.Modified));
        invDA.Update(invTable.GetChanges(DataRowState.Added | DataRowState.Modified));
      }
      catch (SqlException ex)
      {
        Console.WriteLine("Sql Error: {0}", ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
      
      form.TheGrid.DataSource = custTable;
    }


    /// <summary>
    /// MultiTable Updates with Separate Updates,
    /// Inserts and Deletes with Transactions
    /// </summary>
    public void Example12()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapters
      SqlDataAdapter custDA = new SqlDataAdapter();
      custDA.SelectCommand = conn.CreateCommand();
      custDA.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";
      SqlDataAdapter invDA = new SqlDataAdapter();
      invDA.SelectCommand = conn.CreateCommand();
      invDA.SelectCommand.CommandText = "SELECT * FROM INVOICE";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      custDA.Fill(dataSet, "Customers");
      invDA.Fill(dataSet, "Invoices");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable custTable = dataSet.Tables["Customers"];
      DataTable invTable = dataSet.Tables["Invoices"];

      // Setup the Relation
      DataColumn custCustIDColumn = custTable.Columns["CustomerID"];
      DataColumn invCustIDColumn = invTable.Columns["CustomerID"];
      dataSet.Relations.Add("rel", custCustIDColumn, invCustIDColumn, true);

      // Add a new Customer
      DataRow newRow = custTable.NewRow();
      newRow.BeginEdit();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Remlinger";
      newRow["FirstName"] = "Mike";
      newRow["Address"] = "10 Aaron Way";
      newRow["City"] = "Atlanta";
      newRow["State"] = "GA";
      newRow["Zip"] = "30307";
      newRow["HomePhone"] = "(404) 543-8765";
      newRow.EndEdit();
      custTable.Rows.Add(newRow);

      // Change a Customer
      DataRow oldRow = custTable.Rows[0];
      oldRow["Address"] = "53 Peachtree Center";
      oldRow["Zip"] = "30342";

      // Change an Invoice
      DataRow oldInv = oldRow.GetChildRows("rel")[0];
      oldInv["Terms"] = "Net 10th";

      // Delete a Customer
      DataRow delRow = custTable.Rows[1];
      delRow.Delete();

      // Create a CommandBuilders to generate the Inserts/Updates/Deletes
      SqlCommandBuilder custBldr = new SqlCommandBuilder(custDA);
      SqlCommandBuilder invBldr = new SqlCommandBuilder(invDA);

      // Update the Database
      SqlTransaction tx = null;
      try
      {
        conn.Open();

        // Add a Transaction to the Select Command
        // so that the CommandBuilder with propogate it
        // to the other Commands
        tx = conn.BeginTransaction(IsolationLevel.Serializable);
        invDA.SelectCommand.Transaction = tx;
        custDA.SelectCommand.Transaction = tx;

        // Deletes
        // Using reverse order to delete the children first
        invDA.Update(invTable.GetChanges(DataRowState.Deleted));
        custDA.Update(custTable.GetChanges(DataRowState.Deleted));

        // Inserts and Updates 
        // Using forward order to insert/update the parents first
        custDA.Update(custTable.GetChanges(DataRowState.Added | DataRowState.Modified));
        invDA.Update(invTable.GetChanges(DataRowState.Added | DataRowState.Modified));

        // If we've gotten this far, we should be able to 
        // commit the transaction
        tx.Commit();
      }
      catch (SqlException ex)
      {
        Console.WriteLine("Sql Error: {0}", ex.Message);
        
        // Rollback the Transaction if an error occurs
        if (tx != null) tx.Rollback();
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }
      
      form.TheGrid.DataSource = custTable;
    }

    /// <summary>
    /// Retrieving Identity on Inserts
    /// </summary>
    public void Example13()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
      conn.Open();

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Build the Insert Command
      string insQry = "";
      insQry += "INSERT INTO PRODUCT( ";
      insQry += "  Description, Vendor, Cost, Price) ";
      insQry += "VALUES ( @Description, ";
      insQry += "  @Vendor, @Cost, @Price) ";
      insQry += "\n";
      insQry += "SELECT @ProductID = @@IDENTITY";  


      SqlCommand insCmd = conn.CreateCommand();
      insCmd.CommandText = insQry;

      // Get a reference of the collection for simplification
      SqlParameterCollection insParams = insCmd.Parameters;

      // Build the Parameters
      insParams.Add("@ProductID", SqlDbType.Int, 0, "ProductID");
      insParams["@ProductID"].Direction = ParameterDirection.Output;
      insParams.Add("@Description", SqlDbType.NVarChar, 255, "Description");
      insParams.Add("@Vendor", SqlDbType.NVarChar, 255, "Vendor");
      insParams.Add("@Cost", SqlDbType.Money, 0, "Cost");
      insParams.Add("@Price", SqlDbType.Money, 0, "Price");

      // Assign the Insert Command to the DataAdapter
      dataAdapter.InsertCommand = insCmd;

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet, "Products");

      // Close the Connection
      conn.Close();

      // Grab the DataTable for convinence
      DataTable prodTable = dataSet.Tables["Products"];

      // Add a new Customer
      DataRow newRow = prodTable.NewRow();
      newRow.BeginEdit();
      newRow["Description"] = "Home Base Broom";
      newRow["Vendor"] = "Smith's Hardware";
      newRow["Cost"] = 12.54;
      newRow["Price"] = 15.00;
      newRow.EndEdit();
      prodTable.Rows.Add(newRow);

      try
      {
        // Update the Database
        conn.Open();
        dataAdapter.Update(prodTable);
        Console.Write("Successfully Updated the Database");
      }
      catch (SqlException ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        if (conn.State != ConnectionState.Closed)
        {
          conn.Close();
        }
      }

      form.TheGrid.DataSource = prodTable;
    }
  }
}
