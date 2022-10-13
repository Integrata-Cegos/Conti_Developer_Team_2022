﻿CREATE OR ALTER TRIGGER LogHistory ON ISSUES
FOR INSERT, UPDATE, DELETE
AS
DECLARE @Operation VARCHAR(15)
 
IF EXISTS (SELECT 0 FROM inserted)
BEGIN
   IF EXISTS (SELECT 0 FROM deleted)
   BEGIN 
      SELECT @Operation = 'UPDATE'
	  	  INSERT INTO HISTORY
		(ISSUE, DATA , OPERATION)
			SELECT
			I.ID, CONCAT( I.ASSIGNEE, ', ', I.DESCRIPTION, ', ' , I.STATUS, ', ', I.PRIORITY), @Operation
			FROM inserted I
   END ELSE
   BEGIN
      SELECT @Operation = 'INSERT'
	  INSERT INTO HISTORY
		(ISSUE, DATA , OPERATION)
			SELECT
			I.ID, CONCAT( I.ASSIGNEE, ', ', I.DESCRIPTION, ', ' , I.STATUS, ', ', I.PRIORITY), @Operation
			FROM Inserted I
   END
END ELSE 
BEGIN
   SELECT @Operation = 'DELETE'
END 
PRINT @Operation