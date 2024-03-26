CREATE PROCEDURE [dbo].[sp_vehicule_update]
	@vehiculeId int,
	@vehiculeImm VARCHAR(100),
	@vehiculeTypeId int,
	@brandId int,
	@vehiculeKilometrage VARCHAR(100), 
	@statusId int ,
	@purschaseDate DateTime
AS
BEGIN
	UPDATE dbo.[vehicule]
	SET
		vehicule_imm = @vehiculeImm,
		vehicule_type_id = @vehiculeTypeId,
		vehicule_brand_id = @brandId,
		vehicule_kilometrage = @vehiculeKilometrage ,
		vehicule_status_id = @statusId,
		purchase_date = @purschaseDate 

	WHERE 
		vehicule_id = @vehiculeId
	
END
