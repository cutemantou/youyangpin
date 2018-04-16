

IF OBJECT_ID(N'[dbo].[Usp_TYYP_Shop_Select]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_Shop_Select]'
	DROP PROCEDURE [dbo].[Usp_TYYP_Shop_Select]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_Shop_Select]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_Shop_Select]
	@ShopId varchar(50)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ShopId],
	[UserId],
	[ShopType],
	[ShopName],
	[VerticalFieldCode],
	[ShopURL],
	[WangWangNo],
	[ShopAddress],
	[DescriptionMatch],
	[ServiceAttitude],
	[LogisticsService],
	[AddTime],
	[UpdateTime]
FROM
	[dbo].[TYYP_Shop]
WHERE
	[ShopId] = @ShopId

GO

--GRANT EXEC ON [dbo].[Usp_TYYP_Shop_Select] TO shafeUser

GO

