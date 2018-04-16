

IF OBJECT_ID(N'[dbo].[Usp_TYYP_StudioHost_Select]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_StudioHost_Select]'
	DROP PROCEDURE [dbo].[Usp_TYYP_StudioHost_Select]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_StudioHost_Select]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_StudioHost_Select]
	@UserId varchar(50)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[UserId],
	[StudioHostName],
	[TKName],
	[Height],
	[Weight],
	[ShoeSize],
	[ClothesSize],
	[Address],
	[LinkmanName],
	[LinkmanPhone],
	[WeChat],
	[QQ],
	[Email],
	[FansNum],
	[AverageDailyViews],
	[VerticalFieldCode],
	[MainPopActivityType],
	[PerCustomerTransactionHight],
	[PerCustomerTransactionLow],
	[AlipayAccount],
	[AccountBalance],
	[Margin],
	[CheckStatus],
	[Remark],
	[DailyBeginTime],
	[DailyEndTime],
	[AddTime],
	[UpdateTime]
FROM
	[dbo].[TYYP_StudioHost]
WHERE
	[UserId] = @UserId

GO

--GRANT EXEC ON [dbo].[Usp_TYYP_StudioHost_Select] TO shafeUser

GO

