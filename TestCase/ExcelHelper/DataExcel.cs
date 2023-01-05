using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.ExcelHelper
{
    enum ProcessOwner
    {
        Null = 1,
        Retail,
        VIP,
        OPER,
        Compliance,
        CreditСommetee,
        CORP,
        PRO,
        ManagementBoard,
        StrategyCompetencyCenter

    }
    public  class DataExcel
    {
        
        public List<string> ProcessCodeList { get; set; }

        public List<string> ProcessNameList { get; set; }
    }
}
