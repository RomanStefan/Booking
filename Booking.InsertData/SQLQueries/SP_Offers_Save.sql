IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Offers_Save')
DROP PROCEDURE [dbo].[SP_Offers_Save]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Roman Stefan
-- Create date: 08/09/2023
-- Description:	Adding and updating records that takes care of concurrent saves of the same record. 
--              (It does not allow to overwrite updates done meanwhile)
-- =============================================
CREATE PROCEDURE [dbo].[SP_Offers_Save]
	@CheckInDate              DATETIME,
	@StayDurationNights		  INT,
	@PersonCombination		  VARCHAR(4),
	@Service_Code			  VARCHAR(30),
	@Price					  DECIMAL(5, 2),
	@PricePerAdult			  DECIMAL (4, 2),
	@PricePerChild			  DECIMAL (4, 2),
	@StrikePrice			  DECIMAL (5, 2),
	@StrikePricePerAdult	  DECIMAL (4, 2),
	@StrikePricePerChild	  DECIMAL (4, 2),
	@ShowStrikePrice		  INT,
	@LastUpdated              DATETIME
AS
BEGIN
	INSERT INTO Offers 
	(CheckInDate, StayDurationNights, PersonCombination, Service_Code, Price, PricePerAdult, PricePerChild, StrikePrice,
		StrikePricePerAdult, StrikePricePerChild, ShowStrikePrice, LastUpdated)
	VALUES
	(@CheckInDate, @StayDurationNights, @PersonCombination, @Service_Code, @Price,@PricePerAdult,@PricePerChild,@StrikePrice,
		@StrikePricePerAdult, @StrikePricePerChild, @ShowStrikePrice, @LastUpdated)
END;