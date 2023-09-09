USE [Supermarket]
GO

CREATE TABLE dbo.Category (
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	Category_Name VARCHAR(255) NOT NULL);

INSERT INTO dbo.Category (Category_Name) VALUES ('Drinks');
INSERT INTO dbo.Category (Category_Name) VALUES ('Chocolate');
INSERT INTO dbo.Category (Category_Name) VALUES ('Snakes');
INSERT INTO dbo.Category (Category_Name) VALUES ('Fruits');

ALTER TABLE dbo.Product  ADD Category_Id INT NOT NULL DEFAULT (1);
ALTER TABLE dbo.Product ADD CONSTRAINT FK_Category_Id FOREIGN KEY (Category_Id)
	REFERENCES dbo.Category (Id);

ALTER TABLE dbo.Category ADD Number_Of_Products INT NOT NULL DEFAULT(0);