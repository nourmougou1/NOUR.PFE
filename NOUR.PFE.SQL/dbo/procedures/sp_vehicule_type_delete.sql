CREATE PROCEDURE [dbo].[sp_vehicule_type_delete]
     @vehiculeTypeId int

AS
BEGIN
	DELETE FROM 
	dbo.[vehicule_type]
	WHERE vehicule_type_id = @vehiculeTypeId
END
