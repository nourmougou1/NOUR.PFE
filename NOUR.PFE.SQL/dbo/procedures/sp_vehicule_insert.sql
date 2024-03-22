CREATE PROCEDURE [dbo].[sp_vehicule_insert]
	 
	@vehiculeImm VARCHAR(100),
	@vehiculeTypeId int,
	@brandId int,
	@vehiculeKilometrage VARCHAR(100), 
	@parcId int,
	@purschaseDate DATETIME,
	@statusId int
AS
BEGIN
	INSERT INTO 
		dbo.[vehicule] (vehicule_imm, vehicule_type_id, vehicule_brand_id, vehicule_kilometrage, parc_id,vehicule_status_id, purchase_date)
	VALUES 
		(@vehiculeImm,  @vehiculeTypeId, @brandId, @vehiculeKilometrage, @parcId,@statusId, GETDATE())
END


