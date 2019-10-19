--S7EDIDB01
USE Tomas

GO

CREATE TABLE [dbo].[Tomas_OrderMaster] (
	[TransactionNumber] [int] IDENTITY(1, 1) NOT NULL
	,[UserID] [varchar](50) NOT NULL
	,[OrderNumber] [varchar](50) NOT NULL
	,[Status] [char](1) NOT NULL
	,[PriceAmount] [decimal] (12,2) NOT NULL
	,[CostAmount] [decimal] (12,2) NOT NULL
	,[InDate] [datetime] NOT NULL
	,[InUser] [varchar](15) NOT NULL
	,[LastEditDate] [datetime] NULL
	,[LastEditUser] [varchar](15) NULL
	,CONSTRAINT [PK_Tomas_OrderMaster] PRIMARY KEY CLUSTERED ([TransactionNumber] ASC) WITH (
		PAD_INDEX = OFF
		,STATISTICS_NORECOMPUTE = OFF
		,IGNORE_DUP_KEY = OFF
		,ALLOW_ROW_LOCKS = ON
		,ALLOW_PAGE_LOCKS = ON
		)
	ON [PRIMARY]
	) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_OrderMaster_OrderNumber_Status ON dbo.Tomas_OrderMaster (
	[OrderNumber]
	,[Status]
	)
	WITH (FILLFACTOR = 90)
GO

