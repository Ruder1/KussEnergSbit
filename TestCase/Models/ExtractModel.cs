using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase.Models
{
    /// <summary>
    /// Модель данных для выгруженных данных из файла .xlsx и не сопоставленных между собой
    /// </summary>
    public class ExtractData
    {
        
        public List<string>? Code { get; set; }
        public List<string>? Process { get; set; }
        public List<string>? Owner { get; set; }

    }
}
