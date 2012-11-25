using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SchemaExplorer;
using CodeSmith.Core.Extensions;

namespace Dev.CSmith.Common
{
    public static class CSharp
    {
        public static string GetCSharpVariableType(ColumnSchema column)
        {
            if (column.Name.EndsWith("TypeCode")) return column.Name;

            switch (column.DataType)
            {
                case DbType.AnsiString: return "string";
                case DbType.AnsiStringFixedLength: return "string";
                case DbType.Binary: return "byte []";
                case DbType.Boolean: return "bool";
                case DbType.Byte: return "byte";
                case DbType.Currency: return "decimal";
                case DbType.Date: return "DateTime";
                case DbType.DateTime: return "DateTime";
                case DbType.Decimal: return "decimal";
                case DbType.Double: return "double";
                case DbType.Guid: return "Guid";
                case DbType.Int16: return "short";
                case DbType.Int32: return "int";
                case DbType.Int64: return "long";
                case DbType.Object: return "object";
                case DbType.SByte: return "sbyte";
                case DbType.Single: return "float";
                case DbType.String: return "string";
                case DbType.StringFixedLength: return "string";
                case DbType.Time: return "TimeSpan";
                case DbType.UInt16: return "ushort";
                case DbType.UInt32: return "uint";
                case DbType.UInt64: return "ulong";
                case DbType.VarNumeric: return "decimal";
                default:
                    {
                        return "__UNKNOWN__" + column.NativeType;
                    }
            }
        }

        public static string GetCSharpConvert(ColumnSchema column, string placeholder)
        {
            if (column.Name.EndsWith("TypeCode")) return column.Name;

            switch (column.DataType)
            {
                case DbType.AnsiString: return placeholder;
                case DbType.AnsiStringFixedLength: return placeholder;
                //case DbType.Binary: return "byte []";
                case DbType.Boolean: return "Convert.ToBoolean(" + placeholder + ");";
                case DbType.Byte: return "Convert.ToByte(" + placeholder + ")";
                case DbType.Currency: return "Convert.ToDecimal(" + placeholder + ")";
                case DbType.Date: return placeholder;
                case DbType.DateTime: return placeholder;
                case DbType.Decimal: return "Convert.ToDecimal(" + placeholder + ")";
                case DbType.Double: return "Convert.ToDouble(" + placeholder + ")";
                case DbType.Guid: return placeholder;
                case DbType.Int16: return "Convert.ToInt16(" + placeholder + ")";
                case DbType.Int32: return "Convert.ToInt32(" + placeholder + ")";
                case DbType.Int64: return "Convert.ToInt64(" + placeholder + ")";
                case DbType.Object: return placeholder;
                case DbType.SByte: return "Convert.ToSByte(" + placeholder + ")";
                case DbType.Single: return "Convert.ToFloat(" + placeholder + ")";
                case DbType.String: return placeholder;
                case DbType.StringFixedLength: return placeholder;
                case DbType.Time: return "TimeSpan";
                case DbType.UInt16: return "Convert.ToUInt16(" + placeholder + ")";
                case DbType.UInt32: return "Convert.ToUInt32(" + placeholder + ")";
                case DbType.UInt64: return "Convert.ToUInt64(" + placeholder + ")";
                case DbType.VarNumeric: return "Convert.ToDecimal(" + placeholder + ")";
                default:
                    {
                        return "__UNKNOWN__" + column.NativeType;
                    }
            }
        }

    }
}
