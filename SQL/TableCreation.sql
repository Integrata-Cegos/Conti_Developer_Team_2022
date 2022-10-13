﻿DROP TABLE IF EXISTS ISSUES;
CREATE TABLE ISSUES (
	ID int IDENTITY(1,1) PRIMARY KEY,
	ASSIGNEE int,
	DESCRIPTION VARCHAR(500) NOT NULL,
	STATUS VARCHAR(50) NOT NULL,
	CONSTRAINT STATUS_CHECK
	CHECK (STATUS IN ('OPEN', 'IN PROGRESS', 'FINISHED')),
	PRIORITY VARCHAR(50) NOT NULL,
	CONSTRAINT PRIO_CHECK
	CHECK (PRIORITY IN ('LOW','MEDIUM', 'HIGH', 'CRITICAL'))
	);

DROP TABLE IF EXISTS USERS;
CREATE TABLE USERS (
	ID int IDENTITY(1,1) PRIMARY KEY,
	USERNAME VARCHAR(50) UNIQUE NOT NULL,
	FIRSTNAME VARCHAR(50) NOT NULL,
	LASTNAME VARCHAR(50) NOT NULL
	);

ALTER TABLE ISSUES ADD CONSTRAINT STATUS_ASSIGNEE_NULL_CHECK
	CHECK
	(NOT ( STATUS = 'IN PROGRESS' AND ASSIGNEE = NULL));
	
ALTER TABLE ISSUES ADD CONSTRAINT ASSIGNEE_CHECK
	CHECK
	(NOT ( ASSIGNEE = NULL AND STATUS = 'IN PROGRESS'));
