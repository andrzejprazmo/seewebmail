SELECT usr.usr_id
	, usr.usr_email
	, mbx.mbx_id
	, mbx.mbx_imap_address
	, mbx.mbx_imap_port
	, mbx.mbx_smtp_address
	, mbx.mbx_smtp_port
	, mbx.mbx_pop3_address
	, mbx.mbx_pop3_port
	, mbx.mbx_use_ssl
FROM users usr JOIN mailboxes mbx ON usr.mbx_id = mbx.mbx_id
WHERE usr.usr_email = @UserEmail
