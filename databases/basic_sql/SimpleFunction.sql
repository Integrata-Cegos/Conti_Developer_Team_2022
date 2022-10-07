USE publishing
DROP FUNCTION IF EXISTS SAWITZKI_CHECK
go
CREATE FUNCTION SAWITZKI_CHECK(@value INT) RETURNS VARCHAR(20) AS

BEGIN
	DECLARE @return_value as VARCHAR(20)
	if (@value >= 0) SET @return_value = 'greater or equals 0';
	if (@value < 0) SET @return_value = 'less than 0';
	return @return_value

END