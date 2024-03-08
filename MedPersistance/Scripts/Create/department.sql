CREATE TABLE IF NOT EXISTS department
(
    id                         serial PRIMARY KEY,
	
	short_name                 varchar(100) NOT NULL,
	full_name                  varchar(100) NOT NULL,
	price					   decimal,
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)