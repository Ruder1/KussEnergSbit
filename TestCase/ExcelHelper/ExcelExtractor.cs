using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using TestCase.Models;

namespace TestCase.ExcelHelper
{
    /// <summary>
    /// Класс для извлечение данных из файла .xlsx
    /// </summary>
    public class ExcelExtractor
    {
        /// <summary>
        /// Извлекает и связывает данные по строчно
        /// </summary>
        /// <param name="companyTable"></param>
        /// <returns>Возвращает связанные между собой извлеченные данные</returns>
        public ExtractData Extractor(IXLTable companyTable,List<string> titles)
        {
            var ext = new ExtractData
            {
                Code = companyTable.DataRange.Rows()
                    .Select(companyRow => companyRow.Field(titles[0]).GetString())
                    .ToList(),
                Process = companyTable.DataRange.Rows()
                    .Select(companyRow => companyRow.Field(titles[1]).GetString())
                    .ToList(),
                Owner = companyTable.DataRange.Rows()
                    .Select(companyRow => companyRow.Field(titles[2]).GetString())
                    .ToList()
            };

            return ext;
        }
    }
}
