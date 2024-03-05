CREATE PROCEDURE [dbo].[sp_vehicule_path_get_one_by_vehicule_id]
	@vehiculeId int
AS
BEGIN
	SELECT 
	v.vehicule_id,
	ISNULL(vp.path_id, '' ) AS path_id ,
	ISNULL(vp.path_lat, '' ) AS path_let
	FROM
	dbo.[vehicule_path] vp
	INNER JOIN dbo.[vehicule] v ON v.vehicule_id= vp.vehicule_id
	WHERE 
	v.vehicule_id = @vehiculeId
END


