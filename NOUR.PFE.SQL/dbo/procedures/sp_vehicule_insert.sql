CREATE PROCEDURE [dbo].[sp_vehicule_insert]
	 
	@vehiculeImm VARCHAR(100),
	@vehiculeTypeId int,
	@brandId int,
	@vehiculeKilometrage VARCHAR(100), 
	@purschaseDate DATETIME,
	@statusId int
AS
BEGIN
	INSERT INTO 
		dbo.[vehicule] (vehicule_imm, vehicule_type_id, vehicule_brand_id, vehicule_kilometrage, purchase_date, vehicule_status_id)
	VALUES 
		(@vehiculeImm,  @vehiculeTypeId, @brandId, @vehiculeKilometrage, @purschaseDate, @statusId)
END


