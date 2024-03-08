CREATE TABLE IF NOT EXISTS doctor
(
    id                         serial PRIMARY KEY,

	first_name   			   varchar(100) ,
	last_name   			   varchar(100) ,
    doctor_info_id             integer NOT NULL REFERENCES doctor_info,
    department_id              integer NOT NULL REFERENCES department,
	user_module_id             bigserial NOT NULL REFERENCES user_module,
    patient_count_by_day       integer,
	doctor_place_id            integer NOT NULL REFERENCES doctor_place,
	patient_id                 integer REFERENCES patient,
	
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)