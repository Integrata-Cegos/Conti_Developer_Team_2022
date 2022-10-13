﻿DROP TABLE IF EXISTS ISSUES;
DROP TABLE IF EXISTS USERS;
DROP TABLE IF EXISTS HISTORY;

CREATE TABLE HISTORY (
	ID int identity(1,1) PRIMARY KEY,
	TIMESTAMP DATETIME DEFAULT CURRENT_TIMESTAMP,
	OPERATION VARCHAR(MAX),
	ISSUE int NOT NULL,
	DATA VARCHAR(MAX),
	FOREIGN KEY (ISSUE) REFERENCES ISSUES(ID)
	);

CREATE TABLE USERS (
	ID int IDENTITY(1,1) PRIMARY KEY,
	USERNAME VARCHAR(50) UNIQUE NOT NULL,
	FIRSTNAME VARCHAR(50) NOT NULL,
	LASTNAME VARCHAR(50) NOT NULL
	);

CREATE TABLE ISSUES (
	ID int IDENTITY(1,1) PRIMARY KEY,
	ASSIGNEE int,
	DESCRIPTION VARCHAR(500) NOT NULL,
	STATUS VARCHAR(50) NOT NULL,
	CONSTRAINT STATUS_CHECK
	CHECK (STATUS IN ('OPEN', 'IN PROGRESS', 'FINISHED')),
	PRIORITY VARCHAR(50) NOT NULL,
	CONSTRAINT PRIO_CHECK
	CHECK (PRIORITY IN ('LOW','MEDIUM', 'HIGH', 'CRITICAL')),
	FOREIGN KEY (ASSIGNEE) REFERENCES USERS(ID)
	);


ALTER TABLE ISSUES ADD CONSTRAINT STATUS_ASSIGNEE_NULL_CHECK
	CHECK
	((STATUS = 'IN PROGRESS' AND ASSIGNEE IS NOT NULL) OR STATUS <> 'IN PROGRESS');
	
--ALTER TABLE ISSUES ADD CONSTRAINT ASSIGNEE_CHECK
--	CHECK
--	(ASSIGNEE IS NULL AND STATUS = 'IN PROGRESS');
