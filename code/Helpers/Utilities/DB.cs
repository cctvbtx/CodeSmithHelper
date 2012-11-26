using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SchemaExplorer;
using CodeSmith.Core.Extensions;

namespace Dev.CSmith.Utilities
{
    public static class DB
    {
        /// <summary>
        /// Helper for class generation from tables, converts a column name into a Property Name
        /// </summary>
        /// <param name="column"></param>
        /// <returns>string</returns>
        public static string GetPropertyNameFromColumn(ColumnSchema column)
        {
            return GetPropertyNameFromColumn(column, "", "");
        }

        /// <summary>
        /// Helper for class generation from tables, converts a column name into a Property Name
        /// </summary>
        /// <param name="column"> Column to be converted</param>
        /// <param name="prefix">Add characters to column</param>
        /// <param name="strip">remove characters from column</param>
        /// <returns>string</returns>
        public static string GetPropertyNameFromColumn(ColumnSchema column, string prefix, string strip)
        {
            if (strip != string.Empty)
            {
                return prefix + column.Name.Replace(strip, "").ToCSharpIdentifier().ToPascalCase();
            }
            else
            {
                return prefix + column.Name.ToCSharpIdentifier().ToPascalCase();
            }
        }

        /// <summary>
        /// Helper to generate class name from a table
        /// </summary>
        /// <param name="table">table to be converted</param>
        /// <returns>string /returns>
        public static string GetClassNameFromTable(TableSchema table)
        {
            return GetClassNameFromTable(table, "", "", "");
        }

        /// <summary>
        /// Helper to generate class name from a table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="prefix"></param>
        /// <param name="strip"></param>
        /// <returns>string</returns>
        public static string GetClassNameFromTable(TableSchema table, string prefix, string postfix, string strip)
        {
            if (strip != string.Empty)
            {
                return prefix + table.Name.Replace(strip, "").ToCSharpIdentifier().ToPascalCase() + postfix;
            }
            else
            {
                return prefix + table.Name.ToCSharpIdentifier().ToPascalCase() + postfix;
            }
        }

        /// <summary>
        /// Is the current column an Identity column
        /// </summary>
        /// <param name="column">table column to be checked</param>
        /// <returns>True/False</returns>
        public static bool IsIdentityColumn(ColumnSchema column)
        {
            return (bool)column.ExtendedProperties["CS_IsIdentity"].Value;
        }


        // todo
        /*
        public string GetPrimaryKeyParameters(TableSchema table, bool includeTypes)
        {
            string parameters = "";

            if (table.PrimaryKey != null)
            {
                for (int i = 0; i < table.PrimaryKey.MemberColumns.Count; i++)
                {
                    if (parameters.Length == 0)
                    {
                        if (includeTypes)
                        {
                            parameters = parameters + GetCSharpVariableType(table.PrimaryKey.MemberColumns[i]) + " ";
                        }
                        parameters = parameters + table.PrimaryKey.MemberColumns[i].Name.ToPascalCase();
                    }
                    else
                    {
                        parameters = parameters + ", ";

                        if (includeTypes)
                        {
                            parameters = parameters + GetCSharpVariableType(table.PrimaryKey.MemberColumns[i]) + " ";
                        }
                        parameters = parameters + table.PrimaryKey.MemberColumns[i].Name.ToPascalCase();
                    }
                }
            }
            else
            {
                throw new ApplicationException("This template will only work on tables with a primary key.");
            }
            return parameters;
        }


        public string CreateColumnList(TableSchema table)
        {
            StringBuilder sb = new StringBuilder();
            int indexer = 1;
            foreach (ColumnSchema column in table.Columns)
            {
                sb.Append("{databaseOwner}[{objectQualifier}" + table.Name + "].[" + column.Name + "]");
                if (indexer < table.Columns.Count)
                    sb.Append(",");
                indexer++;
            }
            return sb.ToString();
        }

        */

    }
}
