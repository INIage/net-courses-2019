CREATE PROCEDURE [dbo].[131OrdersQuantity]
AS
	SELECT DISTINCT OrderID
FROM [Order Details]
WHERE Quantity BETWEEN 3 AND 10