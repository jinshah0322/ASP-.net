USE [master]
GO
/****** Object:  Database [QandA]    Script Date: 05-04-2024 19:02:59 ******/
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
/****** Object:  Table [dbo].[QuestionPapers]    Script Date: 05-04-2024 19:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionPapers](
	[QuestionPaperID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreationDate] [date] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[CreatorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionPaperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 05-04-2024 19:02:59 ******/
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
	[CorrectAnswer] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Submission]    Script Date: 05-04-2024 19:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Submission](
	[SubmissionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[QuestionPaperID] [int] NULL,
	[QuestionID] [int] NULL,
	[TickedAnswer] [nvarchar](100) NULL,
	[SubmissionDate] [datetime] NOT NULL,
	[isCorrect] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubmissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05-04-2024 19:02:59 ******/
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

INSERT [dbo].[QuestionPapers] ([QuestionPaperID], [Title], [Description], [CreationDate], [Status], [CreatorID]) VALUES (4, N'Odoo', N'One and only free erp providing platform', CAST(N'2024-03-28' AS Date), N'Approved', 4)
INSERT [dbo].[QuestionPapers] ([QuestionPaperID], [Title], [Description], [CreationDate], [Status], [CreatorID]) VALUES (5, N'Maths', N'Maths test', CAST(N'2024-04-05' AS Date), N'Draft', 8)
SET IDENTITY_INSERT [dbo].[QuestionPapers] OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionID], [QuestionPaperID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer]) VALUES (8, 4, N'Is it pythons framework?', N'yes', N'no', N'dont know', N'may be', N'yes')
INSERT [dbo].[Questions] ([QuestionID], [QuestionPaperID], [QuestionText], [OptionA], [OptionB], [OptionC], [OptionD], [CorrectAnswer]) VALUES (9, 5, N' Which of following is not sport?', N'Calling', N'Cricket', N'Football', N'Basketball', N'Calling')
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
SET IDENTITY_INSERT [dbo].[Submission] ON 

INSERT [dbo].[Submission] ([SubmissionID], [UserID], [QuestionPaperID], [QuestionID], [TickedAnswer], [SubmissionDate], [isCorrect]) VALUES (7, 1, 4, 8, N'yes', CAST(N'2024-03-28T18:24:17.093' AS DateTime), 1)
INSERT [dbo].[Submission] ([SubmissionID], [UserID], [QuestionPaperID], [QuestionID], [TickedAnswer], [SubmissionDate], [isCorrect]) VALUES (8, 7, 4, 8, N'dont know', CAST(N'2024-04-05T18:48:07.177' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Submission] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Role]) VALUES (1, N'Jinay', N'nRd45S9D8Eyz59Qr8/Z+0Q==', N'jinay@gmail.com', N'Student')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Role]) VALUES (2, N'Admin', N'tGFt8HKgkUtDigUkv+k5Fw==', N'admin@gmail.com', N'Admin')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Role]) VALUES (4, N'Vishal', N'fJYPFfJDjS8pgoWHKVtboA==', N'vishal@gmail.com', N'Teacher')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Role]) VALUES (6, N'Sanjay', N'nRd45S9D8Eyz59Qr8/Z+0Q==', N'sanjay@gmail.com', N'Student')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Role]) VALUES (7, N'Naitik', N'rqlaNEB/chYSXQu9uTYrqA==', N'naitik@gmail.com', N'Student')
INSERT [dbo].[Users] ([UserID], [Username], [Password], [Email], [Role]) VALUES (8, N'dhruv', N'RIO+CmAhYvE6uphq11iEZA==', N'dhruv@gmail.com', N'Teacher')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[QuestionPapers] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[QuestionPapers] ADD  DEFAULT ('Draft') FOR [Status]
GO
ALTER TABLE [dbo].[Submission] ADD  DEFAULT (getdate()) FOR [SubmissionDate]
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
ALTER TABLE [dbo].[Submission]  WITH CHECK ADD  CONSTRAINT [FK_Submission_Question] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([QuestionID])
GO
ALTER TABLE [dbo].[Submission] CHECK CONSTRAINT [FK_Submission_Question]
GO
ALTER TABLE [dbo].[Submission]  WITH CHECK ADD  CONSTRAINT [FK_Submission_QuestionPaper] FOREIGN KEY([QuestionPaperID])
REFERENCES [dbo].[QuestionPapers] ([QuestionPaperID])
GO
ALTER TABLE [dbo].[Submission] CHECK CONSTRAINT [FK_Submission_QuestionPaper]
GO
ALTER TABLE [dbo].[Submission]  WITH CHECK ADD  CONSTRAINT [FK_Submission_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Submission] CHECK CONSTRAINT [FK_Submission_User]
GO
USE [master]
GO
ALTER DATABASE [QandA] SET  READ_WRITE 
GO
