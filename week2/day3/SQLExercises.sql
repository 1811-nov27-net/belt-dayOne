SELECT FirstName, EmailAddress
FROM SalesLT.Customer
WHERE CompanyName = 'Bike World';

SELECT CompanyName
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.CustomerAddress AS ca ON c.CustomerID = ca.CustomerID
	INNER JOIN SalesLT.Address AS a ON a.AddressID = ca.AddressID
WHERE a.City = 'Dallas'; 

SELECT SUM(OrderQty)
FROM SalesLT.SalesOrderDetail AS o
	INNER JOIN SalesLT.Product AS p ON p.ProductID = o.ProductID
WHERE p.ListPrice > 1000;

SELECT CompanyName
FROM SalesLT.Customer AS c
	LEFT JOIN SalesLT.SalesOrderHeader AS o ON c.CustomerID = o.CustomerID
WHERE TotalDue > 100000;

SELECT SUM(OrderQty)
FROM SalesLT.Product AS p
	INNER JOIN SalesLT.SalesOrderDetail AS od ON p.ProductID = od.ProductID
	INNER JOIN SalesLT.SalesOrderHeader AS oh ON oh.SalesOrderID = od.SalesOrderID
	INNER JOIN SalesLT.Customer AS c ON oh.CustomerID = c.CustomerID
WHERE c.CompanyName = 'Riding Cycles' AND p.Name = 'Racing Socks, L';

SELECT SalesOrderID, UnitPrice
FROM SalesLT.SalesOrderDetail
WHERE OrderQty = 1

SELECT * FROM SalesLT.ProductModel

SELECT p.Name, c.CompanyName
FROM SalesLT.Customer AS c
	INNER JOIN SalesLT.SalesOrderHeader AS soh ON c.CustomerID = soh.CustomerID
	INNER JOIN SalesLT.SalesOrderDetail AS sod ON sod.SalesOrderID = soh.SalesOrderID
	INNER JOIN SalesLT.Product AS p ON sod.ProductID = p.ProductID
	INNER JOIN SalesLT.ProductModel AS pm ON p.ProductModelID = pm.ProductModelID
WHERE pm.Name = 'Racing Socks';

SELECT pd.Description
FROM SalesLT.ProductModelProductDescription AS pmpd
	INNER JOIN SalesLT.ProductDescription AS pd ON pd.ProductDescriptionID = pmpd.ProductDescriptionID
	INNER JOIN SalesLT.Product AS p ON p.ProductModelID = pmpd.ProductModelID
WHERE p.ProductID = 736 AND pmpd.Culture = 'fr'

SELECT c.CompanyName, soh.SubTotal, p.Weight
FROM SalesLT.SalesOrderHeader AS soh
	INNER JOIN SalesLT.SalesOrderDetail AS sod ON sod.SalesOrderID = soh.SalesOrderID
	INNER JOIN SalesLT.Customer AS c ON soh.CustomerID = c.CustomerID
	INNER JOIN SalesLT.Product AS p ON p.ProductID = sod.ProductID
ORDER BY soh.SubTotal DESC

SELECT a.AddressLine1 AS [Main Office Address] 
FROM SalesLT.CustomerAddress AS ca
	INNER JOIN SalesLT.Address AS a ON a.AddressID = ca.AddressID
WHERE a.City = 'Dallas' AND ca.AddressType = 'Main Office'
UNION
SELECT a.AddressLine1 AS [Shipping Address] 
FROM SalesLT.CustomerAddress AS ca
	INNER JOIN SalesLT.Address AS a ON a.AddressID = ca.AddressID
WHERE a.City = 'Dallas' AND ca.AddressType = 'Shipping'