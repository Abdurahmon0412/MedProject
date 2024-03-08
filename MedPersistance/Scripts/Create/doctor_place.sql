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