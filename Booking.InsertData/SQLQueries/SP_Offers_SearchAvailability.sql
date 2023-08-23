IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_Offers_SearchAvailability')
DROP PROCEDURE [dbo].[SP_Offers_SearchAvailability]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Roman Stefan
-- Create date: 08/22/2023
-- Description:	Search for offers based on DateForm, Duration, PersonCombination
--exec [dbo].[SP_Offers_SearchAvailability] '08/09/2024',2,'1A1C'
-- =============================================
CREATE PROCEDURE [dbo].[SP_Offers_SearchAvailability]
	@CheckInDate              DATETIME,
	@StayDurationNights		  INT,
	@PersonCombination		  VARCHAR(4)
AS
BEGIN
	SELECT 
	CheckInDate, 
	StayDurationNights, 
	PersonCombination, 
	Service_Code AS ServiceCode,
	Price, 
	PricePerAdult, 
	PricePerChild, 
	StrikePrice, 
	StrikePricePerAdult, 
	StrikePricePerChild,
	ShowStrikePrice
	FROM Offers
	WHERE CheckInDate = @CheckInDate AND StayDurationNights = @StayDurationNights AND PersonCombination = @PersonCombination
	
END;