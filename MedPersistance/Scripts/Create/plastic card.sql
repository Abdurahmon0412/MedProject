CREATE TABLE IF NOT EXISTS plastic_card
(
    id                         serial PRIMARY KEY,

    card_number                varchar(100) NOT NULL,
    validate_period        	   timestamp without time zone,
	balans					   decimal ,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)