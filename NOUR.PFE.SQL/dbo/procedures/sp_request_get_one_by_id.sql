--CREATE PROCEDURE [dbo].[sp_request_get_one_by_id]
--	@requestId int 

--AS
--BEGIN
--SELECT
--	    r.request_id,
--		vt.vehicu,
--		ISNULL(r.mission_date, '') AS mission_date
		
--	FROM
--		dbo.[request] r
--		INNER JOIN dbo.[vhicule_type] vt ON vt.Id = r.VehiculeTypeId
--	WHERE
--		r.request_id = @requestId

--END
