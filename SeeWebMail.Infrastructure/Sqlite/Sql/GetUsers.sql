SELECT usr.usr_id
	, usr.usr_email
	, usr.usr_admin
	, mbx.mbx_id
	, mbx.mbx_imap_address
	, mbx.mbx_imap_port
	, mbx.mbx_smtp_address
	, mbx.mbx_smtp_port
	, mbx.mbx_smtp_ssl
	, mbx.mbx_imap_ssl
FROM users usr JOIN mailboxes mbx ON usr.mbx_id = mbx.mbx_id
WHERE usr.usr_email = @UserEmail
