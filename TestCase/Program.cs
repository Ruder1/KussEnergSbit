using System.Collections;
using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;
using TestCase.DataConvertor;
using TestCase.Models;
using TestCase.ExcelHelper;
using System.Data.SqlClient;
using System.Data;
using TestCase.DataLoader;
using TestCase.Models.DatabaseModels;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.EMMA;

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
            var companyTable = provider.GetTable(sheet);

            var extractedData = new ExcelExtractor().Extractor(companyTable,titles);

            var matchedData = new TransformData().MatchingRows(extractedData);

            var loader = new LoaderToDatabase();
            loader.AddDataToDb(matchedData);
            loader.AddRelationMTM(matchedData);
            
        }
    }
}