using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace TestCase.ExcelHelper
{
    public class ExcelProvider
    {
        /// <summary>
        /// Подключается к файлу .xlsx
        /// </summary>
        /// <param name="path">Путь к файлу</param>
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
        /// <param name="sheet">Рабочий лист</param>
        /// <returns>Возвращает все используемые ячейки</returns>
        public IXLCells GetCells(IXLWorksheet sheet)
        {
            var cells = sheet.CellsUsed();
            return cells;

        }

        /// <summary>
        /// Получение таблицы в используемом диапазоне ячеек на рабочем листе
        /// </summary>
        /// <param name="sheet">Рабочий лист</param>
        /// <returns>Возвращает таблицу в рабочем диапазоне</returns>
        public IXLTable GetTable(IXLWorksheet sheet)
        {
            //Ищем первую используемую строку
            var firstRowUsed = sheet.FirstRowUsed();
            //Сужаем строку до используемой части
            var categoryRow = firstRowUsed.RowUsed();
            //Переходим от заголовка к нужным данным
            categoryRow = categoryRow.RowBelow();

            var firstPossibleAddress = sheet.Row(categoryRow.RowNumber()).FirstCell().Address;
            var lastPossibleAddress = sheet.LastCellUsed().Address;

            var companyRange = sheet.Range(firstPossibleAddress, lastPossibleAddress).RangeUsed();
            var companyTable = companyRange.AsTable();

            return companyTable;
        }

    }
}
