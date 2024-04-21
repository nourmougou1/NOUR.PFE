CREATE PROCEDURE [dbo].[sp_vehicule_get_one_by_id]
	@vehiculeId int
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
		vs.status_id,
		ISNULL(vs.status_name,'')AS status_name,
		ISNULL(v.vehicule_kilometrage ,'') AS vehicule_kilometrage,
		vp.parc_id,
		ISNULL(vp.parc_name,'')AS parc_name,
		ISNULL(vp.parc_address,'') AS parc_address,
		ISNULL(v.purchase_date,'') AS purchase_date
	FROM
		dbo.[vehicule] v
		INNER JOIN dbo.vehicule_brand vb ON vb.vehicule_brand_id = vb.vehicule_brand_id
		INNER JOIN dbo.vehicule_type vt ON vt.vehicule_type_id = vt.vehicule_type_id
		INNER JOIN dbo.Vehicule_status vs ON vs.status_id = vs.status_id
		INNER JOIN dbo.parc vp ON vp.parc_id  = vp.parc_id



END

/*
CREATE PROCEDURE [dbo].[sp_user_get_one_by_id]
	@userId int 

AS
BEGIN
SELECT
	    u.user_id,
		u.role_id,
		ISNULL(dr.role_code, '') AS role_code,
		ISNULL(dr.role_name, '') AS role_name,
		ISNULL(u.user_first_name, '') AS user_first_name,
		ISNULL(u.user_last_name, '') AS user_last_name,
		u.user_login,
		u.user_password,
		ISNULL(u.user_email, '') AS user_email,
		ISNULL(u.user_phone, '') AS user_phone,
		ISNULL(u.user_is_active, 0) AS user_is_active,
		ISNULL(u.user_img,'')AS user_img,
		u.user_birth_date,
		u.user_creation_date
	FROM
		dbo.[app_user] u
		INNER JOIN dbo.[user_role] dr ON dr.role_id = u.role_id
	WHERE
		u.user_id = @userId

END

*/
