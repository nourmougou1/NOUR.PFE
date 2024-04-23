CREATE PROCEDURE [dbo].[sp_request_update]
	@requestId int,
	@vehiculeTypeId int,
	@missionDescription VARCHAR(100),
	@userId int,
	@missionDate DATETIME,
	@missionAddress VARCHAR(100),
	@status BIT,
	@approvalDate DATETIME
AS
BEGIN
	UPDATE 
		dbo.[request]
	SET
		request_id = @requestId,
		VehiculeTypeId = @vehiculeTypeId,
		mission_description = @missionDescription,
		user_id = @userId,
		mission_date = @missionDate,
		mission_address = @missionAddress,
		request_status = @status,
		approval_date = @approvalDate
	WHERE 
		request_id = @requestId
END
