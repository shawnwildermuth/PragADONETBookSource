using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BookExamples
{
	/// <summary>
	/// Summary description for Chapter7.
	/// </summary>
	public class Chapter7 : BaseChapter
	{
    /// <summary>
    /// 
    /// </summary>
    public void Example1()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Write the name of each customer to the 
      // console using the Column Name
      Console.WriteLine("Customer List");
      Console.WriteLine("=============");
      foreach (DataRow row in dataTable.Rows)
      {
        Console.WriteLine("{0}, {1}", row["LastName"], row["FirstName"]);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Example2()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Write the name of each customer to the 
      // console using the Column Name
      Console.WriteLine("Customer List");
      Console.WriteLine("=============");
      foreach (DataRow row in dataTable.Rows)
      {
        Console.WriteLine("{0}, {1}", row["LastName"], row["FirstName"]);
      }

      // Write and empty line
      Console.WriteLine("");

      // Write the name of each customer to the 
      // console using the Column Ordinal Number
      Console.WriteLine("Customer List");
      Console.WriteLine("=============");
      foreach (DataRow row in dataTable.Rows)
      {
        Console.WriteLine("{0}, {1}", row[1], row[2]);
      }

      // Get object references to the DataColumns
      DataColumn lastNameColumn = dataTable.Columns["LastName"];
      DataColumn firstNameColumn = dataTable.Columns["FirstName"];

      // Write the name of each customer to the 
      // console using the Column Ordinal Number
      Console.WriteLine("Customer List");
      Console.WriteLine("=============");
      foreach (DataRow row in dataTable.Rows)
      {
        Console.WriteLine("{0}, {1}", row[lastNameColumn], row[firstNameColumn]);
      }
    }

    public void Example3()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Write the name of each customer to the 
      // console using the Column Name
      Console.WriteLine("Customer List");
      Console.WriteLine("=============");
      foreach (DataRow row in dataTable.Rows)
      {
        Console.WriteLine("{0}, {1}:", row["LastName"], row["FirstName"]);
        for (int x = 0; x < row.ItemArray.GetLength(0); ++x)
        {
          object obj = row.ItemArray[x];
          if (obj.GetType() == typeof(Guid))
          {
            Console.WriteLine("  {0} : {1} *Should be readonly*", 
                              obj.GetType().Name, 
                              obj);
          }
          else if (obj.GetType() == typeof(DBNull))
          {
            Console.WriteLine("  {0} : ColumnType: {1}", 
                              obj.GetType().Name, 
                              dataTable.Columns[x].DataType.Name);
          }
          else
          {
            Console.WriteLine("  {0} : {1}", 
                              obj.GetType().Name, 
                              obj);
          }
        }
      }
    }

    /// <summary>
    /// Runtime Type-Safety
    /// </summary>
    public void Example4()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the first Row for simplified use
      DataRow row = dataSet.Tables[0].Rows[0];

      // Set some valid values
      row["LastName"] = "Millwood";
      row["FirstName"] = "Kevin";

      // Set a Double
      row["Discount"] = .15;

      // Set a Date 
      // (succeeds since this converts
      // to a DateTime easily)
      row["DOB"] = "04/24/1969";

      // This would fail since the date is bad
      //row["DOB"] = "04/31/1969";

      // Set a Bad Type
      // (Fails since this string is incompatible with the float)
      row["Discount"] = ".15";
      
      foreach (object value in row.ItemArray)
      {
        Console.WriteLine("{0}", value);
      }
    }

    public void Example5()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the first Row for simplified use
      DataRow row = dataSet.Tables[0].Rows[0];

      // Start the Edit
      row.BeginEdit();

      // Set some valid values
      row["LastName"] = "Millwood";
      row["FirstName"] = "Kevin";

      // Set a Double
      row["Discount"] = .15;

      // End the Edit
      row.EndEdit();

      // Start the Edit Again
      row.BeginEdit();

      // Set a Date 
      // (succeeds since this converts
      // to a DateTime easily)
      row["DOB"] = "04/24/1969";

      // We want to revert, so we call CancelEdit()
      row.CancelEdit();

      form.TheGrid.DataSource = dataSet.Tables[0];
    }

    public void Example6()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the first Row for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Start the DataLoad
      // (disabling constraints, notifications 
      // and indexes)
      dataTable.BeginLoadData();

      // Create a Row
      object[] row = new object[dataTable.Columns.Count];
      row[0] = Guid.NewGuid();
      row[1] = "Kevin";
      row[2] = "Millwood";

      // Add it
      // but, don't tell the row that its been 
      // updated in the data store
      dataTable.LoadDataRow(row, false);

      // Create a Row
      row = new object[dataTable.Columns.Count];
      row[0] = Guid.NewGuid();
      row[1] = "Damian";
      row[2] = "Moss";

      // Add it
      // and, tell it to mark the row as already 
      // updated in the data stored
      dataTable.LoadDataRow(row, true);

      // Finish the Loading 
      // (turning back on constraints, notifications 
      // and indexes)
      dataTable.EndLoadData();

      form.TheGrid.DataSource = dataSet.Tables[0];
    }

    public void Example7()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Add a row by Creating a new DataRow
      DataRow newRow = dataTable.NewRow();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Millwood";
      newRow["FirstName"] = "Kevin";
      dataTable.Rows.Add(newRow); // <- Important!

      // Add a row by appending an Item Array (of objects)
      object[] newValues = new object[dataTable.Columns.Count];
      newValues[0] = Guid.NewGuid();
      newValues[1] = "Damian";
      newValues[2] = "Moss";
      dataTable.Rows.Add(newValues); // <- Important!
      
      // Add a row by Creating a new DataRow
      DataRow insertedRow = dataTable.NewRow();
      insertedRow["CustomerID"] = Guid.NewGuid();
      insertedRow["LastName"] = "Marquis";
      insertedRow["FirstName"] = "Jason";
      dataTable.Rows.InsertAt(insertedRow, 1); // <- Important!
      
      form.TheGrid.DataSource = dataTable;
    }

    public void Example8()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Add a row by Creating a new DataRow
      DataRow newRow = dataTable.NewRow();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Millwood";
      newRow["FirstName"] = "Kevin";
      dataTable.Rows.Add(newRow); // <- Important!

     // Now let's Delete it
      dataTable.Rows.Remove(newRow);

      // Get the First Row
      DataRow row = dataSet.Tables[0].Rows[0];

      // Delete It!
      row.Delete();

      // Now let's delete Row 2 by ordinal number
      dataTable.Rows.RemoveAt(1);
      
      form.TheGrid.DataSource = dataSet.Tables[0];
    }
    
    public void Example9()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Add a row 
      DataRow newRow = dataTable.NewRow();
      newRow["CustomerID"] = Guid.NewGuid();
      newRow["LastName"] = "Millwood";
      newRow["FirstName"] = "Kevin";
      dataTable.Rows.Add(newRow); // <- Important!

      // Report the State
      Console.WriteLine("New Row State:\t\t{0}", newRow.RowState);

      // Get the First Row
      DataRow deleteRow = dataSet.Tables[0].Rows[0];

      // Delete It!
      deleteRow.Delete();

      // Report the State
      Console.WriteLine("Deleted Row State:\t\t{0}", deleteRow.RowState);

      // Get another row
      DataRow changeRow = dataSet.Tables[0].Rows[1];

      // Change a value
      changeRow["DOB"] = "04/24/1969";

      // Report the State
      Console.WriteLine("Changed Row State:\t{0}", changeRow.RowState);

      // Get yet another row
      DataRow unchangedRow = dataSet.Tables[0].Rows[2];

      // Report the State
      Console.WriteLine("Unchanged Row State:\t{0}", unchangedRow.RowState);

    }

    public void Example10()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the customerAdapter
      SqlDataAdapter customerAdapter = new SqlDataAdapter();
      customerAdapter.SelectCommand = conn.CreateCommand();
      customerAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the InvoiceAdapter
      SqlDataAdapter invoiceAdapter = new SqlDataAdapter();
      invoiceAdapter.SelectCommand = conn.CreateCommand();
      invoiceAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICE";

      // Create the itemAdapter
      SqlDataAdapter itemAdapter = new SqlDataAdapter();
      itemAdapter.SelectCommand = conn.CreateCommand();
      itemAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICEITEM";

      // Create the itemAdapter
      SqlDataAdapter productAdapter = new SqlDataAdapter();
      productAdapter.SelectCommand = conn.CreateCommand();
      productAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      customerAdapter.Fill(dataSet, "Customers");
      invoiceAdapter.Fill(dataSet, "Invoices");
      itemAdapter.Fill(dataSet, "InvoiceItems");
      productAdapter.Fill(dataSet, "Products");

      // Get the Columns to create the relations
      DataColumn custIDColumn = dataSet.Tables["Customers"].Columns["CustomerID"];
      DataColumn invCustIDColumn = dataSet.Tables["Invoices"].Columns["CustomerID"];
      DataColumn invIDColumn = dataSet.Tables["Invoices"].Columns["invoiceID"];
      DataColumn itemInvIDColumn = dataSet.Tables["InvoiceItems"].Columns["invoiceID"];
      DataColumn itemprodIDColumn = dataSet.Tables["InvoiceItems"].Columns["ProductID"];
      DataColumn prodIDColumn = dataSet.Tables["Products"].Columns["ProductID"];

      // Setup relationships
      dataSet.Relations.Add("Customer_Invoice", custIDColumn, invCustIDColumn, true);
      dataSet.Relations.Add("Invoice_Item", invIDColumn, itemInvIDColumn, true);
      dataSet.Relations.Add("Item_Product", itemprodIDColumn, prodIDColumn, false);

      // Walk throught the customers and 
      // show all the invoices
      foreach (DataRow custRow in dataSet.Tables["Customers"].Rows)
      {
        // Write out Customer Name
        Console.WriteLine("{0}, {1}", custRow["LastName"], custRow["FirstName"]);

        // List Invoices
        DataRow[] invoiceRows = custRow.GetChildRows("Customer_Invoice");
        foreach(DataRow invRow in invoiceRows)
        {
          string invoiceDate = ((DateTime)invRow["InvoiceDate"]).ToShortDateString();
          Console.WriteLine("  {0} : {1}", invRow["InvoiceNumber"], invoiceDate);
          Decimal grandTotal = 0;
          
          // Write out Invoice Items
          DataRow[] itemRows = invRow.GetChildRows("Invoice_Item");
          foreach (DataRow itemRow in itemRows)
          {
            DataRow productRow = itemRow.GetChildRows("Item_Product")[0];
            int quantity = ((int)itemRow["Quantity"]);
            Decimal total = ((Decimal)productRow["Price"]) * quantity;
            grandTotal += total;
            Console.WriteLine("    {0} {1} @ {2:C} ea", productRow["Description"], quantity, total);
          }
          Console.WriteLine("    Total: {0:C}", grandTotal);
        }
        
      }
    }

    public void Example11()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Get a Count of the Rows in the default view
      Console.WriteLine("DefaultView Count: {0}", dataTable.DefaultView.Count);

      // Create a new DataView
      DataView sortedView = new DataView(dataTable);
      sortedView.Sort = "Vendor";

    }

    public void Example12()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Sort by the LastName, Ascending order by default
      dataTable.DefaultView.Sort = "LastName";

      // Sort by the LastName, Descending order
      dataTable.DefaultView.Sort = "LastName DESC";

      // Sort by the LastName (Ascending), 
      // and secondarily by FirstName (Descending)
      dataTable.DefaultView.Sort = "LastName, FirstName DESC";

      form.TheGrid.DataSource = dataTable.DefaultView;

    }

    public void Example13()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Set a filter to only see Rawlings Items
      dataTable.DefaultView.RowFilter = "Vendor = 'Rawlings'";

      // Check count
      Console.WriteLine("Rawlings Products: {0}", dataTable.DefaultView.Count);

      form.TheGrid.DataSource = dataTable.DefaultView;

    }

    public void Example14()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Set a filter to see the original data
      // (in modified rows, the original values 
      //  will be shown)
      dataTable.DefaultView.RowStateFilter = DataViewRowState.OriginalRows;

      form.TheGrid.DataSource = dataTable.DefaultView;

    }

    public void Example15()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Find Rows that have Wilson as its vendor
      DataRow[] rows = dataTable.Select("Vendor = 'Wilson'");
      Console.WriteLine("Simple Select Search:");

      // Show them all
      foreach (DataRow row in rows)
      {
        Console.WriteLine("  Item: {0} - Vendor: {1}",
                          row["ProductID"],
                          row["Vendor"]);
      }

      // Find Rows with a compound expression
      DataRow[] compoundRows = dataTable.Select("Vendor = 'Wilson' AND Price > 20.00");
      Console.WriteLine("Compound Select Search:");

      // Show them all
      foreach (DataRow row in compoundRows)
      {
        Console.WriteLine("  Item: {0} - Vendor: {1} - Price: {2}",
          row["ProductID"],
          row["Vendor"],
          row["Price"]);
      }

    }
    
    public void Example16()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the customerAdapter
      SqlDataAdapter customerAdapter = new SqlDataAdapter();
      customerAdapter.SelectCommand = conn.CreateCommand();
      customerAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the InvoiceAdapter
      SqlDataAdapter invoiceAdapter = new SqlDataAdapter();
      invoiceAdapter.SelectCommand = conn.CreateCommand();
      invoiceAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICE";

      // Create the itemAdapter
      SqlDataAdapter itemAdapter = new SqlDataAdapter();
      itemAdapter.SelectCommand = conn.CreateCommand();
      itemAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICEITEM";

      // Create the itemAdapter
      SqlDataAdapter productAdapter = new SqlDataAdapter();
      productAdapter.SelectCommand = conn.CreateCommand();
      productAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      customerAdapter.Fill(dataSet, "Customers");
      invoiceAdapter.Fill(dataSet, "Invoices");
      itemAdapter.Fill(dataSet, "InvoiceItems");
      productAdapter.Fill(dataSet, "Products");

      // Get the Columns to create the relations
      DataColumn custIDColumn = dataSet.Tables["Customers"].Columns["CustomerID"];
      DataColumn invCustIDColumn = dataSet.Tables["Invoices"].Columns["CustomerID"];
      DataColumn invIDColumn = dataSet.Tables["Invoices"].Columns["invoiceID"];
      DataColumn itemInvIDColumn = dataSet.Tables["InvoiceItems"].Columns["invoiceID"];
      DataColumn itemprodIDColumn = dataSet.Tables["InvoiceItems"].Columns["ProductID"];
      DataColumn prodIDColumn = dataSet.Tables["Products"].Columns["ProductID"];

      // Setup relationships
      dataSet.Relations.Add("Customer_Invoice", custIDColumn, invCustIDColumn, true);
      dataSet.Relations.Add("Invoice_Item", invIDColumn, itemInvIDColumn, true);
      dataSet.Relations.Add("Item_Product", itemprodIDColumn, prodIDColumn, false);

      // Search for Customers who's address is in Georgia
      DataRow[] gaCusts = dataSet.Tables["Customers"].Select("State = 'GA'");

      // Create a new DataSet 
      DataSet newDataSet = new DataSet();

      // Copy the schema from the old DataSet to a stream
      MemoryStream strm = new MemoryStream();      
      dataSet.WriteXmlSchema(strm);

      // Reset the Stream so we can read it
      strm.Position = 0;

      // Read in the schema to the new DataSet
      newDataSet.ReadXmlSchema(strm);

      // Copy the Rows into the new DataSet
      newDataSet.Merge(gaCusts);

    }

    public void Example17()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the DataAdapter
      SqlDataAdapter dataAdapter = new SqlDataAdapter();
      dataAdapter.SelectCommand = conn.CreateCommand();
      dataAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Create the DataSet
      DataSet dataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      dataAdapter.Fill(dataSet);

      // Get object reference of the Table for simplified use
      DataTable dataTable = dataSet.Tables[0];

      // Set a Sort Order
      dataTable.DefaultView.Sort = "Vendor";

      // Find the Wilson Product
      int found = dataTable.DefaultView.Find("Wilson");
      Console.WriteLine("Vendor: {0}", dataTable.DefaultView[found]["Vendor"]);

      // Find all Rawlings Products
      DataRowView[] rows = dataTable.DefaultView.FindRows("Rawlings");
      Console.WriteLine("Rawlings count: {0}", rows.Length);

      // Set a compound Sort Order
      dataTable.DefaultView.Sort = "Vendor, Price DESC";

      // Find the compound criteria product
      object[] criteria = new object[] {"Wilson", 29.99};
      found = dataTable.DefaultView.Find(criteria);
      Console.WriteLine("Compound Vendor Search: {0}", dataTable.DefaultView[found]["Vendor"]);

    }


    public void Example18()
    {
      // Create and Open the Connection
      SqlConnection conn = new SqlConnection(
        "server=localhost;" +
        "database=ADONET;" + 
        "Integrated Security=true;");

      // Create the customerAdapter
      SqlDataAdapter customerAdapter = new SqlDataAdapter();
      customerAdapter.SelectCommand = conn.CreateCommand();
      customerAdapter.SelectCommand.CommandText = "SELECT * FROM CUSTOMER";

      // Create the InvoiceAdapter
      SqlDataAdapter invoiceAdapter = new SqlDataAdapter();
      invoiceAdapter.SelectCommand = conn.CreateCommand();
      invoiceAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICE";

      // Create the itemAdapter
      SqlDataAdapter itemAdapter = new SqlDataAdapter();
      itemAdapter.SelectCommand = conn.CreateCommand();
      itemAdapter.SelectCommand.CommandText = "SELECT * FROM INVOICEITEM";

      // Create the itemAdapter
      SqlDataAdapter productAdapter = new SqlDataAdapter();
      productAdapter.SelectCommand = conn.CreateCommand();
      productAdapter.SelectCommand.CommandText = "SELECT * FROM PRODUCT";

      // Create the DataSets
      DataSet mainDataSet = new DataSet();
      DataSet secondDataSet = new DataSet();

      // Use the DataAdapter to fill the DataSet
      customerAdapter.Fill(mainDataSet, "Customers");
      invoiceAdapter.Fill(mainDataSet, "Invoices");
      itemAdapter.Fill(secondDataSet, "InvoiceItems");
      productAdapter.Fill(secondDataSet, "Products");

      // Merge two DataSets together (where they have the same schema)
      mainDataSet.Merge(secondDataSet);

      // Merge two DataSets together (where they have the same schema)
      mainDataSet.Merge(secondDataSet.Tables["Products"]);

      // Merge changes from o0ne DataSet into another where they both have 
      // the same schema
      mainDataSet.Merge(secondDataSet.GetChanges());

      // Merge changes from o0ne DataSet into another where they both have 
      // the same schema
      mainDataSet.Merge(secondDataSet.Tables["Products"].GetChanges());

      // Merge two DataSets with dissimilar Schema
      mainDataSet.Merge(secondDataSet, false, MissingSchemaAction.AddWithKey);

      // Merge a DataTable into a DataSet where the Table does not exist
      mainDataSet.Merge(secondDataSet.Tables["Products"], false, MissingSchemaAction.AddWithKey);
  

    }

  }
}
