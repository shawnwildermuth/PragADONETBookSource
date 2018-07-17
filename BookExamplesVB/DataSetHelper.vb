Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Xml
Imports System.Runtime.Serialization


Namespace BookExamples
    _
  Public Class DataSetHelper

    Private Sub New()
    End Sub 'New

    Public Shared Sub MoveDataTableSchema(ByVal tblSource As DataTable, ByVal tblDest As DataTable)
      ' Copy the PrimaryKey
      tblDest.PrimaryKey = tblSource.PrimaryKey

      ' Add the columns (not copies)
      Dim col As DataColumn
      For Each col In tblSource.Columns
        tblSource.Columns.Remove(col.ColumnName)
        tblDest.Columns.Add(col)
      Next col

      ' Add the Constraints
      Dim con As Constraint
      For Each con In tblSource.Constraints
        tblDest.Constraints.Add(con)
      Next con

      ' Add the PrimaryKey
      tblDest.PrimaryKey = tblSource.PrimaryKey

      ' Add the Relationships
      Dim rel As DataRelation
      For Each rel In tblSource.ChildRelations
        tblDest.ChildRelations.Add(rel)
      Next rel

      For Each rel In tblSource.ParentRelations
        tblDest.ParentRelations.Add(rel)
      Next rel

      ' Extended Properties
      tblDest.TableName = tblSource.TableName
    End Sub 'MoveDataTableSchema
  End Class 'DataSetHelper
End Namespace 'BookExamples