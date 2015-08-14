USE [Budget]
GO

/****** Object:  Table [dbo].[Cost]    Script Date: 14.08.2015 14:28:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cost](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nchar](50) NULL,
	[Category] [nchar](30) NULL,
	[Amount] [int] NULL,
	[Timestamp] [date] NULL,
	[Account] [nchar](10) NULL,
 CONSTRAINT [PK_Cost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


