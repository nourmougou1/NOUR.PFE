CREATE PROCEDURE [dbo].[sp_vehicule_update]
	@vehiculeId int,
	@vehiculeImm VARCHAR(100),
	@vehiculeTypeId int,
	@brandId int,
	@vehiculeKilometrage VARCHAR(100),
	@vehiculeDocId int,
	@parcId int
AS
BEGIN
	UPDATE dbo.[vehicule]
	SET
		
		vehicule_imm = @vehiculeImm,
		vehicule_type_id = @vehiculeTypeId,
		vehicule_brand_id =@brandId,
		vehicule_kilometrage = @vehiculeKilometrage,		
		parc_id = @parcId
	WHERE 
		vehicule_id = @vehiculeId
	
END
