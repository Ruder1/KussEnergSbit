using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Models
{
    public enum ProcessOwner
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

    public class BuisnessModel
    {
        public BuisnessModel(List<ProcessModel> buisnesses)
        {
            Buisnesses = buisnesses;
        }

        public List<ProcessModel> Buisnesses { get; set; }
    }

    public class ProcessModel
    {

        public ProcessModel(string codeName, string processName, List<string> ownerName)
        {
            this.CodeName = codeName;
            this.ProcessName = processName;
            this.OwnerName = ownerName;
        }

        public string? CodeName { get; set; }
        public string? ProcessName { get; set; }

        public List<string?> OwnerName { get; set; }
    }
}
