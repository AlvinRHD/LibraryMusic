USE [master]
GO
/****** Object:  Database [Library_Music]    Script Date: 19/05/2024 14:56:47 ******/
CREATE DATABASE [Library_Music]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library_Music', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Library_Music.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_Music_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Library_Music_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Library_Music] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library_Music].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library_Music] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library_Music] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library_Music] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library_Music] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library_Music] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library_Music] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Library_Music] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library_Music] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library_Music] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library_Music] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library_Music] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library_Music] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library_Music] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library_Music] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library_Music] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Library_Music] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library_Music] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library_Music] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library_Music] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library_Music] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library_Music] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library_Music] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library_Music] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library_Music] SET  MULTI_USER 
GO
ALTER DATABASE [Library_Music] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library_Music] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library_Music] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library_Music] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library_Music] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Library_Music] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Library_Music] SET QUERY_STORE = ON
GO
ALTER DATABASE [Library_Music] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Library_Music]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[ReleaseDate] [date] NULL,
	[Genre] [nvarchar](100) NULL,
	[ArtistID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [nvarchar](60) NULL,
	[RealName] [nvarchar](60) NULL,
	[RealLastName] [nvarchar](60) NULL,
	[Country] [nvarchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[SongLanguage] [nvarchar](50) NULL,
	[AlbumID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([AlbumID], [Title], [ReleaseDate], [Genre], [ArtistID]) VALUES (1, N'Heaven and Earth', CAST(N'2024-05-19' AS Date), N'Ghospel', 3)
INSERT [dbo].[Albums] ([AlbumID], [Title], [ReleaseDate], [Genre], [ArtistID]) VALUES (2, N'Bella vida', CAST(N'2024-05-19' AS Date), N'Romance', 2)
INSERT [dbo].[Albums] ([AlbumID], [Title], [ReleaseDate], [Genre], [ArtistID]) VALUES (4, N'Cease Fire', CAST(N'2024-05-19' AS Date), N'Ghospel', 2)
SET IDENTITY_INSERT [dbo].[Albums] OFF
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([ArtistID], [ArtistName], [RealName], [RealLastName], [Country]) VALUES (2, N'EvanCraft', N'Evan', N'Craft', N'Estados Unidos')
INSERT [dbo].[Artists] ([ArtistID], [ArtistName], [RealName], [RealLastName], [Country]) VALUES (3, N'Forking and Country', N'Juan', N'Hernandez', N'Estados Unidos')
SET IDENTITY_INSERT [dbo].[Artists] OFF
GO
SET IDENTITY_INSERT [dbo].[Songs] ON 

INSERT [dbo].[Songs] ([SongID], [Title], [SongLanguage], [AlbumID]) VALUES (1, N'Glorioso dia', N'Español', 1)
INSERT [dbo].[Songs] ([SongID], [Title], [SongLanguage], [AlbumID]) VALUES (2, N'What a beautiful name it is', N'Austriaco', 2)
INSERT [dbo].[Songs] ([SongID], [Title], [SongLanguage], [AlbumID]) VALUES (3, N'God only knows', N'Ingles', 1)
INSERT [dbo].[Songs] ([SongID], [Title], [SongLanguage], [AlbumID]) VALUES (4, N'God only knows', N'Ingles', 4)
INSERT [dbo].[Songs] ([SongID], [Title], [SongLanguage], [AlbumID]) VALUES (5, N'Alabare a mi Señor', N'Español', 4)
SET IDENTITY_INSERT [dbo].[Songs] OFF
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artists] ([ArtistID])
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Albums] ([AlbumID])
GO
/****** Object:  StoredProcedure [dbo].[spAlbums_Delete]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAlbums_Delete]
    @AlbumID INT
AS
BEGIN
    DELETE FROM Albums WHERE AlbumID = @AlbumID;
END
GO
/****** Object:  StoredProcedure [dbo].[spAlbums_GetAll]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAlbums_GetAll]
AS
BEGIN
    SELECT * FROM Albums;
END
GO
/****** Object:  StoredProcedure [dbo].[spAlbums_GetByID]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAlbums_GetByID]
    @AlbumID INT
AS
BEGIN
    SELECT * FROM Albums WHERE AlbumID = @AlbumID;
END
GO
/****** Object:  StoredProcedure [dbo].[spAlbums_Insert]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAlbums_Insert]
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
GO
/****** Object:  StoredProcedure [dbo].[spAlbums_Update]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAlbums_Update]
    @AlbumID INT,
    @Title NVARCHAR(200),
    @ReleaseDate DATE,
    @Genre NVARCHAR(100),
    @ArtistID INT
AS
BEGIN
    UPDATE Albums
    SET Title = @Title,
        ReleaseDate = @ReleaseDate,
        Genre = @Genre,
        ArtistID = @ArtistID
    WHERE AlbumID = @AlbumID;
END
GO
/****** Object:  StoredProcedure [dbo].[spArtist_Delete]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spArtist_Delete]
    @ArtistID INT
AS
BEGIN
    DELETE FROM Artists WHERE ArtistID = @ArtistID;
END
GO
/****** Object:  StoredProcedure [dbo].[spArtist_GetAll]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spArtist_GetAll]
AS
BEGIN
    SELECT * FROM Artists;
END
GO
/****** Object:  StoredProcedure [dbo].[spArtist_GetByID]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spArtist_GetByID]
@ArtistID INT
AS
BEGIN
    SELECT * FROM Artists WHERE ArtistID = @ArtistID;
END
GO
/****** Object:  StoredProcedure [dbo].[spArtist_Insert]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spArtist_Insert]
    @ArtistName NVARCHAR(60),
    @RealName NVARCHAR(60),
    @RealLastName NVARCHAR(60),
    @Country NVARCHAR(60)
AS
BEGIN
    INSERT INTO Artists (ArtistName, RealName, RealLastName, Country)
    VALUES (@ArtistName, @RealName, @RealLastName, @Country);
END
GO
/****** Object:  StoredProcedure [dbo].[spArtist_Update]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spArtist_Update]
    @ArtistID INT,
    @ArtistName NVARCHAR(60),
    @RealName NVARCHAR(60),
    @RealLastName NVARCHAR(60),
    @Country NVARCHAR(60)
AS
BEGIN
    UPDATE Artists
    SET ArtistName = @ArtistName,
        RealName = @RealName,
        RealLastName = @RealLastName,
        Country = @Country
    WHERE ArtistID = @ArtistID;
END
GO
/****** Object:  StoredProcedure [dbo].[spSongs_Delete]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSongs_Delete]
    @SongID INT
AS
BEGIN
    DELETE FROM Songs WHERE SongID = @SongID;
END
GO
/****** Object:  StoredProcedure [dbo].[spSongs_GetAll]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSongs_GetAll]
AS
BEGIN
    SELECT * FROM Songs;
END
GO
/****** Object:  StoredProcedure [dbo].[spSongs_GetByAlbumID]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSongs_GetByAlbumID]
    @AlbumID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Songs
    WHERE AlbumID = @AlbumID;
END
GO
/****** Object:  StoredProcedure [dbo].[spSongs_GetByID]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSongs_GetByID]
    @SongID INT
AS
BEGIN
    SELECT * FROM Songs WHERE SongID = @SongID;
END
GO
/****** Object:  StoredProcedure [dbo].[spSongs_Insert]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSongs_Insert]
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
GO
/****** Object:  StoredProcedure [dbo].[spSongs_Update]    Script Date: 19/05/2024 14:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSongs_Update]
    @SongID INT,
    @Title NVARCHAR(200),
    @SongLanguage NVARCHAR(50),
    @AlbumID INT
AS
BEGIN
    UPDATE Songs
    SET Title = @Title,
        SongLanguage = @SongLanguage,
        AlbumID = @AlbumID
    WHERE SongID = @SongID;
END
GO
USE [master]
GO
ALTER DATABASE [Library_Music] SET  READ_WRITE 
GO
