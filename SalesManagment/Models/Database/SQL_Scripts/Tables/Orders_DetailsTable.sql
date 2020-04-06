USE [ProductDB]
GO

CREATE TABLE [dbo].[Orders_Details](
	[Order_ID] [int] NULL,
	[Quantity] [int] NULL,
	[Discount] [decimal](18, 0) NULL,
	[Row_Number] [int] NULL,
	[Product_Name] [varchar](100) NULL,
	[Product_Price] [decimal](18, 0) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders_Details]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Details_Orders] FOREIGN KEY([Order_ID])
REFERENCES [dbo].[Orders] ([Order_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Orders_Details] CHECK CONSTRAINT [FK_Orders_Details_Orders]
GO

