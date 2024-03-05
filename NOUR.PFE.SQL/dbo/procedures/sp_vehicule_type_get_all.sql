CREATE PROCEDURE [dbo].[sp_vehicule_type_get_all]
AS
BEGIN

    SELECT
         vehicule_type_id,
         ISNULL (type_name , '') AS type_name
    FROM
         [dbo].[vehicule_type]
    ORDER BY
         vehicule_type_id ASC


END
