Imports System
Imports System.Data


Namespace BookExamples
    _
  Public Class Field

    ' Disallow Construction
    Private Sub New()
    End Sub 'New

    ' By Number
    Public Overloads Shared Function GetString(ByVal rec As IDataRecord, ByVal fldnum As Integer) As String
      If rec.IsDBNull(fldnum) Then
        Return ""
      End If
      Return rec.GetString(fldnum)
    End Function 'GetString


    Public Overloads Shared Function GetDecimal(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Decimal
      If rec.IsDBNull(fldnum) Then
        Return 0
      End If
      Return rec.GetDecimal(fldnum)
    End Function 'GetDecimal


    Public Overloads Shared Function GetInt(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Integer
      If rec.IsDBNull(fldnum) Then
        Return 0
      End If
      Return rec.GetInt32(fldnum)
    End Function 'GetInt


    Public Overloads Shared Function GetBoolean(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Boolean
      If rec.IsDBNull(fldnum) Then
        Return False
      End If
      Return rec.GetBoolean(fldnum)
    End Function 'GetBoolean


    Public Overloads Shared Function GetByte(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Byte
      If rec.IsDBNull(fldnum) Then
        Return 0
      End If
      Return rec.GetByte(fldnum)
    End Function 'GetByte


    Public Overloads Shared Function GetDateTime(ByVal rec As IDataRecord, ByVal fldnum As Integer) As DateTime
      If rec.IsDBNull(fldnum) Then
        Return New DateTime(0)
      End If
      Return rec.GetDateTime(fldnum)
    End Function 'GetDateTime


    Public Overloads Shared Function GetDouble(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Double
      If rec.IsDBNull(fldnum) Then
        Return 0
      End If
      Return rec.GetDouble(fldnum)
    End Function 'GetDouble


    Public Overloads Shared Function GetFloat(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Single
      If rec.IsDBNull(fldnum) Then
        Return 0
      End If
      Return rec.GetFloat(fldnum)
    End Function 'GetFloat


    Public Overloads Shared Function GetGuid(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Guid
      If rec.IsDBNull(fldnum) Then
        Return Guid.Empty
      End If
      Return rec.GetGuid(fldnum)
    End Function 'GetGuid


    Public Overloads Shared Function GetInt32(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Int32
      If rec.IsDBNull(fldnum) Then
        Return 0
      End If
      Return rec.GetInt32(fldnum)
    End Function 'GetInt32


    Public Overloads Shared Function GetInt16(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Int16
      If rec.IsDBNull(fldnum) Then
        Return 0
      End If
      Return rec.GetInt16(fldnum)
    End Function 'GetInt16


    Public Overloads Shared Function GetInt64(ByVal rec As IDataRecord, ByVal fldnum As Integer) As Int64
      If rec.IsDBNull(fldnum) Then
        Return 0
      End If
      Return rec.GetInt64(fldnum)
    End Function 'GetInt64


    ' By Name
    Public Overloads Shared Function GetString(ByVal rec As IDataRecord, ByVal fldname As String) As String
      Return GetString(rec, rec.GetOrdinal(fldname))
    End Function 'GetString


    Public Overloads Shared Function GetDecimal(ByVal rec As IDataRecord, ByVal fldname As String) As Decimal
      Return GetDecimal(rec, rec.GetOrdinal(fldname))
    End Function 'GetDecimal


    Public Overloads Shared Function GetInt(ByVal rec As IDataRecord, ByVal fldname As String) As Integer
      Return GetInt(rec, rec.GetOrdinal(fldname))
    End Function 'GetInt


    Public Overloads Shared Function GetBoolean(ByVal rec As IDataRecord, ByVal fldname As String) As Boolean
      Return GetBoolean(rec, rec.GetOrdinal(fldname))
    End Function 'GetBoolean


    Public Overloads Shared Function GetByte(ByVal rec As IDataRecord, ByVal fldname As String) As Byte
      Return GetByte(rec, rec.GetOrdinal(fldname))
    End Function 'GetByte


    Public Overloads Shared Function GetDateTime(ByVal rec As IDataRecord, ByVal fldname As String) As DateTime
      Return GetDateTime(rec, rec.GetOrdinal(fldname))
    End Function 'GetDateTime


    Public Overloads Shared Function GetDouble(ByVal rec As IDataRecord, ByVal fldname As String) As Double
      Return GetDouble(rec, rec.GetOrdinal(fldname))
    End Function 'GetDouble


    Public Overloads Shared Function GetFloat(ByVal rec As IDataRecord, ByVal fldname As String) As Single
      Return GetFloat(rec, rec.GetOrdinal(fldname))
    End Function 'GetFloat


    Public Overloads Shared Function GetGuid(ByVal rec As IDataRecord, ByVal fldname As String) As Guid
      Return GetGuid(rec, rec.GetOrdinal(fldname))
    End Function 'GetGuid


    Public Overloads Shared Function GetInt32(ByVal rec As IDataRecord, ByVal fldname As String) As Int32
      Return GetInt32(rec, rec.GetOrdinal(fldname))
    End Function 'GetInt32


    Public Overloads Shared Function GetInt16(ByVal rec As IDataRecord, ByVal fldname As String) As Int16
      Return GetInt16(rec, rec.GetOrdinal(fldname))
    End Function 'GetInt16


    Public Overloads Shared Function GetInt64(ByVal rec As IDataRecord, ByVal fldname As String) As Int64
      Return GetInt64(rec, rec.GetOrdinal(fldname))
    End Function 'GetInt64
  End Class 'Field 
End Namespace 'BookExamples