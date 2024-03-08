CREATE TABLE IF NOT EXISTS payment
(
    id                         serial PRIMARY KEY,

	details					   varchar(500) NOT NULL,
    plastic_card_id            integer NOT NULL REFERENCES plastic_card,
    payment_hystory            integer NOT NULL REFERENCES region,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)