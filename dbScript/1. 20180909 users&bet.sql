USE [betdb]
GO
/****** Object:  Table [dbo].[bet]    Script Date: 9/9/2018 11:19:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[agent_id] [int] NULL,
	[bet_type] [varchar](50) NULL,
	[bet_number] [int] NULL,
	[up] [int] NULL,
	[down] [int] NULL,
	[created_date] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_date] [int] NULL,
	[updated_by] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 9/9/2018 11:19:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [varbinary](128) NOT NULL,
	[salt] [varbinary](128) NOT NULL,
	[iteration] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[status] [tinyint] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_at] [datetime] NULL,
	[updated_by] [int] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [username], [password], [salt], [iteration], [role_id], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1, N'sysadmin', 0x57A06E382EBCE6F267C60EAB5CC1E17CAB65367C8CE83D15, 0x75F31A488DBDF4503F048866449166BC350E5D6A, 19, 2, 1, CAST(N'2017-11-20T15:40:21.263' AS DateTime), 1, CAST(N'2017-11-20T15:40:21.263' AS DateTime), 1)
INSERT [dbo].[users] ([id], [username], [password], [salt], [iteration], [role_id], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (7, N'bear', 0x8F3DD064004ED2427DAC672F5B19528047FE98D69B208875, 0xA58A61222FB1EC5B40530E307FE43B25F1D4A787, 13, 1, 1, CAST(N'2017-11-22T17:54:46.310' AS DateTime), 0, CAST(N'2017-11-22T17:54:46.310' AS DateTime), 1)
INSERT [dbo].[users] ([id], [username], [password], [salt], [iteration], [role_id], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (8, N'fai', 0x94F12BBA232692E2D6AA8A7E0590704ED958134FBADD3F6A, 0xC0FF5B3586C3C93A91B06F3C85D994DB77AACD72, 16, 1, 1, CAST(N'2017-12-07T19:32:30.660' AS DateTime), 0, CAST(N'2017-12-07T19:32:30.660' AS DateTime), 1)
INSERT [dbo].[users] ([id], [username], [password], [salt], [iteration], [role_id], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (9, N'dong', 0xB7FBD7943D6B9D9ED6848104D55B36979AAA01FA4D16BB1D, 0x948AE3EBC7959AE88A8F439A430DEBAC3DFD48CD, 15, 1, 1, CAST(N'2017-12-07T19:33:13.197' AS DateTime), 0, CAST(N'2017-12-07T19:33:13.197' AS DateTime), 1)
INSERT [dbo].[users] ([id], [username], [password], [salt], [iteration], [role_id], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (10, N'jason', 0xB6FB0AD25A0E8129BBEA969AD7A3013848D412568AA40233, 0x81AE5E90DA2FA302EAD149732069A5B1F8625581, 13, 1, 1, CAST(N'2017-12-07T19:34:20.590' AS DateTime), 0, CAST(N'2017-12-07T19:34:20.590' AS DateTime), 1)
INSERT [dbo].[users] ([id], [username], [password], [salt], [iteration], [role_id], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (11, N'L3N', 0x5A3F3D7F81F015694A358E980CFFA0974E28E0013DC1DBB3, 0xC3BB14C8F019D948A539A7C655BA30DE95CBAB27, 10, 1, 1, CAST(N'2017-12-19T10:51:31.880' AS DateTime), 1, CAST(N'2017-12-19T11:51:47.553' AS DateTime), 11)
INSERT [dbo].[users] ([id], [username], [password], [salt], [iteration], [role_id], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (12, N'test1', 0xD94ADD515D8FD94B88BDEA2E404DA24A6AB5432F9739613D, 0x8444A772545749D65B2E26061E0075E28FA1C8F4, 17, 1, 1, CAST(N'2018-01-10T13:27:10.137' AS DateTime), 1, CAST(N'2018-01-10T13:28:36.893' AS DateTime), 12)
SET IDENTITY_INSERT [dbo].[users] OFF
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_user_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_user_status]  DEFAULT ((1)) FOR [status]
GO
