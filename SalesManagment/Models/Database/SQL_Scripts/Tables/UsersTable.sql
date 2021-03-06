USE [ProductDB]
GO

CREATE TABLE [dbo].[Users](
	[ID] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[UserType] [varchar](50) NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

