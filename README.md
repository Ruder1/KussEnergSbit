# KussEnergSbit
Тестовое задание для КузбассЭнергоСбыт
## Создание БД
База данных создавалась в СУБД MS SQL Server.

Все SQL запросы были написаны на языке T-SQL, файлы запросов находятся в папке [SQLCommands](https://github.com/Ruder1/KussEnergSbit/tree/master/SQLCommands)


## Программа-загрузчик
Все исходники кода написанные на C# находятся в папке [TestCase](https://github.com/Ruder1/KussEnergSbit/tree/master/TestCase).

## Пояснение к программе

Для работы программы необходима уже созданная база данных на MS SQL Server

Чтобы работа программы была корректной необходимо чтобы база данных и соответсвовала строке подключения приведенной ниже.

`"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BuisnessTest"`

Для этого нужно создать сервер с названием `MSSQLLocalDB` и базу c названием `BuisnessTest`

Если выполнять через SQL команды в папке [SQLCommands](https://github.com/Ruder1/KussEnergSbit/tree/master/SQLCommands) файла [CreateTableSQL](https://github.com/Ruder1/KussEnergSbit/blob/master/SQLCommands/CreateTableSQL.sql)

### Задание

Имеется файл "тестовые данные.xlsx", содержащий информацию о бизнес-процессах  
в некотором банке.  
 
1. Спроектировать и создать реляционную БД для хранения этих данных. 
СУБД - любая реляционная, поддерживающая SQL (MySQL, MSSql Server и т.п.). 
Предпочтительно Oracle (можно использовать свободно распространяемую версию Oracle XE). 
 
2. Разработать программу-загрузчик, которая загрузит данные из файла EXCEL в  
созданную БД. Язык разработки программы - C#. 
 
3. Для полученной БД написать SQL запросы: 
- Выбрать все процессы, входящие в группу A1; 
- Выбрать все процессы входящие в группу A1, c их подразделениями-владельцами.  
