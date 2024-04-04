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

INSERT INTO diagnose (short_name, full_name, medicine_id, details, created_user_id) 
VALUES 
    ('Fever', 'Fever Diagnosis', 1, 'Temperature above 38°C', 1),
    ('Cold', 'Common Cold', 2, 'Runny nose, sneezing, sore throat', 1),
    ('Headache', 'Headache Diagnosis', 3, 'Pain in head region', 1),
    ('Hypertension', 'High Blood Pressure', 4, 'Elevated blood pressure', 1),
    ('Diabetes', 'Diabetes Mellitus', 5, 'Elevated blood sugar levels', 1),
    ('Asthma', 'Asthma Diagnosis', 6, 'Breathing difficulties, wheezing', 1),
    ('Gastritis', 'Gastritis Diagnosis', 7, 'Stomach lining inflammation', 1),
    ('Anemia', 'Anemia Diagnosis', 8, 'Low red blood cell count', 1),
    ('Pneumonia', 'Pneumonia Diagnosis', 9, 'Inflammation of lung tissue', 1),
    ('UTI', 'Urinary Tract Infection', 10, 'Infection in urinary system', 1);