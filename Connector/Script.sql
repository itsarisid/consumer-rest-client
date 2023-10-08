USE [Connector]
GO
/****** Object:  Table [dbo].[ApiDetails]    Script Date: 10/4/2023 12:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[AuthUrl] [nvarchar](550) NULL,
	[Method] [nvarchar](10) NULL,
	[AuthType] [nvarchar](10) NULL,
	[ConsumerKey] [nvarchar](1000) NULL,
	[ConsumerSecret] [nvarchar](1000) NULL,
	[Token] [nvarchar](1000) NULL,
	[OAuthToken] [nvarchar](1000) NULL,
	[OAuthTokenSecret] [nvarchar](1000) NULL,
	[UserName] [nvarchar](1000) NULL,
	[Password] [nvarchar](1000) NULL,
	[APIKey] [nvarchar](1000) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_ApiDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiRequest]    Script Date: 10/4/2023 12:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiRequest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ApiID] [int] NULL,
	[BaseUrl] [nvarchar](550) NULL,
	[ResourceUrl] [nvarchar](550) NULL,
	[NextUrl] [nvarchar](550) NULL,
	[ContentType] [nvarchar](350) NULL,
	[RequestBody] [nvarchar](350) NULL,
	[Body] [nvarchar](max) NULL,
	[IsSuccessful] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_ApiRequest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Header]    Script Date: 10/4/2023 12:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Header](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReqID] [int] NULL,
	[Key] [nvarchar](1000) NULL,
	[Value] [nvarchar](1000) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Header] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QueryParameters]    Script Date: 10/4/2023 12:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueryParameters](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReqID] [int] NULL,
	[Key] [nvarchar](1000) NULL,
	[Value] [nvarchar](1000) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_QueryParams] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApiRequest]  WITH CHECK ADD  CONSTRAINT [FK_ApiRequest_ApiRequest] FOREIGN KEY([ApiID])
REFERENCES [dbo].[ApiDetails] ([ID])
GO
ALTER TABLE [dbo].[ApiRequest] CHECK CONSTRAINT [FK_ApiRequest_ApiRequest]
GO
ALTER TABLE [dbo].[Header]  WITH CHECK ADD  CONSTRAINT [FK_Header_ApiRequest] FOREIGN KEY([ReqID])
REFERENCES [dbo].[ApiRequest] ([ID])
GO
ALTER TABLE [dbo].[Header] CHECK CONSTRAINT [FK_Header_ApiRequest]
GO
ALTER TABLE [dbo].[QueryParameters]  WITH CHECK ADD  CONSTRAINT [FK_QueryParameters_ApiRequest] FOREIGN KEY([ReqID])
REFERENCES [dbo].[ApiRequest] ([ID])
GO
ALTER TABLE [dbo].[QueryParameters] CHECK CONSTRAINT [FK_QueryParameters_ApiRequest]
GO
