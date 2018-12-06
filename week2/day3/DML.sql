SELECT * FROM SalesLT.Address

INSERT INTO SalesLT.Address VALUES
('123 Main St', NULL, 'Dallas', 'Texas', 'United States', '12345', '268AF621-76D7-4C78-9441-144FD139821B', GETUTCDATE());

INSERT INTO SalesLT.Address(AddressLine1, City, StateProvince, CountryRegion, PostalCode) VALUES
('123 Main St', 'Dallas', 'Texas', 'United States', '12345'),
(REPLACE('123 Main St', '123','456'), 'Dallas', 'Texas', 'United States', '12345');

--BULK INSERT SalesLT.Address FROM 'data.csv' WITH (FIELDTERMINATOR = ',', ROWTERMINATOR = '\n');

INSERT INTO SalesLT.Address(AddressLine1, City, StateProvince, CountryRegion, PostalCode)
	SELECT AddressLine1, City, StateProvince, CountryRegion, REVERSE(PostalCode) 
	FROM SalesLT.Address
	WHERE ModifiedDate > '2018';

SELECT AddressLine1, City, StateProvince, CountryRegion, PostalCode
	INTO #my_table 
	FROM SalesLT.Address
	WHERE ModifiedDate > '2018';

UPDATE SalesLT.Address
	SET AddressLine2 = 'Apt 45',
	PostalCode =
	(
		SELECT TOP(1) PostalCode FROM SalesLT.Address ORDER BY ModifiedDate DESC
	)
	WHERE YEAR(ModifiedDate) >= 2018;

--DELETE FROM SalesLT.Address
--WHERE ModifiedDate > '2018';

--TRUNCATE TABLE SalesLT.Address;
