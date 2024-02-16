USE [master]
GO
/****** Object:  Database [QandA]    Script Date: 16-02-2024 19:31:44 ******/
CREATE DATABASE [QandA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QandA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QandA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QandA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QandA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QandA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QandA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QandA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QandA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QandA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QandA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QandA] SET ARITHABORT OFF 
GO
ALTER DATABASE [QandA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QandA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QandA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QandA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QandA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QandA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QandA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QandA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QandA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QandA] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QandA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QandA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QandA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QandA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QandA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QandA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QandA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QandA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QandA] SET  MULTI_USER 
GO
ALTER DATABASE [QandA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QandA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QandA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QandA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QandA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QandA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QandA] SET QUERY_STORE = OFF
GO
USE [QandA]
GO
/****** Object:  Table [dbo].[QuestionPapers]    Script Date: 16-02-2024 19:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionPapers](
	[QuestionPaperID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreatorID] [int] NULL,
	[Status] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionPaperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 16-02-2024 19:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionPaperID] [int] NULL,
	[QuestionText] [nvarchar](max) NOT NULL,
	[OptionA] [nvarchar](max) NULL,
	[OptionB] [nvarchar](max) NULL,
	[OptionC] [nvarchar](max) NULL,
	[OptionD] [nvarchar](max) NULL,
	[CorrectAnswer] [nvarchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16-02-2024 19:31:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[QuestionPapers] ON 

INSERT [dbo].[QuestionPapers] ([QuestionPaperID], [Title], [Description], [CreationDate], [CreatorID], [Status]) VALUES (14, N'Mathematics Quiz', N'A quiz covering various topics in mathematics.', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 6, N'Pending')
INSERT [dbo].[QuestionPapers] ([QuestionPaperID], [Title], [Description], [CreationDate], [CreatorID], [Status]) VALUES (15, N'dfgdfg', N'sdfgfgd', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 6, N'Pending')
INSERT [dbo].[QuestionPapers] ([QuestionPaperID], [Title], [Description], [CreationDate], [CreatorID], [Status]) VALUES (16, N'asdfasdf', N'asdfasdfasdfasd', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 6, N'Pending')
INSERT [dbo].[QuestionPapers] ([QuestionPaperID], [Title], [Description], [CreationDate], [CreatorID], [Status]) VALUES (18, N'qwerty', N'qwerty', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 6, N'Pending')
INSERT [dbo].[QuestionPapers] ([QuestionPaperID], [Title], [Description], [CreationDate], [CreatorID], [Status]) VALUES (19, N'ghfghfgh', N'fghfgh', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 6, N'Pending')
INSERT [dbo].[QuestionPapers] ([QuestionPaperID], [Title], [Description], [CreationDate], [CreatorID], [Status]) VALUES (22, N'sdadfgdfhfgh', N'dfghdfghdfgh', CAST(N'2024-02-16T00:00:00.000' AS DateTime), 6, N'Pending')
SET IDENTITY_INSERT [dbo].[QuestionPapers] OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionID], [QuestionPaperID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer]) VALUES (1, 18, N'Question 1', N'A', N'B', N'C', N'D', N'D')
INSERT [dbo].[Questions] ([QuestionID], [QuestionPaperID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer]) VALUES (2, 19, N'Question 1', N'A', N'B', N'C', N'D', N'D')
INSERT [dbo].[Questions] ([QuestionID], [QuestionPaperID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer]) VALUES (3, 19, N'Question 2', N'A', N'B', N'C', N'D', N'D')
INSERT [dbo].[Questions] ([QuestionID], [QuestionPaperID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer]) VALUES (5, 22, N'Question 1', N'A', N'B', N'C', N'D', N'D')
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Role]) VALUES (5, N'student1', N'nRd45S9D8Eyz59Qr8/Z+0Q==', N'student1@example.com', N'Student')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Role]) VALUES (6, N'teacher1', N'fJYPFfJDjS8pgoWHKVtboA==', N'teacher1@example.com', N'Teacher')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D1053486267D0C]    Script Date: 16-02-2024 19:31:45 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[QuestionPapers] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[QuestionPapers] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[QuestionPapers]  WITH CHECK ADD  CONSTRAINT [FK_QuestionPaper_Creator] FOREIGN KEY([CreatorID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[QuestionPapers] CHECK CONSTRAINT [FK_QuestionPaper_Creator]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionPaper] FOREIGN KEY([QuestionPaperID])
REFERENCES [dbo].[QuestionPapers] ([QuestionPaperID])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Question_QuestionPaper]
GO
USE [master]
GO
ALTER DATABASE [QandA] SET  READ_WRITE 
GO
