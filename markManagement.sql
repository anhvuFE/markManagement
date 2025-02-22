USE [prn231]
GO
/****** Object:  Database [prn231]    Script Date: 11/5/2024 6:15:31 PM ******/
CREATE DATABASE [prn231]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prn231', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\prn231.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'prn231_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\prn231_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [prn231] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prn231].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prn231] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prn231] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prn231] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prn231] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prn231] SET ARITHABORT OFF 
GO
ALTER DATABASE [prn231] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prn231] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prn231] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prn231] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prn231] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prn231] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prn231] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prn231] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prn231] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prn231] SET  ENABLE_BROKER 
GO
ALTER DATABASE [prn231] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prn231] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prn231] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prn231] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prn231] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prn231] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [prn231] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prn231] SET RECOVERY FULL 
GO
ALTER DATABASE [prn231] SET  MULTI_USER 
GO
ALTER DATABASE [prn231] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prn231] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prn231] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prn231] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [prn231] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [prn231] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [prn231] SET QUERY_STORE = ON
GO
ALTER DATABASE [prn231] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [prn231]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComparisonType]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComparisonType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_ComparisonType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](255) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[gradeTypeId] [int] NOT NULL,
	[courseId] [int] NOT NULL,
	[weight] [int] NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeType]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](255) NULL,
	[passConditionId] [int] NULL,
	[gradedByRole] [int] NOT NULL,
 CONSTRAINT [PK_GradeType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassCondition]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassCondition](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[comparisonTypeId] [int] NULL,
	[gradeValue] [int] NULL,
 CONSTRAINT [PK_PassCondition] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[status] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[courseId] [int] NOT NULL,
	[teahcerId] [int] NOT NULL,
	[classId] [int] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionStudent]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionStudent](
	[sessionId] [int] NOT NULL,
	[studentId] [int] NOT NULL,
	[avgGragde] [decimal](5, 2) NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK__SessionS__F70A0F48963274F8] PRIMARY KEY CLUSTERED 
