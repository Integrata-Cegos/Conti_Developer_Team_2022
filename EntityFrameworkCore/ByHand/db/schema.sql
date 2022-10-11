use publishing
DROP TABLE IF EXISTS BLEICATS;
CREATE TABLE BLEICATS (id int identity(1,1) primary key, name varchar(20), coatcolor varchar(20), weight float)