use Library

--�������� ������ ����, ���������� ������� N (������� �����������, �� ������� �����������).

Select Book.BookName, Author.AuthorName, Book.YearPublication 
From Author, AuthorBook, Book
Where Author.AuthorName = N'�����1' AND Author.AuthorId = AuthorBook.AuthorId AND AuthorBook.BookId = Book.BookId
Order by Book.YearPublication


-- �������� ������ ����, ���������� ������� N � ����������� � M.

Select Book.BookName, Book.YearPublication
From AuthorBook
Left Join Author On Author.AuthorId = AuthorBook.AuthorId
Left join Book On Book.BookId = AuthorBook.BookId
Where Author.AuthorName IN (N'�����1', N'�����3')
Group by Book.BookName, Book.YearPublication
Having count(AuthorBook.BookId) > 1



-- �������� ������ ����, ������� �������� 3-�� ����������.

 Select Book.BookName, Author.AuthorName, Book.YearPublication
From AuthorBook
	Left join Author on Author.AuthorId = AuthorBook.AuthorId 
	Left join Book on Book.BookId = AuthorBook.BookId
Where  Book.BookId IN 
	(SELECT c.BookId        				
    FROM AuthorBook As c                
    GROUP BY c.BookId                
    HAVING count(c.BookId) = 3);  


--�������� ���� �������, � ������� ����� ����� ����� ����� �� ��������� ���.

Select Book.BookName, Author.AuthorName, Book.YearPublication
From AuthorBook
	Left join Author on Author.AuthorId = AuthorBook.AuthorId 
	Left join Book on Book.BookId = AuthorBook.BookId
Where  Book.YearPublication in (2000,2012)
Order By Book.YearPublication
