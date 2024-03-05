CREATE PROCEDURE [dbo].[sp_vehicule_path_update]
	@pathId int,
	@pathLat DECIMAL  ,
	@pathLng DECIMAL ,
	@vehiculeId int

AS
BEGIN
	UPDATE dbo.[vehicule_path]
	SET 
	path_id = @pathId,
	path_lat = @pathLat,
	path_lng = @pathLng,
	vehicule_id = @vehiculeId
	WHERE 
	path_id = @pathId
END


