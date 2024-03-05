CREATE PROCEDURE [dbo].[sp_request_delete]
	@requestId int
AS
BEGIN
	DELETE FROM dbo.[request]
	WHERE request_id = @requestId
END


