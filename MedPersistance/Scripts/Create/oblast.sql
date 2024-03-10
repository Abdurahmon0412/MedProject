CREATE TABLE IF NOT EXISTS oblast
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,
        
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

// insert 
INSERT INTO oblast (id, short_name, full_name, created_user_id)
VALUES 
    (1, 'AN', 'Andijon viloyati', 1),
    (2, 'BU', 'Buxoro viloyati', 1),
    (3, 'FA', 'Fargʻona viloyati', 1),
    (4, 'JI', 'Jizzax viloyati', 1),
    (5, 'NA', 'Namangan viloyati', 1),
    (6, 'NU', 'Navoiy viloyati', 1),
    (7, 'QA', 'Qashqadaryo viloyati', 1),
    (8, 'SA', 'Samarqand viloyati', 1),
    (9, 'SI', 'Sirdaryo viloyati', 1),
    (10, 'TA', 'Toshkent viloyati', 1),
    (11, 'TK', 'Toshkent shahri', 1),
    (12, 'XO', 'Xorazm viloyati', 1),
    (13, 'QA', 'Qoraqalpogʻiston Respublikasi', 1);