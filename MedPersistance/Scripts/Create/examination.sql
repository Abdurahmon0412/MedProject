CREATE TABLE IF NOT EXISTS examination
(
    id                         serial PRIMARY KEY,

	short_name   			   varchar(100),
	full_name   			   varchar(100),
	details      			   varchar(100),
    number                     integer,
	
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

-- Examination jadvali
INSERT INTO examination (short_name, full_name, details, number, created_user_id) 
VALUES 
    ('ECG', 'Electrocardiogram', 'Heart examination', 1, 1),
    ('MRI', 'Magnetic Resonance Imaging', 'Detailed body scan', 2, 1),
    ('X-Ray', 'X-Ray Imaging', 'Radiological examination', 3, 1),
    ('CT Scan', 'Computed Tomography Scan', 'Detailed body imaging', 4, 1),
    ('Blood Test', 'Blood Test', 'Blood examination', 5, 1),
    ('Urine Test', 'Urine Test', 'Urine examination', 6, 1),
    ('Ultrasound', 'Ultrasound Imaging', 'Sound wave imaging', 7, 1),
    ('Endoscopy', 'Endoscopy', 'Internal organ examination', 8, 1),
    ('Colonoscopy', 'Colonoscopy', 'Colon examination', 9, 1),
    ('Biopsy', 'Biopsy', 'Tissue sample examination', 10, 1);
