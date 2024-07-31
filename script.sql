USE [databaseShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Orders] [int] NOT NULL,
	[MetaKey] [nvarchar](150) NULL,
	[MetaDesc] [nvarchar](150) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[UpdatedBy] [int] NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](15) NULL,
	[Title] [nvarchar](255) NULL,
	[Detail] [ntext] NULL,
	[CreatedAt] [smalldatetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[UpdatedBy] [int] NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Link]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Link](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [varchar](max) NULL,
	[TableId] [int] NULL,
	[Type] [varchar](200) NULL,
	[ParentId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Type] [varchar](255) NOT NULL,
	[Link] [varchar](255) NULL,
	[TableId] [int] NULL,
	[ParentId] [int] NOT NULL,
	[Orders] [int] NOT NULL,
	[Position] [varchar](255) NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[ExportDate] [smalldatetime] NULL,
	[DeliveryAddress] [nvarchar](255) NOT NULL,
	[DeliveryName] [nvarchar](100) NOT NULL,
	[DeliveryPhone] [varchar](255) NOT NULL,
	[DeliveryEmail] [varchar](255) NOT NULL,
	[DeliveryPaymentMethod] [nvarchar](255) NOT NULL,
	[StatusPayment] [int] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PriceSale] [int] NOT NULL,
	[Amount] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopId] [int] NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[Detail] [ntext] NULL,
	[Img] [varchar](255) NULL,
	[Type] [varchar](50) NULL,
	[MetaKey] [nvarchar](150) NOT NULL,
	[MetaDesc] [nvarchar](150) NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatId] [int] NOT NULL,
	[Submenu] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](255) NOT NULL,
	[Img] [varchar](100) NOT NULL,
	[Detail] [ntext] NOT NULL,
	[Number] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[PriceSale] [float] NOT NULL,
	[MetaKey] [nvarchar](150) NULL,
	[MetaDesc] [nvarchar](max) NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Sold] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[AccessName] [varchar](255) NOT NULL,
	[Description] [nvarchar](225) NULL,
	[GroupId] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Url] [varchar](255) NOT NULL,
	[Position] [varchar](100) NOT NULL,
	[Img] [varchar](100) NOT NULL,
	[Orders] [int] NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Slug] [varchar](255) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Orders] [int] NOT NULL,
	[MetaKey] [varchar](150) NULL,
	[MetaDesc] [nvarchar](max) NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 31/07/2024 4:56:01 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](255) NOT NULL,
	[Username] [varchar](225) NOT NULL,
	[Password] [varchar](64) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Gender] [nvarchar](5) NULL,
	[Phone] [varchar](20) NULL,
	[Img] [varchar](100) NULL,
	[Access] [int] NOT NULL,
	[CreatedAt] [smalldatetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedAt] [smalldatetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (7, N'giay 1', N'giay-1', 1, 1, N'MetaKey 1', N'MetaDesc 1', CAST(N'2024-07-19T10:00:00' AS SmallDateTime), 1, CAST(N'2024-07-31T10:35:00' AS SmallDateTime), 8, 1)
INSERT [dbo].[Category] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (8, N'giay 2', N'giay-2', 1, 2, N'MetaKey 2', N'MetaDesc 2', CAST(N'2024-07-19T11:00:00' AS SmallDateTime), 1, CAST(N'2024-07-19T11:00:00' AS SmallDateTime), 1, 1)
INSERT [dbo].[Category] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (9, N'giay 3', N'giay-3', 1, 3, N'MetaKey 3', N'MetaDesc 3', CAST(N'2024-07-19T12:00:00' AS SmallDateTime), 2, CAST(N'2024-07-19T12:00:00' AS SmallDateTime), 2, 1)
INSERT [dbo].[Category] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (18, N'giay 6', N'giay-6', 1, 2, N'MetaKey 2', N'MetaDesc 2', CAST(N'2024-07-22T00:00:00' AS SmallDateTime), 2, CAST(N'2024-07-22T00:00:00' AS SmallDateTime), 2, 1)
INSERT [dbo].[Category] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (14, N'giay 4', N'giay-4', 1, 4, N'MetaKey 1', N'MetaDesc 1', CAST(N'2024-07-19T15:10:00' AS SmallDateTime), 1, CAST(N'2024-07-19T15:10:00' AS SmallDateTime), 1, 1)
INSERT [dbo].[Category] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (17, N'giay 5', N'giay-5', 1, 0, N'MetaKey 1', N'MetaDesc 1', CAST(N'2024-07-19T15:11:00' AS SmallDateTime), 1, CAST(N'2024-07-19T15:11:00' AS SmallDateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([Id], [TopId], [Title], [Slug], [Detail], [Img], [Type], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (3, 2, N'abc 1999', N'abc-1999', N'adsfd', N'abc-1999.jpg', N'post', N'xfxbhn', N'bbuudtrs', CAST(N'2024-07-31T00:00:00' AS SmallDateTime), 1, CAST(N'2024-07-31T16:18:00' AS SmallDateTime), 8, 2)
INSERT [dbo].[Post] ([Id], [TopId], [Title], [Slug], [Detail], [Img], [Type], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (4, 0, N'abc 123 767', N'abc-123-767', N'adsfd', N'abc-123-767.jpg', N'1', N'xfxbhn', N'bbuudtrs', CAST(N'2024-07-31T16:05:00' AS SmallDateTime), 1, CAST(N'2024-07-31T16:10:00' AS SmallDateTime), 8, 1)
INSERT [dbo].[Post] ([Id], [TopId], [Title], [Slug], [Detail], [Img], [Type], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (5, 0, N'abc 123', N'abc-123', N'adsfd', N'abc-123.jpg', N'1', N'xfxbhn', N'bbuudtrs', CAST(N'2024-07-31T16:05:00' AS SmallDateTime), 1, CAST(N'2024-07-31T16:10:00' AS SmallDateTime), 8, 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [CatId], [Submenu], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status], [Sold]) VALUES (20, 8, 0, N'Giày Adidas VL Court 2.0 Nam - Xám Nâu', N'giay-adidas-vl-court-2.0-nam---xam-nau', N'giay-adidas-vl-court-2.0-nam---xam-nau.jpg', N'Giày Adidas VL Court 2.0 chính hãng tại Myshoes.vn được nhập khẩu chính hãng. Full box, đầy đủ phụ kiện.', 1, 2500000, 1790000, N'Giày Adidas ', N'Giày Adidas VL Court 2.0 được thiết kế phong cách cổ điển nhưng đẹp mãi với thời gian. Một mẫu giày bạn có thể sử dụng trong mọi hoàn cảnh và luôn phù hợp dù ở bất cứ nơi đâu.  Phần Upper được làm từ da lộn cao cấp với logo đặc trưng của adidas, đế giày chất liệu cao su siêu bền, chắc chắn hỗ trợ từng bước chân.', CAST(N'2024-07-30T10:50:00' AS SmallDateTime), 1, CAST(N'2024-07-30T10:50:00' AS SmallDateTime), 1, 1, 0)
INSERT [dbo].[Product] ([Id], [CatId], [Submenu], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status], [Sold]) VALUES (21, 7, 0, N'Giày Adidas VL Court 2.0 Nam - Đen Nâu', N'giay-adidas-vl-court-2.0-nam---den-nau', N'giay-adidas-vl-court-2.0-nam---den-nau.jpg', N'Giày Adidas VL Court 2.0 chính hãng tại Myshoes.vn được nhập khẩu chính hãng. Full box, đầy đủ phụ kiện.', 2, 2500000, 1790000, N'Giày Adidas', N'Giày Adidas VL Court 2.0 được thiết kế phong cách cổ điển nhưng đẹp mãi với thời gian. Một mẫu giày bạn có thể sử dụng trong mọi hoàn cảnh và luôn phù hợp dù ở bất cứ nơi đâu.  Phần Upper được làm từ da lộn cao cấp với logo đặc trưng của adidas, đế giày chất liệu cao su siêu bền, chắc chắn hỗ trợ từng bước chân.', CAST(N'2024-07-30T10:53:00' AS SmallDateTime), 1, CAST(N'2024-07-30T10:53:00' AS SmallDateTime), 1, 1, 0)
INSERT [dbo].[Product] ([Id], [CatId], [Submenu], [Name], [Slug], [Img], [Detail], [Number], [Price], [PriceSale], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status], [Sold]) VALUES (22, 8, 0, N'Giày Adidas Supernova Stride Nữ - Hồng', N'giay-adidas-supernova-stride-nu---hong', N'giay-adidas-supernova-stride-nu---hong.jpg', N'Giày Adidas Supernova Stride được Myshoes.vn nhập khẩu chính hãng. Full box, đầy đủ phụ kiện', 3, 3200000, 2490000, N'Giày Adidas', N'Giày Adidas Supernova Stride là một trong những mẫu giày thể thao tốt nhất của adidas vừa ra mắt trong năm nay. Bạn có thể sử dụng Adidas Supernova Stride cho việc chạy bộ, tập thể dục thể thao hoặc đi hàng ngày đều rất phù hợp.  Adidas Supernova Stride  có phần upper được làm bằng chất liệu rất nhẹ và thoáng. Phần đế giữa với công nghệ Dreamstrike+ nâng niu từng bước chân. Phần đế ngoài công nghệ Adiwear độc quyền giúp đôi giày bền bỉ và chắc chắn.', CAST(N'2024-07-30T10:56:00' AS SmallDateTime), 1, CAST(N'2024-07-30T10:56:00' AS SmallDateTime), 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([Id], [Name], [Slug], [ParentId], [Orders], [MetaKey], [MetaDesc], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (2, N'Shopping', N'Shop-ping', 0, 2, N'b', N'b', CAST(N'2024-07-22T00:00:00' AS SmallDateTime), 1, CAST(N'2024-07-22T00:00:00' AS SmallDateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Topic] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FullName], [Username], [Password], [Email], [Gender], [Phone], [Img], [Access], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [Status]) VALUES (8, N'Dassss', N'admin', N'4QrcOUm6Wau+VuBX8g+IPg==', N'ads@gmail.com', N'Nu', N'0377377794', N'ads', 1, CAST(N'2020-10-10T00:00:00' AS SmallDateTime), 1, CAST(N'2020-10-10T00:00:00' AS SmallDateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
