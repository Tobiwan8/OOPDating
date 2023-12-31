USE [master]
GO
/****** Object:  Database [OOPDatingDB]    Script Date: 30-08-2023 17:53:07 ******/
CREATE DATABASE [OOPDatingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OOPDatingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OOPDatingDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OOPDatingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OOPDatingDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OOPDatingDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OOPDatingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OOPDatingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OOPDatingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OOPDatingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OOPDatingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OOPDatingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OOPDatingDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OOPDatingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OOPDatingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OOPDatingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OOPDatingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OOPDatingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OOPDatingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OOPDatingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OOPDatingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OOPDatingDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OOPDatingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OOPDatingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OOPDatingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OOPDatingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OOPDatingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OOPDatingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OOPDatingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OOPDatingDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OOPDatingDB] SET  MULTI_USER 
GO
ALTER DATABASE [OOPDatingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OOPDatingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OOPDatingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OOPDatingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OOPDatingDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OOPDatingDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OOPDatingDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [OOPDatingDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OOPDatingDB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chat]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SenderID] [int] NOT NULL,
	[ReceiverID] [int] NOT NULL,
	[ChatMessage] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Like]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[SenderID] [int] NOT NULL,
	[ReceiverID] [int] NOT NULL,
	[IsLiked] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SenderID] ASC,
	[ReceiverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DoB] [date] NOT NULL,
	[Gender] [nvarchar](6) NULL,
	[ProfileText] [nvarchar](500) NULL,
	[AccountID] [int] NOT NULL,
	[ZipcodeID] [nchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZipcodeCity]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZipcodeCity](
	[Zipcode] [nchar](4) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Zipcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AccountName]    Script Date: 30-08-2023 17:53:07 ******/
