using System.Collections;
using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;
using TestCase.DataConvertor;
using TestCase.Models;
using TestCase.ExcelHelper;
using System.Data.SqlClient;
using System.Data;
using TestCase.DataLoader;

namespace TestCase
{
    public class Program
    {
        static async Task Main(string[] args)
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

            using (BuisnessTestContext db = new BuisnessTestContext())
            {

                var buisnessProcess = db.BuisnessProcesses.ToList();
                foreach (var buisness in buisnessProcess)
                {
                    Console.Write($"{buisness.CodeId} ");
                    //Console.WriteLine(buisness.Code.CodeName);
                    Console.Write($"{buisness.ProcessId} ");
                    Console.WriteLine(buisness.OwnerId);
                }
            }

            //foreach (var data in sorted)
            //{
            //    Console.Write(data.CodeName + " ");
            //    Console.Write(data.ProcessName + " ");
            //    foreach (var owner in data.OwnerName)
            //    {
            //        Console.Write($"{owner} ");
            //    }

            //    Console.WriteLine();
            //}

        }

        static async Task ConnectToServer()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BuisnessTest;Trusted_Connection=True;";
            string sqlExpression = @"SELECT CodeProcess.CodeName, Process.ProcessName, OwnerProcess.OwnerName
            From BuisnessProcess, CodeProcess,Process, OwnerProcess
            WHERE CodeProcess.ID = BuisnessProcess.CodeId AND Process.ID = BuisnessProcess.ProcessId  AND OwnerProcess.Id = BuisnessProcess.OwnerId
            AND CodeProcess.CodeName BETWEEN 'A1' AND 'A2' AND NOT CodeProcess.CodeName = 'A2'";
            // Создание подключения
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                try
                {
                    // Открываем подключение
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows) // если есть данные
                    {
                        // выводим названия столбцов
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);
                       

                        Console.WriteLine($"{columnName1}\t {columnName2} \t{columnName3}");

                        while (await reader.ReadAsync()) // построчно считываем данные
                        {
                            var code = reader.GetString(0);
                            var name = reader.GetString(1);
                            var owner = reader.GetValue(2);
                            Console.WriteLine($"{code} \t{name} \t {owner}");
                        }
                    }
                    await reader.CloseAsync();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // если подключение открыто
                    if (connection.State == ConnectionState.Open)
                    {
                        // закрываем подключение
                        await connection.CloseAsync();
                        Console.WriteLine("Подключение закрыто...");
                    }
                }
            }
            Console.WriteLine("Программа завершила работу.");
            Console.Read();
        }
    }
}