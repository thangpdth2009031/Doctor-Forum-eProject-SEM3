USE [master]
GO
/****** Object:  Database [DoctorForum]    Script Date: 4/26/2022 10:22:32 AM ******/
CREATE DATABASE [DoctorForum]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DoctorForum', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DoctorForum.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DoctorForum_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DoctorForum_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DoctorForum] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DoctorForum].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DoctorForum] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DoctorForum] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DoctorForum] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DoctorForum] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DoctorForum] SET ARITHABORT OFF 
GO
ALTER DATABASE [DoctorForum] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DoctorForum] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DoctorForum] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DoctorForum] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DoctorForum] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DoctorForum] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DoctorForum] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DoctorForum] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DoctorForum] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DoctorForum] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DoctorForum] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DoctorForum] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DoctorForum] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DoctorForum] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DoctorForum] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DoctorForum] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DoctorForum] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DoctorForum] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DoctorForum] SET  MULTI_USER 
GO
ALTER DATABASE [DoctorForum] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DoctorForum] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DoctorForum] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DoctorForum] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DoctorForum] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DoctorForum]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[Avatar] [nvarchar](max) NULL,
	[UserName] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[FullName] [nvarchar](250) NULL,
	[AddressDetail] [nvarchar](max) NULL,
	[DistrictId] [int] NULL,
	[ProvinceId] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Status] [bit] NOT NULL,
	[SpecializationId] [int] NULL,
	[Email] [nvarchar](250) NULL,
	[Phone] [varchar](15) NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Achievements]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achievements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[AccountId] [int] NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpatedAt] [datetime] NULL,
 CONSTRAINT [PK_Achievements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachments](
	[Id] [int] NOT NULL,
	[RepId] [int] NULL,
	[Type] [int] NULL,
	[Link] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Attachments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Experiences]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experiences](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[StartYear] [nchar](50) NULL,
	[EndYear] [nchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Workplace] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
 CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Type] [int] NULL,
	[SpecializationId] [int] NULL,
	[Image] [nvarchar](max) NULL,
	[AccountId] [int] NULL,
	[Tag] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professional]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professional](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfessionalName] [nvarchar](max) NULL,
	[AccountId] [int] NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Professional] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Qualifications]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [nchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[AccountId] [int] NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[School] [nvarchar](max) NULL,
 CONSTRAINT [PK_Qualifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Replies]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Replies](
	[Id] [int] NOT NULL,
	[ParenId] [int] NULL,
	[PostId] [int] NULL,
	[AccountId] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Replies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Specializations]    Script Date: 4/26/2022 10:22:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specializations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (4, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'vana', N'vana', N'nguyenvana', N'yenhoa', 11, 1, CAST(N'2022-04-16 17:24:34.780' AS DateTime), CAST(N'2022-04-16 17:24:34.783' AS DateTime), 1, 2, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (5, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'vanb', N'ac4865660909c5ba7cf872c28dd9d754', N'nguyenvanb', N'yenhoa', 60313, 603, CAST(N'2022-04-17 11:18:03.207' AS DateTime), CAST(N'2022-04-17 11:18:03.207' AS DateTime), 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (7, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'vanc', N'f2b2bea78435e5789b52cce3f508f948', N'nguyenvanc', N'ngõ 42, ', 10151, 101, CAST(N'2022-04-18 01:12:54.687' AS DateTime), CAST(N'2022-04-18 01:12:54.687' AS DateTime), 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (8, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'vand', N'a3cdfbe3ac78bdee833c986f68038d13', N'nguyenvanc', N'yenhoa', 11111, 111, CAST(N'2022-04-18 02:25:24.667' AS DateTime), CAST(N'2022-04-18 02:25:24.667' AS DateTime), 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (9, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'admin', N'admin', 60301, 603, CAST(N'2022-04-18 17:23:36.503' AS DateTime), CAST(N'2022-04-18 17:23:36.503' AS DateTime), 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (10, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'tiendung', N'6b12523e2367e1de9b8936caad798a1f', N'lethanhdat', N'ngõ 42, ', 70137, 701, CAST(N'2022-04-18 18:22:10.917' AS DateTime), CAST(N'2022-04-18 18:22:10.917' AS DateTime), 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (11, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'Tiendang', N'6c228bc8eedbce04923029045262d5d0', N'Dang van tien', N'yenhoa', 82309, 823, CAST(N'2022-04-18 22:18:13.177' AS DateTime), CAST(N'2022-04-18 22:18:13.177' AS DateTime), 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (13, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'datle', N'11a030b05621709c3150ba6155397e3b', N'Dang van tien', N'yenhoa', 10153, 101, CAST(N'2022-04-18 22:35:22.100' AS DateTime), CAST(N'2022-04-18 22:35:22.320' AS DateTime), 1, 2, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (14, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'cuongtoi', N'8cd3ced88c230cd499d155de2f560f25', N'cuong toi', N'admin', 81529, 815, CAST(N'2022-04-19 11:09:19.910' AS DateTime), CAST(N'2022-04-19 11:09:19.910' AS DateTime), 1, 2, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (1014, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'cuong6oi', N'9e9074be8c7ec918032be71a9edb4513', N'nguyenvana', N'yenhoa', 80519, 805, CAST(N'2022-04-22 15:49:48.857' AS DateTime), CAST(N'2022-04-22 15:49:48.857' AS DateTime), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (1015, 1, N'https://i.pinimg.com/236x/ff/4f/c3/ff4fc3f2cbe6f1b6f9acbef2981f6d36.jpg', N'cuongtoithailo', N'e10adc3949ba59abbe56e057f20f883e', N'cuongtoithailo', N'cuongtoithailo', 81523, 815, CAST(N'2022-04-22 15:51:43.560' AS DateTime), CAST(N'2022-04-22 15:51:43.560' AS DateTime), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [RoleId], [Avatar], [UserName], [Password], [FullName], [AddressDetail], [DistrictId], [ProvinceId], [CreatedAt], [UpdatedAt], [Status], [SpecializationId], [Email], [Phone], [Gender]) VALUES (1016, 1, N'https://www.google.com/search?q=anh+ch%C3%B3+c%C3%A1i&tbm=isch&source=iu&ictx=1&vet=1&fir=0UNyXGXRhs1BAM%252CrkTehdWMeBvcVM%252C_%253B96jsqs9znMlJuM%252CSikzlz8ZkqbVAM%252C_%253B6Im-F7JPJq7DfM%252C7C2vQRXrmW7O6M%252C_%253BG4XTUEBICOyBcM%252CmXVLueWmc_hFkM%252C_%253BUg9hNBbEk7m3RM%252CaveGu5rGWvAteM%252C_%253BAAWAqAe7jLsKrM%252CbOYhom-2z5TsZM%252C_%253B1bqgYUBUBAAwjM%252C122plkH52MnmyM%252C_%253BxtsTEDxmm9ZzeM%252C00-lj1XE7QXPAM%252C_%253B8i6S5OtoqEoi6M%252C00-lj1XE7QXPAM%252C_%253BuNEPFJizz6rh3M%252C7C2vQRXrmW7O6M%252C_%253BMCzSPtKXtuOHZM%252CyGQm9vNcj6KTbM%252C_%253BTl0ujKpLyK8DNM%252CjFPRw_orXIn6MM%252C_%253B99gZOdqEbOhZjM%252CHgf03Wj3EoyRoM%252C_%253B9Z3rAF0PXxMdgM%252C122plkH52MnmyM%252C_%253BhGgg6NygM3pKWM%252C3OSdu-Y5X0v5LM%252C_&usg=AI4_-kSpnXAf8KNGLSFzpxBIKeIGgv0wmg&sa=X&ved=2ahUKEwi3lpng-Kb3AhUNCYgKHWPVBD4Q9QF6BAgFEAE#imgrc=96jsqs9znMlJuM', N'hanhatngao', N'e10adc3949ba59abbe56e057f20f883e', N'hanhatngao', N'hanhatngao', 81531, 815, CAST(N'2022-04-22 15:55:27.700' AS DateTime), CAST(N'2022-04-22 15:55:27.700' AS DateTime), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Achievements] ON 

INSERT [dbo].[Achievements] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpatedAt]) VALUES (2, N'2012', N'thành tích ', 7, 1, CAST(N'2022-04-18 01:12:54.730' AS DateTime), CAST(N'2022-04-18 01:12:54.730' AS DateTime))
INSERT [dbo].[Achievements] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpatedAt]) VALUES (3, N'2012', N'thành tích ', 8, 1, CAST(N'2022-04-18 02:25:24.857' AS DateTime), CAST(N'2022-04-18 02:25:24.857' AS DateTime))
INSERT [dbo].[Achievements] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpatedAt]) VALUES (4, NULL, NULL, 9, 1, CAST(N'2022-04-18 17:23:36.577' AS DateTime), CAST(N'2022-04-18 17:23:36.577' AS DateTime))
INSERT [dbo].[Achievements] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpatedAt]) VALUES (5, NULL, N'thành tích ', 10, 1, CAST(N'2022-04-18 18:22:10.980' AS DateTime), CAST(N'2022-04-18 18:22:10.980' AS DateTime))
INSERT [dbo].[Achievements] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpatedAt]) VALUES (6, NULL, NULL, 11, 1, CAST(N'2022-04-18 22:18:13.357' AS DateTime), CAST(N'2022-04-18 22:18:13.357' AS DateTime))
INSERT [dbo].[Achievements] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpatedAt]) VALUES (7, N'2012', N'thành tích ', 13, 1, CAST(N'2022-04-18 22:35:29.097' AS DateTime), CAST(N'2022-04-18 22:35:29.107' AS DateTime))
INSERT [dbo].[Achievements] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpatedAt]) VALUES (8, NULL, NULL, 14, 1, CAST(N'2022-04-19 11:09:20.103' AS DateTime), CAST(N'2022-04-19 11:09:20.103' AS DateTime))
SET IDENTITY_INSERT [dbo].[Achievements] OFF
SET IDENTITY_INSERT [dbo].[Experiences] ON 

