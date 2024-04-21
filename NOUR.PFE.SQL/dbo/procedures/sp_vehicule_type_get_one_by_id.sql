CREATE PROCEDURE [dbo].[sp_vehicule_type_get_one_by_id]
	@typeId int
AS
BEGIN
	SELECT 
		vehicule_type.vehicule_type_id,
		ISNULL(vehicule_type.type_name,'') AS type_name
	FROM
		dbo.[vehicule_type]
	WHERE
		vehicule_type.vehicule_type_id = @typeId
		
END

