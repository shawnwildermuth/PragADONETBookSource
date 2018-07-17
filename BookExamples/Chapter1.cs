using System;
using System.Runtime.InteropServices;
using ADODB;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace BookExamples
{
	/// <summary>
	/// Summary description for Chapter1.
	/// </summary>
	public class Chapter1 : BaseChapter
	{

    /// <summary>
    /// Classic ADO through Interop
    /// </summary>
    public void Example2()
    {
      // Open our Connection
      Connection conn = new Connection();

      conn.Open("Provider=SQLOLEDB;Server=localhost;" +
        "Database=ADONET","someuser", "", 0);
      // Query the database
      Command cmd = new Command();
      cmd.ActiveConnection = conn;
      cmd.CommandText = "SELECT * FROM CUSTOMER";
      object recaffected = null;
      object prms = new object();
      _Recordset rs = cmd.Execute(out recaffected, ref prms, 0);

      // Dump all the records to the standard output
      while (!rs.EOF)
      {
        for (int x = 0; x < rs.Fields.Count; x++)
        {
          Console.Write(rs.Fields[x].Value.ToString() + ":");
        }
        Console.WriteLine(""); // Endline
        rs.MoveNext();
      }

      // Clean up
      conn.Close();
    }

    /// <summary>
    /// DataReader example
    /// </summary>
    public void Example3()
    {

      // Open our Connection
      OleDbConnection conn = new 
        OleDbConnection("Provider=SQLOLEDB;" +
        "Server=localhost;" +
        "Database=ADONET;" +
        "UID=someuser;");

      conn.Open();

      // Query the database
      OleDbCommand cmd = new OleDbCommand();
      cmd.Connection = conn;
      cmd.CommandText = "SELECT * FROM CUSTOMER";

      // Execute the Command to create the DataReader
      OleDbDataReader reader = cmd.ExecuteReader();

      // Dump all the records to the standard output
      while (reader.Read())
      {
        for (int x = 0; x < reader.FieldCount; x++)
        {
          Console.Write(reader.GetValue(x).ToString());
        }
        Console.WriteLine(""); // Endline
      }

      // Clean up
      conn.Close();
    }

    /// <summary>
    /// Shorter Connection
    /// </summary>
    public void Example4()
    {
      // Open our Connection
      OleDbConnection conn = new 
        OleDbConnection("Provider=SQLOLEDB;" +
        "Server=localhost;" +
        "Database=ADONET;" +
        "UID=someuser;");

      // Connection opened here
      conn.Open();

      // Create DataSet and Command objects
      OleDbCommand cmdAuthors = new OleDbCommand(
        "SELECT COUNT(*) FROM CUSTOMER",
        conn);

      // Execute the command
      int count = (int)cmdAuthors.ExecuteScalar();

      // Closed this fast!
      conn.Close();
    }

    /// <summary>
    /// Using a DataSet
    /// </summary>
    public void Example5()
    {
      // Open our Connection
      OleDbConnection conn = new 
        OleDbConnection("Provider=SQLOLEDB;" +
        "Server=localhost;" +
        "Database=ADONET;" +
        "UID=someuser;");

      // Open the connection
      conn.Open();

      // Create Dataset and Command Objects
      DataSet ds = new DataSet();
      OleDbDataAdapter daAuthors = new OleDbDataAdapter(
        "SELECT * FROM CUSTOMER",
        conn);

      // Fill the DataSet
      daAuthors.Fill(ds);

      // We can close the connection without any ramifications!
      conn.Close();

      // Get the table out of the DataSet
      DataTable tbl = ds.Tables["Table"];

      // Walk all the rows
      foreach (DataRow row in tbl.Rows)
      {
        // Walk all the fields in the row
        foreach (Object val in row.ItemArray)
        {
          Console.Write(val.ToString());
        }
        Console.WriteLine(""); // End of line
      }
    }

    /// <summary>
    /// Updating from DataSet
    /// </summary>
    public void Example6()
    {
      // Create the connection
      OleDbConnection conn = new 
        OleDbConnection("Provider=SQLOLEDB;" +
        "Server=localhost;" +
        "Database=ADONET;" +
        "UID=someuser;");

      // Create DataSet and Command objects
      DataSet ds = new DataSet();
      OleDbDataAdapter daAuthors = 
        new OleDbDataAdapter("SELECT * FROM CUSTOMER", conn);

      // Create an OleDbCommandBuilder to wrap
      // the DataAdapter to support dynamic
      // generation of update/insert/delete
      // commands
      OleDbCommandBuilder bldr = 
        new OleDbCommandBuilder(daAuthors);

      // Fill the DataSet
      daAuthors.Fill(ds);

      // Get the table out of the DataSet
      DataTable tbl = ds.Tables["Table"];

      // Set up the primary key
      DataColumn[] colArr = new DataColumn[1];
      colArr[0] = tbl.Columns[0];
      tbl.PrimaryKey = colArr;

      // Insert a row
      object[] rowVals = new object[3];
      rowVals[0] = Guid.NewGuid();
      rowVals[1] = "Greg";
      rowVals[2] = "Maddux";
      DataRow insertedRow = tbl.Rows.Add(rowVals);

      // Delete a row
      tbl.Rows[0].Delete();

      // Change a row
      tbl.Rows[1].BeginEdit();
      tbl.Rows[1]["FirstName"] = "New Name";
      tbl.Rows[1].EndEdit();

      // Save changes
      conn.Open();

      daAuthors.Update(ds);
    }

    /// <summary>
    /// OleDb Example
    /// </summary>
    public void Example7()
    {
      // Create the connection
      OleDbConnection conn = 
        new OleDbConnection("Provider=SQLOLEDB;" +
        "Server=localhost;" +
        "Database=ADONET;" +
        "UID=someuser;");

      // Create DataSet and Command objects
      DataSet ds = new DataSet();

      OleDbDataAdapter daAuthors = 
        new OleDbDataAdapter("SELECT * FROM CUSTOMER",
        conn);

      // Fill the DataSet
      daAuthors.Fill(ds);

      // Get the table out of the DataSet
      DataTable tbl = ds.Tables["Table"];

      // Walk all the rows
      foreach( DataRow row in tbl.Rows)
      {
        // Walk all the fields in the row
        foreach (Object val in row.ItemArray)
        {
          Console.Write(val.ToString());
        }
        Console.WriteLine(""); // End of line

      }           
    }

    /// <summary>
    /// SQL Server Example
    /// </summary>
    public void Example8()
    {
      // Create the connection
      SqlConnection conn = new SqlConnection();
      conn.ConnectionString = "Server=localhost;" +
        "Database=ADONET;" +
        "UserID=someuser;";

      // Create DataSet and Command objects
      DataSet ds = new DataSet();

      SqlDataAdapter daAuthors = new SqlDataAdapter(
        "SELECT * FROM CUSTOMER",
        conn);

      // Fill the DataSet
      daAuthors.Fill (ds);

      // We can close the connection without any ramifications!
      conn.Close();

      // Get the table out of the DataSet
      DataTable tbl = ds.Tables["Table"];

      // Walk all the rows
      foreach( DataRow row in tbl.Rows)
      {
        // Walk all the fields in the row
        foreach (Object val in row.ItemArray)
        {
          Console.Write(val.ToString());
        }
        Console.WriteLine(""); // End of Line

      }
    }
  }
}
