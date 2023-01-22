
--Создаем базу данных Library
Create Database Library

GO

Use Library

GO

--Таблица авторов, Где у каждого автора есть имя и свой Id
--Первичным ключаом является AuthorId
CREATE TABLE Author (
    AuthorId   INT            IDENTITY (1, 1) NOT NULL,
    AuthorName NVARCHAR (200) unique NULL ,
    CONSTRAINT PK_Author PRIMARY KEY CLUSTERED (AuthorId ASC)
);

GO

--Таблица книг, где у каждой книги есть свой Id, имя и год издания
--Первичным ключом является BookId
CREATE TABLE Book (
    BookId          INT            IDENTITY (1, 1) NOT NULL,
    BookName	        NVARCHAR (300) NULL,
    YearPublication INT           NULL,
    CONSTRAINT PK_Book PRIMARY KEY CLUSTERED (BookId ASC),
);

GO

--Таблица АвторКнига, где у каждой книги есть AuthorId и у каждого автора есть BookId
--Так же есть сурогатный ключ Id
--Данная таблица нужна для обеспечения связи многие ко многим между таблицами Author и Book
--Взаимодействует между каждой из этих таблиц связью один ко многим
--Первичный ключ Id, связывание между Таблицами Author и Book происходит по внешним ключами FK BookId и FK AuthorId

CREATE TABLE AuthorBook (
    Id       INT IDENTITY (1, 1) NOT NULL,
    BookId   INT NULL,
    AuthorId INT NULL,
    CONSTRAINT PK_AuthorBook PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_AuthorBook_Book FOREIGN KEY (BookId) REFERENCES Book (BookId),
    CONSTRAINT FK_AuthorBook_Author FOREIGN KEY (AuthorId) REFERENCES Author (AuthorId)
);

