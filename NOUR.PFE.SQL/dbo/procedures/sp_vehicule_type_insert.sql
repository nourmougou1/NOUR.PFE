CREATE PROCEDURE [dbo].[sp_vehicule_type_insert]
	@typeName varchar(100)
AS
	
BEGIN
INSERT INTO vehicule_type (type_name) VALUES (@typeName)


END