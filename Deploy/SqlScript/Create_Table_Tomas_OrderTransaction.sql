--S7EDIDB01
USE Tomas
GO

CREATE TABLE [dbo].[Tomas_OrderTransaction] (
	[TransactionNumber] [int] IDENTITY(1, 1) NOT NULL
	,[MasterTransaction] [int] NOT NULL
	,[ItemNumber] [varchar](50) NOT NULL
	,[ItemDescription] [varchar](50) NOT NULL
	,[UnitPrice] [decimal] (12,2) NOT NULL
	,[Cost] [decimal] (12,2) NOT NULL
	,[Qty] [int] NOT NULL
	,[InDate] [datetime] NOT NULL
	,[InUser] [varchar](15) NOT NULL
	,[LastEditDate] [datetime] NULL
	,[LastEditUser] [varchar](15) NULL
	,CONSTRAINT [PK_OrderTransaction] PRIMARY KEY CLUSTERED ([TransactionNumber] ASC) WITH (
		PAD_INDEX = OFF
		,STATISTICS_NORECOMPUTE = OFF
		,IGNORE_DUP_KEY = OFF
		,ALLOW_ROW_LOCKS = ON
		,ALLOW_PAGE_LOCKS = ON
		)
	ON [PRIMARY]
	) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_OrderTransaction_MasterTransaction_ItemNumber ON dbo.Tomas_OrderTransaction (
	[MasterTransaction]
	,[ItemNumber]
	)
	WITH (FILLFACTOR = 90)
GO


