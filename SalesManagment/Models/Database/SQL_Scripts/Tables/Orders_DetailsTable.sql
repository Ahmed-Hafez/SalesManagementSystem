USE [ProductDB]
GO

CREATE TABLE [dbo].[Orders_Details](
	[Product_ID] [varchar](50) NULL,
	[Order_ID] [int] NULL,
	[Quantity] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders_Details]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Details_Orders] FOREIGN KEY([Order_ID])
REFERENCES [dbo].[Orders] ([Order_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Orders_Details] CHECK CONSTRAINT [FK_Orders_Details_Orders]
GO

ALTER TABLE [dbo].[Orders_Details]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Details_Products] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[Products] ([Product_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Orders_Details] CHECK CONSTRAINT [FK_Orders_Details_Products]
GO


