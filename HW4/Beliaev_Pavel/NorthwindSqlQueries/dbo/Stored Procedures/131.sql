CREATE PROCEDURE [dbo].[131]
AS
	SELECT DISTINCT OrderID
	FROM [Order Details]
	WHERE Quantity BETWEEN 3 AND 10
RETURN 0
