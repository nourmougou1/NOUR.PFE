﻿CREATE PROCEDURE [dbo].[sp_vehicule_type_insert]
	@typeId int,
	@typeName varchar(100)
AS
	
BEGIN
INSERT INTO vehicule_type (vehicule_type_id, type_name) VALUES 
		((SELECT MAX(vehicule_type_id) FROM vehicule_type)+1, @typeName)


END