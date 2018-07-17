using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace BookExamples
{
	/// <summary>
	/// Summary description for Chapter4.
	/// </summary>
	public class Chapter4 : BaseChapter
	{
    public void ExampleDialog()
    {
      Chapter4Example ex = new Chapter4Example();
      ex.ShowDialog();
    }

    /// <summary>
    /// Using a DataReader
    /// </summary>
    public void Example1()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM CUSTOMER";

      // Get the reader object by executing the query
      SqlDataReader rdr = cmd.ExecuteReader();
      
      // Iterate through all the records
      while (rdr.Read())
      {
        Console.WriteLine(rdr[0]);
      }


    }

    /// <summary>
    /// Retrieving DataReader Columns
    /// </summary>
    public void Example2()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM CUSTOMER";

      // Get the reader object by executing the query
      SqlDataReader rdr = cmd.ExecuteReader();

      // Iterate through all the records
      while (rdr.Read())
      {
        Console.WriteLine(rdr[0]);    // These lines are identical
        Console.WriteLine(rdr["CustomerID"]);// in functionality
      }
    }

    /// <summary>
    /// Type-Safe DataReader Access
    /// </summary>
    public void Example3()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM CUSTOMER";

      // Get the reader object by executing the query
      SqlDataReader rdr = cmd.ExecuteReader();

      // Iterate through all the records
      while (rdr.Read())
      {
        Console.WriteLine((string) rdr[0]);  // Identical
        Console.WriteLine(rdr.GetString(0)); // Functionality
      }

    }

    /// <summary>
    /// Using the System.Convert Class with the DataReader
    /// </summary>
    public void Example4()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM PRODUCT";

      // Get the reader object by executing the query
      SqlDataReader rdr = cmd.ExecuteReader();

      // Iterate through all the records
      while (rdr.Read())
      {
        Console.WriteLine(Convert.ToString(rdr["Price"])); 
      }

    }

    /// <summary>
    /// Using GetOrdinal with Type-Safe Accessors
    /// </summary>
    public void Example5()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM INVOICE";

      // Get the reader object by executing the query
      SqlDataReader rdr = cmd.ExecuteReader();

      // Iterate through all the records
      while (rdr.Read())
      {
        // These lines are identical in functionality
        Console.WriteLine(rdr.GetDateTime(
          rdr.GetOrdinal("InvoiceDate")));
        Console.WriteLine((DateTime) rdr["InvoiceDate"]);
      }

    }

    /// <summary>
    /// Dealing with Null Values in a DataReader
    /// </summary>
    public void Example6()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM INVOICE";

      // Assumes that cmd is a SqlCommand
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        // Write the field if the field is not null
        if (!rdr.IsDBNull(0))
        {
          // Write the first field
          Console.WriteLine(rdr.GetString(0));
        }
      }

    }

    /// <summary>
    /// Using the DataReader with Database Locks
    /// </summary>
    public void Example10()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM INVOICE";

      // Locks the records
      SqlDataReader rdr = cmd.ExecuteReader();

      // Does not lock the records
      SqlDataReader rdr2 = 
        cmd.ExecuteReader(CommandBehavior.KeyInfo);

    }

    public void Example11()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM CUSTOMER\n" +
        "SELECT * FROM INVOICE";

      // Get the reader object by executing the query
      SqlDataReader rdr = cmd.ExecuteReader();

      // Do all result sets
      do
      {
        // Iterate through all the records of the result
      while (rdr.Read())
      {
        Console.WriteLine(rdr[0]);
      }
      }

      while (rdr.NextResult());

    }

    /// <summary>
    /// 
    /// </summary>
    public void Example12()
    {
      // Create the connection
      SqlConnection conn =
        new SqlConnection("Server=localhost;" +
        "Database=ADONET;" +
        "Integrated Security=true;");
      conn.Open();

      // Create the command object
      SqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = "SELECT * FROM CUSTOMER\n" +
        "SELECT * FROM INVOICE";

      // Get the reader object by executing the query
      SqlDataReader rdr = cmd.ExecuteReader();

      // Do all Result Sets
      do
      {

        // Get a DataTable of the schema from this Result Set
        DataTable schema = rdr.GetSchemaTable();

        // Show the Result Set Header
        Console.WriteLine("Result Set");

        // Dump the schema information
        foreach (DataRow row in schema.Rows)
        {
          Console.WriteLine("  Column:");
          Console.WriteLine("    {0} : ", 
            row["ColumnName"]);
          Console.WriteLine("      Type:        {0}",
            row["DataType"]);
          Console.WriteLine("      IsUnique:    {0}",
            row["IsUnique"]);
          Console.WriteLine("      AllowDBNull: {0}",
            row["AllowDBNull"]);
        }
      }

      while (rdr.NextResult());    }

  }
}
