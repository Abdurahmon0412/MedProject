CREATE TABLE IF NOT EXISTS examination
(
    id                         serial PRIMARY KEY,

	short_name   			   varchar(100),
	full_name   			   varchar(100),
	details      			   varchar(100),
    number                     integer,
	
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)