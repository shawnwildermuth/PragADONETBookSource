using System;
using System.Data;

namespace BookExamples
{
  public class Field
  {
    // Disallow Construction
    private Field() {}

    // By Number
    static public string GetString(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return "";
      return rec.GetString(fldnum);
    }

    static public decimal GetDecimal(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return 0;
      return rec.GetDecimal(fldnum);
    }

    static public int GetInt(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return 0;
      return rec.GetInt32(fldnum);
    }

    static public bool GetBoolean(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return false;
      return rec.GetBoolean(fldnum);
    }

    static public byte GetByte(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return 0;
      return rec.GetByte(fldnum);
    }

    static public DateTime GetDateTime(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return new DateTime(0);
      return rec.GetDateTime(fldnum);
    }

    static public double GetDouble(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return 0;
      return rec.GetDouble(fldnum);
    }

    static public float GetFloat(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return 0;
      return rec.GetFloat(fldnum);
    }

    static public Guid GetGuid(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return Guid.Empty;
      return rec.GetGuid(fldnum);
    }

    static public Int32 GetInt32(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return 0;
      return rec.GetInt32(fldnum);
    }

    static public Int16 GetInt16(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return 0;
      return rec.GetInt16(fldnum);
    }

    static public Int64 GetInt64(IDataRecord rec, int fldnum)
    {
      if (rec.IsDBNull(fldnum)) return 0;
      return rec.GetInt64(fldnum);
    }

    // By Name
    static public string GetString(IDataRecord rec, string fldname)
    {
      return GetString(rec, rec.GetOrdinal(fldname));
    }

    static public decimal GetDecimal(IDataRecord rec, string fldname)
    {
      return GetDecimal(rec, rec.GetOrdinal(fldname));
    }

    static public int GetInt(IDataRecord rec, string fldname)
    {
      return GetInt(rec, rec.GetOrdinal(fldname));
    }

    static public bool GetBoolean(IDataRecord rec, string fldname)
    {
      return GetBoolean(rec, rec.GetOrdinal(fldname));
    }

    static public byte GetByte(IDataRecord rec, string fldname)
    {
      return GetByte(rec, rec.GetOrdinal(fldname));
    }

    static public DateTime GetDateTime(IDataRecord rec, 
      string fldname)
    {
      return GetDateTime(rec, rec.GetOrdinal(fldname));
    }

    static public double GetDouble(IDataRecord rec, string fldname)
    {
      return GetDouble(rec, rec.GetOrdinal(fldname));
    }

    static public float GetFloat(IDataRecord rec, string fldname)
    {
      return GetFloat(rec, rec.GetOrdinal(fldname));
    }

    static public Guid GetGuid(IDataRecord rec, string fldname)
    {
      return GetGuid(rec, rec.GetOrdinal(fldname));
    }

    static public Int32 GetInt32(IDataRecord rec, string fldname)
    {
      return GetInt32(rec, rec.GetOrdinal(fldname));
    }

    static public Int16 GetInt16(IDataRecord rec, string fldname)
    {
      return GetInt16(rec, rec.GetOrdinal(fldname));
    }

    static public Int64 GetInt64(IDataRecord rec, string fldname)
    {
      return GetInt64(rec, rec.GetOrdinal(fldname));
    }

  }
}
