use publishing 
DROP PROCEDURE IF EXISTS CREATE_BOOK
DROP PROCEDURE IF EXISTS DELETE_BOOK
GO
CREATE PROCEDURE CREATE_BOOK @isbn VARCHAR(20), @title VARCHAR(50), @publisherName VARCHAR(50) as

BEGIN
	INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, PUBLISHER_ID) select @isbn, @title, 200, 19.99, 1, ID FROM PUBLISHERS WHERE NAME=@publisherName;
END

GO

CREATE PROCEDURE DELETE_BOOK @isbn VARCHAR(20) as

BEGIN
	DELETE FROM BOOKS_AUTHORS  WHERE ISBN=@isbn
	DELETE FROM BOOKS  WHERE ISBN=@isbn

END