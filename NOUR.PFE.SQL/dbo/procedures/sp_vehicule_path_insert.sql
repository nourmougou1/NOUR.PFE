  CREATE PROCEDURE [dbo].[sp_vehicule_path_insert]
	@pathId int,
	@pathLat Varchar(50)  ,
	@pathLng Varchar(50) ,
	@vehiculeId int

AS
BEGIN 
	INSERT INTO 
		dbo.[vehicule_path] (path_id, path_lat, path_lng, vehicule_id)
	VALUES (@pathId, @pathLat, @pathLng,@vehiculeId )
END

