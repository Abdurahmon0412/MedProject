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

-- Payment_history jadvali
INSERT INTO payment_hystory (details, transform_time, transform_balans, recieved_card_id, sent_card_id, created_user_id) 
VALUES 
    ('Payment for groceries', '2024-04-01 10:15:00', 50.00, 1, 2, 1),
    ('Online purchase', '2024-04-02 14:30:00', 100.00, 2, 3, 1),
    ('Utility bill payment', '2024-04-03 09:45:00', 75.00, 3, 4, 1),
    ('Restaurant bill payment', '2024-04-04 19:00:00', 40.00, 4, 5, 1),
    ('Fuel purchase', '2024-04-05 12:00:00', 30.00, 5, 6, 1),
    ('Shopping', '2024-04-06 15:45:00', 80.00, 6, 7, 1),
    ('Payment for subscription', '2024-04-07 11:20:00', 25.00, 7, 8, 1),
    ('Medical bill payment', '2024-04-08 16:10:00', 120.00, 8, 9, 1),
    ('Entertainment expenses', '2024-04-09 13:05:00', 60.00, 9, 10, 1),
    ('Donation', '2024-04-10 18:30:00', 20.00, 10, 1, 1);
