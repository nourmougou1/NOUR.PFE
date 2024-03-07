CREATE PROCEDURE [dbo].[sp_vehicule_insert]
	
	@vehiculeId int,
	@vehiculeImm VARCHAR(100),
	@vehiculeTypeId int,
	@brandId int,
	@vehiculeKilometrage VARCHAR(100),
	@vehiculeDocId int,
	@parcId int
AS
BEGIN
	INSERT INTO 
		dbo.[vehicule] (vehicule_id, vehicule_imm, vehicule_type_id, vehicule_brand_id, vehicule_kilometrage, document_id, parc_id)
	VALUES 
		(@vehiculeId, @vehiculeImm, @vehiculeTypeId, @vehiculeTypeId, @brandId, @vehiculeKilometrage, @vehiculeDocId, @parcId)
END


