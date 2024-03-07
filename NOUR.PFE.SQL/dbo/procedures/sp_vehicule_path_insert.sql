CREATE PROCEDURE [dbo].[sp_vehicule_path_insert]
	@pathId int,
	@pathLat DECIMAL  ,
	@pathLng DECIMAL ,
	@vehiculeId int

AS
BEGIN 
	INSERT INTO 
		dbo.[vehicule_path] (path_id, path_lat, path_lng)
	VALUES (@pathId, @pathLat, @pathLng)
END

