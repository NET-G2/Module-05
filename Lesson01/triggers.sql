CREATE OR ALTER TRIGGER dbo.UpdateNumberOfProducts
ON dbo.Product
AFTER INSERT, UPDATE, DELETE
AS
	BEGIN
	DECLARE @currentNumberOfProducts INT;
	DECLARE @categoryId INT;
	
	IF EXISTS (SELECT * FROM Inserted)
		BEGIN
			SELECT @categoryId = Category_Id FROM Inserted;
			SELECT @currentNumberOfProducts = Number_Of_Products FROM dbo.Category
			WHERE Id = @categoryId;

			UPDATE dbo.Category SET Number_Of_Products = @currentNumberOfProducts + 1
			WHERE Id = @categoryId;
		END;
	IF EXISTS (SELECT * FROM Deleted)
		BEGIN
			SELECT @categoryId = Category_Id FROM Deleted;
			SELECT @currentNumberOfProducts = Number_Of_Products FROM dbo.Category
			WHERE Id = @categoryId;

			UPDATE dbo.Category SET Number_Of_Products = @currentNumberOfProducts - 1
			WHERE Id = @categoryId;
		END;
END;