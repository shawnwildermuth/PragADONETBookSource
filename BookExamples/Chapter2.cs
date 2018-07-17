using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BookExamples
{
	/// <summary>
	/// Summary description for Chapter2.
	/// </summary>
	public class Chapter2  : BaseChapter
	{

    /// <summary>
    /// 
    /// </summary>
    public void Example1()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      // Open the connection
      conn.Open();

      // Create the command object
      SqlCommand cmd = new SqlCommand("SELECT * FROM Customers",
        conn);

      // Execute the query
      SqlDataReader reader = cmd.ExecuteReader();

      // Dump the results to the console
      while (reader.Read())
      {
        Console.WriteLine(reader["FirstName"] + " " +
          reader["LastName"]);
      }

      // Close the connection
      conn.Close();
    }
    
    /// <summary>
    /// Reusable Connections
    /// </summary>
    public void Example2()
    {
      // Create and set up the server
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
 
      // Use the connection
      SqlCommand cmd = new SqlCommand("SELECT COUNT(CustomerID)" +
        " FROM Customer",
        conn);
 
      // Open the Connection
      conn.Open();
 
      // Execute a command
      int result = (int) cmd.ExecuteScalar();
 
      // Close the Connection
      conn.Close();
 
      // Do some work with the data retrieved
      // ...
 
      // Change the command information
      cmd.CommandText = "SELECT MAX(Discount)" +
        " FROM Customer;";
 
      // Reopen the Connection
      conn.Open();
 
      // Execute the new work
      float maxDiscount = (float) cmd.ExecuteScalar();
 
      // Close the Connection
      conn.Close();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Example3()
    {
      // Create and setup the server
      SqlConnection conn = new SqlConnection();
      conn.ConnectionString = "Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=True;" +
        "ConnectionTimeout=5;";

      // Use the connection
      SqlCommand cmd = new SqlCommand(
        "SELECT COUNT(au_id) FROM CUSTOMER;");
      cmd.Connection = conn;
      
      // Open the Connection
      conn.Open();
      
      // Execute a command
      int result = (int) cmd.ExecuteScalar();
      
      // Change the Database that we're using
      conn.ChangeDatabase("master");
      
      // Change the Command information
      cmd.CommandText =
        "SELECT COUNT(name) FROM dbo.sysdatabases;";
      
      // Execute the new work
      int nDatabases = Convert.ToInt32(cmd.ExecuteScalar());
 
      // Close the Connection
      conn.Close();
 
      // Clean up our Resources
      conn.Dispose();
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Example5()
    {
      // Create Connection
      OleDbConnection conn = new OleDbConnection();

      conn.ConnectionString = "Provider=SQLOLEDB.1;" +
        "Server=localhost;" +
        "Database=Northwind;" +
        "Integrated Security=SSPI;";

      // Set Events
      conn.InfoMessage += new OleDbInfoMessageEventHandler(this.ConnInfo);
      conn.StateChange += new StateChangeEventHandler(this.ConnChange);

      // Open Database
      conn.Open();

      // Create the Command Object
      OleDbCommand cmd = conn.CreateCommand();

      cmd.CommandText = "SELECT * from [Order Details];" +
        "SELECT * from orders;";

      // Get the Reader Object by Executing the Query
      OleDbDataReader rdr = cmd.ExecuteReader();

      // Dump All Results
      do
      {
        Console.WriteLine("Result:");

        // Iterate through all the records of the result
      while (rdr.Read())
      {
        Console.WriteLine(rdr[0]);
      }
      }
      while (rdr.NextResult());

    }

    // Info Event Handler
    void ConnInfo(object sender, OleDbInfoMessageEventArgs e)
    {
      Console.WriteLine("Connection Info Message:" + 
        e.Message);
    }

    // State Change Event Handler
    void ConnChange(object sender, StateChangeEventArgs e)
    {
      Console.WriteLine(  "Connection State Changed: From: " +
        e.OriginalState.ToString() +
        " to " +
        e.CurrentState.ToString());
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Example9()
    {
      // Connect to the database
      OleDbConnection conn = new OleDbConnection();

      conn.ConnectionString = "Provider=SQLOLEDB;" +
        "Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=SSPI;";

      conn.Open();

      // Create a DataSet
      DataSet ds = new DataSet();

      // Get the tables in the database
      ds.Tables.Add(conn.GetOleDbSchemaTable(
        OleDbSchemaGuid.Tables,
        new object[] {null, null, null, "TABLE"}));

      // Add a new table to the DataSet per table in the database
      foreach (DataRow row in ds.Tables[0].Rows)
      {
        // Get a Table with the Columns of each table
        DataTable tbl = 
          conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,
          new object[] {null, null, row["TABLE_NAME"], null});

        // Change the TableName (since it will be named Columns 
        // and we can't add multiple tables with the same name)
        tbl.TableName = row["TABLE_NAME"].ToString();

        // Add to it DataSet
        ds.Tables.Add(tbl);

      }

    }
    
    /// <summary>
    /// 
    /// </summary>
    public int Example10()
    {
      int nResult = 0;

      try
      {
        // Try to call SomeFunction() to get the nResult
        SomeFunction();
      }
      catch (SqlException exception)
      {
        // Whoops . . . if we got here, we must have a 
        // problem with our SQL provider so show the user 
        // what the error was and tell them that it is a 
        // SQL provider error
        MessageBox.Show("SQL Provider Error: " + 
          exception.Message);
      }
      catch (Exception exception)
      {
        // Whoops . . . if we got here, we must have a 
        // problem, so show the user what the error was
        MessageBox.Show(exception.Message);
      }
      finally
      {
        // This gets called whether an exception was
        // thrown or not
        nResult = -1;
      }

      return nResult;
    }
    
    public void SomeFunction()
    {
      throw new Exception("Foo");
    }

    /// <summary>
    /// 
    /// </summary>
    public void Example11()
    {
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Integrated Security=true");
      try
      {
        conn.Open();

        SqlCommand cmd =
          new SqlCommand("SELECT * FROM Teams", conn);

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
          Console.WriteLine(reader.GetString(2) +
            " " + reader.GetString(1));
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(
          "An Error Occurred: " + ex.Message);
      }
      finally
      {
        // Close the connection if it was opened
        // correctly.
        if (conn.State == ConnectionState.Open)
        {
          conn.Close();
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Example12()
    {
      int nResult = 0;
      try
      {
        // Try to call SomeFunction() to get the nResult
        SomeFunction();
      }
      catch (SqlException ex)
      {
        string error = "";

        // Get the exception's message
        error += ex.Message + "\n";

        // Tack on each of the errors
        foreach (SqlError err in ex.Errors)
        {
          error += err.Message + "\n";
        }

        // Whoops . . . if we got here, we must have a 
        // problem with our SQL provider so show the user 
        // what the error was and tell them that it is a 
        // SQL provider error
        MessageBox.Show("SQL Provider Error: " + error);
      }
      finally
      {
        // This gets called whether an exception was
        // thrown or not
        nResult = -1;
      }

      return nResult;
    }
  
  }

  /*

    Example Usage:
 
      ODBCPooling.Enable();
 
  */
 
  public class ODBCPooling
  {
    [System.Runtime.InteropServices.DllImport
       ("odbc32.dll",
       CharSet=System.Runtime.InteropServices.CharSet.Auto)]
 
    private static extern int SQLSetEnvAttr(
      long Environment,
      long EnvAttribute,
      long ValuePtr,
      long StringLength);
 
    const long SQL_ATTR_CONNECTION_POOLING = 201;
    const long SQL_CP_ONE_PER_DRIVER = 1;
    const long SQL_IS_INTEGER = -6;
    const long SQL_CP_OFF = 0;
 
    static int Enable()
    {
      return SQLSetEnvAttr( 0,
        SQL_ATTR_CONNECTION_POOLING,
        SQL_CP_ONE_PER_DRIVER,
        SQL_IS_INTEGER);
    }

    static int Disable()
    {
      return SQLSetEnvAttr( 0,
        SQL_ATTR_CONNECTION_POOLING,
        SQL_CP_OFF,
        SQL_IS_INTEGER);
    }
  }

  public class ConnectionFactory
  {

    static public OleDbConnection CreateOleDbConnection()
    {
      return CreateOleDbConnection("ADONET");
    }

    static public OleDbConnection CreateOleDbConnection(
      string sDatabase)
    {
      OleDbConnection conn = new OleDbConnection();

      // Set the Connection string
      conn.ConnectionString = "Provider=SQLOLEDB.1;" +
        "Data Source=localhost;" +
        "Database=" + sDatabase + ";" +
        "UID=sa;" +
        "Pwd=password;" +
        "ConnectionTimeout=5;";

      return conn;
    }
  }

  public class DynamicConnectionFactory
  {
    static public OleDbConnection CreateRegisteredConnection()
    {
      try
      {
        // You could store the connection string information 
        // in the Registry, app.config, or even machine.config

        // Get it from the Registry
        string sKey = 
          "Software\\AW\\ADO.NET\\Chapter2\\ConnFactory";

        RegistryKey fac = 
          Registry.LocalMachine.OpenSubKey(sKey);

        string sSrc = fac.GetValue("Data Source").ToString();
        string sDB = fac.GetValue("Database").ToString();
        string sUID = fac.GetValue("Database").ToString();
        string sPwd = fac.GetValue("Pwd").ToString();

        // Create a new connection
        OleDbConnection conn = new OleDbConnection();

        // Set the connection string
        conn.ConnectionString = "Provider=SQLOLEDB.1;" +
          "Data Source=" + sSrc +
          ";Database=" + sDB +
          ";UID=" + sUID +
          ";Pwd=" + sPwd +
          ";ConnectionTimeout=5;";

        fac.Close();
        return conn;
      }
      catch(Exception)
      {
        // ...
        return null;
      }
    }

  }

}
