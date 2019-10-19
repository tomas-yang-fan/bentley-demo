--S7EDIDB01
USE Tomas
GO

CREATE TABLE [dbo].[Tomas_Shipping] (
	[TransactionNumber] [int] IDENTITY(1, 1) NOT NULL
	,[ShippingNumber] [int] NOT NULL
	,[TrackingNumber] [varchar](50)  NULL
	,[OrderNumber] [varchar](50) NOT NULL
	,[ShipTo] [varchar](500) NOT NULL
	,[ShipFrom] [varchar](500) NOT NULL
	,[Status] [char](1) NOT NULL
	,[InDate] [datetime] NOT NULL
	,[InUser] [varchar](15) NOT NULL
	,[LastEditDate] [datetime] NULL
	,[LastEditUser] [varchar](15) NULL
	,CONSTRAINT [PK_Shipping] PRIMARY KEY CLUSTERED ([TransactionNumber] ASC) WITH (
		PAD_INDEX = OFF
		,STATISTICS_NORECOMPUTE = OFF
		,IGNORE_DUP_KEY = OFF
		,ALLOW_ROW_LOCKS = ON
		,ALLOW_PAGE_LOCKS = ON
		)
	ON [PRIMARY]
	) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_Shipping_ShippingNumber_TrackingNumber_OrderNumber_Status ON dbo.Tomas_Shipping (
	[ShippingNumber]
	,[TrackingNumber]
	,[OrderNumber]
	,[Status]
	)
	WITH (FILLFACTOR = 90)
GO


