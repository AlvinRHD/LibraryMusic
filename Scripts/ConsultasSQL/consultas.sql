USE Library_Music

SELECT * FROM Artists
SELECT * FROM Albums
SELECT * FROM Songs


-- eliminar datos
DELETE FROM Songs;
DELETE FROM Albums;
DELETE FROM Artists;

-- resetear a 0 las tablas
DBCC CHECKIDENT ('Artists', RESEED, 0);
DBCC CHECKIDENT ('Albums', RESEED, 0);
DBCC CHECKIDENT ('Songs', RESEED, 0);


