using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace TestCase.ExcelHelper
{
    public class ExcelProvider
    {
        /// <summary>
        /// Подключается к файлу .xlsx
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Возвращает лист с которым будем работать</returns>
        public IXLWorksheet ConnectorToWorkSheet(string path, string currentSheet)
        {
            var book = new XLWorkbook(path);
            var sheet = book.Worksheet(currentSheet);
            return sheet;
        }

        /// <summary>
        /// Метод получения используемых ячеек
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns>Возвращает все используемые ячейки</returns>
        public IXLCells GetCells(IXLWorksheet sheet)
        {
            var cells = sheet.CellsUsed();
            return cells;

        }

    }
}
