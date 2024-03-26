CREATE PROCEDURE [dbo].[sp_vehicule_get_all]

AS
BEGIN
		SELECT 
        v.vehicule_id,
		ISNULL(v.vehicule_imm,'') AS vehicule_imm,
		ISNULL(vt.vehicule_type_id,'') AS vehicule_type_id,
		ISNULL(vt.type_name,'') AS type_name, 
        ISNULL(vb.vehicule_brand_id,'') AS vehicule_brand_id,
        ISNULL(vb.brand_name,'') AS brand_name,
	    ISNULL(vb.brand_logo,'') AS brand_logo,
        ISNULL(vs.status_id, '') AS status_id,
		ISNULL(vs.status_name, '') AS status_name,
		ISNULL(v.vehicule_kilometrage,'')AS vehicule_kilometrage,   
        ISNULL(p.parc_id,'') AS parc_id,
		ISNULL(p.parc_name,'') AS parc_name,
        ISNULL(p.parc_address,'') AS parc_address,
        ISNULL(purchase_date,'') AS purchase_date
		 
    FROM
        [dbo].[vehicule] v
		INNER JOIN [dbo].[parc] p ON p.parc_id = v.parc_id 
		INNER JOIN [dbo].[vehicule_type] vt ON vt.vehicule_type_id = v.vehicule_type_id 
		INNER JOIN [dbo].[vehicule_brand] vb ON vb.vehicule_brand_id = v.vehicule_brand_id 
		INNER JOIN [dbo].[Vehicule_status] vs ON vs.status_id = v.vehicule_status_id 
    ORDER BY 
        vehicule_id ASC
END

