Imports System
Imports System.Data
Imports System.Xml
Imports System.Runtime.Serialization


Namespace BookExamples
    _
  Public Class CustomersObject
    Inherits CustomerTDS

    Public Sub New()
      Register()
    End Sub 'New


    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      MyBase.New(info, context)
      Register()
    End Sub 'New


    Private Sub Register()
      AddHandler Invoice.InvoiceRowChanging, AddressOf InvoiceChanging
    End Sub 'Register


    Private Sub InvoiceChanging(ByVal [source] As Object, ByVal args As InvoiceRowChangeEvent)
      If args.Action = DataRowAction.Add Or args.Action = DataRowAction.Change Then
        If args.Row.InvoiceDate > DateTime.Today Then
          Throw New Exception("Cannot Create Invoices in the Future")
        End If
      End If
    End Sub 'InvoiceChanging
  End Class 'CustomersObject
End Namespace 'BookExamples