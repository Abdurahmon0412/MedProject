CREATE TABLE IF NOT EXISTS language
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,
        
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

INSERT INTO language (id,short_name, full_name, created_user_id)
VALUES 
    (1,'uz', 'Oʻzbekcha', 1),
    (2,'ru', 'Русский', 1),
    (3,'en', 'English', 1);