

IF OBJECT_ID(N'[dbo].[Usp_TYYP_Goods_SelectRelated]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_Goods_SelectRelated]'
	DROP PROCEDURE [dbo].[Usp_TYYP_Goods_SelectRelated]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_Goods_SelectRelated]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_Goods_SelectRelated]
	@ShopId varchar(50),
	@ActivityType nvarchar(10),
	@CheckStatus nvarchar(5)
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
	[ShopId] = @ShopId AND ActivityType = @ActivityType AND CheckStatus = @CheckStatus AND (GETDATE() BETWEEN [ActivityBeginTime] AND [ActivityEndTime])

GO

--GRANT EXEC ON [dbo].[Usp_TYYP_Goods_SelectRelated] TO shafeUser

GO

