USE [ProductDB]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 10/5/2019 4:48:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Product_ID] [varchar](50) NOT NULL,
	[Product_Label] [varchar](50) NULL,
	[Quantity_in_Stock] [int] NULL,
	[Price] [varchar](50) NULL,
	[Product_Image] [image] NULL,
	[Category_ID] [int] NULL,
	[Product_Description] [varchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Categories] ([Category_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO


