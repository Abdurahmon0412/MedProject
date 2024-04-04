CREATE TABLE IF NOT EXISTS doctor_place
(
    id                         serial PRIMARY KEY,
	
	floor                      integer,
    room_number                integer,
    room_name                  varchar(100) NOT NULL,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)


-- Doctor_place jadvali
INSERT INTO doctor_place (floor, room_number, room_name, created_user_id) 
VALUES 
    (1, 101, 'Exam Room 1', 1),
    (1, 102, 'Exam Room 2', 1),
    (2, 201, 'Consultation Room 1', 1),
    (2, 202, 'Consultation Room 2', 1),
    (3, 301, 'Treatment Room 1', 1),
    (3, 302, 'Treatment Room 2', 1),
    (4, 401, 'Procedure Room 1', 1),
    (4, 402, 'Procedure Room 2', 1),
    (5, 501, 'Waiting Area', 1),
    (5, 502, 'Reception', 1);
