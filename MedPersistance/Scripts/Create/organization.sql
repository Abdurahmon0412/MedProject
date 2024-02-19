CREATE TABLE IF NOT EXISTS organization
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,
	address					   varchar(100) NOT NULL,
	pinfl					   varchar(100) NOT NULL,
	phone_number               varchar(100) NOT NULL,
    oblast_id                  integer NOT NULL REFERENCES oblast,
	region_id				   integer NOT NULL REFERENCES region,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)