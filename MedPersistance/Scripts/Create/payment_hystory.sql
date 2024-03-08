CREATE TABLE IF NOT EXISTS payment_hystory
(
    id                         serial PRIMARY KEY,

    details                    varchar(100) NOT NULL,
    transform_time        	   timestamp without time zone,
	transform_balans		   decimal ,
	recieved_card_id           integer NOT NULL REFERENCES plastic_card,
	sent_card_id 			   integer NOT NULL REFERENCES plastic_card,
    
	created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)