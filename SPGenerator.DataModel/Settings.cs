using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPGenerator.DataModel
{
    public class Settings
    {
        public string prefixWhereParameter = "@w_";
        public string prefixInputParameter = "@p_";
        public string prefixInsertSp = "spCreate_";
        public string prefixUpdateSp = "spEdit_";
        public string prefixSelectSp = "spSelect_";
        public string prefixDeleteSp = "spDelete_";
        public string  errorHandling = "No";
    }
}
