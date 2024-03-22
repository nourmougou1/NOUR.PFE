CREATE PROCEDURE [dbo].[sp_request_update]
	@requestId int,
	@vehiculeId int,
	@missionDescription VARCHAR(100),
	@userId int,
	@missionDate DATETIME,
	@missionLocation VARCHAR(100),
	@status BIT,
	@approvalDate DATETIME,
	@vehiculeTypeId int,
	@requestDate DATETIME
AS
BEGIN
	UPDATE 
		dbo.[request]
	SET
		request_id = @requestId,
		vehicule_id = @vehiculeId,
		mission_description = @missionDescription,
		user_id = @userId,
		mission_date = @missionDate,
		mission_address = @missionLocation,
		status = @status,
		approval_date = @approvalDate,
		vehicule_type_id = @vehiculeTypeId,
		request_date = @requestDate
	WHERE 
		request_id = @requestId
END
