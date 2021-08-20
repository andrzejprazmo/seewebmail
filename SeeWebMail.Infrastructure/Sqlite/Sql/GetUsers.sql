SELECT usr.usr_id
	, usr.usr_email
	, mbx.mbx_id
	, mbx.mbx_server
	, mbx.mbx_port
FROM users usr JOIN mailboxes mbx ON usr.mbx_id = mbx.mbx_id
WHERE usr.usr_email = @UserEmail
