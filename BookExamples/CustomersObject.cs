using System;
using System.Data;
using System.Xml;
using System.Runtime.Serialization;

namespace BookExamples
{
public class CustomersObject : CustomerTDS
{
	public CustomersObject() : base()
	{
    Register();
	}

  protected CustomersObject(SerializationInfo info, StreamingContext context) :
    base(info, context)
  {
    Register();
  }

  private void Register()
  {
    Invoice.InvoiceRowChanging += new InvoiceRowChangeEventHandler(InvoiceChanging);
  }

  private void InvoiceChanging(object source, InvoiceRowChangeEvent args)
  {
    if (args.Action == DataRowAction.Add || args.Action == DataRowAction.Change)
    {
      if (args.Row.InvoiceDate > DateTime.Today)
      {
        throw new Exception("Cannot Create Invoices in the Future");
      }
    }
  }
	}
}
