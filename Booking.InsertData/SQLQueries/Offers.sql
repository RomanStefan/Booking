IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Offers]') AND type in (N'U'))
	DROP TABLE [dbo].[Offers]
GO

CREATE TABLE [dbo].[Offers] (
	[ID]					  INT IDENTITY(1,1) NOT NULL,
    [CheckInDate]             DATETIME		  NOT NULL,
	[StayDurationNights]	  INT			  NOT NULL,
	[PersonCombination]		  VARCHAR(4)	  NOT NULL,
	[Service_Code]			  VARCHAR(30)	  NOT NULL,
	[Price]					  DECIMAL (4, 2)  NOT NULL,
	[PricePerAdult]			  DECIMAL (4, 2)  NOT NULL,
	[PricePerChild]			  DECIMAL (4, 2)  NOT NULL,
	[StrikePrice]			  DECIMAL (4, 2)  NOT NULL,
	[StrikePricePerAdult]	  DECIMAL (4, 2)  NOT NULL,
	[StrikePricePerChild]	  DECIMAL (4, 2)  NOT NULL,
	[ShowStrikePrice]		  INT			  NOT NULL,
	[LastUpdated]             DATETIME		  NOT NULL
    CONSTRAINT [Ix_Offers_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
); 


GO
