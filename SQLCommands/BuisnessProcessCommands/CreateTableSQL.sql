Create database BuisnesTest

GO --need to go next request MS SQL

use BuisnessTest

Create Table CodeProcess
(
	ID int Primary Key Identity(1,1),
	CodeName nvarchar(50)
);

Create table Process
(
	ID int primary key identity(1,1),
	ProcessName nvarchar(max) NOT NULL
);

CREATE table OwnerProcess 
(
	Id int Primary Key IDENTITY(1,1),
	OwnerName nvarchar(50)
);

CREATE table BuisnessProcess
( 
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	CodeId int NOT NULL References CodeProcess(ID), 
	ProcessId int NOT NULL References Process(ID),
	OwnerId int NOT NULL References OwnerProcess(ID)
);