CREATE PROCEDURE [dbo].[InsertContact]
	@name VARCHAR(MAX),
	@phone VARCHAR(20),
	@carrierId BIGINT
AS
	
	INSERT INTO [dbo].[Contact] ([Name], PhoneNumber, CarrierId)
		VALUES (@name, @phone, @carrierId)

SELECT @@IDENTITY
