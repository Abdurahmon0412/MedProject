CREATE TABLE IF NOT EXISTS organization
(
    id                         serial PRIMARY KEY,

    short_name                 varchar(100) NOT NULL,
    full_name                  varchar(100) NOT NULL,
	address					   varchar(100) NOT NULL,
	pinfl					   varchar(100) NOT NULL,
	phone_number               varchar(100) NOT NULL,
    oblast_id                  integer NOT NULL REFERENCES oblast,
	region_id				   integer NOT NULL REFERENCES region,
	
    created_date               timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_user_id            integer,
    modified_date              timestamp without time zone,
    modified_user_id           integer
)

INSERT INTO organization (id, short_name, full_name, address, pinfl, phone_number, oblast_id, region_id, created_user_id)
VALUES 
    (1, 'MedTravelers', 'MedTravelers', '123 Main St, New York, USA', '12345678901234', '+1 123-456-7890', 1, 1, 1),
    (2, 'Mayo Clinic', 'Mayo Clinic', '200 1st St SW, Rochester, MN, USA', '12345678901235', '+1 507-284-2511', 2, 2, 1),
    (3, 'Cleveland Clinic', 'Cleveland Clinic', '9500 Euclid Ave, Cleveland, OH, USA', '12345678901236', '+1 800-223-2273', 3, 3, 1),
    (4, 'Johns Hopkins Hospital', 'Johns Hopkins Hospital', '1800 Orleans St, Baltimore, MD, USA', '12345678901237', '+1 410-955-5000', 4, 4, 1),
    (5, 'Massachusetts General Hospital', 'Massachusetts General Hospital', '55 Fruit St, Boston, MA, USA', '12345678901238', '+1 617-726-2000', 5, 5, 1),
    (6, 'University of Michigan Hospitals-Michigan Medicine', 'University of Michigan Hospitals-Michigan Medicine', '1500 E Medical Center Dr, Ann Arbor, MI, USA', '12345678901239', '+1 734-936-4000', 6, 6, 1),
    (7, 'Ronald Reagan UCLA Medical Center', 'Ronald Reagan UCLA Medical Center', '757 Westwood Plaza, Los Angeles, CA, USA', '12345678901240', '+1 310-825-9111', 7, 7, 1),
    (8, 'NewYork-Presbyterian Hospital-Columbia and Cornell', 'NewYork-Presbyterian Hospital-Columbia and Cornell', '525 E 68th St, New York, NY, USA', '12345678901241', '+1 212-746-5454', 8, 8, 1),
    (9, 'Stanford Health Care-Stanford Hospital', 'Stanford Health Care-Stanford Hospital', '300 Pasteur Dr, Stanford, CA, USA', '12345678901242', '+1 650-723-4000', 9, 9, 1),
    (10, 'Baptist Health South Florida', 'Baptist Health South Florida', '8900 N Kendall Dr, Miami, FL, USA', '12345678901243', '+1 786-596-1960', 10, 10, 1);