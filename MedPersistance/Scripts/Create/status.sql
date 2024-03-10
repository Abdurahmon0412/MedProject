CREATE TABLE IF NOT EXISTS status
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,    
    details                    varchar(500),
        
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

INSERT INTO status (id, short_name, full_name, details, created_user_id)
VALUES 
    (1, 'active', 'Active', 'This status indicates an active state.', 1),
    (2, 'inactive', 'Inactive', 'This status indicates an inactive state.', 1),
    (3, 'pending', 'Pending', 'This status indicates a pending state.', 1),
    (4, 'completed', 'Completed', 'This status indicates a completed state.', 1),
    (5, 'cancelled', 'Cancelled', 'This status indicates a cancelled state.', 1);