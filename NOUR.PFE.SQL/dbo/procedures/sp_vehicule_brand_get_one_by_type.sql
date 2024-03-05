CREATE PROCEDURE [dbo].[sp_vehicule_brand_get_one_by_type]
    @vehiculeTypeName VARCHAR (100)
AS
BEGIN
    
    SELECT 
        vb.vehicule_brand_id,
        vt.vehicule_type_id,
        ISNULL(vb.brand_name, '') AS brand_name
    FROM 
        dbo.[vehicule_brand] vb
    INNER JOIN 
        dbo.[vehicule_type] vt ON vt.vehicule_type_id = vb.vehicule_type_id
    WHERE
        vt.type_name = @vehiculeTypeName;
END

