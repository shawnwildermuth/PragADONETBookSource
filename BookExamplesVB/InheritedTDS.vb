Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Xml
Imports System.Runtime.Serialization


Namespace BookExamples
    _
  Public Class InheritedTDS
    Inherits FixedCustomerTDS

    Public Sub New()
      ' Overwrite the DataSet name
      MyBase.DataSetName = "InheritedTDS"
    End Sub 'New


    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      MyBase.New(info, context)
    End Sub 'New


    Public Shadows ReadOnly Property Invoice() As InheritedInvoiceDataTable
      Get
        Debug.Assert(TypeOf (MyBase.Invoice) Is InheritedInvoiceDataTable)
        Return CType(Me.Invoice, InheritedInvoiceDataTable)
      End Get
    End Property


    Protected Overrides Function CreateInvoiceDataTable(ByVal table As DataTable) As InvoiceDataTable
      If table Is Nothing Then
        Return New InheritedInvoiceDataTable()
      End If
      Return New InheritedInvoiceDataTable(table) '
    End Function 'CreateInvoiceDataTable

    Public Class InheritedInvoiceRow
      Inherits FixedCustomerTDS.InvoiceRow

      Public Sub New(ByVal builder As DataRowBuilder)
        MyBase.New(builder)
      End Sub 'New


      Public Shadows Property InvoiceDate() As DateTime
        Get
          Return MyBase.InvoiceDate
        End Get
        Set(ByVal Value As DateTime)
          If Value > DateTime.Today Then
            Throw New StrongTypingException("Invoice Date Cannot be in the future", Nothing)
          Else
            MyBase.InvoiceDate = Value
          End If
        End Set
      End Property


      Default Public Shadows ReadOnly Property Item(ByVal index As Integer) As Object
        Get
          Return MyBase.Item(index)
        End Get
      End Property
    End Class 'InheritedInvoiceRow
       _ 

    Public Class InheritedInvoiceDataTable
      Inherits FixedCustomerTDS.InvoiceDataTable

      Friend Sub New()
      End Sub 'New


      Friend Sub New(ByVal table As DataTable)
        MyBase.New(table)
      End Sub 'New


      Public Shadows Sub AddInvoiceRow(ByVal row As InvoiceRow)
        If DoesCustomerHaveCredit() Then
          MyBase.AddInvoiceRow(row)
        Else
          Throw New Exception("Customer Invoice cannot be created, no credit available")
        End If
      End Sub 'AddInvoiceRow


      Public Shadows Sub AddInvoiceRow(ByVal row As InheritedInvoiceRow)
        If DoesCustomerHaveCredit() Then
          MyBase.AddInvoiceRow(row)
        Else
          Throw New Exception("Customer Invoice cannot be created, no credit available")
        End If
      End Sub 'AddInvoiceRow


      Public Shadows Function AddInvoiceRow(ByVal InvoiceID As Guid, ByVal InvoiceDate As DateTime, ByVal Terms As String, ByVal FOB As String, ByVal PO As String, ByVal parentCustomerRowByCustomerInvoice As CustomerRow) As InheritedInvoiceRow
        If DoesCustomerHaveCredit() Then
          Return CType(MyBase.AddInvoiceRow(InvoiceID, InvoiceDate, Terms, FOB, PO, parentCustomerRowByCustomerInvoice), InheritedInvoiceRow)
        Else
          Throw New Exception("Customer Invoice cannot be created, " + "no credit available")
        End If
      End Function 'AddInvoiceRow


      Public Shadows Function NewInvoiceRow() As InheritedInvoiceRow
        If DoesCustomerHaveCredit() Then
          Return CType(MyBase.NewInvoiceRow(), InheritedInvoiceRow)
        Else
          Throw New Exception("Customer Invoice cannot be created, no credit available")
        End If
      End Function 'NewInvoiceRow


      Private Function DoesCustomerHaveCredit() As Boolean
        ' Credit Calculation Code
        Return True
      End Function 'DoesCustomerHaveCredit


      Default Public Shadows ReadOnly Property Item(ByVal index As Integer) As InheritedInvoiceRow
        Get
          Return CType(MyBase.Rows(index), InheritedInvoiceRow)
        End Get
      End Property


      Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
        Return New InheritedInvoiceRow(builder)
      End Function 'NewRowFromBuilder


      Protected Overrides Function GetRowType() As System.Type
        Return GetType(InheritedInvoiceRow)
      End Function 'GetRowType
    End Class 'InheritedInvoiceDataTable 
  End Class 'InheritedTDS
End Namespace 'BookExamples