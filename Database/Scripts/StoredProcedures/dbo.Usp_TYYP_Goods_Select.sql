

IF OBJECT_ID(N'[dbo].[Usp_TYYP_Good_Select]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_Good_Select]'
	DROP PROCEDURE [dbo].[Usp_TYYP_Good_Select]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_Good_Select]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_Good_Select]
	@GoodsId varchar(50)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[GoodsId],
	[UserId],
	[ShopId],
	[GoodsImgURL],
	[GoodsName],
	[GoodsURL],
	[ActivityType],
	[DailyPrice],
	[LivePrice],
	[CommissionRatio],
	[CommissionURL],
	[InventoryNum],
	[SupplyNum],
	[IsProvideMulticolor],
	[ColorNum],
	[Sales],
	[PreferentialWay],
	[NeedSendBack],
	[SellingPointDescribe],
	[CouponsURL],
	[ActivityBeginTime],
	[ActivityEndTime],
	[FansOrAverageDailyViews],
	[AverageDailyViewsHight],
	[AverageDailyViewsLow],
	[FansHight],
	[FansLow],
	[CheckStatus],
	[AddTime]
FROM
	[dbo].[TYYP_Goods]
WHERE
	[GoodsId] = @GoodsId

GO

--GRANT EXEC ON [dbo].[Usp_TYYP_Good_Select] TO shafeUser

GO

