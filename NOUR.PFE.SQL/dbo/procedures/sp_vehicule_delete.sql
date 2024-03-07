CREATE PROCEDURE [dbo].[sp_vehicule_delete]
	@vehiculeId int
AS
BEGIN
	DELETE FROM dbo.[vehicule]
	WHERE @vehiculeId = vehicule_id
END




