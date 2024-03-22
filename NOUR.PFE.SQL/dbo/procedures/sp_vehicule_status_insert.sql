CREATE PROCEDURE [dbo].[sp_vehicule_status_insert]
	@statusId int,
	@statusName VARCHAR(100)
AS
BEGIN
	INSERT INTO
		dbo.[Vehicule_status] (status_id, status_name)
	VALUES 
		(@statusId, @statusName )

END


