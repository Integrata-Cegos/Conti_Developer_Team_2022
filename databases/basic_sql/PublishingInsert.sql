INSERT INTO SAWITZKI_PUBLISHERS (NAME) VALUES ('Springer');
INSERT INTO SAWITZKI_BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, PUBLISHER_ID) SELECT 'ISBN1', 'Title1', 200, 19.99, 1, ID FROM SAWITZKI_PUBLISHERS WHERE NAME='Springer';
INSERT INTO SAWITZKI_BOOKS (ISBN, TITLE, PAGES, PRICE, AVAILABLE, PUBLISHER_ID) SELECT 'ISBN2', 'Title3', 200, 19.99, 1, ID FROM SAWITZKI_PUBLISHERS WHERE NAME='Springer';
INSERT INTO SAWITZKI_AUTHORS (LASTNAME, FIRSTNAME) VALUES ('Mustermann', 'Hans');
INSERT INTO SAWITZKI_AUTHORS (LASTNAME, FIRSTNAME) VALUES ('Müller', 'Frieda');
INSERT INTO SAWITZKI_AUTHORS (LASTNAME, FIRSTNAME) VALUES ('Pausenkurt', 'Pascal');
INSERT INTO SAWITZKI_BOOKS_AUTHORS (ISBN, AUTHOR_ID) SELECT 'ISBN1', ID FROM SAWITZKI_AUTHORS WHERE LASTNAME = 'Mustermann'
INSERT INTO SAWITZKI_BOOKS_AUTHORS (ISBN, AUTHOR_ID) SELECT 'ISBN2', ID FROM SAWITZKI_AUTHORS WHERE LASTNAME = 'Müller'
INSERT INTO SAWITZKI_BOOKS_AUTHORS (ISBN, AUTHOR_ID) SELECT 'ISBN2', ID FROM SAWITZKI_AUTHORS WHERE LASTNAME = 'Pausenkurt'