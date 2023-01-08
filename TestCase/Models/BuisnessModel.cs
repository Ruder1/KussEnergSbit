using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Models
{
    /// <summary>
    /// Модель бизнес логики для выгруженных данных из файла .xlsx и сопоставляенных между собой
    /// </summary>
    public class ProcessModel
    {

        public ProcessModel(string codeName, string processName, List<string> ownerName)
        {
            this.CodeName = codeName;
            this.ProcessName = processName;
            this.OwnerName = ownerName;
        }

        public ProcessModel()
        {
        }

        public string? CodeName { get; set; }
        public string? ProcessName { get; set; }

        public List<string?> OwnerName { get; set; }
    }
}
