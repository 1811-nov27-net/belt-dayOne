-- CREATE, ALTER, DROP

--CREATE DATABASE Pizza;

CREATE SCHEMA PS;
GO
--GO separates "batches"

CREATE TABLE PS.Pizza
(
	PizzaID INT NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	CrustID INT NOT NULL,
	ModifiedDate DATETIME2 NOT NULL,
	CreatorName NVARCHAR(100) 
);

-- DROP gets rid of whole tables
--DROP TABLE PS.Pizza

-- add constraints in CREATE or ALTER
ALTER TABLE PS.Pizza
	ADD CONSTRAINT PK_Pizza_PizzaID PRIMARY KEY (PizzaID);

ALTER TABLE PS.Pizza
	ADD CONSTRAINT U_Pizza_Name UNIQUE (Name);

CREATE TABLE PS.Crust
(
	CrustID INT NOT NULL PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL UNIQUE
);

ALTER TABLE PS.Pizza
	ADD CONSTRAINT FK_Pizza_Crust_CrustID FOREIGN KEY (CrustID) REFERENCES PS.Crust (CrustID);

ALTER TABLE PS.Pizza
	DROP CONSTRAINT FK_Pizza_Crust_CrustID;

ALTER TABLE PS.Pizza
	ADD CONSTRAINT FK_Pizza_Crust_CrustID FOREIGN KEY (CrustID) REFERENCES PS.Crust (CrustID)
	ON DELETE CASCADE
	ON UPDATE CASCADE;
	-- deleting a crust woud delete all pizzas that use it

	-- other constraints: DEFAULT, CHECK
	
-- ADD columns with ALTER(must be nullable or have defaults)

ALTER TABLE PS.Crust
	ADD Active BIT NOT NULL DEFAULT(1);
	
-- CHECK Constraint is for any condition on the value
ALTER TABLE PS.Pizza
	DROP CONSTRAINT CK_Pizza_DateNotInFuture;

ALTER TABLE PS.Pizza
	ADD CONSTRAINT CK_Pizza_DateNotInFuture CHECK (ModifiedDate >= (GETUTCDATE() - '00:00:01'));

INSERT INTO PS.Crust(CrustID, Name) VALUES
	(1, 'Plain');


INSERT INTO PS.Pizza (PizzaID, Name, CrustID, ModifiedDate) VALUES
	(1, 'Standard', 1, '2018-01-01');

SELECT * FROM PS.Crust;

ALTER TABLE PS.Pizza
	ADD CONSTRAINT D_Pizza_ModifieDate DEFAULT GETUTCDATE() FOR ModifiedDate;

DELETE FROM PS.Crust;

SELECT * FROM PS.Pizza;
	
INSERT INTO PS.Pizza (PizzaID, Name, CrustID) VALUES
	(1, 'Standard', 1);

SELECT * FROM PS.Pizza;

CREATE VIEW PS.ActivePizzas
AS
SELECT CrustID, Name, InternalName
FROM PS.Crust
WHERE Active = 1;

SELECT * FROM PS.Crust;

DELETE FROM PS.ActivePizzas;

DROP VIEW PS.ActivePizzas;