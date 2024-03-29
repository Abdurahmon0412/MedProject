CREATE TABLE IF NOT EXISTS gender
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

INSERT INTO gender (id, short_name, full_name, created_user_id)
VALUES 
    (1,'Male', 'Male', 1),
    (2,'Female', 'Female', 1);
