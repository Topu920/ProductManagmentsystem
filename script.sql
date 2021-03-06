USE [OnlineProductMS]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 14-Aug-20 4:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 14-Aug-20 4:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Comments] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderandComments]    Script Date: 14-Aug-20 4:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderandComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_OrderandComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 14-Aug-20 4:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](max) NULL,
	[ProductName] [nvarchar](max) NULL,
	[ProductDetails] [nvarchar](max) NULL,
	[PhotoPathOfProduct] [nvarchar](max) NULL,
	[FreezeProduct] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14-Aug-20 4:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[ActorId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 

INSERT [dbo].[Actors] ([Id], [UserType]) VALUES (2, N'Seller')
INSERT [dbo].[Actors] ([Id], [UserType]) VALUES (3, N'Buyer')
SET IDENTITY_INSERT [dbo].[Actors] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [ProductId], [UserId], [Comments]) VALUES (1, 1, 2, N'this product is not good
')
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[OrderandComments] ON 

INSERT [dbo].[OrderandComments] ([Id], [ProductId], [UserId]) VALUES (1, 1, 2)
SET IDENTITY_INSERT [dbo].[OrderandComments] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductCode], [ProductName], [ProductDetails], [PhotoPathOfProduct], [FreezeProduct], [UserId]) VALUES (1, N'Mango001', N'Mango', N'this is testy fruit', N'f0a727df-36cd-42e4-a9a3-7d15726799de_1527939192.jpg', 1, 0)
INSERT [dbo].[Products] ([Id], [ProductCode], [ProductName], [ProductDetails], [PhotoPathOfProduct], [FreezeProduct], [UserId]) VALUES (2, N'Mango002', N'Mango', N'this is testy fruit', N'0930b182-131f-434f-8cf1-0c780a0d4abd_download (1).jfif', 0, 0)
INSERT [dbo].[Products] ([Id], [ProductCode], [ProductName], [ProductDetails], [PhotoPathOfProduct], [FreezeProduct], [UserId]) VALUES (3, N'Mango002', N'Mango', N'this is testy fruit', N'7f876298-7144-440c-9856-7161f3d70deb_download.jfif', 0, 0)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Email], [Password], [ActorId]) VALUES (1, N'Topu', N'topu920@gmail.com', N'Topu920@', 2)
INSERT [dbo].[Users] ([Id], [UserName], [Email], [Password], [ActorId]) VALUES (2, N'Tofiq', N'16303039@iubat.edu', N'trt123', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Actors_ActorId] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Actors_ActorId]
GO
