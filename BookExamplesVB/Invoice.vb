Imports System
Imports System.Data
Imports System.Collections


Namespace BookExamples
    _
  Public Class Invoice


    Public Sub New(ByVal rdr As IDataReader)

      ' If the columns are not null, then fill our Invoice Info
      InvoiceID = Field.GetGuid(rdr, "InvoiceID")
      InvoiceNumber = Field.GetInt32(rdr, "InvoiceNumber")
      InvoiceDate = Field.GetDateTime(rdr, "InvoiceDate")
      PO = Field.GetString(rdr, "PO")
      FOB = Field.GetString(rdr, "FOB")
      Terms = Field.GetString(rdr, "Terms")
    End Sub 'New 

    ' Our Data...it is public in case we need to 
    ' access it directly
    Public InvoiceID As Guid
    Public InvoiceNumber As Int32
    Public InvoiceDate As DateTime
    Public PO As String
    Public FOB As String
    Public Terms As String


    Public Function ToStringArray() As String()
      ' Create an array of strings for the book info so we can 
      ' more easily show them in a ListView
      Dim values(5) As String
      values(0) = InvoiceNumber.ToString()
      values(1) = InvoiceDate.ToString("d")
      values(2) = PO
      values(3) = FOB
      values(4) = Terms
      Return values
    End Function 'ToStringArray
  End Class 'Invoice
    _

  Public Class InvoiceList
    Inherits ArrayList


    Public Sub New(ByVal rdr As IDataReader)
      ' Cache the current customer
      Dim customerID As Guid = rdr.GetGuid(rdr.GetOrdinal("CustomerID"))

      ' Add new invoice for the customer until the customer changes or
      ' we reach the end of the DataReader
      Do
        Dim inv As New Invoice(rdr)
        Add(inv)
      Loop While rdr.Read() And customerID.Equals(rdr.GetGuid(rdr.GetOrdinal("CustomerID")))
    End Sub 'New
  End Class 'InvoiceList
End Namespace 'BookExamples 
