CREATE PROCEDURE [dbo].[sp_request_insert]
	@requestId int,
	@vehiculeId int,
	@missionDescription VARCHAR(100),
	@userId int,
	@missionDate DATETIME,
	@missionLocation VARCHAR(100),
	@status BIT,
	@approvalDate DATETIME,
	@vehiculeTypeId int,
	@request_date DATETIME
AS
BEGIN
	INSERT INTO 
		dbo.[request] (request_id, vehicule_id, mission_description, user_id, mission_date, mission_location,
		status, vehicule_type_id, request_date)
	VALUES 
		(@requestId, @vehiculeId, @missionDescription,@userId, @missionDate, @missionLocation, @status,
		 @vehiculeTypeId, GETDATE())

END

