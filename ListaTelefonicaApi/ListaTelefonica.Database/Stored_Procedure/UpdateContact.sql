CREATE PROCEDURE [dbo].[_UpdateContact]
	@id BIGINT,
	@name VARCHAR(MAX),
	@phone VARCHAR(20),
	@carrierId BIGINT
AS
	UPDATE [dbo].[Contact] 
	
SET [Name] = @name,
	PhoneNumber = @phone,
	CarrierId = @carrierId

WHERE id = @id;