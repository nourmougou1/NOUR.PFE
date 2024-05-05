CREATE PROCEDURE [dbo].[sp_request_update]
	@requestId int,
	@vehiculeTypeId int,
	@missionDescription VARCHAR(100),
	@userId int,
	@missionDate DATETIME,
	@missionAddress VARCHAR(100),
	@statusId int,
	@vehiculeId int
AS
BEGIN
	UPDATE 
		dbo.[request]
	SET
		
		VehiculeTypeId = @vehiculeTypeId,
		mission_description = @missionDescription,
		user_id = @userId,
		mission_date = @missionDate,
		mission_address = @missionAddress,
		status_id = @statusId,
		VehiculeId = @vehiculeId
		
	WHERE 
		request_id = @requestId
END