CREATE TABLE IF NOT EXISTS patient
(
    id                         serial PRIMARY KEY,

	first_name   			   varchar(100),
	last_name   			   varchar(100),
	diagnose_id                integer NOT NULL REFERENCES diagnose,
	organization_id            integer NOT NULL REFERENCES organization,
	examination_id             integer NOT NULL REFERENCES examination,
	payment_id                 integer NOT NULL REFERENCES payment,
	user_module_id             bigserial NOT NULL REFERENCES user_module,
	address_id                 integer NOT NULL REFERENCES address,
	date_of_birth              timestamp without time zone,
	queue_number  			   integer,
	
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)