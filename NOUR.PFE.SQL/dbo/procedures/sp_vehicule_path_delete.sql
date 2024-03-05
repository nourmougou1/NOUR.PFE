CREATE PROCEDURE [dbo].[sp_vehicule_path_delete]
	@vehiculePathId int
AS
BEGIN
	DELETE FROM dbo.[vehicule_path]
	WHERE path_id = @vehiculePathId

END

