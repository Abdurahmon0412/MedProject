CREATE TABLE IF NOT EXISTS roletype
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,    
        
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

INSERT INTO roletype (id, short_name, full_name, created_user_id)
VALUES 
    (1, 'view', 'View',  1),
    (2, 'edit', 'Edit',  1),
    (3, 'delete', 'Delete', 1),
    (4, 'create', 'Create', 1);