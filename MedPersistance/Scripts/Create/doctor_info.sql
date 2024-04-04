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

-- Doctor_info jadvali
INSERT INTO doctor_info (details, doctor_place_id, working_hours_id, experiense_of_year, created_user_id) 
VALUES 
    ('Specializes in cardiology.', 1, 1, 5, 1),
    ('Expertise in pediatrics.', 2, 2, 8, 1),
    ('Focused on dermatology.', 3, 3, 6, 1),
    ('Specializes in neurology.', 4, 4, 10, 1),
    ('Expertise in oncology.', 5, 5, 12, 1),
    ('Focused on pulmonology.', 6, 6, 7, 1),
    ('Specializes in gastroenterology.', 7, 7, 9, 1),
    ('Expertise in hematology.', 8, 8, 11, 1),
    ('Focused on infectious diseases.', 9, 9, 6, 1),
    ('Specializes in endocrinology.', 10, 10, 8, 1);
