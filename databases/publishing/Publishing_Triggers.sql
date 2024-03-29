use publishing 
DROP TRIGGER IF EXISTS BOOKS_TO_STORE
GO

CREATE TRIGGER BOOKS_TO_STORE ON BOOKS FOR INSERT, DELETE AS
BEGIN
	DECLARE @isbn varchar(20)
	select @isbn=isbn from INSERTED
	IF (@isbn is null) 
		BEGIN
			select @isbn=isbn from DELETED
			DELETE FROM STORE WHERE CATEGORY='books' AND ITEM=@isbn
		END
	ELSE
	BEGIN
		INSERT INTO STORE (CATEGORY, ITEM, STOCK) VALUES('books', @isbn, 0)
	END
END
