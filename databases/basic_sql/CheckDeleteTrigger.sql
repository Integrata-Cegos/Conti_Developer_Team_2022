declare @isbn varchar(20)
set @isbn = 'ISBN1'

select STOCK from SAWITZKI_STORE WHERE ITEM = @isbn
delete from SAWITZKI_BOOKS_AUTHORS WHERE ISBN = @isbn
delete from SAWITZKI_BOOKS where ISBN = @isbn
select STOCK from SAWITZKI_STORE WHERE ITEM = @isbn

