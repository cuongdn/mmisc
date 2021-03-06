USE [ContosoUniversity]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[Genre] [nvarchar](50) NOT NULL,
	[PublishDate] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Credits] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseInstructor]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseInstructor](
	[InstructorId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_CourseInstructor_1] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Budget] [money] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[InstructorId] [int] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Grade] [int] NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[InstructorId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstMidName] [nvarchar](50) NOT NULL,
	[HireDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Thread] [nvarchar](50) NULL,
	[Level] [nvarchar](50) NULL,
	[Logger] [nvarchar](255) NULL,
	[Message] [nvarchar](4000) NULL,
	[Exception] [nvarchar](2000) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OfficeAssignment]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfficeAssignment](
	[InstructorId] [int] NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OfficeAssignment] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 11.08.2015 12:14:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstMidName] [nvarchar](50) NOT NULL,
	[EnrollmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (1, N'Ralls')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (2, N'Corets')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (3, N'Randall')
INSERT [dbo].[Author] ([AuthorId], [Name]) VALUES (4, N'Thurman')
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookId], [Title], [Price], [Genre], [PublishDate], [Description], [AuthorId]) VALUES (1, N'Midnight Rain', 14.9900, N'Fantasy', N'2000-1-1', N'A former architect battles an evil sorceress.', 1)
INSERT [dbo].[Book] ([BookId], [Title], [Price], [Genre], [PublishDate], [Description], [AuthorId]) VALUES (2, N'Midnight Rain', 14.9900, N'Fantasy1', N'2000-12-1', N'A former architect battles an evil sorceress.', 1)
INSERT [dbo].[Book] ([BookId], [Title], [Price], [Genre], [PublishDate], [Description], [AuthorId]) VALUES (3, N'Midnight Rain', 14.9900, N'Fantasy1', N'2000-11-1', N'A former architect battles an evil sorceress.', 1)
INSERT [dbo].[Book] ([BookId], [Title], [Price], [Genre], [PublishDate], [Description], [AuthorId]) VALUES (4, N'Midnight Rain', 14.9900, N'Fantasy2', N'2000-10-1', N'A former architect battles an evil sorceress.', 1)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (1, N'Chemistry', 3, 1)
INSERT [dbo].[Course] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (2, N'Microeconomics', 3, 1)
INSERT [dbo].[Course] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (3, N'Macroeconomics', 3, 1)
INSERT [dbo].[Course] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (4, N'Calculus111', 5, 1)
INSERT [dbo].[Course] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (8, N'sdfsadfsaf', 5, 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
INSERT [dbo].[CourseInstructor] ([InstructorId], [CourseId]) VALUES (1, 1)
INSERT [dbo].[CourseInstructor] ([InstructorId], [CourseId]) VALUES (1, 2)
INSERT [dbo].[CourseInstructor] ([InstructorId], [CourseId]) VALUES (1, 3)
INSERT [dbo].[CourseInstructor] ([InstructorId], [CourseId]) VALUES (21, 1)
INSERT [dbo].[CourseInstructor] ([InstructorId], [CourseId]) VALUES (21, 4)
INSERT [dbo].[CourseInstructor] ([InstructorId], [CourseId]) VALUES (21, 8)
INSERT [dbo].[CourseInstructor] ([InstructorId], [CourseId]) VALUES (23, 2)
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [Name], [Budget], [StartDate], [InstructorId]) VALUES (1, N'Computer Science', 1000.0000, CAST(0x00009CF100000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Enrollment] ON 

INSERT [dbo].[Enrollment] ([EnrollmentId], [CourseId], [StudentId], [Grade]) VALUES (1, 1, 1, 4)
INSERT [dbo].[Enrollment] ([EnrollmentId], [CourseId], [StudentId], [Grade]) VALUES (2, 1, 2, 3)
INSERT [dbo].[Enrollment] ([EnrollmentId], [CourseId], [StudentId], [Grade]) VALUES (3, 1, 3, 2)
INSERT [dbo].[Enrollment] ([EnrollmentId], [CourseId], [StudentId], [Grade]) VALUES (4, 2, 4, 1)
INSERT [dbo].[Enrollment] ([EnrollmentId], [CourseId], [StudentId], [Grade]) VALUES (5, 2, 3, 2)
INSERT [dbo].[Enrollment] ([EnrollmentId], [CourseId], [StudentId], [Grade]) VALUES (7, 3, 1, 4)
INSERT [dbo].[Enrollment] ([EnrollmentId], [CourseId], [StudentId], [Grade]) VALUES (8, 3, 2, 3)
INSERT [dbo].[Enrollment] ([EnrollmentId], [CourseId], [StudentId], [Grade]) VALUES (9, 4, 7, 4)
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
SET IDENTITY_INSERT [dbo].[Instructor] ON 

INSERT [dbo].[Instructor] ([InstructorId], [LastName], [FirstMidName], [HireDate]) VALUES (1, N'DO532', N'Ngoc Cuongasdfasdf', CAST(0x000091A600000000 AS DateTime))
INSERT [dbo].[Instructor] ([InstructorId], [LastName], [FirstMidName], [HireDate]) VALUES (21, N'asdfasf', N'23123', CAST(0x0000A48700000000 AS DateTime))
INSERT [dbo].[Instructor] ([InstructorId], [LastName], [FirstMidName], [HireDate]) VALUES (23, N'sdfaasd', N'dfasdfsaf', CAST(0x0000A48700000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Instructor] OFF
SET IDENTITY_INSERT [dbo].[Log] ON 

INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (1, CAST(0x0000A4880173E341 AS DateTime), NULL, N'DEBUG', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (2, CAST(0x0000A4880173E35F AS DateTime), NULL, N'WARN', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (3, CAST(0x0000A4880173E35F AS DateTime), NULL, N'ERROR', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (4, CAST(0x0000A4880173E360 AS DateTime), NULL, N'INFO', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (5, CAST(0x0000A4880173E360 AS DateTime), NULL, N'FATAL', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (6, CAST(0x0000A4880175BAB5 AS DateTime), N'1', N'DEBUG', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (7, CAST(0x0000A4880175BAC1 AS DateTime), N'1', N'WARN', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (8, CAST(0x0000A4880175BAC2 AS DateTime), N'1', N'ERROR', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (9, CAST(0x0000A4880175BAC2 AS DateTime), N'1', N'INFO', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (10, CAST(0x0000A4880175BAC2 AS DateTime), N'1', N'FATAL', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (11, CAST(0x0000A4880177F6E4 AS DateTime), N'1', N'DEBUG', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (12, CAST(0x0000A4880177F6F0 AS DateTime), N'1', N'WARN', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (13, CAST(0x0000A4880177F6F0 AS DateTime), N'1', N'ERROR', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (14, CAST(0x0000A4880177F6F0 AS DateTime), N'1', N'INFO', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (15, CAST(0x0000A4880177F6F1 AS DateTime), N'1', N'FATAL', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (16, CAST(0x0000A4880178703E AS DateTime), N'1', N'DEBUG', N'System', N'ConsoleApplication1.Program', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (17, CAST(0x0000A4880178704F AS DateTime), N'1', N'WARN', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (18, CAST(0x0000A48801787050 AS DateTime), N'1', N'ERROR', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (19, CAST(0x0000A48801787050 AS DateTime), N'1', N'INFO', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (20, CAST(0x0000A48801787051 AS DateTime), N'1', N'FATAL', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (21, CAST(0x0000A488017A8567 AS DateTime), N'1', N'DEBUG', N'System', N'ConsoleApplication1.Program', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (22, CAST(0x0000A488017A8575 AS DateTime), N'1', N'WARN', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (23, CAST(0x0000A488017A8576 AS DateTime), N'1', N'ERROR', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (24, CAST(0x0000A488017A8576 AS DateTime), N'1', N'INFO', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (25, CAST(0x0000A488017A8576 AS DateTime), N'1', N'FATAL', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (26, CAST(0x0000A488017B1FB0 AS DateTime), N'1', N'DEBUG', N'System', N'ConsoleApplication1.Program', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (27, CAST(0x0000A488017B1FBE AS DateTime), N'1', N'WARN', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (28, CAST(0x0000A488017B1FBF AS DateTime), N'1', N'ERROR', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (29, CAST(0x0000A488017B1FBF AS DateTime), N'1', N'INFO', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (30, CAST(0x0000A488017B1FC0 AS DateTime), N'1', N'FATAL', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (31, CAST(0x0000A488017B366E AS DateTime), N'1', N'DEBUG', N'System', N'ConsoleApplication1.Program', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (32, CAST(0x0000A488017B3680 AS DateTime), N'1', N'WARN', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (33, CAST(0x0000A488017B3680 AS DateTime), N'1', N'ERROR', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (34, CAST(0x0000A488017B3680 AS DateTime), N'1', N'INFO', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (35, CAST(0x0000A488017B3681 AS DateTime), N'1', N'FATAL', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (36, CAST(0x0000A488017D4DD0 AS DateTime), N'1', N'DEBUG', N'System', N'ConsoleApplication1.Program', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (37, CAST(0x0000A488017D4DDA AS DateTime), N'1', N'WARN', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (38, CAST(0x0000A488017D4DDA AS DateTime), N'1', N'ERROR', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (39, CAST(0x0000A488017D4DDB AS DateTime), N'1', N'INFO', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (40, CAST(0x0000A488017D4DDB AS DateTime), N'1', N'FATAL', N'System', N'Asdfasfasf', N'', NULL, NULL)
INSERT [dbo].[Log] ([Id], [Date], [Thread], [Level], [Logger], [Message], [Exception], [CreatedDate], [UpdatedDate]) VALUES (41, CAST(0x0000A489000DE4C8 AS DateTime), N'1', N'DEBUG', N'Default', N'b', N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Log] OFF
INSERT [dbo].[OfficeAssignment] ([InstructorId], [Location]) VALUES (1, N'aaa bbb')
INSERT [dbo].[OfficeAssignment] ([InstructorId], [Location]) VALUES (21, N'sfsf')
INSERT [dbo].[OfficeAssignment] ([InstructorId], [Location]) VALUES (23, N'safasdfsdf')
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (1, N'Alexander', N'Carson', CAST(0x000096CC00000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (2, N'Alonso', N'Meredith', CAST(0x0000927A00000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (3, N'Anand', N'Arturo', CAST(0x000093E700000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (4, N'Barzdukas', N'Gytis', CAST(0x0000927A00000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (5, N'Li', N'Yan', CAST(0x0000927A00000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (7, N'Peggy', N'Justice', CAST(0x0000910D00000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (9, N'Laura', N'Norman', CAST(0x000093E700000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (10, N'Nino', N'Olivetto', CAST(0x000096C200000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (15, N'adfsd', N'fsdfasf', CAST(0x0000A49E00000000 AS DateTime))
INSERT [dbo].[Student] ([StudentId], [LastName], [FirstMidName], [EnrollmentDate]) VALUES (18, N'asdfsdf', N'asfsadf asdf', CAST(0x00008EF300000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Student] OFF
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[CourseInstructor]  WITH CHECK ADD  CONSTRAINT [FK_CourseInstructor_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[CourseInstructor] CHECK CONSTRAINT [FK_CourseInstructor_Course]
GO
ALTER TABLE [dbo].[CourseInstructor]  WITH CHECK ADD  CONSTRAINT [FK_CourseInstructor_Instructor] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[Instructor] ([InstructorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseInstructor] CHECK CONSTRAINT [FK_CourseInstructor_Instructor]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Instructor] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[Instructor] ([InstructorId])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Instructor]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Course]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Student]
GO
ALTER TABLE [dbo].[OfficeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_OfficeAssignment_Instructor] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[Instructor] ([InstructorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OfficeAssignment] CHECK CONSTRAINT [FK_OfficeAssignment_Instructor]
GO
