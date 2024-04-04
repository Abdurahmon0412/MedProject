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

-- Plastic_card jadvali
INSERT INTO plastic_card (card_number, validate_period, balans, created_user_id) 
VALUES 
    ('1234567890123456', '2026-12-31', 1000.00, 1),
    ('2345678901234567', '2027-11-30', 1500.00, 1),
    ('3456789012345678', '2028-10-31', 2000.00, 1),
    ('4567890123456789', '2029-09-30', 2500.00, 1),
    ('5678901234567890', '2030-08-31', 3000.00, 1),
    ('6789012345678901', '2031-07-31', 3500.00, 1),
    ('7890123456789012', '2032-06-30', 4000.00, 1),
    ('8901234567890123', '2033-05-31', 4500.00, 1),
    ('9012345678901234', '2034-04-30', 5000.00, 1),
    ('0123456789012345', '2035-03-31', 5500.00, 1);
