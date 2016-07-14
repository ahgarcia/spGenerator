using SPGenerator.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPGenerator.Core
{
    class SelectSPGenerator : BaseSPGenerator
    {
        protected override string GetSpName(string tableName)
        {
            return prefixSelectSp + tableName;
        }

        protected override void GenerateInputParameters(List<DBTableColumnInfo> tableFields, StringBuilder sb)
        {
            base.GenerateInputParameters(_whereConditionFields, sb);
        }

        protected override void GenerateStatement(string tableName,StringBuilder sb, List<DBTableColumnInfo> selectedFields, List<DBTableColumnInfo> whereConditionFields)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            var schema = "";

            if(!string.IsNullOrEmpty(selectedFields[0].Schema))
                schema = "[" + selectedFields[0].Schema +"].";

            //sb.Append(Environment.NewLine + "\tSelect " + schema + WrapIfKeyWord(tableName) );
            sb.AppendLine(Environment.NewLine + "\tSelect ");
            string comma = ",";
            int i = 1;

            foreach (DBTableColumnInfo colInf in selectedFields)
            {
                if (i == selectedFields.Count)                   
                comma = "";

                if (colInf.Exclude)
                {
                    i += 1;
                    continue;
                }
                //sb.Append(WrapIfKeyWord(colInf.ColumnName) + "=" + prefixInputParameter + colInf.ColumnName);

                sb.AppendLine("\t" + WrapIfKeyWord(colInf.ColumnName) + comma);
                //sb.Append(",");
                i += 1;
            }
           //Remove Commma from end
            //sb[sb.Length - 1] = ' ';
            sb.Append("\tfrom " + schema + WrapIfKeyWord(tableName));

            GenerateWhereStatement(whereConditionFields, sb);
        }
    }
}
