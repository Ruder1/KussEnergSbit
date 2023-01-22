
--������� ���� ������ Library
Create Database Library

GO

Use Library

GO

--������� �������, ��� � ������� ������ ���� ��� � ���� Id
--��������� ������� �������� AuthorId
CREATE TABLE Author (
    AuthorId   INT            IDENTITY (1, 1) NOT NULL,
    AuthorName NVARCHAR (200) unique NULL ,
    CONSTRAINT PK_Author PRIMARY KEY CLUSTERED (AuthorId ASC)
);

GO

--������� ����, ��� � ������ ����� ���� ���� Id, ��� � ��� �������
--��������� ������ �������� BookId
CREATE TABLE Book (
    BookId          INT            IDENTITY (1, 1) NOT NULL,
    BookName	        NVARCHAR (300) NULL,
    YearPublication INT           NULL,
    CONSTRAINT PK_Book PRIMARY KEY CLUSTERED (BookId ASC),
);

GO

--������� ����������, ��� � ������ ����� ���� AuthorId � � ������� ������ ���� BookId
--��� �� ���� ���������� ���� Id
--������ ������� ����� ��� ����������� ����� ������ �� ������ ����� ��������� Author � Book
--��������������� ����� ������ �� ���� ������ ������ ���� �� ������
--��������� ���� Id, ���������� ����� ��������� Author � Book ���������� �� ������� ������� FK BookId � FK AuthorId

CREATE TABLE AuthorBook (
    Id       INT IDENTITY (1, 1) NOT NULL,
    BookId   INT NULL,
    AuthorId INT NULL,
    CONSTRAINT PK_AuthorBook PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT FK_AuthorBook_Book FOREIGN KEY (BookId) REFERENCES Book (BookId),
    CONSTRAINT FK_AuthorBook_Author FOREIGN KEY (AuthorId) REFERENCES Author (AuthorId)
);

