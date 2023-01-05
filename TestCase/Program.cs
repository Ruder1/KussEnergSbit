using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;
using TestCase.ExcelHelper;


namespace TestCase
{
    public class Program
    {
        static void Main(string[] args)
        {
            var path = "тестовые данные.xlsx";
            var book = new XLWorkbook(path);
            var sheet = book.Worksheet("Лист1");
            var fistColumnNumber = sheet.FirstColumnUsed().ColumnNumber();
            var lastColumnNumber = sheet.LastColumnUsed().ColumnNumber();
            var firstRowNumber = sheet.FirstRowUsed().RowNumber();
            var lastRowNumber = sheet.LastRowUsed().RowNumber();

            var range = sheet.Range(firstRowNumber, fistColumnNumber, lastRowNumber, lastColumnNumber);
            var cells = range.Cells();
            foreach (var cell in cells)
            {
                Console.WriteLine(cell.GetString());
                if (cell.GetString() == ProcessOwner.CORP.ToString())
                {
                    int corp = (int) ProcessOwner.CORP;
                }
            }
        }
    }
}