  CREATE PROCEDURE [dbo].[sp_vehicule_path_insert]
	@pathLat Varchar(100)  ,
	@pathLng Varchar(100) ,
	@vehiculeId int

AS
BEGIN 
	INSERT INTO 
		dbo.[vehicule_path] (path_lat, path_lng, vehicule_id)
	VALUES (@pathLat, @pathLng,@vehiculeId )
END

