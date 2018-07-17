using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Text;
using System.Xml;

namespace BookExamples
{
	/// <summary>
	/// Summary description for Chapter3.
	/// </summary>
	public class Chapter3 : BaseChapter
	{

    /// <summary>
    /// Creating a Command
    /// </summary>
    public void Example1()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      //...
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = conn;
      cmd.CommandText = "SELECT * FROM Customer;";
    }
      
    /// <summary>
    /// Creating a Command froma  Connection
    /// </summary>
    public void Example2()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      //...
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM Customer;";

    }

    /// <summary>
    /// Specifying the Command Type
    /// </summary>
    public void Example3()
    {
      // Create the connection
      SqlConnection sqlconn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      //...

      SqlCommand sqlcmd = sqlconn.CreateCommand();

      // You could set the CommandText to text, but it is 
      // unnecessary
      sqlcmd.CommandText = "SELECT * FROM Customer;";

      OleDbConnection odbconn = new OleDbConnection();

      //...

      OleDbCommand odbcmd = odbconn.CreateCommand();
      odbcmd.CommandType = CommandType.StoredProcedure;

      odbcmd.CommandText = "spMyStoredProc";

    }

    /// <summary>
    /// Using Execute Reader
    /// </summary>
    public void Example4()
    {
      // ...
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      SqlCommand sqlcmd = conn.CreateCommand();

      SqlDataReader sqlrdr = sqlcmd.ExecuteReader();

      while (sqlrdr.Read())
      {
        //...
      }

      //...
      OleDbConnection odbconn = new OleDbConnection();
      OleDbCommand odbcmd = odbconn.CreateCommand();

      OleDbDataReader odbrdr = odbcmd.ExecuteReader();

      while (odbrdr.Read())
      {
        //...

      }

    }

    /// <summary>
    /// Using ExecuteXmlReader()
    /// </summary>
    public void Example5()
    {
      // Create the connection
      SqlConnection sqlconn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      //...

      SqlCommand sqlcmd = sqlconn.CreateCommand();
      sqlcmd.CommandType = CommandType.Text;
      sqlcmd.CommandText = "SELECT * FROM Customer FOR XML AUTO;";

      //...

      XmlReader xml = sqlcmd.ExecuteXmlReader();

    }

    /// <summary>
    /// Using Parameters
    /// </summary>
    public void Example6()
    {
      // Connect to the database
      SqlConnection conn = new SqlConnection(
        "Server=localhost;Database=master;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command for the stored procedure
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "sp_stored_procedures";
      cmd.CommandType = CommandType.StoredProcedure;

      // Set up the parameters
      SqlParameter param = 
        new SqlParameter("@RETURN", SqlDbType.Int);
      param.Direction = ParameterDirection.ReturnValue;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@sp_name", SqlDbType.NVarChar);
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      param = new SqlParameter("@sp_owner", SqlDbType.NVarChar);
      param.Direction = ParameterDirection.Input;
      param.Value = "dbo";
      cmd.Parameters.Add(param);

      param = 
        new SqlParameter("@sp_qualifier", SqlDbType.NVarChar);
      param.Direction = ParameterDirection.Input;
      cmd.Parameters.Add(param);

      // Execute the stored procedure
      SqlDataReader rdr = cmd.ExecuteReader();

      // Run through the records and show 
      // the stored procedure names 
      while (rdr.Read())
      {
        Console.WriteLine("Proc: {0}", rdr["PROCEDURE_NAME"]);
      }

      // Clean up
      conn.Dispose();
    }

    /// <summary>
    /// Creating Parameters
    /// </summary>
    public void Example7()
    {
      // ...
      SqlCommand _cmd = new SqlCommand();

      // The verbose way
      SqlParameter param = new SqlParameter();
      param.ParameterName = "@RETURN_VALUE";
      param.DbType = DbType.Int32;
      param.Direction = ParameterDirection.ReturnValue;
      _cmd.Parameters.Add(param);

      // The concise way
      _cmd.Parameters.Add("@RETURN_VALUE", 
        DbType.Int32).Direction =
        ParameterDirection.ReturnValue;

    }

    /// <summary>
    /// Using Stored Procedure Wrapper
    /// </summary>
    public void Example9()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      conn.Open();

      // Create the stored procedure wrapper
      spAddMember sp = new spAddMember(conn);

      // Call the procedure
      sp.Execute("Maddux",
        "Greg",
        "123 Main Street",
        "Atlanta",
        "GA",
        "30307",
        "404-555-1212",
        "404-555-1213");

      // If the query worked, then get the key
      Int32 key;
      if (sp.RETURN_VALUE == 0)
      {
        key = sp.Key;
      }

    }

    /// <summary>
    /// Calling Wrapper Stored Procedure's Parameters
    /// </summary>
    public void Example10()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      conn.Open();

      // Create the stored procedure wrapper
      spAddMember sp = new spAddMember(conn);

      // Add the member variables
      sp.FirstName = "Greg";
      sp.LastName = "Maddux";
      sp.Address = "123 Main Street";
      sp.City = "Atlanta";
      sp.State = "GA";
      sp.Zip = "30307";
      sp.Phone = "404-555-1212";
      sp.Fax = "404-555-1213";

      // Execute the stored procedure
      sp.Command.ExecuteNonQuery();

      // If the query worked, then get the key
      Int32 key;
      if (sp.RETURN_VALUE == 0)
      {
        key = sp.Key;
      }

    }

    /// <summary>
    /// Calling Parameterized Queries
    /// </summary>
    public void Example11()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      conn.Open();

      SqlCommand cmd = conn.CreateCommand();

      // Our CustomerID
      int custID = 12345;

      // Create the Command with a string.Format()
      cmd.CommandText = string.Format("SELECT * FROM Customer WHERE CustomerID = {0}",
        custID);

      // Or with a StringBuilder
      StringBuilder bldr = new StringBuilder();
      bldr.Append("SELECT * FROM Customer WHERE CustomerID = ");
      bldr.Append(custID);
      cmd.CommandText = bldr.ToString();
    }
  
    /// <summary>
    /// Calling a Query without Using Parameters
    /// </summary>
    public void Example12()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      SqlCommand cmd = conn.CreateCommand();

      // Our CustomerID
      int custID = 12345;

      // Create the command with a string.Format()
      cmd.CommandText = string.Format(@"SELECT * FROM Customer 
        WHERE CustomerID = {0}", custID);

      // Or with a StringBuilder
      StringBuilder bldr = new StringBuilder();
      bldr.Append("SELECT * FROM Customer WHERE CustomerID = ");
      bldr.Append(custID);

      cmd.CommandText = bldr.ToString();
    }

    /// <summary>
    /// Calling a Stored Procedure without Parameter Objects
    /// </summary>
    public void Example13()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      conn.Open();

      // Create the command for the stored procedure
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = 
        "EXEC sp_stored_procedures NULL, 'dbo', NULL";

      // Execute the stored procedure
      SqlDataReader rdr = cmd.ExecuteReader();

      //...

      // Clean up
      conn.Close();
    }

    // We can call this method to call the statement and let us
    // know if it was committed or not
    bool RunCommand(SqlConnection conn, string sqlStatement)
    {
      // Create the command
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = sqlStatement; 

      // Set up the return parameter
      cmd.Parameters.Add("@RETURN", DbType.Int32).Direction =
        ParameterDirection.ReturnValue;
      // Open the connection
      conn.Open();

      // Execute the command
      cmd.ExecuteScalar();

      // Close the connection
      conn.Close();

      // if result is zero, we committed so return true
      int result = (int) cmd.Parameters["@RETURN"].Value;
      return (result == 0);
    }


    /// <summary>
    /// Using a Transaction
    /// </summary>
    public void Example15()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");

      conn.Open();

      // Create the command
      SqlCommand cmd = conn.CreateCommand();

      // Create the transaction
      cmd.Transaction = conn.BeginTransaction();

      try
      {
        // Add the customer
        cmd.CommandText = @"INSERT INTO Customer 
                              (CustomerID, LastName, FirstName, 
                               Phone, Zip) 
                            VALUES (newid(), 
                              'Smoltz', 'John', '503-432-4565', 
                              '12345');";
        cmd.ExecuteNonQuery();

        // Add the invoice
        cmd.CommandText = @"INSERT INTO Invoice 
                              (InvoiceID, InvoiceNumber, 
                               InvoiceDate, Terms) 
                            VALUES (newid(), '123456', 
                               '05/01/2001', 'Net 20');";
        cmd.ExecuteNonQuery();

        // If we got this far then commit it
        cmd.Transaction.Commit();
      }
      catch(Exception ex)
      {
        cmd.Transaction.Rollback( );
        Console.WriteLine("Command failed: " +
          ex.Message +
          "\nTransaction Rolled back");
      }

    }

    /// <summary>
    /// Rolling Back a Transaction
    /// </summary>
    public void Example16()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command
      SqlCommand cmd = conn.CreateCommand();

      // Create the transaction
      cmd.Transaction = 
        conn.BeginTransaction(IsolationLevel.ReadCommitted);

      try
      {
        // Add the customer
        cmd.CommandText = @"INSERT INTO Customer " +
          "(CustomerID, LastName, FirstName, Phone, Zip) " +
          "VALUES (newid(), 'Smoltz', 'John', " +
          "'503-432-4565', '12345');";
        cmd.ExecuteNonQuery();

        // Create a SavePoint
        cmd.Transaction.Save("New Customer");

        try
        {

          // Add the invoice
          cmd.CommandText = "INSERT INTO Invoice " +
            "(InvoiceID, InvoiceNumber, InvoiceDate, Terms) " +
            "VALUES (newid(), '123456', '05/01/2001', " +
            "'Net 20');";
          cmd.ExecuteNonQuery();

        }
        catch(Exception)
        {
          // Roll back to after saving of the new customer
          cmd.Transaction.Rollback("New Customer");
        }

        // If we got this far then commit it
        cmd.Transaction.Commit();
      }
      catch(Exception ex)
      {
        cmd.Transaction.Rollback( );
        Console.WriteLine("Command failed:" + 
                          "{0}\nTransaction Rolled back", 
                          ex.Message);
      }

    }

    /// <summary>
    /// Executing a Query without Batching
    /// </summary>
    public void Example17()
    {
      string sQuery1 = "INSERT INTO Customer " +
                "(CustomerID, LastName, FirstName, Phone, Zip) " +
                "VALUES (newid(), 'Smoltz', 'John', " +
                "'503-432-4565', '12345');";

      string sQuery2 = "INSERT INTO Customer " +
                "(CustomerID, LastName, FirstName, Phone, Zip) " +
                "VALUES (newid(), 'Maddux', 'Greg', " +
                "'503-432-4566', '12345');";

      // Create the connection
      SqlConnection sqlconn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      sqlconn.Open();

      //...

      SqlCommand sqlcmd = sqlconn.CreateCommand();
      sqlcmd.CommandType = CommandType.Text;

      // First query
      sqlcmd.CommandText =  sQuery1;
      sqlcmd.ExecuteNonQuery();

      // Second query
      sqlcmd.CommandText =  sQuery2;
      sqlcmd.ExecuteNonQuery();

    }

    /// <summary>
    /// Executing a Batch Query
    /// </summary>
    public void Example18()
    {
      string sQuery = "INSERT INTO Customer " +
                "(CustomerID, LastName, FirstName, Phone, Zip) " +
                "VALUES (newid(), 'Smoltz', 'John', " +
                "'503-432-4565', '12345'); " +
                "INSERT INTO Customer " +
                "(CustomerID, LastName, FirstName, Phone, Zip) " +
                "VALUES (newid(), 'Maddux', 'Greg', " +
                "'503-432-4566', '12345');";

      // Create the connection
      SqlConnection sqlconn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      sqlconn.Open();

      SqlCommand sqlcmd = sqlconn.CreateCommand();
      sqlcmd.CommandType = CommandType.Text;

      // Batch query
      sqlcmd.CommandText =  sQuery;

      sqlcmd.ExecuteNonQuery();

    }

    /// <summary>
    /// Retrieving Multiple Result Sets with a DataReader
    /// </summary>
    public void Example19()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create a command with two selects to return 
      // two Result Sets 
      SqlCommand cmd = conn.CreateCommand(); 
      cmd.CommandText = "SELECT * FROM Customer; " +
        "SELECT * FROM Invoice;"; 
            
      // Get a DataReader to go through the ResultSets 
      SqlDataReader rdr = cmd.ExecuteReader(); 

      // Go through each row and ResultSet
      do
      { 
        // while we have more rows in a ResultSet 
      while (rdr.Read())
      {
        Console.WriteLine(rdr[0]);
      } 

        // After we're through the first ResultSet 
        // Move to the next one and do it again 
      } while (rdr.NextResult());
    }

  }

  public class spAddMember : IDisposable
  {
    public spAddMember(SqlConnection conn)
    {
      ConstructCommand();
      _cmd.Connection = conn;
    }

    public SqlCommand Command
    {
      get
      {
        return _cmd;
      }
    }

    public Int32 Execute( string firstName,
      string lastName,
      string address,
      string city,
      string state,
      string zip,
      string phone,
      string fax)
    {
      FirstName = firstName;
      LastName = lastName;
      Address = address;
      City = city;
      State = state;
      Zip = zip;
      Phone = phone;
      Fax = fax;
      _cmd.ExecuteNonQuery();
      return RETURN_VALUE;
    }

    // IDisposable
    public void Dispose()
    {
      _cmd.Dispose();
    }

    // Parameter Access
    public  Int32 RETURN_VALUE
    {
      get
      {
        return (Int32) _cmd.Parameters["@RETURN_VALUE"].Value;
      }
    }

    public  String FirstName
    {
      set
      {
        _cmd.Parameters["@FirstName"].Value = value;
      }
    }

    public  String LastName
    {
      set
      {
        _cmd.Parameters["@LastName"].Value = value;
      }
    }

    public  String Address
    {
      set
      {
        _cmd.Parameters["@Address"].Value = value;
      }
    }

    public  String City
    {
      set
      {
        _cmd.Parameters["@City"].Value = value;
      }
    }

    public  String State
    {
      set
      {
        _cmd.Parameters["@State"].Value = value;
      }
    }

    public  String Zip
    {
      set
      {
        _cmd.Parameters["@Zip"].Value = value;
      }
    }

    public  String Phone
    {
      set
      {
        _cmd.Parameters["@Phone"].Value = value;
      }
    }

    public  String Fax
    {
      set
      {
        _cmd.Parameters["@Fax"].Value = value;
      }
    }

    public  Int32 Key
    {
      get
      {
        return (Int32) _cmd.Parameters["@Key"].Value;
      }
    }

    // Protected member that constructs the command object
    protected void ConstructCommand()
    {
      _cmd = new SqlCommand("spAddMember");
      _cmd.CommandType = CommandType.StoredProcedure;

      // RETURN_VALUE parameter
      SqlParameter _RETURN_VALUE = new SqlParameter();
      _RETURN_VALUE.ParameterName = "@RETURN_VALUE";
      _RETURN_VALUE.DbType = DbType.Int32;
      _RETURN_VALUE.Direction = 
        ParameterDirection.ReturnValue;
      _RETURN_VALUE.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_RETURN_VALUE);

      // FirstName parameter
      SqlParameter _FirstName = new SqlParameter();
      _FirstName.ParameterName = "@FirstName";
      _FirstName.DbType = DbType.String;
      _FirstName.Direction = ParameterDirection.Input;
      _FirstName.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_FirstName);

      // LastName parameter
      SqlParameter _LastName = new SqlParameter();
      _LastName.ParameterName = "@LastName";
      _LastName.DbType = DbType.String;
      _LastName.Direction = ParameterDirection.Input;
      _LastName.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_LastName);

      // Address parameter
      SqlParameter _Address = new SqlParameter();
      _Address.ParameterName = "@Address";
      _Address.DbType = DbType.String;
      _Address.Direction = ParameterDirection.Input;
      _Address.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_Address);

      // City parameter
      SqlParameter _City = new SqlParameter();
      _City.ParameterName = "@City";
      _City.DbType = DbType.String;
      _City.Direction = ParameterDirection.Input;
      _City.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_City);

      // State parameter
      SqlParameter _State = new SqlParameter();
      _State.ParameterName = "@State";
      _State.DbType = DbType.String;
      _State.Direction = ParameterDirection.Input;
      _State.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_State);

      // Zip parameter
      SqlParameter _Zip = new SqlParameter();
      _Zip.ParameterName = "@Zip";
      _Zip.DbType = DbType.String;
      _Zip.Direction = ParameterDirection.Input;
      _Zip.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_Zip);

      // Phone parameter
      SqlParameter _Phone = new SqlParameter();
      _Phone.ParameterName = "@Phone";
      _Phone.DbType = DbType.String;
      _Phone.Direction = ParameterDirection.Input;
      _Phone.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_Phone);

      // Fax parameter
      SqlParameter _Fax = new SqlParameter();
      _Fax.ParameterName = "@Fax";
      _Fax.DbType = DbType.String;
      _Fax.Direction = ParameterDirection.Input;
      _Fax.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_Fax);

      // Key parameter
      SqlParameter _Key = new SqlParameter();
      _Key.ParameterName = "@Key";
      _Key.DbType = DbType.Int32;
      _Key.Direction = ParameterDirection.Output;
      _Key.SourceVersion = DataRowVersion.Current;
      _cmd.Parameters.Add(_Key);
    }

    // Data members
    protected SqlCommand _cmd;

  }


}
