using System.Collections;
using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;
using TestCase.DataConvertor;
using TestCase.Models;
using TestCase.ExcelHelper;

namespace TestCase
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "тестовые данные.xlsx";
            const string currentSheet = "Лист1";
            var titles = new List<string>()
            {
                "Код\r\nпроцесса", 
                "Наименование процесса", 
                "Подразделение \r\nВладелец процесса"
            };

            var provider = new ExcelProvider();

            var sheet = provider.ConnectorToWorkSheet(fileName, currentSheet);
            var cellsUsed = provider.GetCells(sheet);
            var companyTable = provider.GetTable(sheet);

            var ext = new ExcelExtractor().Extractor(companyTable,titles);

            var sorted = new TransformData().MatchingRows(ext);

            for (int i = 0; i < ext.Code.Count; i++)
            {
                Console.Write(ext.Code[i] + " ");
                Console.Write(ext.Process[i] + " ");
                Console.Write(ext.Owner[i]);
                Console.WriteLine();
            }

            //var range = sheet.Range(sheet.FirstRowUsed().RowNumber(),
            //    sheet.FirstColumnUsed().ColumnNumber(), sheet.LastRowUsed().RowNumber(),
            //    sheet.FirstColumnUsed().ColumnNumber());

            //var buisnessProcess = new BuisnessModel(new List<ProcessModel>());

            //foreach (var xlCell in companyTable.Cells())
            //{
            //    Console.WriteLine(xlCell.Address);
            //    Console.WriteLine(xlCell.GetString());
            //}
        }
    }
}