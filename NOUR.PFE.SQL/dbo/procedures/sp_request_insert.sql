CREATE PROCEDURE [dbo].[sp_request_insert]
	@vehiculeTypeId int,
	@missionDescription VARCHAR(100),
	@missionDate DATETIME,
	@missionLocation VARCHAR(100),
 	@request_date DATETIME
AS
BEGIN
	INSERT INTO 
		dbo.[request] (VehiculeTypeId,  mission_description, mission_date, mission_address)
	VALUES 
		(@vehiculeTypeId, @missionDescription, @missionDate, @missionLocation )

END

