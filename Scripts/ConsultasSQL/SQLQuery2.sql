USE Library_Music

SELECT * FROM Artists

DROP PROCEDURE spAlbums_Insert

CREATE PROCEDURE spAlbums_Insert
 @Title NVARCHAR(200),
    @ReleaseDate DATE,
    @Genre NVARCHAR(100),
    @ArtistID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Artists WHERE ArtistID = @ArtistID)
    BEGIN
        INSERT INTO Albums (Title, ReleaseDate, Genre, ArtistID)
        VALUES (@Title, @ReleaseDate, @Genre, @ArtistID);
	END
   ELSE
    BEGIN
        RAISERROR ('ArtistID not found in Artists table.', 16, 1);
    END
END

DROP PROCEDURE spSongs_Insert

CREATE PROCEDURE spSongs_Insert
	@Title NVARCHAR(200),
    @SongLanguage NVARCHAR(50),
    @AlbumID INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Albums WHERE AlbumID = @AlbumID)
    BEGIN
        INSERT INTO Songs (Title, SongLanguage, AlbumID)
        VALUES (@Title, @SongLanguage, @AlbumID);
    END
    ELSE
    BEGIN
        RAISERROR ('AlbumID not found in Albums table.', 16, 1);
    END
END

CREATE PROCEDURE spSongs_GetByAlbumID
    @AlbumID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Songs
    WHERE AlbumID = @AlbumID;
END
GO



