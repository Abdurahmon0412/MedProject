CREATE TABLE IF NOT EXISTS doctor_info
(
    id                         serial PRIMARY KEY,

	details					   varchar(500) ,
    doctor_place_id            integer NOT NULL REFERENCES doctor_place,
    working_hours_id           integer NOT NULL REFERENCES working_hours,
	experiense_of_year         integer,
    
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)