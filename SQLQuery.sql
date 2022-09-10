USE db_3

CREATE TABLE Users( 
	Id		VARCHAR(255) NOT NULL UNIQUE, 
	[Name]	VARCHAR(255) NOT NULL, 
	Email	VARCHAR(255) NOT NULL,
	PWD		VARCHAR(255) NOT NULL
	)

INSERT INTO Users Values('eda2b5b5-5894-4c25-9688-b00495739295', 'Administrador', 'admin@email.com', 'admin123')

