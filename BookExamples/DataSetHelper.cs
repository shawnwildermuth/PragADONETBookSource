using System;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Runtime.Serialization;

namespace BookExamples
{
	public class DataSetHelper
	{
    private DataSetHelper() {}

    public static void MoveDataTableSchema(DataTable tblSource, DataTable tblDest)
    {
      // Copy the PrimaryKey
      tblDest.PrimaryKey = tblSource.PrimaryKey;

      // Add the columns (not copies)
      foreach(DataColumn col in tblSource.Columns)
      {
        tblSource.Columns.Remove(col.ColumnName);
        tblDest.Columns.Add(col);
      }

      // Add the Constraints
      foreach(Constraint con in tblSource.Constraints)
      {
        tblDest.Constraints.Add(con);
      }

      // Add the PrimaryKey
      tblDest.PrimaryKey = tblSource.PrimaryKey;

      // Add the Relationships
      foreach(DataRelation rel in tblSource.ChildRelations)
      {
        tblDest.ChildRelations.Add(rel);
      }
      foreach(DataRelation rel in tblSource.ParentRelations)
      {
        tblDest.ParentRelations.Add(rel);
      }

      // Extended Properties
      tblDest.TableName = tblSource.TableName;
    }
	}
}
