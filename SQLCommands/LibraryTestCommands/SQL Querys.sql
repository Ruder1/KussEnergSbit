use Library

--Получить список книг, написанных автором N (включая соавторство, не включая соавторство).

Select Book.BookName, Author.AuthorName, Book.YearPublication 
From Author, AuthorBook, Book
Where Author.AuthorName = N'Автор1' AND Author.AuthorId = AuthorBook.AuthorId AND AuthorBook.BookId = Book.BookId
Order by Book.YearPublication


-- Получить список книг, написанные автором N в соавторстве с M.

Select Book.BookName, Book.YearPublication
From AuthorBook
Left Join Author On Author.AuthorId = AuthorBook.AuthorId
Left join Book On Book.BookId = AuthorBook.BookId
Where Author.AuthorName IN (N'Автор1', N'Автор3')
Group by Book.BookName, Book.YearPublication
Having count(AuthorBook.BookId) > 1



-- Получить список книг, которые написаны 3-мя соавторами.

 Select Book.BookName, Author.AuthorName, Book.YearPublication
From AuthorBook
	Left join Author on Author.AuthorId = AuthorBook.AuthorId 
	Left join Book on Book.BookId = AuthorBook.BookId
Where  Book.BookId IN 
	(SELECT c.BookId        				
    FROM AuthorBook As c                
    GROUP BY c.BookId                
    HAVING count(c.BookId) = 3);  


--Получить всех авторов, у которых вышло более одной книги за указанный год.

Select Book.BookName, Author.AuthorName, Book.YearPublication
From AuthorBook
	Left join Author on Author.AuthorId = AuthorBook.AuthorId 
	Left join Book on Book.BookId = AuthorBook.BookId
Where  Book.YearPublication in (2000,2012)
Order By Book.YearPublication
