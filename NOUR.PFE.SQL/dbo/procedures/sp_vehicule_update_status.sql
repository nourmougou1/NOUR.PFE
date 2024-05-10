CREATE PROCEDURE [dbo].[sp_vehicule_update_status]
	@vehiculeId int, 
	@statusId int 
AS
BEGIN
	UPDATE dbo.[vehicule]
	SET 
		vehicule_status_id = @statusId 

	WHERE 
		vehicule_id = @vehiculeId
	
END
