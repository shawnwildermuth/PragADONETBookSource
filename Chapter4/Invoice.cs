using System;
using System.Data;
using System.Collections;

namespace BookExamples
{
  public class Invoice
  {

    public Invoice(IDataReader rdr)
    {

      // If the columns are not null, then fill our Invoice Info
      InvoiceID     = Field.GetGuid(rdr,     "InvoiceID");
      InvoiceNumber = Field.GetInt32(rdr,    "InvoiceNumber");
      InvoiceDate   = Field.GetDateTime(rdr, "InvoiceDate");
      PO            = Field.GetString(rdr,   "PO");
      FOB           = Field.GetString(rdr,   "FOB");
      Terms         = Field.GetString(rdr,   "Terms");

    }

    // Our Data...it is public in case we need to 
    // access it directly
    public Guid        InvoiceID;
    public Int32       InvoiceNumber;
    public DateTime    InvoiceDate;
    public string      PO;
    public string      FOB;
    public string      Terms;

    public string[] ToStringArray()
    {
      // Create an array of strings for the book info so we can 
      // more easily show them in a ListView
      string[] values = new string[5];
      values[0] = InvoiceNumber.ToString();
      values[1] = InvoiceDate.ToString("d");
      values[2] = PO;
      values[3] = FOB;
      values[4] = Terms;
      return values;
    }
  }

  public class InvoiceList : ArrayList
  {

    public InvoiceList(IDataReader rdr)
    {
      // Cache the current customer
      Guid customerID = rdr.GetGuid(rdr.GetOrdinal("CustomerID"));
    
      // Add new invoice for the customer until the customer changes or
      // we reach the end of the DataReader
      do 
      {
        Invoice inv = new Invoice(rdr);
        Add(inv);
      }
      while (rdr.Read() && 
        customerID == rdr.GetGuid(rdr.GetOrdinal("CustomerID")));

    }

  }
}
