SELECT * FROM SalesLT.Customer;
SELECT * FROM SalesLT.CustomerAddress;
SELECT * FROM SalesLT.Address;

Select c.FirstName, c.LastName, a.AddressLine1, a.AddressLine2, a.City, a.StateProvince 
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.CustomerAddress as ca ON c.CustomerID = ca.CustomerID
	INNER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID
WHERE a.City = 'Houston' AND a.StateProvince = 'Texas';
-- find all customers with multiple addresses
SELECT FirstName, LastName, COUNT(ca.AddressID) AS [Address Count]
FROM SalesLT.Customer AS c 
	INNER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
GROUP BY c.CustomerID, c.FirstName, c.LastName
HAVING COUNT(ca.AddressID) > 1;
-- find all customers (even those with no address) and all address (even those with no customer)
Select c.FirstName, c.LastName, a.AddressLine1, a.AddressLine2, a.City, a.StateProvince 
FROM SalesLT.Customer AS c
	FULL OUTER JOIN SalesLT.CustomerAddress as ca ON c.CustomerID = ca.CustomerID
	FULL OUTER JOIN SalesLT.Address AS a ON ca.AddressID = a.AddressID;

SELECT FirstName, LastName
FROM SalesLT.Customer
WHERE CustomerID IN
	(
	SELECT CustomerID
	FROM SalesLT.CustomerAddress
	WHERE AddressID IN
		(
		SELECT AddressID 
		FROM SalesLT.Address
		WHERE City = 'Houston' AND StateProvince = 'Texas'
		)
	);

SELECT DISTINCT c.FirstName
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.Customer AS a ON c.FirstName = a.LastName;

--UNION, INTERSECT, EXCEPT combine SELECT statements

SELECT FirstName
FROM SalesLT.Customer
WHERE FirstName LIKE 'A%'
UNION
SELECT LastName
FROM SalesLT.Customer
WHERE LastName Like 'A%';

-- all set opereations remove duplicates
-- UNION ALL, INTERSECT ALL, EXCEPT ALL

SELECT FirstName
FROM SalesLT.Customer
WHERE FirstName LIKE 'A%'
UNION ALL
SELECT LastName
FROM SalesLT.Customer
WHERE LastName Like 'A%';

-- INTERSECT gives record in BOTH sets
-- EXCEPT gives all records in first but not second

SELECT FirstName
FROM SalesLT.Customer
INTERSECT
SELECT LastName
FROM SalesLT.Customer;

-- NULL == empty cell
-- all comparisons to NULL are false, even NULL == NULL
-- use IS NULL

-- COALESCE takes a list , returns list with all NULLs converted to something else

SELECT CustomerID, Title, 
	Coalesce(FirstName,' ')+' ' +COALESCE(MiddleName,' ')+' '+COALESCe(LastName,' ') AS [Full Name], Suffix 
From SalesLT.Customer;