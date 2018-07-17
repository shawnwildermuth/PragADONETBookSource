using System;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Runtime.Serialization;
  
namespace BookExamples
{
  public class InheritedTDS : FixedCustomerTDS
  {
    public InheritedTDS() : base()
    {
      // Overwrite the DataSet name
      this.DataSetName = "InheritedTDS";
    }

    protected InheritedTDS(SerializationInfo info, StreamingContext context) 
      : base(info, context)
    {
    }

    public new InheritedInvoiceDataTable Invoice
    {
      get
      {
        Debug.Assert(base.Invoice is InheritedInvoiceDataTable);
        return (InheritedInvoiceDataTable)base.Invoice;
      }
    }

    protected override InvoiceDataTable CreateInvoiceDataTable(DataTable table)
    {
      if (table == null) return new InheritedInvoiceDataTable() as InvoiceDataTable;
      else return new InheritedInvoiceDataTable(table) as InvoiceDataTable;
    }

    public class InheritedInvoiceRow : InvoiceRow
    {
      public InheritedInvoiceRow(DataRowBuilder builder) : base(builder)
      {
      }

      public new DateTime InvoiceDate 
      {
        get 
        {
          return base.InvoiceDate;
        }
        set 
        {
          if (value > DateTime.Today)
          {
            throw new StrongTypingException("Invoice Date Cannot be in the future", null);
          }
          else
          {
            base.InvoiceDate = value;
          }
        }
      }

      public new object this[int index]
      {
        get 
        { 
          return base[index]; 
        }
      }

    }
    
    public class InheritedInvoiceDataTable : InvoiceDataTable
    {
      internal InheritedInvoiceDataTable() : base()
      {
      }
      
      internal InheritedInvoiceDataTable(DataTable table) : 
        base(table) 
      {
      }

      public new void AddInvoiceRow(InvoiceRow row) 
      {
        if (DoesCustomerHaveCredit())
        {
          base.AddInvoiceRow(row);
        }
        else
        {
          throw new Exception("Customer Invoice cannot be created, no credit available");
        }
      }
            
      public void AddInvoiceRow(InheritedInvoiceRow row) 
      {
        if (DoesCustomerHaveCredit())
        {
          base.AddInvoiceRow(row);
        }
        else
        {
          throw new Exception("Customer Invoice cannot be created, no credit available");
        }
      }

      public new InheritedInvoiceRow 
                  AddInvoiceRow(Guid InvoiceID, 
                                DateTime InvoiceDate, 
                                string Terms, 
                                string FOB, 
                                string PO, 
                                CustomerRow parentCustomerRowByCustomerInvoice) 
      {
        if (DoesCustomerHaveCredit())
        {
          return (InheritedInvoiceRow) base.AddInvoiceRow(InvoiceID, 
                                                          InvoiceDate, 
                                                          Terms, 
                                                          FOB, 
                                                          PO, 
                                                          parentCustomerRowByCustomerInvoice);
        }
        else
        {
          throw new Exception("Customer Invoice cannot be created, " + 
                              "no credit available");
        }
      }

      public new InheritedInvoiceRow NewInvoiceRow() 
      {
        if (DoesCustomerHaveCredit())
        {
          return (InheritedInvoiceRow) base.NewInvoiceRow();
        }
        else
        {
          throw new Exception("Customer Invoice cannot be created, no credit available");
        }
      }
      
      private bool DoesCustomerHaveCredit()
      {
        // Credit Calculation Code
        return true;
      }

      public new InheritedInvoiceRow this[int index] 
      {
        get 
        {
          return ((InheritedInvoiceRow)(this.Rows[index]));
        }
      }

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) 
      {
        return new InheritedInvoiceRow(builder);
      }
            
      protected override System.Type GetRowType() 
      {
        return typeof(InheritedInvoiceRow);
      }

    }
  }
}
