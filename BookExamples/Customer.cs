using System;
using System.Data;
using System.Collections;

namespace BookExamples
{
  public class Customer
  {

    public Customer(IDataReader rdr)
    {

      // If the column is not null, get the member data
      // from the DataReader
      CustomerID = Field.GetGuid(rdr,     "CustomerID");
      LastName =   Field.GetString(rdr,   "LastName");
      FirstName =  Field.GetString(rdr,   "FirstName");
      HomePhone =  Field.GetString(rdr,   "HomePhone");
      Address =    Field.GetString(rdr,   "Address");
      City =       Field.GetString(rdr,   "City");
      State =      Field.GetString(rdr,   "State");
      Zip =        Field.GetString(rdr,   "Zip");
    
      // Create the BookList
      Invoices = new InvoiceList(rdr);

    }

    // Member Data
    public Guid     CustomerID;
    public string   LastName;
    public string   FirstName;
    public string   HomePhone;
    public string   Address;
    public string   City;
    public string   State;
    public string   Zip;
    public InvoiceList Invoices;

    // Override object.ToString() to support formatting of
    // the name in the ComboBox
    public override string ToString() 
    {
      return LastName + ", " + FirstName;
    }
  }

  // Wrapper for ArrayList to support Creation from a DataReader
  public class CustomerList : ArrayList
  {

    public CustomerList(IDataReader rdr)
    {

      // Add Each Author to the colleciton
      while (rdr.Read())
      {
        Customer cust = new Customer(rdr);
        Add(cust);
      }

    }

  }

}
