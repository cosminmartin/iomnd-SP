CREATE PROCEDURE SP_Offers_GetOfferByService
	(@service_code VARCHAR(256))

AS
BEGIN
	SELECT * FROM Offers 
	WHERE Service_Code = @service_code
END