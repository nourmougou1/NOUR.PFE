CREATE PROCEDURE [dbo].[sp_vehicule_status_update]
	@statusId int,
	@statusName VARCHAR(100)
AS
BEGIN
	UPDATE
		dbo.[Vehicule_status]
	SET
		status_name = @statusName

	WHERE 
		status_id = @statusId
END


