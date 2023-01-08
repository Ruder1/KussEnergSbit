using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Models;

namespace TestCase.DataConvertor
{
    /// <summary>
    /// Класс для изменения полученных данных
    /// </summary>
    public class TransformData
    {
        /// <summary>
        /// Метод для соотнесения строк по своим группам
        /// </summary>
        /// <param name="extract">Выгруженные данные из файла .xlsx</param>
        /// <returns>Возвращает список соотнесенных между собой данных из файла .xlsx</returns>
        public List<ProcessModel> MatchingRows(ExtractData extract)
        {
            try
            {
                var processList = new List<ProcessModel>();

                for (int i = 0; i < extract.Code.Count; i++)
                {
                    var process = new ProcessModel(null, null, new List<string>());

                    //Если пустые строки под заголовка Кода и подразделения процесса
                    if (extract.Code[i] == "" && extract.Process[i] != "")
                    {
                        process.ProcessName = extract.Process[i];
                        process.CodeName = extract.Code[i];
                        process.OwnerName.Add(extract.Owner[i]);
                        processList.Add(process);
                    }

                    //Если все строкие не пустые
                    if (extract.Code[i] != "" && extract.Process[i] != "" && extract.Owner[i] != null)
                    {
                        process.ProcessName = extract.Process[i];
                        process.CodeName = extract.Code[i];
                        process.OwnerName.Add(extract.Owner[i]);
                        processList.Add(process);
                    }

                    //Если у процесса есть несколько подразделений
                    if (extract.Code[i] == "" && extract.Process[i] == "" && extract.Owner[i] != null)
                    {
                        processList[^1].OwnerName.Add(extract.Owner[i]);
                    }
                }
                Console.WriteLine("Успешное соотношение выгруженных данных из файла .xlsx");
                return processList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
