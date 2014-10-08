using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSEPM.Common.Enums
{
    public static class SellPointType
    {
        public static string Office = "Office";
        public static string Outside = "Outside";

        public static IEnumerable<string> GetAllSellPointTypes()
        {
            return new List<string> { Office, Outside };
        }
    }
}
