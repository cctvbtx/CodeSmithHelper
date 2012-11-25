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
            return prefix + column.Name.Replace(strip, "").ToCSharpIdentifier().ToPascalCase();
        }

        /// <summary>
        /// Helper to generate class name from a table
        /// </summary>
        /// <param name="table">table to be converted</param>
        /// <returns>string /returns>
        public static string GetClassNameFromTable(TableSchema table)
        {
            return GetClassNameFromTable(table, "", "");
        }

        /// <summary>
        /// Helper to generate class name from a table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="prefix"></param>
        /// <param name="strip"></param>
        /// <returns>string</returns>
        public static string GetClassNameFromTable(TableSchema table, string prefix, string strip)
        {
            return prefix + table.Name.Replace(strip, "").ToCSharpIdentifier().ToPascalCase();
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

        public string DnnSqlModel(SchemaExplorer.TableSchema SourceTable)
        {
            return "IDnn" + SourceTable.Name.Replace("NetTv_", "") + "Sql";
        }
        public string DnnDataModel(SchemaExplorer.TableSchema SourceTable)
        {
            return "IDnn" + SourceTable.Name.Replace("NetTv_", "").ToCSharpIdentifier().ToPascalCase();
        }
        public string DnnTableModel(SchemaExplorer.TableSchema SourceTable)
        {
            return "IDnn" + SourceTable.Name.Replace("NetTv_", "").ToCSharpIdentifier().ToPascalCase() + "Table";
        }
        public string ITableModel(SchemaExplorer.TableSchema SourceTable)
        {
            return "I" + SourceTable.Name.Replace("NetTv_", "").ToCSharpIdentifier().ToPascalCase() + "Table";
        }
        public string DataModel(SchemaExplorer.TableSchema SourceTable)
        {
            return "I" + SourceTable.Name.Replace("NetTv_", "").ToCSharpIdentifier().ToPascalCase();
        }
        public string IDnnDal(SchemaExplorer.TableSchema SourceTable)
        {
            return "I" + SourceTable.Name.Replace("NetTv_", "");
        }
        public string ISql(SchemaExplorer.TableSchema SourceTable)
        {
            return "I" + SourceTable.Name.Replace("NetTv_", "") + "Sql";
        }

        public string IRepository(SchemaExplorer.TableSchema SourceTable)
        {
            return "I" + SourceTable.Name.Replace("NetTv_", "") + "Repository";
        }

        public string IDal(SchemaExplorer.TableSchema SourceTable)
        {
            return "I" + SourceTable.Name.Replace("NetTv_", "") + "Dal";
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
