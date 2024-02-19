CREATE TABLE IF NOT EXISTS user_module
(
    id                         bigserial NOT NULL PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,
	user_name                  varchar(100) NOT NULL,
	password                   varchar(100) NOT NULL,
	password_hash              varchar(100),
	password_salt              varchar(100),
	email_address              varchar(100) NOT NULL,
	phone_number               varchar(100) NOT NULL,
	organization_id            integer NOT NULL REFERENCES organization,
	language_id                integer NOT NULL REFERENCES language,
	status_id                  integer NOT NULL REFERENCES status,
	oblast_id				   integer NOT NULL REFERENCES oblast,
	region_id				   integer NOT NULL REFERENCES region,
	role_id					   integer NOT NULL REFERENCES role,
	gender_id				   integer NOT NULL REFERENCES gender,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)