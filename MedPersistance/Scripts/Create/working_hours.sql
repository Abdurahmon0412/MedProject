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
-- working_hours jadvali
INSERT INTO working_hours (from_time, to_time, week_day_id, created_user_id) 
VALUES 
    ('2024-04-02 09:00:00', '2024-04-02 17:00:00', 1, 1),  -- Monday
    ('2024-04-03 09:00:00', '2024-04-03 17:00:00', 2, 1),  -- Tuesday
    ('2024-04-04 09:00:00', '2024-04-04 17:00:00', 3, 1),  -- Wednesday
    ('2024-04-05 09:00:00', '2024-04-05 17:00:00', 4, 1),  -- Thursday
    ('2024-04-06 09:00:00', '2024-04-06 17:00:00', 5, 1),  -- Friday
    ('2024-04-07 10:00:00', '2024-04-07 14:00:00', 6, 1),  -- Saturday
    ('2024-04-08 10:00:00', '2024-04-08 14:00:00', 7, 1),  -- Sunday
    (NULL, NULL, 8, 1),                                    -- Holiday
    ('2024-04-09 09:00:00', '2024-04-09 17:00:00', 9, 1),  -- Working Day
    (NULL, NULL, 10, 1);                                   -- Off Day