INSERT [dbo].[Experiences] ([Id], [AccountId], [StartYear], [EndYear], [Description], [Status], [CreatedAt], [UpdatedAt], [Workplace], [Position]) VALUES (1, 7, N'2014                                              ', N'2016                                              ', N'Làm khá là lâu rồi', 1, CAST(N'2022-04-18 01:12:54.733' AS DateTime), CAST(N'2022-04-18 01:12:54.733' AS DateTime), N'Bệnh viện đa khoa tỉnh phú thọ', N'Phụ tá')
INSERT [dbo].[Experiences] ([Id], [AccountId], [StartYear], [EndYear], [Description], [Status], [CreatedAt], [UpdatedAt], [Workplace], [Position]) VALUES (2, 8, N'2014                                              ', N'2016                                              ', N'Làm khá là lâu rồi', 1, CAST(N'2022-04-18 02:25:24.870' AS DateTime), CAST(N'2022-04-18 02:25:24.870' AS DateTime), N'Bệnh viện đa khoa tỉnh phú thọ', N'Phụ tá')
INSERT [dbo].[Experiences] ([Id], [AccountId], [StartYear], [EndYear], [Description], [Status], [CreatedAt], [UpdatedAt], [Workplace], [Position]) VALUES (3, 9, NULL, NULL, NULL, 1, CAST(N'2022-04-18 17:23:36.587' AS DateTime), CAST(N'2022-04-18 17:23:36.587' AS DateTime), NULL, NULL)
INSERT [dbo].[Experiences] ([Id], [AccountId], [StartYear], [EndYear], [Description], [Status], [CreatedAt], [UpdatedAt], [Workplace], [Position]) VALUES (4, 10, NULL, NULL, NULL, 1, CAST(N'2022-04-18 18:22:10.983' AS DateTime), CAST(N'2022-04-18 18:22:10.983' AS DateTime), NULL, NULL)
INSERT [dbo].[Experiences] ([Id], [AccountId], [StartYear], [EndYear], [Description], [Status], [CreatedAt], [UpdatedAt], [Workplace], [Position]) VALUES (5, 11, NULL, NULL, NULL, 1, CAST(N'2022-04-18 22:18:13.377' AS DateTime), CAST(N'2022-04-18 22:18:13.377' AS DateTime), NULL, NULL)
INSERT [dbo].[Experiences] ([Id], [AccountId], [StartYear], [EndYear], [Description], [Status], [CreatedAt], [UpdatedAt], [Workplace], [Position]) VALUES (6, 13, N'2014                                              ', N'2016                                              ', N'Làm khá là lâu rồi', 1, CAST(N'2022-04-18 22:35:35.553' AS DateTime), CAST(N'2022-04-18 22:35:35.557' AS DateTime), N'Bệnh viện đa khoa tỉnh phú thọ', N'Phụ tá')
INSERT [dbo].[Experiences] ([Id], [AccountId], [StartYear], [EndYear], [Description], [Status], [CreatedAt], [UpdatedAt], [Workplace], [Position]) VALUES (7, 14, NULL, NULL, NULL, 1, CAST(N'2022-04-19 11:09:20.117' AS DateTime), CAST(N'2022-04-19 11:09:20.117' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Experiences] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1, N'test 1', N'content1', 1, 2, N'test.jpg', 12, N'nhi', 0, CAST(N'2022-04-18 23:56:04.957' AS DateTime), CAST(N'2022-04-18 23:56:04.957' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (2, N'ACC: Can thiệp ít natri có ít lợi ích trong suy tim', N'&lt;h1&gt;ACC: Can thi?p &amp;iacute;t natri c&amp;oacute; &amp;iacute;t l?i &amp;iacute;ch trong suy tim&lt;/h1&gt;

&lt;p&gt;TIN T?C13/00/22 Theo&amp;nbsp;&lt;/p&gt;

&lt;p&gt;HealthDay Tin t?c&lt;/p&gt;

&lt;p&gt;&lt;img alt="ACC: Can thi?p ít natri có ít l?i ích trong suy tim" src="https://consumer.healthday.com/media-library/eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpbWFnZSI6Imh0dHBzOi8vYXNzZXRzLnJibC5tcy8yOTM3ODEzMi9vcmlnaW4uanBnIiwiZXhwaXJlc19hdCI6MTcxMDUyMzkzMX0.vNUuqw6MzGmf_Q4eYtm_w_tXFFnO-5TudsLY2UfFytI/image.jpg?width=180&amp;amp;coordinates=235%2C0%2C235%2C0&amp;amp;height=135" /&gt;&lt;/p&gt;

&lt;p&gt;TH? TU, ng&amp;agrave;y 13 th&amp;aacute;ng Tu nam 2022 (HealthDay News) &amp;ndash; Theo m?t nghi&amp;ecirc;n c?u du?c c&amp;ocirc;ng b? tr?c tuy?n ng&amp;agrave;y 2 th&amp;aacute;ng Tu tr&amp;ecirc;n&amp;nbsp;&lt;em&gt;The Lancet&amp;nbsp;&lt;/em&gt;tr&amp;ugrave;ng v?i th?i di?m c&amp;oacute; h?i ngh? h&amp;agrave;ng nam c?a Hi?p h?i Tim m?ch Hoa K?, du?c t? ch?c t? ng&amp;agrave;y 2 d?n ng&amp;agrave;y 4 th&amp;aacute;ng Tu t?i Washington, D.C, can thi?p ch? d? an u?ng d? l&amp;agrave;m gi?m lu?ng natri an v&amp;agrave;o l&amp;agrave; kh? thi d?i v?i b?nh nh&amp;acirc;n suy tim m?n t&amp;iacute;nh nhung kh&amp;ocirc;ng l&amp;agrave;m c?i thi?n k?t qu? l&amp;acirc;m s&amp;agrave;ng.&lt;/p&gt;

&lt;p&gt;C? nh&amp;acirc;n Y khoa, C? nh&amp;acirc;n Ph?u thu?t Justin A. Ezekowitz t? University of Alberta ? Edmonton, Canada v&amp;agrave; c&amp;aacute;c d?ng nghi?p d&amp;atilde; ti?n h&amp;agrave;nh m?t th? nghi?m ch?n ng?u nhi&amp;ecirc;n, c&amp;oacute; d?i ch?ng, nh&amp;atilde;n m? d? thu nh?n 806 b?nh nh&amp;acirc;n suy tim m?n t&amp;iacute;nh du?c di?u tr? n?i khoa theo d?nh hu?ng hu?ng d?n du?c dung n?p t?i uu, t?i 26 co s? ? s&amp;aacute;u qu?c gia. Ngu?i tham gia du?c ch? d?nh ng?u nhi&amp;ecirc;n v&amp;agrave;o ch? d? cham s&amp;oacute;c th&amp;ocirc;ng thu?ng ho?c ch? d? an &amp;iacute;t natri du?i 100 mmol (&amp;lt; 1.500 mg/ng&amp;agrave;y; l?n lu?t l&amp;agrave; 409 b?nh nh&amp;acirc;n v&amp;agrave; 397 b?nh nh&amp;acirc;n).&lt;/p&gt;

&lt;p&gt;C&amp;aacute;c nh&amp;agrave; nghi&amp;ecirc;n c?u th?y r?ng lu?ng natri an v&amp;agrave;o trung b&amp;igrave;nh gi?m t? 2,286 xu?ng 1,658 mg/ng&amp;agrave;y t? l?n kh&amp;aacute;m ban d?u cho d?n 12 th&amp;aacute;ng ? nh&amp;oacute;m an &amp;iacute;t natri v&amp;agrave; t? 2,119 xu?ng 2,073 mg/ng&amp;agrave;y ? nh&amp;oacute;m cham s&amp;oacute;c th&amp;ocirc;ng thu?ng. Ð?n 12 th&amp;aacute;ng, k?t c?c ch&amp;iacute;nh (t?ng h?p c?a nh?p vi?n li&amp;ecirc;n quan d?n tim m?ch, d?n kh&amp;aacute;m t?i khoa c?p c?u li&amp;ecirc;n quan d?n tim m?ch, ho?c t? vong do m?i nguy&amp;ecirc;n nh&amp;acirc;n) l?n lu?t x?y ra ? 15% v&amp;agrave; 17% s? b?nh nh&amp;acirc;n trong nh&amp;oacute;m an &amp;iacute;t natri v&amp;agrave; trong nh&amp;oacute;m cham s&amp;oacute;c th&amp;ocirc;ng thu?ng (t? l? nguy co l&amp;agrave; 0,89; kho?ng tin c?y 95 ph?n tram t? 0,63 d?n 1,26; P = 0,53). Kh&amp;ocirc;ng quan s&amp;aacute;t th?y c&amp;aacute;c kh&amp;aacute;c bi?t d&amp;aacute;ng k? gi?a c&amp;aacute;c nh&amp;oacute;m v? t? vong do m?i nguy&amp;ecirc;n nh&amp;acirc;n, nh?p vi?n li&amp;ecirc;n quan d?n tim m?ch v&amp;agrave; c&amp;aacute;c l?n kh&amp;aacute;m t?i khoa c?p c?u li&amp;ecirc;n quan d?n tim m?ch. C? hai nh&amp;oacute;m d?u kh&amp;ocirc;ng b&amp;aacute;o c&amp;aacute;o c&amp;aacute;c bi?n c? d? an to&amp;agrave;n li&amp;ecirc;n quan d?n di?u tr? nghi&amp;ecirc;n c?u.&lt;/p&gt;

&lt;p&gt;C&amp;aacute;c t&amp;aacute;c gi? vi?t: &amp;ldquo;Vi?c can thi?p ch? d? an u?ng trong nghi&amp;ecirc;n c?u n&amp;agrave;y l&amp;agrave; kh? thi v&amp;agrave; hi?u qu? trong vi?c l&amp;agrave;m gi?m lu?ng natri an v&amp;agrave;o ? b?nh nh&amp;acirc;n suy tim nhung kh&amp;ocirc;ng l&amp;agrave;m thay d?i k?t qu? l&amp;acirc;m s&amp;agrave;ng&amp;rdquo;.&lt;/p&gt;

&lt;p&gt;M?t s? t&amp;aacute;c gi? ti?t l? m?i quan h? t&amp;agrave;i ch&amp;iacute;nh v?i ng&amp;agrave;nh c&amp;ocirc;ng nghi?p du?c ph?m.&lt;/p&gt;
', 1, 2, N'/FileUploads/images/Img-post/UseCaseBook.png', 12, N'nhi', 0, CAST(N'2022-04-19 02:41:13.907' AS DateTime), CAST(N'2022-04-19 02:41:13.907' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (4, N'Thuốc kháng sinh trong giai đoạn đầu đời làm thay đổi hệ vi sinh đường ruột của trẻ sơ sinh', N'&lt;h1&gt;Thu?c kh&amp;aacute;ng sinh trong giai do?n d?u d?i l&amp;agrave;m thay d?i h? vi sinh du?ng ru?t c?a tr? so sinh&lt;/h1&gt;

&lt;p&gt;TIN T?C16/00/22 Theo&amp;nbsp;&lt;/p&gt;

&lt;p&gt;HealthDay Tin t?c&lt;/p&gt;

&lt;p&gt;&lt;img alt="Thu?c kháng sinh trong giai do?n d?u d?i làm thay d?i h? vi sinh du?ng ru?t c?a tr? so sinh" src="https://consumer.healthday.com/media-library/eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpbWFnZSI6Imh0dHBzOi8vYXNzZXRzLnJibC5tcy8yMzYzMzkyOS9vcmlnaW4uanBnIiwiZXhwaXJlc19hdCI6MTcwNjU0OTk4MH0.esQn2ngx8rGlhpmJYGMrwgeJUn27XSPvHNvs7XSkjaA/image.jpg?width=180&amp;amp;coordinates=53%2C0%2C53%2C0&amp;amp;height=135" /&gt;&lt;/p&gt;

&lt;p&gt;TH? TU, ng&amp;agrave;y 16 th&amp;aacute;ng Ba nam 2022 (HealthDay News) &amp;ndash; Theo m?t nghi&amp;ecirc;n c?u du?c c&amp;ocirc;ng b? tr?c tuy?n ng&amp;agrave;y 16 th&amp;aacute;ng Hai tr&amp;ecirc;n&amp;nbsp;&lt;em&gt;Nature Communications&lt;/em&gt;, d?i v?i tr? so sinh c&amp;oacute; nghi ng? nhi?m tr&amp;ugrave;ng so sinh kh?i ph&amp;aacute;t s?m (suspected early-onset neonatal sepsis, sEONS), th&amp;agrave;nh ph?n t?p h?p vi sinh v?t du?ng ru?t n&amp;oacute;i chung v&amp;agrave; h? so gen kh&amp;aacute;ng kh&amp;aacute;ng sinh thay d?i tr?c ti?p sau khi di?u tr? b?ng kh&amp;aacute;ng sinh.&lt;/p&gt;

&lt;p&gt;Marta Reyman t? B?nh vi?n Nhi Wilhelmina v&amp;agrave; Trung t&amp;acirc;m Y t? Ð?i h?c Utrecht ? H&amp;agrave; Lan v&amp;agrave; c&amp;aacute;c d?ng nghi?p d&amp;atilde; ch? d?nh ng?u nhi&amp;ecirc;n 147 tr? sinh ra v?i tu?i thai &amp;ge; 36 tu?n c?n ph?i d&amp;ugrave;ng kh&amp;aacute;ng sinh ph? r?ng d? di?u tr? sEONS (th?i gian trung b&amp;igrave;nh l&amp;agrave; 48 gi?) trong tu?n d?u d?i c?a tr? d&amp;ugrave;ng penicillin + gentamicin, co-amoxiclav + gentamicin, ho?c amoxicillin + cefotaxime. T&amp;aacute;m muoi tr? so sinh kh&amp;ocirc;ng du?c di?u tr? b?ng kh&amp;aacute;ng sinh t? m?t do&amp;agrave;n h? so sinh kh?e m?nh du?c coi l&amp;agrave; d?i ch?ng. Tru?c v&amp;agrave; ngay sau khi di?u tr? v&amp;agrave; khi tr? du?c 1, 4 v&amp;agrave; 12 th&amp;aacute;ng tu?i, que tam b&amp;ocirc;ng l?y b?nh ph?m ? tr?c tr&amp;agrave;ng v&amp;agrave;/ho?c ph&amp;acirc;n d&amp;atilde; du?c thu th?p. H? vi sinh v?t d&amp;atilde; du?c m&amp;ocirc; t? d?c di?m v&amp;agrave; m?t nh&amp;oacute;m g?m 31 gen kh&amp;aacute;ng thu?c kh&amp;aacute;ng sinh d&amp;atilde; du?c x&amp;eacute;t nghi?m.&lt;/p&gt;

&lt;p&gt;C&amp;aacute;c nh&amp;agrave; nghi&amp;ecirc;n c?u ph&amp;aacute;t hi?n ra r?ng ngay sau khi di?u tr?, c&amp;oacute; m?t s? thay d?i l?n trong th&amp;agrave;nh ph?n t?p h?p vi sinh v?t du?ng ru?t n&amp;oacute;i chung v&amp;agrave; h? so gen kh&amp;aacute;ng thu?c kh&amp;aacute;ng sinh, v?n d&amp;atilde; b&amp;igrave;nh thu?ng h&amp;oacute;a trong 12 th&amp;aacute;ng. So v?i nh&amp;oacute;m d?i ch?ng, tr? so sinh du?c di?u tr? b?ng kh&amp;aacute;ng sinh c&amp;oacute; gi?m m?c d? phong ph&amp;uacute; c?a lo&amp;agrave;i&amp;nbsp;&lt;em&gt;Bifidobacterium&amp;nbsp;&lt;/em&gt;v&amp;agrave; tang m?c d? phong ph&amp;uacute; c?a lo&amp;agrave;i&amp;nbsp;&lt;em&gt;Klebsiella&lt;/em&gt;&amp;nbsp;v&amp;agrave; lo&amp;agrave;i&amp;nbsp;&lt;em&gt;Enterococcus&lt;/em&gt;. ?nh hu?ng l?n nh?t d?n c? th&amp;agrave;nh ph?n t?p h?p vi sinh v?t v&amp;agrave; h? so gen kh&amp;aacute;ng kh&amp;aacute;ng sinh d&amp;atilde; du?c quan s&amp;aacute;t th?y d?i v?i amoxicilin + cefotaxime, trong khi ?nh hu?ng &amp;iacute;t nh?t d&amp;atilde; du?c quan s&amp;aacute;t th?y v?i penicilin + gentamicin.&lt;/p&gt;

&lt;p&gt;Ð?ng t&amp;aacute;c gi? cho bi?t: &amp;ldquo;Ch&amp;uacute;ng t&amp;ocirc;i r?t ng?c nhi&amp;ecirc;n v?i m?c d? v&amp;agrave; th?i gian t&amp;aacute;c d?ng c?a kh&amp;aacute;ng sinh ph? r?ng d?i v?i h? vi sinh v?t c?a tr? so sinh khi so s&amp;aacute;nh v?i t&amp;aacute;c d?ng c?a c&amp;ugrave;ng lo?i kh&amp;aacute;ng sinh d&amp;oacute; d?i v?i h? vi sinh v?t c?a ngu?i l?n&amp;rdquo;.&lt;/p&gt;
', 1, 2, N'/FileUploads/images/Img-post/UseCaseBook.png', 12, N'nhi', 0, CAST(N'2022-04-19 03:24:39.627' AS DateTime), CAST(N'2022-04-19 03:24:39.627' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (5, N'Tại sao nên ăn theo tháp dinh dưỡng cho người trưởng thành?', N'&lt;h2&gt;T?i sao n&amp;ecirc;n an theo th&amp;aacute;p dinh du?ng cho ngu?i tru?ng th&amp;agrave;nh?&lt;/h2&gt;

&lt;p&gt;Ngu?i tru?ng th&amp;agrave;nh l&amp;agrave; ngu?i ho?t d?ng nhi?u hon ( linh v?c tr&amp;iacute; &amp;oacute;c, ch&amp;acirc;n tay,&amp;hellip;) d&amp;ograve;i h?i ph?i ti&amp;ecirc;u th? nhi?u calo hon trong m?t ng&amp;agrave;y.&lt;/p&gt;
', 1, 1, N'/FileUploads/images/Img-post/UseCaseBook.png', 12, N'nhi', 0, CAST(N'2022-04-19 10:26:01.433' AS DateTime), CAST(N'2022-04-19 10:26:01.433' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (6, N'Tại sao nên ăn theo tháp dinh dưỡng cho người trưởng thành? ', N'&lt;p&gt;Ngu?i tru?ng th&amp;agrave;nh l&amp;agrave; ngu?i ho?t d?ng nhi?u hon ( linh v?c tr&amp;iacute; &amp;oacute;c, ch&amp;acirc;n tay,&amp;hellip;) d&amp;ograve;i h?i ph?i ti&amp;ecirc;u th? nhi?u calo hon trong m?t ng&amp;agrave;y.&lt;/p&gt;

&lt;p&gt;Ch&amp;iacute;nh b?i v?y n&amp;ecirc;n th&amp;aacute;p dinh du?ng d&amp;agrave;nh cho ngu?i tru?ng th&amp;agrave;nh ra d?i nh?m&amp;nbsp;&lt;strong&gt;m?c d&amp;iacute;ch ph&amp;acirc;n lo?i r&amp;otilde; r&amp;agrave;ng, chi ti?t t?ng nh&amp;oacute;m th?c ph?m c? th? v&amp;agrave; dinh du?ng n&amp;ecirc;n n?p v&amp;agrave;o c?a nh&amp;oacute;m n&amp;ecirc;n l&amp;agrave; bao nhi&amp;ecirc;u&lt;/strong&gt;. Con ngu?i cung ghi nh? h&amp;igrave;nh ?nh t?t hon ch? vi?t b?i v?y th&amp;aacute;p dinh du?ng cho ngu?i tru?ng th&amp;agrave;nh tr? th&amp;agrave;nh c&amp;ocirc;ng c?&amp;nbsp;&lt;strong&gt;d? d&amp;agrave;ng &amp;aacute;p d?ng&lt;/strong&gt;.&lt;/p&gt;
', 1, 2, N'/FileUploads/images/Img-post/UseCaseBook.png', 12, N'Nhi', 0, CAST(N'2022-04-19 10:32:57.507' AS DateTime), CAST(N'2022-04-19 10:32:57.507' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (7, N'Tại sao nên ăn theo tháp dinh dưỡng cho người trưởng thành?', N'&lt;p&gt;Ch&amp;iacute;nh b?i v?y n&amp;ecirc;n th&amp;aacute;p dinh du?ng d&amp;agrave;nh cho ngu?i tru?ng th&amp;agrave;nh ra d?i nh?m&amp;nbsp;&lt;strong&gt;m?c d&amp;iacute;ch ph&amp;acirc;n lo?i r&amp;otilde; r&amp;agrave;ng, chi ti?t t?ng nh&amp;oacute;m th?c ph?m c? th? v&amp;agrave; dinh du?ng n&amp;ecirc;n n?p v&amp;agrave;o c?a nh&amp;oacute;m n&amp;ecirc;n l&amp;agrave; bao nhi&amp;ecirc;u&lt;/strong&gt;. Con ngu?i cung ghi nh? h&amp;igrave;nh ?nh t?t hon ch? vi?t b?i v?y th&amp;aacute;p dinh du?ng cho ngu?i tru?ng th&amp;agrave;nh tr? th&amp;agrave;nh c&amp;ocirc;ng c?&amp;nbsp;&lt;strong&gt;d? d&amp;agrave;ng &amp;aacute;p d?ng&lt;/strong&gt;.&lt;/p&gt;
', 1, 1, N'/FileUploads/images/Img-post/UseCaseBook.png', 12, N'Nhi', 0, CAST(N'2022-04-19 10:37:56.607' AS DateTime), CAST(N'2022-04-19 10:37:56.607' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (8, N'hi', N'h?i ch?m h?i ch?m hà d?t h?i ch?m h?i h?i ch?m ch?m chéo', 1, 2, N'/FileUploads/images/Img-post/UseCaseBook.png', 12, N'nha', 0, CAST(N'2022-04-19 11:44:09.473' AS DateTime), CAST(N'2022-04-19 11:44:09.473' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (9, N'hỏi chấm chéo chậm chéo chẻo hỏi hẹ hòa hòa hòa hi hi ảnh ảnh ẻo', N'h?i ch?m chéo ch?m chéo ch?o h?i h? hòa hòa hòa hi hi ?nh ?nh ?o', 1, 1, N'/FileUploads/images/Img-post/UseCaseBook.png', 12, N'hỏi chấm chéo chậm chéo chẻo hỏi hẹ hòa hòa hòa hi hi ảnh ảnh ẻo', 0, CAST(N'2022-04-19 11:57:27.157' AS DateTime), CAST(N'2022-04-19 11:57:27.157' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1006, N'Cảnh giác nguy cơ bội nhiễm nha chu do mắc tay chân miệng', N'&lt;p&gt;&lt;strong&gt;Tay ch&amp;acirc;n mi?ng l&amp;agrave; m?t b?nh l&amp;yacute; kh&amp;aacute; ph? bi?n trong c?ng d?ng, d?c bi?t tr? em l&amp;agrave; d?i tu?ng m?c b?nh chi?m t? l? l?n nh?t. Tr? m?c tay ch&amp;acirc;n mi?ng n?u kh&amp;ocirc;ng du?c di?u tr?, cham s&amp;oacute;c d&amp;uacute;ng c&amp;aacute;ch s? c&amp;oacute; nguy co d?n d?n b?i nhi?m nha chu.&lt;/strong&gt;&lt;/p&gt;

&lt;h2&gt;1. Sai l?m khi cham s&amp;oacute;c tr? b? tay ch&amp;acirc;n mi?ng&lt;/h2&gt;

&lt;p&gt;&amp;nbsp;&lt;/p&gt;

&lt;p&gt;V?n d? tr?m tr?ng nh?t khi tr? b?&amp;nbsp;&lt;strong&gt;tay ch&amp;acirc;n mi?ng&lt;/strong&gt;&amp;nbsp;d&amp;oacute; l&amp;agrave; vi?c xu?t hi?n c&amp;aacute;c n?t ph?ng trong mi?ng khi?n tr? kh&amp;ocirc;ng th? an u?ng du?c. Ð&amp;acirc;y cung ch&amp;iacute;nh l&amp;agrave; di?m khi?n c&amp;aacute;c b&amp;agrave; m? b?n ch?n, lo l?ng kh&amp;ocirc;ng y&amp;ecirc;n. V&amp;igrave; th?, kh&amp;ocirc;ng &amp;iacute;t b&amp;agrave; m? t&amp;igrave;m d? m?i c&amp;aacute;ch can thi?p v?i m?c d&amp;iacute;ch gi&amp;uacute;p c&amp;aacute;c n?t ph?ng nhanh bi?n m?t d? tr? an u?ng du?c. Nhung ch&amp;iacute;nh v&amp;igrave; n&amp;ocirc;n n&amp;oacute;ng, cham s&amp;oacute;c kh&amp;ocirc;ng d&amp;uacute;ng c&amp;aacute;ch, nhi?u tr? m?c&amp;nbsp;&lt;strong&gt;tay ch&amp;acirc;n mi?ng b?i nhi?m&lt;/strong&gt;, c&amp;agrave;ng l&amp;agrave;m tr? dau d?n.&lt;/p&gt;

&lt;p&gt;Sai l?m hay g?p nh?t khi&amp;nbsp;&lt;a href="https://bacsi247.org/chu-de/cham-soc-tre-bi-tay-chan-mieng"&gt;&lt;strong&gt;cham s&amp;oacute;c tr? b? tay ch&amp;acirc;n mi?ng&lt;/strong&gt;&lt;/a&gt;&amp;nbsp;d&amp;oacute; l&amp;agrave; nhi?u ph? huynh d&amp;ugrave;ng khan s?a, g?c d? v? sinh rang mi?ng cho tr?. Khi b? dau v&amp;igrave; c&amp;aacute;c n?t ph?ng, tr? thu?ng kh&amp;ocirc;ng mu?n nu?t nu?c b?t khi?n mi?ng b&amp;eacute; r?t h&amp;ocirc;i. Do kh&amp;ocirc;ng d&amp;aacute;nh rang du?c cho con, nhi?u b&amp;agrave; m? d&amp;atilde; d&amp;ugrave;ng khan s?a, b&amp;ocirc;ng g?c th?m nu?c mu?i r?a rang mi?ng cho tr?. Tuy nhi&amp;ecirc;n kh&amp;ocirc;ng ph?i em b&amp;eacute; n&amp;agrave;o cung ng?i y&amp;ecirc;n cho m? v? sinh rang mi?ng, b&amp;eacute; thu?ng qu?y kh&amp;oacute;c khi?n nguy co ch?m, v? c&amp;aacute;c n?t ph?ng c&amp;agrave;ng tang, l&amp;agrave;m v?t lo&amp;eacute;t th&amp;ecirc;m n?ng, nguy co g&amp;acirc;y b?i nhi?m vi khu?n, n?m nhi?u hon. T&amp;igrave;nh tr?ng n&amp;agrave;y d?n khi?n tr? ti?p t?c dau k&amp;eacute;o d&amp;agrave;i, an u?ng s? c&amp;agrave;ng k&amp;eacute;m di.&lt;/p&gt;

&lt;p&gt;&lt;img alt="ve-sinh-mieng-cho-tre-bi-chan-tay-mieng-2" height="371.81818181818" src="https://bacsi247.org/images/blog/2020-04/15873-canh-giac-nguy-co-boi-nhiem-nha-chu-do-mac-tay-chan-mieng-0.jpg" width="600" /&gt;&lt;/p&gt;

&lt;p&gt;Tr? b? tay ch&amp;acirc;n mi?ng thu?ng c&amp;oacute; xu?t hi?n n?t ph?ng trong mi?ng&lt;/p&gt;

&lt;h2&gt;2. Bi?n ch?ng b?i nhi?m nha chu ? tr? b? tay ch&amp;acirc;n mi?ng&lt;/h2&gt;

&lt;p&gt;&lt;a href="https://bacsi247.org/chu-de/benh-nha-chu"&gt;&lt;strong&gt;B?nh nha chu&lt;/strong&gt;&lt;/a&gt;&amp;nbsp;l&amp;agrave; b?nh l&amp;yacute; vi&amp;ecirc;m nhi?m m&amp;atilde;n t&amp;iacute;nh ? m&amp;ocirc; nu?u v&amp;agrave; m&amp;ocirc; n&amp;acirc;ng d? c?a rang, do c&amp;aacute;c vi khu?n hi?n di?n trong m?ng b&amp;aacute;m rang g&amp;acirc;y n&amp;ecirc;n. Nha chu thu?ng x?y ra sau d?t s?t, v?a gi?m s?t th&amp;igrave; dau mi?ng d? d?i. Khi tr? cu?i c&amp;oacute; th? g&amp;acirc;y ch?y m&amp;aacute;u, hai h&amp;agrave;m rang sung, d? t&amp;iacute;a.&lt;/p&gt;

&lt;p&gt;C&amp;oacute; nhi?u tru?ng h?p tr? b?&amp;nbsp;&lt;strong&gt;b?i nhi?m nha chu&lt;/strong&gt;&amp;nbsp;l&amp;agrave; do b? b? m? v? sinh rang mi?ng theo ki?u th? c&amp;ocirc;ng. C&amp;aacute;c b&amp;aacute;c si dua ra con s? gi?t m&amp;igrave;nh: trong 10 tr? b?&amp;nbsp;&lt;strong&gt;tay ch&amp;acirc;n mi?ng b?i nhi?m nha chu&lt;/strong&gt;&amp;nbsp;th&amp;igrave; c&amp;oacute; t?i 9 tru?ng h?p l&amp;agrave; do m? lau mi?ng, c? rang cho b&amp;eacute; b?ng g?c.&lt;/p&gt;

&lt;p&gt;Th?c t? khi kh&amp;aacute;m ch?a b?nh cho tr? tay ch&amp;acirc;n mi?ng, c&amp;aacute;c b&amp;aacute;c si ghi nh?n nhi?u tr? b? bi?n ch?ng&amp;nbsp;&lt;strong&gt;vi&amp;ecirc;m nha chu&lt;/strong&gt;&amp;nbsp;do c&amp;aacute;ch cham s&amp;oacute;c n&amp;agrave;y c?a ngu?i th&amp;acirc;n. Tr? h?t c&amp;aacute;c v?t lo&amp;eacute;t trong mi?ng r?i nhung v?n kh&amp;ocirc;ng an du?c v&amp;igrave; hai h&amp;agrave;m rang, l?i b? vi&amp;ecirc;m d? r?c, th?m ch&amp;iacute; ch?y m&amp;aacute;u v&amp;agrave; khi?n b&amp;aacute;c si bu?c ph?i d&amp;ugrave;ng th&amp;ecirc;m kh&amp;aacute;ng sinh.&lt;/p&gt;

&lt;p&gt;Cung c&amp;oacute; tr? b? tay b?i nhi?m n?m mi?ng cung v&amp;igrave; h&amp;agrave;nh vi lau mi?ng cho tr? b?ng khan s?a, g?c d&amp;atilde; dua n?m ? b&amp;ecirc;n ngo&amp;agrave;i v&amp;agrave;o mi?ng tr?. Ði?u n&amp;agrave;y kh&amp;ocirc;ng ch? khi?n tr? ph?i u?ng kh&amp;aacute;ng sinh m&amp;agrave; t&amp;igrave;nh tr?ng vi&amp;ecirc;m nha chu c&amp;ograve;n khi?n tr? ti?p t?c dau d?n, an u?ng s? c&amp;agrave;ng k&amp;eacute;m di.&lt;/p&gt;

&lt;p&gt;&lt;img alt="Thu?c h? tr? tr? b?nh tay - chân - mi?ng ? tr? em" height="317.14285714286" src="https://bacsi247.org/images/blog/2020-04/15873-canh-giac-nguy-co-boi-nhiem-nha-chu-do-mac-tay-chan-mieng-1.jpg" width="600" /&gt;&lt;/p&gt;

&lt;p&gt;B?nh nha chu ? tr? b? m?c b?nh ch&amp;acirc;n tay mi?ng ch? y?u l&amp;agrave; do cham s&amp;oacute;c cho tr? kh&amp;ocirc;ng d&amp;uacute;ng c&amp;aacute;ch&lt;/p&gt;

&lt;h2&gt;3. Cham s&amp;oacute;c tr? b? tay ch&amp;acirc;n mi?ng d&amp;uacute;ng c&amp;aacute;ch ph&amp;ograve;ng ng?a b?i nhi?m&lt;/h2&gt;

&lt;p&gt;&amp;nbsp;&lt;/p&gt;

&lt;p&gt;Qu&amp;aacute; tr&amp;igrave;nh cham s&amp;oacute;c tr? b?&amp;nbsp;&lt;strong&gt;tay ch&amp;acirc;n mi?ng&lt;/strong&gt;&amp;nbsp;gi&amp;uacute;p ph&amp;ograve;ng ng?a c&amp;aacute;c bi?n ch?ng nguy hi?m ? tr? c?n tu&amp;acirc;n th? c&amp;aacute;c hu?ng d?n sau:&lt;/p&gt;

&lt;ul&gt;
	&lt;li&gt;Ch? cho tr? u?ng thu?c h? s?t khi b&amp;eacute; s?t tr&amp;ecirc;n 38.5 d? C. C&amp;oacute; b&amp;eacute; ch? h&amp;acirc;m h?p s?t nhung n?u qu&amp;aacute; dau, c?n tr? an u?ng c&amp;oacute; th? d&amp;ugrave;ng thu?c h? s?t d? gi?m dau theo d&amp;uacute;ng hu?ng d?n, 4 - 6 ti?ng/l?n theo li?u lu?ng d?a tr&amp;ecirc;n c&amp;acirc;n n?ng c?a tr?. Ngo&amp;agrave;i ra, c&amp;oacute; th? b&amp;ocirc;i c&amp;aacute;c thu?c g&amp;acirc;y t&amp;ecirc; b? m?t, s&amp;aacute;t khu?n mi?ng nhu don c?a b&amp;aacute;c si tru?c b?a an kho?ng 15 ph&amp;uacute;t, gi&amp;uacute;p gi?m dau v&amp;agrave; b&amp;eacute; s? an u?ng d? hon.&lt;/li&gt;
	&lt;li&gt;Ð?i v?i vi?c v? sinh mi?ng, t?t nh?t ch? s? d?ng nu?c mu?i sinh l&amp;yacute; d? s&amp;uacute;c mi?ng cho tr? sau m?i l?n an, tru?c khi di ng?, sau ng? d?y. Cha m? cung kh&amp;ocirc;ng n&amp;ecirc;n qu&amp;aacute; lo l?ng khi th?y mi?ng con c&amp;oacute; m&amp;ugrave;i h&amp;ocirc;i, lu?i ph?ng r?p m&amp;agrave; c? d&amp;ugrave;ng g?c d? &amp;ldquo;c?o&amp;rdquo; c&amp;aacute;c n?t r?p tr?ng, di?u n&amp;agrave;y r?t nguy hi?m v&amp;igrave; d? d?n d?n tay ch&amp;acirc;n mi?ng b?i nhi?m. Mi?ng tr? c&amp;oacute; co ch? t? l&amp;agrave;m s?ch, cha m? h&amp;atilde;y c? g?ng khuy?n kh&amp;iacute;ch tr? u?ng nu?c, s&amp;uacute;c mi?ng b?ng nu?c mu?i... d? l&amp;agrave;m s?ch rang mi?ng.&lt;/li&gt;
	&lt;li&gt;Khi b&amp;eacute; dau, c&amp;aacute;c m? n&amp;ecirc;n cho con an t?ng ch&amp;uacute;t m?t. S? d?ng c&amp;aacute;c th?c ph?m d? ngu?i, n?u lo&amp;atilde;ng nhu ch&amp;aacute;o, s&amp;uacute;p, s?a... Tang cu?ng c&amp;aacute;c lo?i nu?c hoa qu? gi&amp;agrave;u vitamin C d? tang s?c d? kh&amp;aacute;ng cho tr?. Tuy nhi&amp;ecirc;n kh&amp;ocirc;ng n&amp;ecirc;n k? v?ng con an u?ng gi?ng nhu ng&amp;agrave;y thu?ng, lu?ng th?c an ch?c ch?n s? b? gi?m (th?m ch&amp;iacute; chua du?c m?t n?a so v?i b&amp;igrave;nh thu?ng), khi d&amp;oacute; c&amp;aacute;c m? cung kh&amp;ocirc;ng qu&amp;aacute; s?t ru?t, kh&amp;ocirc;ng &amp;eacute;p b&amp;eacute; an b?ng du?c v&amp;igrave; b&amp;eacute; b? dau, khi nh&amp;igrave;n th?y d? an s? c&amp;agrave;ng s? h&amp;atilde;i hon, c&amp;agrave;ng kh&amp;ocirc;ng &amp;quot;h?p t&amp;aacute;c&amp;quot; v?i m? nhi?u hon.&lt;/li&gt;
&lt;/ul&gt;

&lt;p&gt;&lt;strong&gt;B?nh tay ch&amp;acirc;n mi?ng&lt;/strong&gt;&amp;nbsp;khi du?c cham s&amp;oacute;c d&amp;uacute;ng c&amp;aacute;ch, th&amp;ocirc;ng thu?ng sau 3 - 4 ng&amp;agrave;y b?nh s? kh?i, tr? s? an u?ng tr? l?i b&amp;igrave;nh thu?ng.&lt;/p&gt;
', 1, 1, NULL, 12, N'Răng', 0, CAST(N'2022-04-19 16:52:40.683' AS DateTime), CAST(N'2022-04-19 16:52:40.683' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1008, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-21 06:16:10.380' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1009, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 01:34:55.760' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1010, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 01:53:29.747' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1011, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-21 06:15:30.863' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1012, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 01:53:49.877' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1013, N'hello', N'<p>hello</p>', 0, 1, N'/FileUploads/images/Img-post/9-cach-chua-covid.jpg', 12, N'nhi', 0, CAST(N'2022-04-21 11:16:32.283' AS DateTime), CAST(N'2022-04-21 11:16:32.283' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1014, N'hello', N'<p>&lt;script&gt;alert(hello)&lt;/script&gt;</p>', 0, 1, N'/FileUploads/images/Img-post/UseCaseBook.png', 12, N'nhi', 0, CAST(N'2022-04-21 11:17:02.747' AS DateTime), CAST(N'2022-04-21 11:17:02.747' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1015, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 02:36:17.350' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1016, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 01:53:11.203' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1017, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 01:34:41.527' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1018, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 02:35:21.450' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1019, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 02:41:49.993' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1020, NULL, NULL, 0, 1, NULL, 12, NULL, 0, CAST(N'2022-04-22 02:38:11.987' AS DateTime), CAST(N'2022-04-22 02:38:11.987' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1021, N'Israel ghi nhận 12 trẻ viêm gan cấp tính bí ẩn', N'<p>Bộ Y tế Israel ngày 20/4 báo cáo 12 ca viêm gan cấp tính nặng, chưa rõ nguyên nhân ở trẻ em dưới 5 tuổi.</p><p>Hầu hết các ca nhiễm xảy ra trong những tháng gần đây, theo đó hai em phải cấy ghép thùy gan từ cha mẹ. Bộ Y tế đã phát thông báo đến bác sĩ trên khắp đất nước, yêu cầu theo dõi chặt chẽ các ca viêm gan cấp tính không rõ nguyên nhân ở bệnh nhi, đồng thời báo cáo các trường hợp này đến giới chức.</p><p>7 ca nhiễm, bao gồm hai ca cấy ghép, ghi nhận tại Trung tâm Y tế Trẻ em Schneider ở Petah Tikva. 5 trường hợp khác tại Trung tâm Y tế Shaare Zedek (SZMC) ở Jerusalem. Cả hai cơ sở y tế đều tiếp nhận những bệnh nhi đến từ nhiều vùng khác nhau của đất nước, không có mối liên quan về chủng tộc hay tôn giáo cụ thể nào.</p><p>Hiện tất cả các bệnh nhân đã xuất viện, theo tiến sĩ Eyal Shteyer, Giám đốc chuyên khoa Gan tại Trung tâm Y tế Shaare Zedek. Bộ Y tế thông báo các ca viêm gan xảy ra trong "vài tháng qua". Tuy nhiên, tiến sĩ Shteyer cho biết những trường hợp này được ghi nhận từ một năm trước.</p><p>Các bệnh nhi không nhiễm một trong 5 virus viêm gan phổ biến là A, B C, D, E. Triệu chứng lâm sàng của các em được xác định là viêm gan cấp tính, với men gan tăng rõ rệt, thường kèm theo vàng da, đôi khi xuất hiện các vấn đề tiêu hóa.</p><p>"Đã có khoảng<a href="https://vnexpress.net/suc-khoe/virus-bi-an-gay-viem-gan-lan-ra-nhieu-nuoc-4453566.html"> 50 trường hợp tương tự ở khắp các nước châu Âu</a>, thật kỳ lạ. Chúng tôi không biết nguyên nhân dẫn đến tình trạng này. Nhưng cộng đồng không cần hoảng sợ, các ca viêm gan còn rất hiếm", tiến sĩ Schneider nói.</p><p>Kể từ khi bùng phát ở Anh, bệnh viêm gan đã lan sang nhiều nước như Mỹ, Đan Mạch, Ireland, Hà Lan và Tây Ban Nha. Alabama báo cáo 9 trường hợp ở trẻ dưới 10 tuổi. Các em trải qua những triệu chứng đường tiêu hóa, mức độ tổn thương gan khác nhau, gồm cả suy gan.</p><p><img src="https://i1-suckhoe.vnecdn.net/2022/04/21/vie-m-gan-1650506496-9529-1650506599.png?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=DY5yXfXnsK2FYztMLGH7oQ" alt="Virus viêm gan A gây viêm gan cấp tính, dạng phổ biến nhất của viêm gan do virus. Ảnh: Flickr"></p><p>Virus viêm gan A gây viêm gan cấp tính, dạng phổ biến nhất của viêm gan do virus. Ảnh: <i>Flickr</i></p><p>Trong các ca viêm gan có một số em mắc Covid-19 hoặc adenovirus - một loại virus cảm lạnh. Cơ quan An ninh Y tế Anh trước đó cũng nghi ngờ các em nhiễm nCoV hoặc một loại bệnh nhiễm trùng khác, sau đó tiến triển thành viêm gan. Tuy nhiên, nhiều chuyên gia cho rằng Covid-19 không phải nguyên nhân gây ra tình trạng viêm gan ở trẻ.</p><p>Các nhà khoa học khác tin rằng adenovirus là thủ phạm gây viêm gan. Adenovirus thường để lại triệu chứng đỏ mắt, đau họng hoặc tiêu chảy. Song, nhiều bác sĩ khác nhận định adenovirus khá phổ biến, việc tìm thấy loại virus này trong các mẫu bệnh phẩm không có nghĩa chúng là nguyên nhân gây ra viêm gan.</p><p>Trung tâm Phòng ngừa và Kiểm soát Dịch bệnh Châu Âu (ECDC) không loại trừ giải thuyết bệnh nhân tiếp xúc với chất độc. Cơ quan đang nỗ lực xác nhận thói quen cá nhân và đồ ăn, thức uống các em sử dụng trong thời gian gần đây.</p>', 0, 2, N'/FileUploads/images/Img-post/cg2a0388-1650467607-3072-1650467632.jpg', 12, N'Nhi', 1, CAST(N'2022-04-22 02:46:43.120' AS DateTime), CAST(N'2022-04-22 02:46:43.120' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1022, NULL, NULL, NULL, NULL, NULL, 12, NULL, 0, NULL, CAST(N'2022-04-22 02:51:27.223' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1023, N'Khối u quái khổng lồ ở buồng trứng bé gái 12 tuổi', N'<p>QUẢNG NINHBé gái đau tức nhiều vùng hạ vị, bác sĩ phát hiện có khối u quái nặng 2 kg ở buồng trứng phải, rất hiếm gặp với trẻ nhỏ.</p><p>Bác sĩ Vũ Xuân Kiên, Trưởng khoa Ung bướu, Bệnh viện Đa khoa tỉnh Quảng Ninh, ngày 21/4 cho biết đây là trường hợp khá hy hữu bởi bé mới 12 tuổi, chưa dậy thì, nhưng khối u buồng trứng rất to. Do bé cao lớn phổng phao, người nhà không nhận thấy vùng bụng của con tăng kích thước bất thường, đến khi có dấu hiệu đau tức nhiều mới đi khám thì u đã lớn.</p><p>Theo bác sĩ Kiên, khối u quái có nguồn gốc từ các tế bào mầm biệt hóa, với cấu trúc là các loại bã nhờn, xương, tóc, da... Bệnh viện hội chẩn quyết định mổ, tuy nhiên bé còn nhỏ trong khi khối u lớn, kíp phẫu thuật phải chuẩn bị phương án dự phòng truyền máu, bóc tách u triệt để, hạn chế tình trạng chảy máu, tránh gây tổn thương cho cơ thể bé gái còn đang phát triển.</p><p>Sau phẫu thuật, bé đang được theo dõi sức khỏe.</p><p><img src="https://i1-suckhoe.vnecdn.net/2022/04/21/0M7A1200-9843-1650514414.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=-w2XTjkDfz005-VEPZ0GZQ" alt="Hình ảnh chụp cắt lớp khối u buồng trứng kích thước lớn ở bé gái 12 tuổi. Ảnh: Bệnh viện cung cấp"></p><p>Hình ảnh chụp cắt lớp khối u buồng trứng kích thước lớn ở bé gái 12 tuổi. Ảnh: <i>Bệnh viện cung cấp</i></p><p>U buồng trứng thường lành tính, tuy nhiên nếu không phát hiện kịp thời, u phát triển quá lớn có thể gây ra các biến chứng nguy hiểm như xoắn nang, vỡ u nang, thậm chí ảnh hưởng khả năng sinh sản và dẫn đến ung thư... Nhóm dễ mắc u buồng trứng là phụ nữ trong độ tuổi sinh sản, trên 20 tuổi, ít gặp ở trẻ nhỏ.</p><p>Theo bác sĩ, u buồng trứng ở bé gái thường khó phát hiện ở giai đoạn mới hình thành hoặc đang phát triển bởi triệu chứng âm thầm. Bệnh dễ nhầm lẫn với bệnh lý khác, khó phát hiện sớm. Do đó, khi trẻ có các biểu hiện đau tức vùng hạ vị, bụng to bất thường, nên đến bệnh viện khám, phát hiện sớm và điều trị triệt để, giúp bảo tồn chức năng sinh sản, tránh biến chứng ác tính sau này.</p>', 0, 1, N'/FileUploads/images/Img-post/0M7A1200-9843-1650514414.jpg', 12, N'Nhi', 1, CAST(N'2022-04-22 02:52:39.750' AS DateTime), CAST(N'2022-04-22 02:52:39.750' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1024, N'Hơn 1.000 ca ghép thận trong 30 năm', N'<p>TP HCMBệnh viện Chợ Rẫy ghép thận thành công cho 1.030 trường hợp trong 30 năm qua, chiếm gần 1/5 số ca ghép thận trên cả nước.</p><p>Phó giáo sư, tiến sĩ Thái Minh Sâm, Trưởng Khoa Ngoại Tiết niệu, Bệnh viện Chợ Rẫy, chia sẻ thông tin trên tại hội nghị khoa học thường niên của bệnh viện, ngày 21/4 và cho biết thêm riêng từ năm 2016 đến nay đã ghép hơn 500 ca thận, tức trong vòng 6 năm qua tăng gấp đôi số ca ghép so với giai đoạn trước.</p><p>Điều này cho thấy nhu cầu ghép thận ngày càng tăng, các bác sĩ Việt Nam cũng ngày càng nắm vững kỹ thuật ghép thận. Hầu hết ca ghép thận đều thành công, phần lớn từ nguồn hiến là người còn sống.</p><p>Ghép thận đã trở thành kỹ thuật thường quy tại Chợ Rẫy. Theo phó giáo sư Sâm, ghép thận là phương pháp điều trị hiệu quả, chất lượng cao, chi phí thấp so với các phương pháp như chạy thận nhân tạo, lọc màng bụng cho bệnh nhân suy thận mạn giai đoạn cuối. Với sự ra đời của nhiều thuốc mới, tỷ lệ thải ghép sau ghép thận giảm dần theo thời gian, giúp bệnh nhân có cuộc sống ngày càng chất lượng. Nhiều người sau khi ghép thận đã lập gia đình, sinh con khỏe mạnh. Hơn 300 em bé đã chào đời từ người từng ghép thận. Nhiều người trên 60 tuổi ghép thận cũng đạt kết quả rất tốt.</p><p>Những ca ghép thận đầu tiên từ năm 1992, bệnh viện được sự hỗ trợ của chuyên gia nước ngoài. Đến năm 1998, các bác sĩ Việt Nam tự lực triển khai. Sau 101 ca lấy thận từ người hiến sống bằng phương pháp mổ hở, từ năm 2004 đến nay các ca lấy thận đều được mổ nội soi, trong đó 36 ca phẫu thuật bằng robot.</p><p><img src="https://i1-suckhoe.vnecdn.net/2022/04/21/screen-shot-2022-01-21-at-11-0-3182-7477-1650526849.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=B_Rf8Dl4YjuBbWSreZWX6w" alt="Các y bác sĩ mổ nội soi lấy thận ghép tại Bệnh viện Chợ Rẫy. Ảnh: Bệnh viện cung cấp"></p><p>Các y bác sĩ mổ nội soi lấy thận ghép tại Bệnh viện Chợ Rẫy. Ảnh: <i>Bệnh viện cung cấp</i></p><p>Năm 2008, Bệnh viện Chợ Rẫy thực hiện ca ghép thận từ người hiến chết não đầu tiên Việt Nam. Đến năm 2015, nơi này tiên phong ghép thận thành công cho hai người nhận từ người cho <a href="https://vnexpress.net/ca-ghep-than-tu-nguoi-cho-ngung-tim-duoc-trao-giai-nhan-tai-dat-viet-3671973.html">tim ngừng đập</a>, mở ra một nguồn tạng hiến mới để tăng số lượng tạng hiến tại Việt Nam. Năm 2017, bệnh viện lần đầu <a href="https://vnexpress.net/hai-gia-dinh-doi-than-cuu-con-trong-ca-ghep-cheo-lan-dau-tai-vn-3537532.html">ghép thận chéo</a> (đổi người hiến) và năm 2021 thực hiện ca ghép <a href="https://vnexpress.net/lan-dau-viet-nam-ghep-than-khong-cung-nhom-mau-4419090.html">không cùng nhóm máu</a> đầu tiên cả nước. Trong đó, ghép thận chéo đòi hỏi phải có số lượng bệnh nhân lớn, rất ít trung tâm trong nước cũng như trên thế giới làm được.</p><p>Theo phó giáo sư Sâm, Việt Nam đã làm chủ được các kỹ thuật ghép thận, vấn đề lớn tồn tại hiện nay là thiếu hụt nguồn thận ghép, trong khi nhu cầu ghép rất cao. "Trong số các ca ghép, nguồn tạng từ người cho sống là chủ yếu, người hiến chết não, ngừng tim chiếm khoảng 5%", ông nói.</p><p>Sự ra đời của đơn vị điều phối ghép tạng đã góp phần tăng nguồn hiến từ người cho chết não thời gian qua, nhưng vẫn còn khá thấp. Tại nhiều nước, nguồn hiến từ người chết não chiếm gần một nửa, giúp nhiều người bệnh có được nguồn tạng để ghép. Phát triển nguồn tạng hiến người chết đang là mô hình các hội ghép tạng trên thế giới và Việt Nam hướng đến.</p>', 0, 1, N'/FileUploads/images/Img-post/screen-shot-2022-01-21-at-11-0-3182-7477-1650526849.jpg', 12, N'nhi', 1, CAST(N'2022-04-22 02:55:21.453' AS DateTime), CAST(N'2022-04-22 02:55:21.453' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1025, N'Siemens Healthineers ký kết hợp tác nghiên cứu ứng dụng AI về ung thư vú', N'<p>Siemens Healthineers, Bệnh viện Đại học Y Hà Nội và Hội Chẩn đoán hình ảnh xuyên biên giới hợp tác nghiên cứu ứng dụng trí tuệ nhân tạo chẩn đoán ung thư vú.</p><p>Hợp tác nghiên cứu sẽ tập trung phân tích ứng dụng trí tuệ nhân tạo trong chẩn đoán ung thư vú, nhất là tầm soát sớm ung thu vú tại Việt Nam.</p><p>PGS.TS.BS Nguyễn Lân Hiếu (Giám đốc Bệnh viện Đại học Y Hà Nội) đánh giá cao mối quan hệ hợp tác giữa các đơn vị. Phó giáo sư Hiếu cho biết, Bệnh viện Đại học Y Hà Nội mỗi năm tiếp nhận hàng nghìn bệnh nhân tới thăm khám và điều trị các bệnh về tuyến vú. Khối lượng công việc, áp lực về thời gian xử lý và độ chính xác trong chẩn đoán đối với các nhân viên y tế rất lớn.</p><p>"Để giảm tải áp lực cho nhân viên y tế đồng thời nâng cao chất lượng dịch vụ chăm sóc sức khỏe cho bệnh nhân, việc áp dụng công nghệ tiên tiến như AI là cần thiết. Hợp tác nghiên cứu cùng Siemens Healthineers và RAB có ý nghĩa rất lớn, kiến thức y khoa tiên tiến sẽ được đưa đến phục vụ người dân Việt Nam", Phó giáo sư Hiếu nói.</p><p><img src="https://i1-suckhoe.vnecdn.net/2022/04/21/Le-ky-ket-8114-1650529161.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=ySlT9WGNNr8a2MK6QAJcKg" alt="Ông Fabrice Leguet và PGS.TS.BS Nguyễn Lân Hiếu ký kết biên bản ghi nhớ về hợp tác nghiên cứu ứng dụng AI-RAD Companion trong X-quang vú tại Việt Nam."></p><p>Ông Fabrice Leguet và PGS.TS.BS Nguyễn Lân Hiếu ký kết biên bản ghi nhớ về hợp tác nghiên cứu ứng dụng AI-RAD Companion trong X-quang vú tại Việt Nam.</p><p>Ông Fabrice Leguet, Giám đốc điều hành Siemens Healthineers khu vực Đông Nam Á cho biết thêm: "Siemens Healthineers hợp tác nghiên cứu và đồng hành cùng một trong những bệnh viện đa khoa hàng đầu như Bệnh viện Đại học Y Hà Nội cùng Hội Chẩn đoán hình ảnh xuyên biên giới. Thông qua hợp tác nghiên cứu này, chúng tôi muốn chứng minh rằng AI có thể hỗ trợ đắc lực cho tầm soát ung thư sớm và phát hiện chính xác các dấu hiệu bất thường ở tuyến vú, giảm tải khối lượng công việc cho các chuyên gia, bác sĩ, từ đó, giúp người bệnh có trải nghiệm thăm khám tốt hơn".</p><p>Siemens Healthineers sẽ cung cấp giải pháp Transpara Breast AI cho Bệnh viện Đại học Y Hà Nội. Hợp tác nghiên cứu sẽ tiến hành trong vòng 24 tháng có thể kéo dài thêm 12 tháng và sẽ được thực hiện với sự tư vấn chuyên môn của Hội chẩn đoán hình ảnh xuyên biên giới. RAB sẽ hỗ trợ thiết lập và chạy thử nghiệm nghiên cứu cũng như đưa ra các khuyến cáo lâm sàng chuyên sâu về hình ảnh tuyến vú.</p><p><img src="https://i1-suckhoe.vnecdn.net/2022/04/21/030-9628-1650528707.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=sVQCERWcS-nmhb232yfz3A" alt="Toàn cảnh đại diện các bên trong lễ ký kết về hợp tác nghiên cứu ứng dụng AI-RAD Companion trong X-quang vú tại Việt Nam vào ngày 20/4."></p><p>Toàn cảnh đại diện các bên trong lễ ký kết về hợp tác nghiên cứu ứng dụng AI-RAD Companion trong X-quang vú tại Việt Nam vào ngày 20/4.</p><p>Tầm soát phát hiện sớm ung thư vú cho phép người bệnh có thêm các lựa chọn điều trị, tăng tỷ lệ điều trị thành công và cải thiện chất lượng cuộc sống cho người bệnh. Một trong những biện pháp tầm soát thường được sử dụng là chụp nhũ ảnh. Chụp nhũ ảnh là kỹ thuật chụp X-Quang dành cho tuyến vú, được dùng để hỗ trợ chẩn đoán các bệnh lý tuyến vú ở phụ nữ. Kỹ thuật này cho phép phân tích cấu trúc tuyến vú để tìm ra những thay đổi bên trong tuyến vú mà việc thăm khám bằng tay không phát hiện được.</p><p>Theo Hội Điện quang Bắc Mỹ (RSNA), ứng dụng những công nghệ hiện đại như trí tuệ nhân tạo (AI) có thể giúp nâng cao hiệu suất tầm soát qua việc tăng tỷ lệ phát hiện ung thư vú. Mặc dù AI không thể thay thế được các bác sĩ chẩn đoán hình ảnh nhưng áp dụng công nghệ này sẽ giúp giảm thiểu thời gian đọc phim X-Quang nhũ ảnh, cho phép các chuyên gia tập trung hơn vào các trường hợp nghi ngờ, cải thiện hiệu quả chẩn đoán.</p><p>Hợp tác nghiên cứu hướng đến là ngày càng có nhiều bác sĩ chẩn đoán hình ảnh được đào tạo chuyên môn phù hợp và sử dụng AI giúp giảm tải khối lượng công việc, tăng cường khả năng chẩn đoán ung thư vú, từ đó gia tăng phát hiện ung thư vú sớm, nâng cao chất lượng đời sống cho phụ nữ Việt Nam.</p><p>Theo ước tính của Globocan năm 2020, tại Việt Nam ghi nhận khoảng 21.555 ca mắc mới ung thư vú với hơn 9.000 ca tử vong. Ung thư vú cũng là một trong những nguyên nhân gây tử vong hàng đầu cho phụ nữ trên thế giới, hầu như xảy ra với rất ít dấu hiệu biểu hiện bệnh.</p>', 0, 2, N'/FileUploads/images/Img-post/Le-ky-ket-8114-1650529161.jpg', 12, N'Nhi', 1, CAST(N'2022-04-22 02:57:03.050' AS DateTime), CAST(N'2022-04-22 02:57:03.050' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1026, N'Chiều nay tư vấn trực tuyến về phục hồi thể chất, tinh thần cho trẻ hậu Covid-19', N'<p>Các chuyên gia về bệnh truyền nhiễm, dinh dưỡng và tâm lý sẽ tư vấn trực tuyến về các giải pháp phục hồi thể chất, tinh thần cho trẻ dưới 3 tuổi hậu Covid-19.</p><p>Chương trình Tư vấn trực tuyến "Bù đắp thể chất, tinh thần cho trẻ dưới 3 tuổi hậu Covid-19" do báo <i>VnExpress </i>phối hợp với nhãn hàng Lineabon D3K2 tổ chức, phát sóng lúc 14h ngày 21/4 trên <i>VnExpress </i>và tiếp sóng trên fanpage Lineabon.</p><p>Chương trình có sự tham gia của Bác sĩ Trương Hữu Khanh, cố vấn khối bệnh Nhiễm - Bệnh viện Nhi đồng 1 TP HCM; Tiến sĩ - Bác sĩ chuyên khoa II Nguyễn Thị Thu Hậu, Trưởng Khoa Dinh Dưỡng - Bệnh viện Nhi đồng 2 TP HCM, Tiến sĩ - Bác sĩ Đinh Thạc, Trưởng Khoa Tâm lý, Bệnh viện Nhi đồng 1 TP HCM và ông Đoàn Văn Toản - Giám đốc phát triển thương hiệu công ty dược phẩm Revopharma.</p><p><strong>Độc giả đặt câu hỏi </strong><a href="https://vnexpress.net/tu-van-truc-tuyen-phuc-hoi-the-chat-tinh-than-cho-tre-duoi-3-tuoi-hau-covid-19-4453703.html"><strong>tại đây</strong></a></p><p><img src="https://i1-suckhoe.vnecdn.net/2022/04/21/278846428-1426117177889608-877-4977-2161-1650507724.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=ErhAFEvkHNJXeEHxQ20jPg" alt="Các chuyên gia tham gia chương trình tư vấn trực tuyến Bù đắp thể chất, tinh thần cho trẻ dưới 3 tuổi hậu Covid-19 lúc 14h ngày 21/4."></p><p>Các chuyên gia tham gia chương trình tư vấn trực tuyến "Bù đắp thể chất, tinh thần cho trẻ dưới 3 tuổi hậu Covid-19" lúc 14h ngày 21/4.</p><p>Theo Bộ Y tế, khoảng 55% trẻ mắc Covid-19 không triệu chứng, triệu chứng nhẹ, có triệu chứng viêm hô hấp hoặc tiêu hóa, 40% mức độ trung bình và 4% nặng, nguy kịch. Dù tỷ lệ tử vong ở trẻ mắc Covid-19 không cao so với người lớn, song bệnh vẫn có thể ảnh hưởng không nhỏ và lâu dài đến thể chất, tinh thần trẻ. Nhiều trẻ mắc Covid-19 nhẹ, nhanh khỏi nhưng lại gặp các triệu chứng hậu Covid-19 như viêm đa hệ thống, loạn khứu giác, não sương mù, mệt mỏi...</p><p>Nhiều nghiên cứu trên thế giới cho thấy khoảng 20 - 40% trẻ em và trẻ vị thành niên có biểu hiện hội chứng hậu Covid-19. Theo WHO, hậu Covid-19 có thể xảy ra ở bất kỳ trẻ nào, kể cả những trẻ trước đó mắc Covid-19 không có triệu chứng, triệu chứng nhẹ hoặc nặng. Các chuyên gia cũng chỉ ra rằng, trẻ lớn, trẻ có tiền sử dị ứng, trẻ mắc Covid-19 mức độ nặng, điều trị hồi sức có nguy cơ cao bị Covid-19 kéo dài.</p><p>Hậu Covid-19 có thể gây ảnh hưởng tới hầu hết các cơ quan trong cơ thể từ hệ thần kinh tới hô hấp, gây ho dai dẳng, khó thở, đau đầu, mất ngủ, rối loạn vị giác, khứu giác... Bên cạnh đó là biểu hiện rối loạn cảm xúc, kém tập trung, giảm trí nhớ, khó khăn trong học tập..</p><p>Trầm cảm ở trẻ em cũng là một triệu chứng của rối loạn lo âu do Covid-19. Nguyên nhân có thể do lo âu có trước khi mắc Covid-19, chiếm khoảng 8%, cách ly xã hội trong thời gian mắc bệnh, nằm viện dài ngày, mặc cảm với những người xung quanh, sợ lây truyền bệnh cho người khác, không chắc chắn có khỏi Covid-19...</p><p>Hiện chưa có con số chính xác về tỷ lệ mắc hậu Covid-19 ở trẻ em. Có những trường hợp trẻ mắc Covid-19 đã khỏi nhưng sau 2 tuần, thậm chí như trường hợp một bé gái ở Hà Nội là sau 2 tháng phải nhập viện do sốt cao 39 độ, khó thở, co giật... Điều này khiến không ít phụ huynh lo lắng, đặc biệt với trẻ dưới 3 tuổi hệ miễn dịch còn non yếu và chưa biết diễn tả rõ các triệu chứng bằng lời.</p><p>Việc theo dõi sức khỏe thể chất và tinh thần của trẻ hậu Covid-19 như thế nào, trẻ cần chế độ dinh dưỡng và vận động ra sao để phục hồi thể trạng hậu Covid-19 là những vấn đề đang rất được các bậc phụ huynh quan tâm. Đặc biệt, phụ huynh cần bổ sung các vi chất nào để phục hồi và tăng cường miễn dịch cho trẻ sẽ được các chuyên gia thảo luận và chia sẻ trong chương trình tư vấn trực tuyến chiều nay.</p>', 0, 2, N'/FileUploads/images/Img-post/278846428-1426117177889608-877-4977-2161-1650507724.jpg', 12, N'Nhi', 1, CAST(N'2022-04-22 02:58:40.603' AS DateTime), CAST(N'2022-04-22 02:58:40.603' AS DateTime))
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Type], [SpecializationId], [Image], [AccountId], [Tag], [Status], [CreatedAt], [UpdatedAt]) VALUES (1027, N'Ca hóc xương cá hiếm gặp', N'<p>Bác sĩ Nguyễn Thanh Vinh, Phó giám đốc Bệnh viện Tai Mũi Họng TP HCM, ngày 20/4 cho biết đây là trường hợp khá đặc biệt và hiếm gặp. Thông thường, khi ăn uống bị hóc, dị vật qua đường miệng sẽ di chuyển theo hai hướng, một là xuống thực quản gây những biến chứng ở đường tiêu hóa; một số ít lọt vào đường thở, nguy hiểm hơn, dễ ảnh hưởng tính mạng. Với bệnh nhân này, dị vật lại cắm vào dây thanh quản gây khàn tiếng, khó nói chuyện; xét nghiệm sinh hóa máu cho thấy rối loạn dung nạp đường huyết.</p><p>Người này bị hóc xương khi đang ăn cá điêu hồng, ho sặc sụa tím tái. Sau đó, ông không đau, không khó thở nhưng khàn tiếng, ho, nuốt vướng, bác sĩ bệnh viện ở Long An không xử lý được nên đến Bệnh viện Tai Mũi Họng TP HCM.</p><p>Bác sĩ Lê Hồ Băng Tâm, Bệnh viện Tai Mũi Họng, cho biết bệnh nhân cần phẫu thuật cấp cứu lấy dị vật đường thở ngay, không thể chờ đợi kết quả xét nghiệm PCR Covid-19 (thường mất 24 giờ) nên phòng mổ nội soi được thiết lập trong khu vực cách ly riêng. Ca này cũng khó xử lý do dị vật nằm ngay cửa đường thở là thanh môn, dụng cụ nội soi gắp xương dễ gây phản xạ ngạt thở nguy hiểm.</p><p>Sử dụng ống mềm nội soi, ê kíp bác sĩ cuối cùng gắp thành công mảnh xương cá kích thước 3,5 cm. Sau phẫu thuật, bệnh nhân giảm triệu chứng nuốt đau, khàn tiếng.</p><p><img src="https://i1-suckhoe.vnecdn.net/2022/04/20/xu-o-ng-ca-1650438289-5354-1650438679.png?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=ykBpI32zHYd6kt-Jrm7bww" alt="Xương cá được gắp ra ngoài. Ảnh: Bệnh viện Tai Mũi Họng TP HCM"></p><p>Mảnh xương cá được gắp khỏi thanh quản bệnh nhân. Ảnh: <i>Bệnh viện Tai Mũi Họng TP HCM</i></p><p>Dị vật đường thở có thể xảy ra ở mọi lứa tuổi, trẻ em thường bị hóc đồ chơi kích thước nhỏ, hạt, xương trong cháo ăn dặm, sặc sữa... Người lớn hóc do ăn uống không cẩn thận, cười nói đùa giỡn khi ăn. Nguy cơ xảy ra biến chứng tăng lên với thời gian dị vật còn trong đường thở, như ho ra máu, ho kéo dài, viêm phổi, tràn khí trung thất, tràn khí phổi, xẹp phổi...</p><p>"Với bệnh nhân trên, một đầu xương đã ở hạ thanh môn có thể di chuyển xuống đâm thủng phế quản, tràn khí trung thất, áp xe trung thất, nguy hiểm tính mạng", bác sĩ Lê Huy Hoàng, Phó Khoa Khám bệnh, Bệnh viện Tai Mũi Họng TP HCM chia sẻ.</p><p>&nbsp;</p><p><img src="https://i1-suckhoe.vnecdn.net/2022/04/20/be-nh-nha-n-ho-c-xu-o-ng-16504-1382-6604-1650438679.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=y9V3UAwR6Fc-woT_GhlaRg" alt="Bệnh nhân hồi phục khoẻ mạnh, trò chuyện cùng bác sĩ Nguyễn Thanh Vinh, trưa 20/4. Ảnh: Lê Phương"></p><p>Bệnh nhân hồi phục, trò chuyện cùng bác sĩ Nguyễn Thanh Vinh, trưa 20/4. Ảnh: <i>Lê Phương</i></p>', 0, 1, N'/FileUploads/images/Img-post/be-nh-nha-n-ho-c-xu-o-ng-16504-1382-6604-1650438679.jpg', 12, N'nhi', 1, CAST(N'2022-04-22 03:00:06.360' AS DateTime), CAST(N'2022-04-22 03:00:06.360' AS DateTime))
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[Professional] ON 

INSERT [dbo].[Professional] ([Id], [ProfessionalName], [AccountId], [Status], [CreatedAt], [UpdatedAt]) VALUES (1, N'Bác sĩ', 7, 1, CAST(N'2022-04-18 01:12:54.730' AS DateTime), CAST(N'2022-04-18 01:12:54.730' AS DateTime))
INSERT [dbo].[Professional] ([Id], [ProfessionalName], [AccountId], [Status], [CreatedAt], [UpdatedAt]) VALUES (2, N'Bác sĩ', 8, 1, CAST(N'2022-04-18 02:25:24.860' AS DateTime), CAST(N'2022-04-18 02:25:24.860' AS DateTime))
INSERT [dbo].[Professional] ([Id], [ProfessionalName], [AccountId], [Status], [CreatedAt], [UpdatedAt]) VALUES (3, NULL, 9, 1, CAST(N'2022-04-18 17:23:36.580' AS DateTime), CAST(N'2022-04-18 17:23:36.580' AS DateTime))
INSERT [dbo].[Professional] ([Id], [ProfessionalName], [AccountId], [Status], [CreatedAt], [UpdatedAt]) VALUES (4, NULL, 10, 1, CAST(N'2022-04-18 18:22:10.980' AS DateTime), CAST(N'2022-04-18 18:22:10.980' AS DateTime))
INSERT [dbo].[Professional] ([Id], [ProfessionalName], [AccountId], [Status], [CreatedAt], [UpdatedAt]) VALUES (5, NULL, 11, 1, CAST(N'2022-04-18 22:18:13.363' AS DateTime), CAST(N'2022-04-18 22:18:13.363' AS DateTime))
INSERT [dbo].[Professional] ([Id], [ProfessionalName], [AccountId], [Status], [CreatedAt], [UpdatedAt]) VALUES (6, N'Bác sĩ', 13, 1, CAST(N'2022-04-18 22:35:31.767' AS DateTime), CAST(N'2022-04-18 22:35:31.777' AS DateTime))
INSERT [dbo].[Professional] ([Id], [ProfessionalName], [AccountId], [Status], [CreatedAt], [UpdatedAt]) VALUES (7, NULL, 14, 1, CAST(N'2022-04-19 11:09:20.107' AS DateTime), CAST(N'2022-04-19 11:09:20.107' AS DateTime))
SET IDENTITY_INSERT [dbo].[Professional] OFF
SET IDENTITY_INSERT [dbo].[Qualifications] ON 

INSERT [dbo].[Qualifications] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpdatedAt], [School]) VALUES (1, N'2022                                              ', N'thành tích ', 7, 1, CAST(N'2022-04-18 01:12:54.733' AS DateTime), CAST(N'2022-04-18 01:12:54.733' AS DateTime), N'Cao đẳng y phú thọ')
INSERT [dbo].[Qualifications] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpdatedAt], [School]) VALUES (2, N'2022                                              ', N'thành tích ', 8, 1, CAST(N'2022-04-18 02:25:24.867' AS DateTime), CAST(N'2022-04-18 02:25:24.867' AS DateTime), N'Cao đẳng y phú thọ')
INSERT [dbo].[Qualifications] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpdatedAt], [School]) VALUES (3, NULL, NULL, 9, 1, CAST(N'2022-04-18 17:23:36.583' AS DateTime), CAST(N'2022-04-18 17:23:36.583' AS DateTime), NULL)
INSERT [dbo].[Qualifications] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpdatedAt], [School]) VALUES (4, N'2022                                              ', N'thành tích ', 10, 1, CAST(N'2022-04-18 18:22:10.983' AS DateTime), CAST(N'2022-04-18 18:22:10.983' AS DateTime), NULL)
INSERT [dbo].[Qualifications] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpdatedAt], [School]) VALUES (5, N'2022                                              ', NULL, 11, 1, CAST(N'2022-04-18 22:18:13.370' AS DateTime), CAST(N'2022-04-18 22:18:13.373' AS DateTime), NULL)
INSERT [dbo].[Qualifications] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpdatedAt], [School]) VALUES (6, N'2022                                              ', N'thành tích ', 13, 1, CAST(N'2022-04-18 22:35:33.900' AS DateTime), CAST(N'2022-04-18 22:35:33.910' AS DateTime), N'Cao đẳng y phú thọ')
INSERT [dbo].[Qualifications] ([Id], [Year], [Description], [AccountId], [Status], [CreatedAt], [UpdatedAt], [School]) VALUES (7, N'2022                                              ', NULL, 14, 1, CAST(N'2022-04-19 11:09:20.113' AS DateTime), CAST(N'2022-04-19 11:09:20.113' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Qualifications] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [Status], [CreatedAt], [UpdatedAt]) VALUES (1, N'User', 1, CAST(N'2022-04-16 00:00:00.000' AS DateTime), CAST(N'2022-04-16 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Specializations] ON 

INSERT [dbo].[Specializations] ([Id], [Name], [Title], [Description], [Image], [Status], [CreatedAt], [UpdatedAt]) VALUES (1, N'Sản phụ khoa', N'Sản phụ khoa', N'Liên quan đến phụ nữ', N'https://chiaseyhoc.net/imgpc/icons/san.svg', 1, CAST(N'2022-04-16 00:00:00.000' AS DateTime), CAST(N'2022-04-16 00:00:00.000' AS DateTime))
INSERT [dbo].[Specializations] ([Id], [Name], [Title], [Description], [Image], [Status], [CreatedAt], [UpdatedAt]) VALUES (2, N'Nhi', N'Nhi', N'Liên quan đến trẻ em', N'https://chiaseyhoc.net/imgpc/icons/nhi.svg', 1, CAST(N'2022-04-16 00:00:00.000' AS DateTime), CAST(N'2022-04-16 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Specializations] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Specializations] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specializations] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Specializations]
GO
ALTER TABLE [dbo].[Achievements]  WITH CHECK ADD  CONSTRAINT [FK_Achievements_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Achievements] CHECK CONSTRAINT [FK_Achievements_Accounts]
GO
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_Replies] FOREIGN KEY([RepId])
REFERENCES [dbo].[Replies] ([Id])
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [FK_Attachments_Replies]
GO
ALTER TABLE [dbo].[Experiences]  WITH CHECK ADD  CONSTRAINT [FK_Experiences_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Experiences] CHECK CONSTRAINT [FK_Experiences_Accounts]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Specializations] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specializations] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Specializations]
GO
ALTER TABLE [dbo].[Professional]  WITH CHECK ADD  CONSTRAINT [FK_Professional_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Professional] CHECK CONSTRAINT [FK_Professional_Accounts]
GO
ALTER TABLE [dbo].[Qualifications]  WITH CHECK ADD  CONSTRAINT [FK_Qualifications_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Qualifications] CHECK CONSTRAINT [FK_Qualifications_Accounts]
GO
ALTER TABLE [dbo].[Replies]  WITH CHECK ADD  CONSTRAINT [FK_Replies_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Replies] CHECK CONSTRAINT [FK_Replies_Accounts]
GO
ALTER TABLE [dbo].[Replies]  WITH CHECK ADD  CONSTRAINT [FK_Replies_Posts] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[Replies] CHECK CONSTRAINT [FK_Replies_Posts]
GO
ALTER TABLE [dbo].[Replies]  WITH CHECK ADD  CONSTRAINT [FK_Replies_Replies] FOREIGN KEY([ParenId])
REFERENCES [dbo].[Replies] ([Id])
GO
ALTER TABLE [dbo].[Replies] CHECK CONSTRAINT [FK_Replies_Replies]
GO
USE [master]
GO
ALTER DATABASE [DoctorForum] SET  READ_WRITE 
GO
