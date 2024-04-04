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

-- Doctor jadvali
INSERT INTO doctor (first_name, last_name, doctor_info_id, department_id, user_module_id, patient_count_by_day, doctor_place_id, patient_id, created_user_id) 
VALUES 
    ('John', 'Doe', 1, 3, 20, 20, 1, NULL, 1),
    ('Jane', 'Smith', 2, 2, 20, 20, 2, NULL, 1),
    ('Michael', 'Johnson', 3, 3, 20, 20, 3, NULL, 1),
    ('Emily', 'Williams', 4, 2, 20, 20, 4, NULL, 1),
    ('David', 'Brown', 5, 2, 20, 20, 5, NULL, 1),
    ('Sarah', 'Jones', 6, 3, 20, 20, 6, NULL, 1),
    ('Christopher', 'Miller', 7, 3, 20, 20, 7, NULL, 1),
    ('Jessica', 'Davis', 8, 2, 20, 20, 8, NULL, 1),
    ('Daniel', 'Garcia', 9, 2, 20, 20, 9, NULL, 1),
    ('Amanda', 'Rodriguez', 3, 2, 20, 20, 10, NULL, 1);
select * from doctor