CREATE PROCEDURE [dbo].[sp_vehicule_type_update]
	@typeId int,
	@typeName VARCHAR (100)
AS
BEGIN
	UPDATE
	dbo.[vehicule_type]
	SET
	vehicule_type_id = @typeId,
	type_name = @typeName
	WHERE 
	vehicule_type_id = @typeId

END