(
	[sessionId] ASC,
	[studentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentGrade]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentGrade](
	[studentId] [int] NOT NULL,
	[gradeId] [int] NOT NULL,
	[value] [decimal](5, 2) NULL,
 CONSTRAINT [PK__StudentG__C2A5E01316895A60] PRIMARY KEY CLUSTERED 
(
	[studentId] ASC,
	[gradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/5/2024 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[roleId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([id], [name]) VALUES (1, N'SE1723')
INSERT [dbo].[Class] ([id], [name]) VALUES (4, N'SE1724')
INSERT [dbo].[Class] ([id], [name]) VALUES (5, N'SE1725')
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[ComparisonType] ON 

INSERT [dbo].[ComparisonType] ([id], [name]) VALUES (1, N'>')
INSERT [dbo].[ComparisonType] ([id], [name]) VALUES (2, N'>=')
SET IDENTITY_INSERT [dbo].[ComparisonType] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([id], [code], [name]) VALUES (1, N'PRN231', N'.NET Standard')
INSERT [dbo].[Course] ([id], [code], [name]) VALUES (2, N'PRM392', N'Mobile Programming')
INSERT [dbo].[Course] ([id], [code], [name]) VALUES (3, N'MLN111', N'Triet hoc MLN')
INSERT [dbo].[Course] ([id], [code], [name]) VALUES (4, N'MLN122', N'Kinh te chinh tri MLN')
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([id], [name], [gradeTypeId], [courseId], [weight]) VALUES (2, N'Lab 1', 1, 1, 5)
INSERT [dbo].[Grade] ([id], [name], [gradeTypeId], [courseId], [weight]) VALUES (3, N'Lab 2', 1, 1, 5)
INSERT [dbo].[Grade] ([id], [name], [gradeTypeId], [courseId], [weight]) VALUES (4, N'assignment 1', 2, 1, 5)
INSERT [dbo].[Grade] ([id], [name], [gradeTypeId], [courseId], [weight]) VALUES (5, N'assignment 2', 2, 1, 5)
INSERT [dbo].[Grade] ([id], [name], [gradeTypeId], [courseId], [weight]) VALUES (6, N'Project', 7, 1, 25)
INSERT [dbo].[Grade] ([id], [name], [gradeTypeId], [courseId], [weight]) VALUES (7, N'PE', 5, 1, 25)
INSERT [dbo].[Grade] ([id], [name], [gradeTypeId], [courseId], [weight]) VALUES (8, N'FE', 8, 1, 30)
SET IDENTITY_INSERT [dbo].[Grade] OFF
GO
SET IDENTITY_INSERT [dbo].[GradeType] ON 

INSERT [dbo].[GradeType] ([id], [name], [description], [passConditionId], [gradedByRole]) VALUES (1, N'Lab', NULL, 1, 3)
INSERT [dbo].[GradeType] ([id], [name], [description], [passConditionId], [gradedByRole]) VALUES (2, N'assignment', NULL, 1, 3)
INSERT [dbo].[GradeType] ([id], [name], [description], [passConditionId], [gradedByRole]) VALUES (5, N'PE', NULL, 2, 2)
INSERT [dbo].[GradeType] ([id], [name], [description], [passConditionId], [gradedByRole]) VALUES (7, N'Project', NULL, 1, 3)
INSERT [dbo].[GradeType] ([id], [name], [description], [passConditionId], [gradedByRole]) VALUES (8, N'FE', NULL, 2, 2)
INSERT [dbo].[GradeType] ([id], [name], [description], [passConditionId], [gradedByRole]) VALUES (9, N'PT', NULL, 1, 3)
INSERT [dbo].[GradeType] ([id], [name], [description], [passConditionId], [gradedByRole]) VALUES (10, N'Participation', NULL, 1, 3)
SET IDENTITY_INSERT [dbo].[GradeType] OFF
GO
SET IDENTITY_INSERT [dbo].[PassCondition] ON 

INSERT [dbo].[PassCondition] ([id], [comparisonTypeId], [gradeValue]) VALUES (1, 1, 0)
INSERT [dbo].[PassCondition] ([id], [comparisonTypeId], [gradeValue]) VALUES (2, 2, 4)
SET IDENTITY_INSERT [dbo].[PassCondition] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([roleId], [roleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([roleId], [roleName]) VALUES (2, N'Phong Khao Thi')
INSERT [dbo].[Role] ([roleId], [roleName]) VALUES (3, N'Teacher')
INSERT [dbo].[Role] ([roleId], [roleName]) VALUES (4, N'Student')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[Semester] ([status]) VALUES (1)
GO
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([id], [courseId], [teahcerId], [classId]) VALUES (1, 1, 3, 1)
INSERT [dbo].[Session] ([id], [courseId], [teahcerId], [classId]) VALUES (3, 2, 3, 1)
INSERT [dbo].[Session] ([id], [courseId], [teahcerId], [classId]) VALUES (4, 3, 3, 1)
INSERT [dbo].[Session] ([id], [courseId], [teahcerId], [classId]) VALUES (5, 4, 3, 1)
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (1, 5, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (1, 6, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (1, 7, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (1, 8, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (3, 5, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (3, 9, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (3, 10, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (3, 11, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (4, 12, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (4, 13, NULL, NULL)
INSERT [dbo].[SessionStudent] ([sessionId], [studentId], [avgGragde], [status]) VALUES (4, 14, NULL, NULL)
GO
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (4, 2, CAST(10.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (4, 3, CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (5, 2, CAST(3.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (5, 3, CAST(4.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (5, 4, CAST(3.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (5, 5, CAST(6.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (5, 6, CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (5, 7, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (5, 8, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (6, 2, CAST(3.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (6, 3, CAST(5.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (6, 4, CAST(4.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (6, 5, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (6, 6, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (6, 7, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (6, 8, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (7, 2, CAST(3.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (7, 3, CAST(6.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (7, 4, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (7, 5, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (7, 6, CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (7, 7, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (7, 8, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (8, 2, CAST(3.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (8, 3, CAST(3.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (8, 4, CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (8, 5, CAST(6.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (8, 6, CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (8, 7, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[StudentGrade] ([studentId], [gradeId], [value]) VALUES (8, 8, CAST(7.00 AS Decimal(5, 2)))
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (1, N'admin', N'123456', 1)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (2, N'phongkhaothi', N'123456', 2)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (3, N'teacher', N'123456', 3)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (4, N'student1', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (5, N'Nguyen Van A', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (6, N'Nguyen Van B', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (7, N'Nguyen Van C', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (8, N'Nguyen Van D', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (9, N'Nguyen Van E', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (10, N'Nguyen Van F', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (11, N'Nguyen Van G', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (12, N'Nguyen Van H', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (13, N'Nguyen Van I', N'123456', 4)
INSERT [dbo].[Users] ([id], [username], [password], [roleId]) VALUES (14, N'Nguyen Van J', N'123456', 4)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Class__72E12F1B079CD921]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Class__72E12F1B079CD921] ON [dbo].[Class]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Comparis__72E12F1B5FFF7F29]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Comparis__72E12F1B5FFF7F29] ON [dbo].[ComparisonType]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Course__357D4CF94DDC8427]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Course__357D4CF94DDC8427] ON [dbo].[Course]
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Course__72E12F1B6BEBC001]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Course__72E12F1B6BEBC001] ON [dbo].[Course]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Grade_courseId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_Grade_courseId] ON [dbo].[Grade]
(
	[courseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Grade_gradeTypeId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_Grade_gradeTypeId] ON [dbo].[Grade]
(
	[gradeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GradeType_gradedByRole]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_GradeType_gradedByRole] ON [dbo].[GradeType]
(
	[gradedByRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GradeType_passConditionId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_GradeType_passConditionId] ON [dbo].[GradeType]
(
	[passConditionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__GradeTyp__72E12F1BFCF00FB3]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ__GradeTyp__72E12F1BFCF00FB3] ON [dbo].[GradeType]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PassCondition_comparisonTypeId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_PassCondition_comparisonTypeId] ON [dbo].[PassCondition]
(
	[comparisonTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Session_classId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_Session_classId] ON [dbo].[Session]
(
	[classId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Session_courseId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_Session_courseId] ON [dbo].[Session]
(
	[courseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Session_teahcerId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_Session_teahcerId] ON [dbo].[Session]
(
	[teahcerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SessionStudent_studentId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_SessionStudent_studentId] ON [dbo].[SessionStudent]
(
	[studentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentGrade_gradeId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentGrade_gradeId] ON [dbo].[StudentGrade]
(
	[gradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_roleId]    Script Date: 11/5/2024 6:15:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_roleId] ON [dbo].[Users]
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK__Grade__courseId__571DF1D5] FOREIGN KEY([courseId])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK__Grade__courseId__571DF1D5]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK__Grade__gradeType__5812160E] FOREIGN KEY([gradeTypeId])
REFERENCES [dbo].[GradeType] ([id])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK__Grade__gradeType__5812160E]
GO
ALTER TABLE [dbo].[GradeType]  WITH CHECK ADD  CONSTRAINT [FK__GradeType__grade__5441852A] FOREIGN KEY([gradedByRole])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[GradeType] CHECK CONSTRAINT [FK__GradeType__grade__5441852A]
GO
ALTER TABLE [dbo].[GradeType]  WITH CHECK ADD  CONSTRAINT [FK__GradeType__passC__534D60F1] FOREIGN KEY([passConditionId])
REFERENCES [dbo].[PassCondition] ([id])
GO
ALTER TABLE [dbo].[GradeType] CHECK CONSTRAINT [FK__GradeType__passC__534D60F1]
GO
ALTER TABLE [dbo].[PassCondition]  WITH CHECK ADD  CONSTRAINT [FK__PassCondi__compa__4F7CD00D] FOREIGN KEY([comparisonTypeId])
REFERENCES [dbo].[ComparisonType] ([id])
GO
ALTER TABLE [dbo].[PassCondition] CHECK CONSTRAINT [FK__PassCondi__compa__4F7CD00D]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK__Session__classId__45F365D3] FOREIGN KEY([classId])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK__Session__classId__45F365D3]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK__Session__courseI__440B1D61] FOREIGN KEY([courseId])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK__Session__courseI__440B1D61]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK__Session__teahcer__44FF419A] FOREIGN KEY([teahcerId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK__Session__teahcer__44FF419A]
GO
ALTER TABLE [dbo].[SessionStudent]  WITH CHECK ADD  CONSTRAINT [FK__SessionSt__sessi__48CFD27E] FOREIGN KEY([sessionId])
REFERENCES [dbo].[Session] ([id])
GO
ALTER TABLE [dbo].[SessionStudent] CHECK CONSTRAINT [FK__SessionSt__sessi__48CFD27E]
GO
ALTER TABLE [dbo].[SessionStudent]  WITH CHECK ADD  CONSTRAINT [FK__SessionSt__stude__49C3F6B7] FOREIGN KEY([studentId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[SessionStudent] CHECK CONSTRAINT [FK__SessionSt__stude__49C3F6B7]
GO
ALTER TABLE [dbo].[StudentGrade]  WITH CHECK ADD  CONSTRAINT [FK__StudentGr__grade__5BE2A6F2] FOREIGN KEY([gradeId])
REFERENCES [dbo].[Grade] ([id])
GO
ALTER TABLE [dbo].[StudentGrade] CHECK CONSTRAINT [FK__StudentGr__grade__5BE2A6F2]
GO
ALTER TABLE [dbo].[StudentGrade]  WITH CHECK ADD  CONSTRAINT [FK__StudentGr__stude__5AEE82B9] FOREIGN KEY([studentId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[StudentGrade] CHECK CONSTRAINT [FK__StudentGr__stude__5AEE82B9]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__roleId__3A81B327] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__roleId__3A81B327]
GO
USE [master]
GO
ALTER DATABASE [prn231] SET  READ_WRITE 
GO
