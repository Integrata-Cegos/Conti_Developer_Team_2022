use publishing 

INSERT INTO PUBLISHERS (NAME) VALUES ('Springer');
INSERT INTO PUBLISHERS (NAME) VALUES ('Addison-Wesley');
INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, PUBLISHER_ID) SELECT 'ISBN1', 'Title1', 200, 19.99, 1, ID FROM PUBLISHERS WHERE NAME='Springer';
INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, PUBLISHER_ID) SELECT 'ISBN2', 'Title3', 200, 19.99, 1, ID FROM PUBLISHERS WHERE NAME='Springer';
INSERT INTO AUTHORS (LASTNAME, FIRSTNAME) VALUES ('Mustermann', 'Hans');
INSERT INTO AUTHORS (LASTNAME, FIRSTNAME) VALUES ('Müller', 'Frieda');
INSERT INTO AUTHORS (LASTNAME, FIRSTNAME) VALUES ('Pausenkurt', 'Pascal');
INSERT INTO BOOKS_AUTHORS (ISBN, AUTHOR_ID) SELECT 'ISBN1', ID FROM AUTHORS WHERE LASTNAME = 'Mustermann'
INSERT INTO BOOKS_AUTHORS (ISBN, AUTHOR_ID) SELECT 'ISBN2', ID FROM AUTHORS WHERE LASTNAME = 'Müller'
INSERT INTO BOOKS_AUTHORS (ISBN, AUTHOR_ID) SELECT 'ISBN2', ID FROM AUTHORS WHERE LASTNAME = 'Pausenkurt'

INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE) VALUES ('ISBN4711', 'Title4711', 200, 19.99, 1);

-- school books
INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, DISCRIMINATOR, SUBJECT, "YEAR", PUBLISHER_ID) SELECT 'ISBN100', 'Title100', 200, 19.99, 1, 'school','physics', 9, ID FROM PUBLISHERS WHERE NAME='Springer';
INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, DISCRIMINATOR, SUBJECT, "YEAR", PUBLISHER_ID) SELECT 'ISBN101', 'Title101', 200, 19.99, 1, 'school', 'math', 8, ID FROM PUBLISHERS WHERE NAME='Springer';

-- specialist books
INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, DISCRIMINATOR, TOPIC, PUBLISHER_ID) SELECT 'ISBN200', 'Title200', 200, 19.99, 1, 'specialist', 'sports', ID FROM PUBLISHERS WHERE NAME='Springer';
INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, DISCRIMINATOR, TOPIC, PUBLISHER_ID) SELECT 'ISBN201', 'Title201', 200, 19.99, 1, 'specialist', 'tv', ID FROM PUBLISHERS WHERE NAME='Springer';
INSERT INTO BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, DISCRIMINATOR, TOPIC, PUBLISHER_ID) SELECT 'ISBN202', 'Title202', 200, 19.99, 1, 'specialist', 'dvd', ID FROM PUBLISHERS WHERE NAME='Springer';


INSERT INTO ADDRESSES (CITY, STREET) VALUES ('München', 'Marienplatz')
INSERT INTO ADDRESSES (CITY, STREET) VALUES ('Berlin', 'Alexanderplatz')
INSERT INTO ADDRESSES (CITY, STREET) VALUES ('Stuttgart', 'Schlossplatz')

INSERT INTO AUTHORS_ADDRESSES (AUTHOR_ID, ADDRESS_ID) SELECT AU.ID, AD.ID FROM AUTHORS AS AU, ADDRESSES AS AD  WHERE AU.LASTNAME = 'Pausenkurt' AND AD.CITY= 'Berlin'
INSERT INTO AUTHORS_ADDRESSES (AUTHOR_ID, ADDRESS_ID) SELECT AU.ID, AD.ID FROM AUTHORS AS AU, ADDRESSES AS AD  WHERE AU.LASTNAME = 'Müller' AND AD.CITY= 'München'
INSERT INTO AUTHORS_ADDRESSES (AUTHOR_ID, ADDRESS_ID) SELECT AU.ID, AD.ID FROM AUTHORS AS AU, ADDRESSES AS AD  WHERE AU.LASTNAME = 'Mustermann' AND AD.CITY= 'Stuttgart'

INSERT INTO PUBLISHERS_ADDRESSES (PUBLISHER_ID, ADDRESS_ID) SELECT PUB.ID, AD.ID FROM PUBLISHERS AS PUB, ADDRESSES AS AD  WHERE PUB.NAME = 'Springer' AND AD.CITY= 'Berlin'

INSERT INTO SPECIALISTBOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, TOPIC) VALUES('ISBN42', 'Title42', 200, 19.99, 1, 'Science');

-- Test Data
DECLARE @publisherCounter INT;
DECLARE @booksCounter INT;
DECLARE @booksNumber INT;
SET @publisherCounter=1;

WHILE (@publisherCounter <=3)
BEGIN
	INSERT INTO PUBLISHERS (NAME) VALUES ('Publisher' + CONVERT(VARCHAR, @publisherCounter));
	SET @booksCounter=1;
	WHILE (@booksCounter <=10)
	BEGIN
		SET @booksNumber=@publisherCounter*1000 + @booksCounter;
		print (@booksNumber)
		INSERT INTO BOOKS (ISBN, TITLE, PRICE, PAGES, AVAILABLE, PUBLISHER_ID) SELECT 'Isbn' + CONVERT(VARCHAR, @booksNumber), 'Title' + CONVERT(VARCHAR, @booksNumber), 1.99 + @booksCounter, 10*@booksCounter, 1, ID FROM PUBLISHERS WHERE NAME = 'Publisher' + CONVERT(VARCHAR, @publisherCounter);
		IF @booksCounter IN (1,4,7,10)
			INSERT INTO BOOKS_AUTHORS(ISBN, AUTHOR_ID) select 'Isbn' + CONVERT(VARCHAR, @booksNumber), ID FROM AUTHORS AS A WHERE A.LASTNAME='Pausenkurt'; 
		IF @booksCounter IN (2,5,8)
			INSERT INTO BOOKS_AUTHORS(ISBN, AUTHOR_ID) select 'Isbn' + CONVERT(VARCHAR, @booksNumber), ID FROM AUTHORS AS A WHERE A.LASTNAME='Müller'; 
		IF @booksCounter IN (3,6,9)
			INSERT INTO BOOKS_AUTHORS(ISBN, AUTHOR_ID) select 'Isbn' + CONVERT(VARCHAR, @booksNumber), ID FROM AUTHORS AS A WHERE A.LASTNAME='Mustermann'; 
		
		SET @booksCounter = @booksCounter + 1;
	END
	SET @publisherCounter = @publisherCounter + 1;
END
go
