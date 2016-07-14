﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPGenerator.DataModel;

namespace SPGenerator.Core
{
    class DeleteSPGenerator : BaseSPGenerator
    {
        protected override void GenerateStatement(string tableName, StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            var schema = "";

            //if (!string.IsNullOrEmpty(selectedFields[0].Schema))
            //    schema = "[" + selectedFields[0].Schema + "].";

            sb.Append(Environment.NewLine + "\tDELETE from " + schema + WrapIfKeyWord(tableName) );

            //foreach (DBTableColumnInfo colInf in selectedFields)
            //{
            //    if (colInf.Exclude)
            //        continue;
            //    sb.Append(WrapIfKeyWord(colInf.ColumnName) + "=" + prefixInputParameter + colInf.ColumnName);
            //    sb.Append(",");
            //}

            //Remove Commma from end
            //sb[sb.Length - 1] = ' ';

            GenerateWhereStatement(whereConditionFields, sb);
        }
    

        protected override string GetSpName(string tableName)
        {
            return prefixDeleteSp + tableName;
        }
    }
}
