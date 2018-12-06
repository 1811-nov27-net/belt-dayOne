CREATE SCHEMA example

DROP TABLE dbo.Employee;

CREATE TABLE example.Employee
(
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	SSN VARCHAR(9) NOT NULL,
	DeptID INT NOT NULL
);

DROP TABLE dbo.Department;

CREATE TABLE example.Department
(
	ID INT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Location VARCHAR(100) NOT NULL
);

ALTER TABLE example.Employee
	ADD CONSTRAINT Pk_Employee_Id PRIMARY KEY (Id)

ALTER TABLE example.Department
	ADD CONSTRAINT Pk_Department_ID PRIMARY KEY (ID) 

ALTER TABLE example.Employee
	ADD CONSTRAINT Fk_Employee_DeptID FOREIGN KEY (DeptID) REFERENCES example.Department(ID);

CREATE TABLE example.EmpDetails
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	EmployeeID INT NOT NULL FOREIGN KEY (EmployeeID) REFERENCES example.Employee(Id),
	Salary MONEY NOT NULL,
	Address1 VARCHAR(100) NOT NULL,
	Address2 VARCHAR(100),
	City VARCHAR(100) NOT NULL,
	State VARCHAR(100) NOT NULL,
	Country VARCHAR (100) NOT NULL
);

ALTER TABLE example.EmpDetails
	ADD CONSTRAINT U_EmpDetails_EmployeeID UNIQUE (EmployeeID);

INSERT INTO example.Department(Name, Location) VALUES
	('IT', 'Houston');

INSERT INTO example.Employee(FirstName, LastName, SSN, DeptID) VALUES
	('Will', 'Belt', '000000000', 1);

SELECT * FROM example.Employee;

INSERT INTO example.EmpDetails(EmployeeID, Salary, Address1, Address2, City, State, Country) VALUES
	(2, 50000, '4727 Oakshire', 'Apt 6', 'Houston', 'Texas', 'United States');

SELECT * FROM example.Employee AS E
	INNER JOIN example.EmpDetails AS ED ON E.Id = ED.EmployeeID;

INSERT INTO example.Department(Name, Location) VALUES
	('Sales', 'Houston');

SELECT * FROM example.Department;

INSERT INTO example.Employee(FirstName, LastName, SSN, DeptID) VALUES
	('Cave', 'Johnson', '111111111', 2);

SELECT * FROM example.Employee

INSERT INTO example.EmpDetails(EmployeeID, Salary, Address1, City, State, Country) VALUES
	(3, 75000, '4651 Richmond', 'Houston', 'Texas', 'United States');

INSERT INTO example.Department(Name, Location) VALUES
	('Administration', 'Rapture');

INSERT INTO example.Employee(FirstName, LastName, SSN, DeptID) VALUES
	('Andrew', 'Ryan', '222222222', 2);

UPDATE example.Employee
	SET DeptID = 3
WHERE FirstName = 'Andrew';

INSERT INTO example.EmpDetails(EmployeeID, Salary, Address1, City, State, Country) VALUES
	(4, 100000, '1138 Atlas', 'Rapture', 'New Jersey', 'United States');

INSERT INTO example.Employee(FirstName, LastName, SSN, DeptID) VALUES
	('Tina', 'Smith', '333333333', 2);

INSERT INTO example.Department(Name, Location) VALUES
	('Marketing', 'New York')

INSERT INTO example.EmpDetails(EmployeeID, Salary, Address1, City, State, Country) VALUES
	(6, 60000, '1234 Fake', 'New York', 'New York', 'United States');

UPDATE example.Employee
	SET DeptID = 4
WHERE FirstName = 'Tina';

SELECT * FROM example.Employee WHERE DeptID = 4;

SELECT SUM(ED.Salary) FROM example.EmpDetails AS ED
	INNER JOIN example.Employee AS E ON e.Id = ED.EmployeeID
	INNER JOIN example.Department AS D ON D.ID = E.DeptID
WHERE D.Name = 'Marketing';
 
SELECT d.Name, COUNT(e.Id)
FROM example.Employee AS e
	INNER JOIN example.Department AS d ON e.DeptID = d.ID
GROUP BY (d.Name);
