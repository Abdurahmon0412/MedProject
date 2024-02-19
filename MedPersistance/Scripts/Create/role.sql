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