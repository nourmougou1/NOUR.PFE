CREATE PROCEDURE [dbo].[sp_request_insert]
	@userId int,
	@vehiculeTypeId int,
	@missionDescription VARCHAR(100),
	@missionDate DATETIME,
	@missionLocation VARCHAR(100)
	
AS
BEGIN
	INSERT INTO 
		dbo.[request] (VehiculeTypeId,  mission_description, mission_date, mission_address, user_id)
	VALUES 
		(@vehiculeTypeId, @missionDescription, @missionDate, @missionLocation, @userId )

END
