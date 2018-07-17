Imports System
Imports System.Data
Imports System.Collections


Namespace BookExamples
    _
  Public Class Customer


    Public Sub New(ByVal rdr As IDataReader)

      ' If the column is not null, get the member data
      ' from the DataReader
      CustomerID = Field.GetGuid(rdr, "CustomerID")
      LastName = Field.GetString(rdr, "LastName")
      FirstName = Field.GetString(rdr, "FirstName")
      HomePhone = Field.GetString(rdr, "HomePhone")
      Address = Field.GetString(rdr, "Address")
      City = Field.GetString(rdr, "City")
      State = Field.GetString(rdr, "State")
      Zip = Field.GetString(rdr, "Zip")

      ' Create the BookList
      Invoices = New InvoiceList(rdr)
    End Sub 'New 

    ' Member Data
    Public CustomerID As Guid
    Public LastName As String
    Public FirstName As String
    Public HomePhone As String
    Public Address As String
    Public City As String
    Public State As String
    Public Zip As String
    Public Invoices As InvoiceList


    ' Override object.ToString() to support formatting of
    ' the name in the ComboBox
    Public Overrides Function ToString() As String
      Return LastName + ", " + FirstName
    End Function 'ToString
  End Class 'Customer
    _

  ' Wrapper for ArrayList to support Creation from a DataReader
  Public Class CustomerList
    Inherits ArrayList


    Public Sub New(ByVal rdr As IDataReader)

      ' Add Each Author to the colleciton
      While rdr.Read()
        Dim cust As New Customer(rdr)
        Add(cust)
      End While
    End Sub 'New 
  End Class 'CustomerList
End Namespace 'BookExamples 
