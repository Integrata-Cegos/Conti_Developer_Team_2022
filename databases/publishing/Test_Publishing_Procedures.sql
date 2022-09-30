USE publishing
DECLARE @isbn VARCHAR(20)
SET @isbn='ISBN999'
EXEC SAWITZKI_CREATE_BOOK @isbn=@isbn, @title='Title999', @publisherName='Springer'

SELECT * FROM SAWITZKI_BOOKS WHERE ISBN=@isbn

EXEC SAWITZKI_DELETE_BOOK @isbn=@isbn

SELECT * FROM SAWITZKI_BOOKS WHERE ISBN=@isbn
