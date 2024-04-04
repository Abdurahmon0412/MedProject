CREATE TABLE IF NOT EXISTS payment
(
    id                         serial PRIMARY KEY,

	details					   varchar(500) NOT NULL,
    plastic_card_id            integer NOT NULL REFERENCES plastic_card,
    payment_hystory_id            integer NOT NULL REFERENCES payment_hystory,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)
-- payment jadvali
INSERT INTO payment (details, plastic_card_id, payment_hystory, created_user_id) 
VALUES 
    ('Online shopping payment', 1, 1, 1),
    ('Utility bill payment', 2, 2, 1),
    ('Dining out payment', 3, 3, 1),
    ('Travel expenses payment', 4, 4, 1),
    ('Medical bill payment', 5, 5, 1),
    ('Entertainment expenses payment', 6, 6, 1),
    ('Education fee payment', 7, 7, 1),
    ('Insurance payment', 8, 8, 1),
    ('Donation', 9, 9, 1),
    ('Loan payment', 10, 10, 1);
