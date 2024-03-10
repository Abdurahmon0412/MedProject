CREATE TABLE IF NOT EXISTS role
(
    id                         serial PRIMARY KEY,

    name                       varchar(100) NOT NULL,
    roletype_id                integer NOT NULL REFERENCES "roletype",
    
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

INSERT INTO role (id, name, roletype_id, created_user_id)
VALUES 
    (1, 'Admin', 1, 1),
    (2, 'Admin', 2, 1),
    (3, 'Admin', 3, 1),
    (4, 'Admin', 4, 1),
	(5, 'Doctor', 1, 1),
    (6, 'Doctor', 2, 1),
    (7, 'Doctor', 3, 1),
    (8, 'Doctor', 4, 1),
	(9, 'Patient', 1, 1),
    (10, 'Patient', 2, 1),
    (11, 'Patient', 3, 1),
    (12, 'Patient', 4, 1);


CREATE TABLE IF NOT EXISTS verification_code
(
    id                         serial PRIMARY KEY,

    name                       varchar(100) NOT NULL,
    user_id                    integer NOT NULL REFERENCES "user_module",
    
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)