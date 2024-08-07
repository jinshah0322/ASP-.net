USE [master]
GO
/****** Object:  Database [EmployeeDB]    Script Date: 08-02-2024 18:34:04 ******/
CREATE DATABASE [EmployeeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EmployeeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EmployeeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmployeeDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeDB] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EmployeeDB] SET QUERY_STORE = OFF
GO
USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[City]    Script Date: 08-02-2024 18:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[StateID] [int] NULL,
	[CityName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 08-02-2024 18:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[DepartmentHead] [varchar](50) NOT NULL,
	[Budget] [decimal](15, 2) NULL,
	[CreationDate] [date] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeProject]    Script Date: 08-02-2024 18:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProject](
	[EPID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[ProjectID] [int] NULL,
	[AssignmentDate] [datetime] NULL,
	[HoursWorked] [int] NULL,
	[Status] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EPID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 08-02-2024 18:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [nvarchar](10) NULL,
	[Salary] [decimal](10, 2) NULL,
	[JoiningDate] [datetime] NULL,
	[DepartmentID] [int] NULL,
	[InterestedTechnologies] [nvarchar](max) NULL,
	[State] [nvarchar](10) NULL,
	[City] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 08-02-2024 18:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NULL,
	[ProjectManager] [varchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Budget] [decimal](15, 2) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salaries]    Script Date: 08-02-2024 18:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salaries](
	[SalaryID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[Amount] [decimal](10, 2) NULL,
	[SalaryType] [varchar](20) NULL,
	[Bonus] [decimal](10, 2) NULL,
	[FinalSalary] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 08-02-2024 18:34:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (1, 1, N'Hyderabad')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (2, 1, N'Visakhapatnam')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (3, 1, N'Vijayawada')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (4, 1, N'Guntur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (5, 1, N'Nellore')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (6, 2, N'Itanagar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (7, 2, N'Naharlagun')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (8, 2, N'Pasighat')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (9, 2, N'Namsai')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (10, 2, N'Bomdila')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (11, 3, N'Guwahati')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (12, 3, N'Silchar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (13, 3, N'Dibrugarh')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (14, 3, N'Jorhat')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (15, 3, N'Tezpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (16, 4, N'Patna')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (17, 4, N'Gaya')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (18, 4, N'Bhagalpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (19, 4, N'Muzaffarpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (20, 4, N'Darbhanga')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (21, 5, N'Raipur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (22, 5, N'Bhilai')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (23, 5, N'Durg')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (24, 5, N'Bilaspur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (25, 5, N'Korba')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (26, 6, N'Panaji')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (27, 6, N'Vasco da Gama')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (28, 6, N'Mapusa')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (29, 6, N'Margao')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (30, 6, N'Ponda')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (31, 7, N'Ahmedabad')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (32, 7, N'Surat')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (33, 7, N'Vadodara')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (34, 7, N'Rajkot')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (35, 7, N'Bhavnagar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (36, 8, N'Faridabad')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (37, 8, N'Gurgaon')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (38, 8, N'Panipat')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (39, 8, N'Ambala')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (40, 8, N'Hisar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (41, 9, N'Shimla')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (42, 9, N'Solan')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (43, 9, N'Dharamshala')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (44, 9, N'Kullu')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (45, 9, N'Mandi')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (46, 10, N'Ranchi')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (47, 10, N'Jamshedpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (48, 10, N'Dhanbad')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (49, 10, N'Bokaro Steel City')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (50, 10, N'Hazaribagh')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (51, 11, N'Bangalore')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (52, 11, N'Mysore')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (53, 11, N'Hubli')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (54, 11, N'Mangalore')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (55, 11, N'Belgaum')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (56, 12, N'Thiruvananthapuram')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (57, 12, N'Kochi')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (58, 12, N'Kozhikode')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (59, 12, N'Thrissur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (60, 12, N'Alappuzha')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (61, 13, N'Bhopal')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (62, 13, N'Indore')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (63, 13, N'Jabalpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (64, 13, N'Gwalior')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (65, 13, N'Ujjain')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (66, 14, N'Mumbai')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (67, 14, N'Pune')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (68, 14, N'Nagpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (69, 14, N'Nashik')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (70, 14, N'Aurangabad')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (71, 15, N'Imphal')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (72, 15, N'Thoubal')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (73, 15, N'Churachandpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (74, 15, N'Bishnupur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (75, 15, N'Kakching')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (76, 16, N'Shillong')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (77, 16, N'Tura')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (78, 16, N'Nongstoin')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (79, 16, N'Jowai')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (80, 16, N'Williamnagar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (81, 17, N'Aizawl')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (82, 17, N'Lunglei')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (83, 17, N'Champhai')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (84, 17, N'Saiha')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (85, 17, N'Kolasib')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (86, 18, N'Kohima')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (87, 18, N'Dimapur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (88, 18, N'Mokokchung')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (89, 18, N'Tuensang')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (90, 18, N'Wokha')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (91, 19, N'Bhubaneswar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (92, 19, N'Cuttack')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (93, 19, N'Rourkela')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (94, 19, N'Berhampur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (95, 19, N'Sambalpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (96, 20, N'Ludhiana')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (97, 20, N'Amritsar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (98, 20, N'Jalandhar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (99, 20, N'Patiala')
GO
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (100, 20, N'Bathinda')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (101, 21, N'Jaipur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (102, 21, N'Jodhpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (103, 21, N'Udaipur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (104, 21, N'Kota')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (105, 21, N'Bikaner')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (106, 22, N'Gangtok')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (107, 22, N'Namchi')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (108, 22, N'Mangan')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (109, 22, N'Rangpo')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (110, 22, N'Soreng')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (111, 23, N'Chennai')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (112, 23, N'Coimbatore')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (113, 23, N'Madurai')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (114, 23, N'Tiruchirappalli')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (115, 23, N'Salem')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (116, 24, N'Hyderabad')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (117, 24, N'Warangal')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (118, 24, N'Nizamabad')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (119, 24, N'Karimnagar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (120, 24, N'Khammam')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (121, 25, N'Agartala')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (122, 25, N'Dharmanagar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (123, 25, N'Udaipur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (124, 25, N'Ambassa')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (125, 25, N'Kailashahar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (126, 26, N'Lucknow')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (127, 26, N'Kanpur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (128, 26, N'Agra')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (129, 26, N'Varanasi')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (130, 26, N'Allahabad')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (131, 27, N'Dehradun')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (132, 27, N'Haridwar')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (133, 27, N'Rishikesh')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (134, 27, N'Haldwani')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (135, 27, N'Kashipur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (136, 28, N'Kolkata')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (137, 28, N'Howrah')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (138, 28, N'Durgapur')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (139, 28, N'Asansol')
INSERT [dbo].[City] ([CityID], [StateID], [CityName]) VALUES (140, 28, N'Siliguri')
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName], [DepartmentHead], [Budget], [CreationDate], [IsActive]) VALUES (39, N'IT', N'XYZ', CAST(100000.00 AS Decimal(15, 2)), CAST(N'2024-02-01' AS Date), 1)
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName], [DepartmentHead], [Budget], [CreationDate], [IsActive]) VALUES (40, N'FinTech', N'ABC', CAST(100000.45 AS Decimal(15, 2)), CAST(N'2024-02-02' AS Date), 1)
INSERT [dbo].[Departments] ([DepartmentID], [DepartmentName], [DepartmentHead], [Budget], [CreationDate], [IsActive]) VALUES (42, N'SDE1', N'PQR', CAST(100.05 AS Decimal(15, 2)), CAST(N'2024-01-31' AS Date), 0)
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeProject] ON 

INSERT [dbo].[EmployeeProject] ([EPID], [EmployeeID], [ProjectID], [AssignmentDate], [HoursWorked], [Status]) VALUES (2, 3, 2, CAST(N'2024-02-07T00:00:00.000' AS DateTime), 10, N'Pending')
SET IDENTITY_INSERT [dbo].[EmployeeProject] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [DateOfBirth], [Gender], [Salary], [JoiningDate], [DepartmentID], [InterestedTechnologies], [State], [City]) VALUES (3, N'Naitik', N'Soni', N'naitik@gmail.com', CAST(N'2003-05-17' AS Date), N'Male', CAST(3871.00 AS Decimal(10, 2)), CAST(N'2024-01-08T00:00:00.000' AS DateTime), 39, N'SpringBoot ', N'8', N'36')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [DateOfBirth], [Gender], [Salary], [JoiningDate], [DepartmentID], [InterestedTechnologies], [State], [City]) VALUES (4, N'Jinay', N'Shah', N'jinshah0322@gmail.com', CAST(N'2003-05-22' AS Date), N'Male', CAST(3871.00 AS Decimal(10, 2)), CAST(N'2024-01-08T00:00:00.000' AS DateTime), 39, N'asp Nodejs ', N'7', N'31')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ProjectManager], [StartDate], [EndDate], [Budget], [IsActive]) VALUES (2, N'Web Forms1', N'XY', CAST(N'2024-02-08' AS Date), CAST(N'2024-02-08' AS Date), CAST(1000.00 AS Decimal(15, 2)), 1)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ProjectManager], [StartDate], [EndDate], [Budget], [IsActive]) VALUES (3, N'Web Forms2', N'XYZ', CAST(N'2024-02-08' AS Date), CAST(N'2024-02-16' AS Date), CAST(15000.00 AS Decimal(15, 2)), 0)
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Salaries] ON 

INSERT [dbo].[Salaries] ([SalaryID], [EmployeeID], [Amount], [SalaryType], [Bonus], [FinalSalary]) VALUES (1, 4, CAST(3871.00 AS Decimal(10, 2)), N'Net Banking', CAST(0.00 AS Decimal(10, 2)), CAST(3871.00 AS Decimal(10, 2)))
INSERT [dbo].[Salaries] ([SalaryID], [EmployeeID], [Amount], [SalaryType], [Bonus], [FinalSalary]) VALUES (2, 3, CAST(3871.00 AS Decimal(10, 2)), N'Net Banking', CAST(0.00 AS Decimal(10, 2)), CAST(3871.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Salaries] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([StateID], [StateName]) VALUES (1, N'Andhra Pradesh')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (2, N'Arunachal Pradesh')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (3, N'Assam')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (4, N'Bihar')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (5, N'Chhattisgarh')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (6, N'Goa')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (7, N'Gujarat')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (8, N'Haryana')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (9, N'Himachal Pradesh')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (10, N'Jharkhand')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (11, N'Karnataka')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (12, N'Kerala')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (13, N'Madhya Pradesh')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (14, N'Maharashtra')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (15, N'Manipur')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (16, N'Meghalaya')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (17, N'Mizoram')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (18, N'Nagaland')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (19, N'Odisha')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (20, N'Punjab')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (21, N'Rajasthan')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (22, N'Sikkim')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (23, N'Tamil Nadu')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (24, N'Telangana')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (25, N'Tripura')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (26, N'Uttar Pradesh')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (27, N'Uttarakhand')
INSERT [dbo].[State] ([StateID], [StateName]) VALUES (28, N'West Bengal')
SET IDENTITY_INSERT [dbo].[State] OFF
GO
ALTER TABLE [dbo].[Departments] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([StateID])
GO
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Department_Employee] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Department_Employee]
GO
ALTER TABLE [dbo].[Salaries]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Salaries] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Salaries] CHECK CONSTRAINT [FK_Employee_Salaries]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO
USE [master]
GO
ALTER DATABASE [EmployeeDB] SET  READ_WRITE 
GO
