
USE Tomas
GO

CREATE TABLE [dbo].[Tomas_Cart] (
	[TransactionNumber] [int] IDENTITY(1, 1) NOT NULL
	,[UserID] [varchar](50) NOT NULL
	,[ItemNumber] [varchar](50) NOT NULL
	,[ItemDescription] [varchar](200) NOT NULL
	,[UnitPrice] [decimal] (12,2) NOT NULL
	,[Cost] [decimal] (12,2) NOT NULL
	,[Qty] [int] NOT NULL
	,[InDate] [datetime] NOT NULL
	,[InUser] [varchar](15) NOT NULL
	,[LastEditDate] [datetime] NULL
	,[LastEditUser] [varchar](15) NULL
	,CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([TransactionNumber] ASC) WITH (
		PAD_INDEX = OFF
		,STATISTICS_NORECOMPUTE = OFF
		,IGNORE_DUP_KEY = OFF
		,ALLOW_ROW_LOCKS = ON
		,ALLOW_PAGE_LOCKS = ON
		)
	ON [PRIMARY]
	) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_Cart_UserID_ItemNumber ON dbo.Tomas_Cart (
	[UserID]
	,[ItemNumber]
	)
	WITH (FILLFACTOR = 90)
GO


