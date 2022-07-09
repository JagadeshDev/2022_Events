CREATE PROCEDURE Get_Customers_By_Id @Id Varchar(50)
AS
SELECT * FROM Customer WHERE CustomerId = @Id
GO

exec Get_Customers_By_Id "C001"