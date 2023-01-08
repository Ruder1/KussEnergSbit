using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.Models.DatabaseModels;
using TestCase.Models;

namespace TestCase.DataLoader
{
    /// <summary>
    /// Класс для загрузки данных из файла .xlsx
    /// </summary>
    public class LoaderToDatabase
    {
        /// <summary>
        /// Метод для занесения в промежуточную таблицы связи многие ко многим
        /// </summary>
        /// <param name="dataList">Список данных для установления связи</param>
        public void AddRelationMTM(List<ProcessModel> dataList)
        {
            using (BuisnessTestContext db = new BuisnessTestContext())
            {
                foreach (var data in dataList)
                {
                    if (data.CodeName != "")
                    {
                        var codeId = db.CodeProcesses.ToList().
                            Find(process => process.CodeName == data.CodeName)!.Id;
                        var processId = db.Processes.ToList().
                            Find(process => process.ProcessName == data.ProcessName)!.Id;

                        foreach (var division in data.OwnerName)
                        {
                            var ownerId = db.OwnerProcesses.ToList().
                                Find(owner => owner.OwnerName == division)!.Id;

                            //Сопоставляем данные в промежуточную таблицу
                            BuisnessProcess business = new BuisnessProcess
                            {
                                CodeId = codeId,
                                ProcessId = processId,
                                OwnerId = ownerId
                            };

                            var dbBusiness = db.BuisnessProcesses.ToList();

                            //Проверяем что таблица не пуста
                            if (dbBusiness.Count != 0)
                            {
                                //Проверяем на дубликаты
                                var check = dbBusiness.
                                    Find(p => p.OwnerId == business.OwnerId
                                              && p.CodeId == business.CodeId);

                                if (check != null)
                                {
                                    db.BuisnessProcesses.Add(business);
                                }
                            }
                            else
                            {
                                db.BuisnessProcesses.Add(business);
                            }
                            //Сохраняем данные
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для загрузки данных из файла .xlsx в базу данных MSSQL
        /// </summary>
        /// <param name="dataList">Данные необходимые для загрузки в БД</param>
        public void AddDataToDb(List<ProcessModel> dataList)
        {
            using (BuisnessTestContext db = new BuisnessTestContext())
            {
                foreach (var data in dataList)
                {
                    CodeProcess code = new CodeProcess
                    {
                        CodeName = data.CodeName
                    };

                    //Проверка на дубликаты в Code
                    if (!db.CodeProcesses.Any(compare => compare.CodeName == code.CodeName))
                    {
                        db.CodeProcesses.Add(code);
                    }

                    Process process = new Process
                    {
                        ProcessName = data.ProcessName
                    };

                    //Проверка на дубликаты в Process
                    if (!db.CodeProcesses.Any(compare => compare.CodeName == code.CodeName))
                    {
                        db.Processes.Add(process);
                    }

                    foreach (var ownerName in data.OwnerName)
                    {
                        OwnerProcess owner = new OwnerProcess
                        {
                            OwnerName = ownerName
                        };

                        //Проверка на дубликаты в Owner
                        if (!db.OwnerProcesses.Any(compare => compare.OwnerName == owner.OwnerName))
                        {
                            db.OwnerProcesses.Add(owner);
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
