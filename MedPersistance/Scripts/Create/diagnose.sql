CREATE TABLE IF NOT EXISTS diagnose
(
    id                         serial PRIMARY KEY,

	short_name   			   varchar(100),
	full_name   			   varchar(100),
	medicine_id                integer NOT NULL REFERENCES medicine,
	details      			   varchar(100),
	
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)