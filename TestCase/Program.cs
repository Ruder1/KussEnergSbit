using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;
using TestCase.Models;
using TestCase.ExcelHelper;

namespace TestCase
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = "тестовые данные.xlsx";
            var currentSheet = "Лист1";
            var provider = new ExcelProvider();
            var sheet = provider.ConnectorToWorkSheet(path, currentSheet);

            var cellsUsed = sheet.CellsUsed();
            var range = sheet.Range(sheet.FirstRowUsed().RowNumber(),
                sheet.FirstColumnUsed().ColumnNumber(), sheet.LastRowUsed().RowNumber(),
                sheet.FirstColumnUsed().ColumnNumber());

            var buisnessProcess = new BuisnessModel(new List<ProcessModel>());
            foreach (var xlCell in cellsUsed)
            {
                Console.WriteLine(xlCell.GetString());
            }

            var listProcess = new List<ProcessModel>();

            //TODO: Исправить получение данных из документа
            foreach (var cell in cellsUsed)
            {
                string codeName = null;
                string processName = null;
                List<string> ownerName = new List<string>();
                if (cell.Address == range)
                {
                    codeName= cell.GetString();
                }

                if (cell.Address == range)
                {
                    processName = cell.GetString();
                }

                if (cell.Address == range)
                {
                    ownerName.Add(cell.GetString());
                }

                
            }
            buisnessProcess.Buisnesses.AddRange(new List<ProcessModel>());
        }
    }
}