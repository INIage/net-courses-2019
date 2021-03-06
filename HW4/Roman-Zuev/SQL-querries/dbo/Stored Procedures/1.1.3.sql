--Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года 
--(ShippedDate) не включая эту дату или которые еще не доставлены. 
--В запросе должны возвращаться только колонки OrderID (переименовать в Order Number)
--и ShippedDate (переименовать в Shipped Date). В результатах запроса возвращать для 
--колонки ShippedDate вместо значений NULL строку ‘Not Shipped’, для остальных 
--значений возвращать дату в формате по умолчанию.

CREATE PROCEDURE [1.1.3]
AS

SELECT OrderID as 'Order Number',
CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' ELSE CAST (ShippedDate AS CHAR(20)) END 'Shipped Date'
FROM Orders
WHERE ShippedDate > '1998-05-06 00:00:00.000' OR ShippedDate IS NULL
