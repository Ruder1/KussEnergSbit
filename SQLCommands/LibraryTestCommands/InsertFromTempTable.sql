use Library

Execute InsertFromNoteInTempTable

Insert Into Author(AuthorName)
(Select Distinct ##TempTable.Author
From ##TempTable
Where NOT Exists (Select * from Author Where Author.AuthorName = ##TempTable.Author))

Insert Into Book(BookName, YearPublication)
(Select Distinct ##TempTable.Book, ##TempTable.YearPublication
From ##TempTable
Where NOT Exists (Select * from Book Where Book.BookName = ##TempTable.Book And Book.YearPublication = ##TempTable.YearPublication))

Insert Into AuthorBook(AuthorId, BookId)
(Select Author.AuthorId, Book.BookId
From ##TempTable 
Left Join Author ON Author.AuthorName = ##TempTable.Author
Left Join Book ON Book.BookName = ##TempTable.Book AND Book.YearPublication = ##TempTable.YearPublication
Where
NOT Exists (Select * From AuthorBook Where AuthorBook.AuthorId = Author.AuthorId AND AuthorBook.BookId = Book.BookId))
Order by AuthorId
