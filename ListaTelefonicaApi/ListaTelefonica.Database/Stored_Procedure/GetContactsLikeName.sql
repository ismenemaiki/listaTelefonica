CREATE PROCEDURE [dbo].[GetContactsLikeName]
	@name VARCHAR(50)
AS
	SELECT * FROM [dbo].[Contact] WHERE [Name] LIKE '%' + @name + '%' ORDER BY [Name];
RETURN 0
