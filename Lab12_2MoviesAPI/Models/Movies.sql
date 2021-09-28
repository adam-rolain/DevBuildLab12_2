CREATE DATABASE movies;

USE movies;

CREATE TABLE movie (
	id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(50) NOT NULL,
    category VARCHAR(5) NOT NULL,
    PRIMARY KEY (id)
);

INSERT INTO movie (name, category) VALUES ('Inception', 'SCIFI');
INSERT INTO movie (name, category) VALUES ('Black Widow', 'SCIFI');
INSERT INTO movie (name, category) VALUES ('Venom', 'SCIFI');
INSERT INTO movie (name, category) VALUES ('Harry Potter', 'FANT');
INSERT INTO movie (name, category) VALUES ('Jungle Cruise', 'FANT');
INSERT INTO movie (name, category) VALUES ('Cinderella', 'FANT');
INSERT INTO movie (name, category) VALUES ('King\'s Speech', 'HIST');
INSERT INTO movie (name, category) VALUES ('42', 'HIST');
INSERT INTO movie (name, category) VALUES ('Dunkirk', 'HIST');
INSERT INTO movie (name, category) VALUES ('Finding Nemo', 'ANIM');
INSERT INTO movie (name, category) VALUES ('Toy Story', 'ANIM');
INSERT INTO movie (name, category) VALUES ('Lion King', 'ANIM');