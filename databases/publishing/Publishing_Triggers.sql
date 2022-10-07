use publishing 
DROP TRIGGER IF EXISTS SAWITZKI_BOOKS_TO_STORE
GO

CREATE TRIGGER SAWITZKI_BOOKS_TO_STORE ON SAWITZKI_BOOKS FOR INSERT, DELETE AS
BEGIN
	DECLARE @isbn varchar(20)
	select @isbn=isbn from INSERTED
	IF (@isbn is null) 
		BEGIN
			select @isbn=isbn from DELETED
			DELETE FROM SAWITZKI_STORE WHERE CATEGORY='books' AND ITEM=@isbn
		END
	ELSE
	BEGIN
		INSERT INTO SAWITZKI_STORE (CATEGORY, ITEM, STOCK) VALUES('books', @isbn, 0)
	END
END