CREATE UNIQUE NONCLUSTERED INDEX [AccountName] ON [dbo].[Account]
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD FOREIGN KEY([ReceiverID])
REFERENCES [dbo].[Profile] ([ID])
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD FOREIGN KEY([SenderID])
REFERENCES [dbo].[Profile] ([ID])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([ReceiverID])
REFERENCES [dbo].[Profile] ([ID])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([SenderID])
REFERENCES [dbo].[Profile] ([ID])
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD FOREIGN KEY([ZipcodeID])
REFERENCES [dbo].[ZipcodeCity] ([Zipcode])
GO
/****** Object:  StoredProcedure [dbo].[usp_AddAccount]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_AddAccount] @AccountName nvarchar(50), @Password nvarchar(50)
as
insert into [Account] 
values (@AccountName, @Password)
GO
/****** Object:  StoredProcedure [dbo].[usp_AddProfile]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_AddProfile] @FirstName nvarchar(50), @LastName nvarchar(50), @DoB nvarchar(10), @Gender nvarchar(6), @ProfileText nvarchar(500), @AccountID int, @ZipcodeID nchar(4)
as
begin
	declare @ConvertedDoB date
	set @ConvertedDoB = convert(date, @DoB, 23)
	insert into [Profile]
	values (@FirstName, @LastName, @ConvertedDoB, @Gender, @ProfileText, @AccountID, @ZipcodeID)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteAccount]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteAccount] @ID int
as
delete from [Account] where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteProfile]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteProfile] @ID int
as
delete from [Profile] where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[usp_Dislike]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Dislike]
    @SenderID INT,
    @ReceiverID INT
AS
BEGIN
    Delete FROM [Like] WHERE (SenderID = @SenderID AND ReceiverID = @ReceiverID) OR (SenderID = @ReceiverID AND ReceiverID = @SenderID)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAccount]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetAccount] @AccountName nvarchar(50)
as
select * from [Account] where AccountName = @AccountName
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllAccounts]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAllAccounts]
AS
select * from [Account]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllProfiles]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAllProfiles]
AS
select * from [Profile]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllZipcodes]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAllZipcodes]
AS
select * from [ZipcodeCity]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMatchedProfiles]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetMatchedProfiles]
    @currentID INT
AS
BEGIN
    SELECT * FROM [Profile]
    LEFT JOIN [Like]
    ON [Profile].ID = [Like].SenderID or [Profile].ID = [Like].ReceiverID
    WHERE ([Like].ReceiverID = @currentID or [Like].SenderID = @currentID) and [Like].IsLiked = 1 and [Profile].ID != @currentID
END;

--exec usp_GetMatchedProfiles @currentID = 1;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProfile]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetProfile] @ID int
as
select * from [Profile] where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProfileByAccountID]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetProfileByAccountID] @ID int
as
select * from [Profile] where AccountID = @ID
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProfilesWhoLikedYou]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetProfilesWhoLikedYou]
    @ReceiverID INT
AS
BEGIN
    SELECT * FROM [Profile]
    LEFT JOIN [Like]
    ON [Profile].ID = [Like].SenderID
    WHERE [Like].ReceiverID = @ReceiverID AND [Like].IsLiked = 0
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetReceiversBySenderID]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetReceiversBySenderID]
    @SenderID INT
AS
BEGIN
    SELECT ReceiverID
    FROM [Like]
    WHERE SenderID = @SenderID

    UNION

    SELECT SenderID
    FROM [Like]
    WHERE ReceiverID = @SenderID;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSpecificChat]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetSpecificChat]
    @CurrentID INT,
    @ReceiverID INT
AS
BEGIN
    SELECT *
    FROM Chat
    WHERE 
        (@CurrentID = SenderID AND @ReceiverID = ReceiverID)
        OR
        (@CurrentID = ReceiverID AND @ReceiverID = SenderID);
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetZipcodeCity]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_GetZipcodeCity] @Zipcode nchar(4)
as
select * from [ZipcodeCity] where Zipcode = @Zipcode
GO
/****** Object:  StoredProcedure [dbo].[usp_LikeOrMatch]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_LikeOrMatch]
    @SenderID INT,
    @ReceiverID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [Like] WHERE (SenderID = @SenderID AND ReceiverID = @ReceiverID) OR (SenderID = @ReceiverID AND ReceiverID = @SenderID))
    BEGIN
        INSERT INTO [Like] (SenderID, ReceiverID, IsLiked)
        VALUES (@SenderID, @ReceiverID, 0);
    END
    ELSE
    BEGIN
        UPDATE [Like]
		SET IsLiked = 1
        WHERE (SenderID = @SenderID AND ReceiverID = @ReceiverID) OR (SenderID = @ReceiverID AND ReceiverID = @SenderID);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchProfiles]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchProfiles]
    @Name NVARCHAR(50) = NULL,
    @AgeMin INT = NULL,
    @AgeMax INT = NULL,
    @Gender NVARCHAR(6) = NULL,
    @Zipcode NCHAR(4) = NULL
AS
BEGIN
    DECLARE @query NVARCHAR(MAX);

    SET @query = 'SELECT * FROM Profile WHERE 1 = 1';

    IF @Name IS NOT NULL
    BEGIN
        SET @query = @query + ' AND (FirstName LIKE ''%' + @Name + '%'' OR LastName LIKE ''%' + @Name + '%'')';
    END

    IF @AgeMin IS NOT NULL
    BEGIN
        DECLARE @birthDateMin DATE;
        SET @birthDateMin = DATEADD(YEAR, -@AgeMin, GETDATE());
        SET @query = @query + ' AND DoB <= ''' + CONVERT(NVARCHAR, @birthDateMin, 23) + '''';
    END

    IF @AgeMax IS NOT NULL
    BEGIN
        DECLARE @birthDateMax DATE;
        SET @birthDateMax = DATEADD(YEAR, -@AgeMax - 1, GETDATE());
        SET @query = @query + ' AND DoB >= ''' + CONVERT(NVARCHAR, @birthDateMax, 23) + '''';
    END

    IF @Gender IS NOT NULL
    BEGIN
        SET @query = @query + ' AND Gender = ''' + @Gender + '''';
    END

    IF @Zipcode IS NOT NULL
    BEGIN
        SET @query = @query + ' AND ZipcodeID = ''' + @Zipcode + '''';
    END

    EXEC sp_executesql @query;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SendMessage]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SendMessage] @CurrentID int, @ReceiverID int, @Message nvarchar(500)
as
begin
insert into [Chat]
values (@CurrentID, @ReceiverID, @Message)
end;
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateAccountPw]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdateAccountPw] @ID int, @Password nvarchar(50)
as
Update [Account]
set [password] = @Password
where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateProfile]    Script Date: 30-08-2023 17:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpdateProfile] @ID int, @FirstName nvarchar(50), @LastName nvarchar(50), @DoB nvarchar(10), @Gender nvarchar(6), @ProfileText nvarchar(500), @AccountID int, @ZipcodeID nchar(4)
as
begin
	declare @ConvertedDoB date
	set @ConvertedDoB = convert(date, @DoB, 23)
	update [Profile]
	set FirstName = @FirstName, LastName = @LastName, Dob = @ConvertedDoB, Gender = @Gender, ProfileText = @ProfileText, ZipcodeID = @ZipcodeID
	where ID = @ID
end
GO
USE [master]
GO
ALTER DATABASE [OOPDatingDB] SET  READ_WRITE 
GO
