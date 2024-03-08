CREATE TABLE IF NOT EXISTS working_hours
(
    id                         serial PRIMARY KEY,
	
	from_time                  timestamp without time zone,
	to_time                    timestamp without time zone,
	week_day_id                integer NOT NULL REFERENCES week_day,
	
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)