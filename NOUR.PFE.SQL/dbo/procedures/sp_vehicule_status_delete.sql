CREATE PROCEDURE [dbo].[sp_vehicule_status_delete]
	@statusId int
AS
BEGIN
	DELETE FROM
		dbo.[Vehicule_status]
	WHERE 
		status_id = @statusId
END


