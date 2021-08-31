SELECT mbx.mbx_id 
	, mbx.mbx_domain_name 	
	, mbx.mbx_imap_address
	, mbx.mbx_imap_port
	, mbx.mbx_smtp_address
	, mbx.mbx_smtp_port
	, mbx.mbx_smtp_ssl
	, mbx.mbx_imap_ssl
FROM mailboxes mbx
WHERE mbx.mbx_domain_name = @DomainName
