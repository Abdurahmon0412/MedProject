CREATE TABLE IF NOT EXISTS week_day
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)


-- Week_day jadvali
INSERT INTO week_day (short_name, full_name, created_user_id) 
VALUES 
    ('Mon', 'Monday', 1),
    ('Tue', 'Tuesday', 1),
    ('Wed', 'Wednesday', 1),
    ('Thu', 'Thursday', 1),
    ('Fri', 'Friday', 1),
    ('Sat', 'Saturday', 1),
    ('Sun', 'Sunday', 1),
    ('Hol', 'Holiday', 1),
    ('WD', 'Working Day', 1),
    ('Off', 'Off Day', 1);
