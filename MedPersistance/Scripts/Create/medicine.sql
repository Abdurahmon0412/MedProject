CREATE TABLE IF NOT EXISTS medicine
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,
	is_consume                 boolean NOT NULL DEFAULT false,
    how_many_times_day     	   integer,
	
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

-- Medicine jadvali
INSERT INTO medicine (short_name, full_name, is_consume, how_many_times_day, created_user_id) 
VALUES 
    ('Paracetamol', 'Paracetamol', true, 3, 1),
    ('Ibuprofen', 'Ibuprofen', true, 2, 1),
    ('Aspirin', 'Aspirin', true, 3, 1),
    ('Amlodipine', 'Amlodipine', true, 1, 1),
    ('Metformin', 'Metformin', true, 2, 1),
    ('Albuterol', 'Albuterol', true, 3, 1),
    ('Omeprazole', 'Omeprazole', true, 1, 1),
    ('Iron Supplement', 'Iron Supplement', true, 1, 1),
    ('Amoxicillin', 'Amoxicillin', true, 3, 1),
    ('Ciprofloxacin', 'Ciprofloxacin', true, 2, 1);
