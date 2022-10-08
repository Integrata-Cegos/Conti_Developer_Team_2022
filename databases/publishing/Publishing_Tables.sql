use publishing 
DROP TABLE IF EXISTS BOOKS_AUTHORS;
DROP TABLE IF EXISTS PUBLISHERS_ADDRESSES;
DROP TABLE IF EXISTS AUTHORS_ADDRESSES;
DROP TABLE IF EXISTS BOOKS;
DROP TABLE IF EXISTS SPECIALISTBOOKS;
DROP TABLE IF EXISTS PUBLISHERS;
DROP TABLE IF EXISTS STORE;
DROP TABLE IF EXISTS AUTHORS;
DROP TABLE IF EXISTS ADDRESSES;

CREATE TABLE PUBLISHERS (
	ID INT IDENTITY(1, 1), 
	NAME VARCHAR(50) NOT NULL, PRIMARY KEY (ID)
	);
CREATE TABLE BOOKS (
	ISBN VARCHAR(20) NOT NULL UNIQUE, 
	TITLE VARCHAR(100) UNIQUE NOT NULL, 
	PAGES INT CHECK (PAGES > 0), 
	PRICE FLOAT CHECK (PRICE >= 0), 
	AVAILABLE BIT NOT NULL, 
	PUBLISHER_ID INT, 
	SUBJECT VARCHAR(50),
	"YEAR" INT,
	TOPIC VARCHAR(50),
	DISCRIMINATOR VARCHAR(10),
	PRIMARY KEY (ISBN), 
	FOREIGN KEY (PUBLISHER_ID) REFERENCES PUBLISHERS(ID)
	);
CREATE TABLE SPECIALISTBOOKS (
	ISBN VARCHAR(20), 
	TITLE VARCHAR(100) UNIQUE NOT NULL, 
	PAGES INT CHECK (PAGES > 0), 
	PRICE FLOAT CHECK (PRICE >= 0), 
	AVAILABLE BIT NOT NULL,
	TOPIC VARCHAR(20),
	PRIMARY KEY (ISBN) 
);
CREATE TABLE AUTHORS(
	ID INT IDENTITY(1, 1), 
	LASTNAME VARCHAR(50) NOT NULL, 
	FIRSTNAME VARCHAR(50) NOT NULL, 
	PRIMARY KEY (ID)
	
)
CREATE TABLE BOOKS_AUTHORS(
	ISBN VARCHAR(20),
	AUTHOR_ID INT,
	PRIMARY KEY (ISBN, AUTHOR_ID),
	FOREIGN KEY (ISBN) REFERENCES BOOKS(ISBN),
	FOREIGN KEY (AUTHOR_ID) REFERENCES AUTHORS(ID)
)
CREATE TABLE STORE (CATEGORY VARCHAR(20), ITEM VARCHAR(20), STOCK INT CHECK (STOCK >= 0), PRIMARY KEY (CATEGORY, ITEM));

CREATE TABLE ADDRESSES (
	ID INT IDENTITY(1, 1),
	CITY VARCHAR(50),
	STREET VARCHAR(50), 
	PRIMARY KEY (ID)
)
CREATE TABLE PUBLISHERS_ADDRESSES(
	PUBLISHER_ID INT,
	ADDRESS_ID INT,
	PRIMARY KEY (PUBLISHER_ID, ADDRESS_ID),
	FOREIGN KEY (PUBLISHER_ID) REFERENCES PUBLISHERS(ID),
	FOREIGN KEY (ADDRESS_ID) REFERENCES ADDRESSES(ID)
)
CREATE TABLE AUTHORS_ADDRESSES(
	AUTHOR_ID INT,
	ADDRESS_ID INT,
	PRIMARY KEY (AUTHOR_ID, ADDRESS_ID),
	FOREIGN KEY (AUTHOR_ID) REFERENCES AUTHORS(ID),
	FOREIGN KEY (ADDRESS_ID) REFERENCES ADDRESSES(ID)
)

CREATE INDEX BOOKS_TITLE ON BOOKS(TITLE)
CREATE INDEX BOOKS_PRICE ON BOOKS(PRICE)
