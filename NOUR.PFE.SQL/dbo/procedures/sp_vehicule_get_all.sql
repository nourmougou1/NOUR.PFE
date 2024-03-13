CREATE PROCEDURE [dbo].[sp_vehicule_get_all]

AS
BEGIN
	SELECT 
        vehicule_id,
        ISNULL(vehicule_brand_id,'') AS vehicule_brand_id,
        ISNULL(vehicule_type_id,'') AS vehicule_type_id,
       
        ISNULL(vehicule_kilometrage,'')AS vehicule_kilometrage,
        ISNULL(vehicule_status, '' ) AS vehicule_status,
        ISNULL(vehicule_kilometrage,'') AS vehicule_kilometrage,
        ISNULL(vehicule_imm,'') AS vehicule_imm,
        ISNULL(purchase_date,'') AS purchase_date,
        ISNULL(parc_id,'') AS parc_id

      

        
    FROM
        [dbo].[vehicule] 
    ORDER BY 
        vehicule_id ASC
END

