-- comment

-- DON'T FORGET TO CHECK DROPDOWN!
SELECT * FROM SalesLT.Customer;
-- highlight queries to run them individually
SELECT 1;
SELECT 1+1;

SELECT CustomerID, Title, FirstName+' '+MiddleName+' '+LastName AS [Full Name], Suffix From SalesLT.Customer;

SELECT * FROM SalesLT.Product;

SELECT Name, ProductNumber, Color, ListPrice*1.0825 AS [Price After Tax], ListPrice - StandardCost AS [Profit Margin] FROM SalesLT.Product;

SELECT DISTINCT ProductID, Color, Size FROM SalesLT.Product;

SELECT p.Color, p.Size FROM SalesLT.Product AS p;

SELECT * FROM SalesLT.Customer WHERE FirstName = 'Brian';

SELECT * FROM SalesLT.Customer WHERE FirstName = 'Brian' AND LastName = 'Goldstein';

SELECT * FROM SalesLT.Customer WHERE FirstName = 'Brian' AND LastName <> 'Goldstein';

SELECT * FROM SalesLT.Customer WHERE FirstName >= 'B' AND FirstName < 'C';

SELECT * FROM SalesLT.Customer WHERE FirstName LIKE 'B%';

SELECT * FROM SalesLT.Customer WHERE FirstName LIKE 'B[ar]%';
-- [abc]% == a, b, or c

SELECT LEFT('123456789', 4);
SELECT RIGHT('123456789', 4);
SELECT LEN('123456789');
SELECT SUBSTRING('123456789', 3, 5); -- (string, start index, length of substring)
--indices are 1 based
SELECT REPLACE('Hello World', 'World', 'Will');
SELECT CHARINDEX(' ', 'Hello World');

-- data types
-- numeric: tinyint, smallint, int, bigint
-- float, real, decimal (use decimal almost always)
-- decimal(10, 3) 10 digits, three after the decimal: 0000000.000
-- money type for currency

-- string: CHAR(10), VARCHAR(10),
-- NCHAR(10)(national a.k.a. unicode), NVARCHAR(10)(Use NVARCHAR all the time)
-- VARCHARS can take MAX as parameter NVARCHAR(MAX) 

-- string literals '' are VARCHAR
-- unicode string literals: N'Hello'

-- BINARY type & VARBINARY

SELECT * FROM SalesLT.Product;

-- date and time types
-- DEAT, TIME, DATETIME
-- Dont use DATETIME, use DATETIME2
-- DATETIMEOFFSET (for intervals e.g. "5 minutes")

SELECT FirstName, COUNT(FirstName) AS Count FROM SalesLT.Customer GROUP BY FirstName; 

-- WHERE takes precedence over GROUP BY, HAVING runs after GROUP BY

SELECT FirstName, COUNT(FirstName) AS Count FROM SalesLT.Customer WHERE COUNT(FirstName) > 1 GROUP BY FirstName; 

SELECT FirstName, COUNT(FirstName) AS Count FROM SalesLT.Customer GROUP BY FirstName HAVING COUNT(FirstName) > 1;

SELECT FirstName, COUNT(FirstName) AS Count FROM SalesLT.Customer WHERE FirstName != 'Andrew' GROUP BY FirstName HAVING COUNT(FirstName) > 1;

SELECT * FROM SalesLT.Product ORDER BY StandardCost;

SELECT * FROM SalesLT.Product ORDER BY StandardCost DESC;

SELECT * FROM SalesLT.Product ORDER BY Color, StandardCost DESC; -- ORDER BY Color, then by Cost

-- execution order of SELECT: FROM, WHERE, GROUP BY, HAVING, ORDER BY, SELECT