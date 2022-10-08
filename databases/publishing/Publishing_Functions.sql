use publishing 
DROP FUNCTION IF EXISTS CATEGORIZE_PRICE
GO
CREATE FUNCTION CATEGORIZE_PRICE(@price FLOAT) RETURNS VARCHAR(20) AS

BEGIN
	DECLARE @return_value as VARCHAR(20)
	if (@price >= 10) SET @return_value = 'expensive';
	if (@price < 10) SET @return_value = 'cheap';
	return @return_value

END
