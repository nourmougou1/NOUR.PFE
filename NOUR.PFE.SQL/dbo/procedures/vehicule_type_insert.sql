CREATE PROCEDURE [dbo].[vehicule_type_insert]
	@typeName varchar(100)
AS
	
BEGIN
INSERT INTO vehicule_type (type_name) VALUES (@typeName, GETDATE())
EXEC vehicule_type_insert @typeName = "Van";
EXEC vehicule_type_insert @typeName = "Pickup Truck";
EXEC vehicule_type_insert @typeName = "Truck";
EXEC vehicule_type_insert @typeName = "Bus";
EXEC vehicule_type_insert @typeName = "Limousine";
EXEC vehicule_type_insert @typeName = "Minivan";
EXEC vehicule_type_insert @typeName = "Motorcycle";

END