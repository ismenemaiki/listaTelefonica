CREATE PROCEDURE [dbo].[ListContacts]
AS
	SELECT 
		CO.Id as Id,
		CO.[Name] as [Name],
		CO.PhoneNumber as PhoneNumber,
		CA.Id as CarrierId,
		CA.[Name] as CarrierName
	FROM Contact as CO
	INNER JOIN Carrier as CA 
	ON (CO.CarrierId = CA.Id)
