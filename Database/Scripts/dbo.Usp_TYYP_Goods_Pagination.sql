

IF OBJECT_ID(N'[dbo].[Usp_TYYP_Goods_Pagination]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_Goods_Pagination]'
	DROP PROCEDURE [dbo].[Usp_TYYP_Goods_Pagination]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_Goods_Pagination]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_Goods_Pagination]
	@PageIndex INT,
	@PageSize INT,
	@SortField NVARCHAR(100),
	@Sort NVARCHAR(6),
	@RecordCount INT OUTPUT
AS
    DECLARE @SelectColumns     NVARCHAR(MAX)
	DECLARE @FromTables        NVARCHAR(MAX)
	DECLARE @WhereCondition    NVARCHAR(MAX)
	DECLARE @OrderByCondition  NVARCHAR(MAX)
	DECLARE @SQL               NVARCHAR(MAX)
    
    --@SelectColumns	
	--===============================================================================================
	SET @SelectColumns = 
	    '	[GoodsId],
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
	[DeleteMark]
  '
	--===============================================================================================
		
	--@FromTables
	--===============================================================================================	
	SET @FromTables = 
	    ' [dbo].[TYYP_Goods]'
	--===============================================================================================
	
	--@WhereCondition
	--===============================================================================================	
	SET @WhereCondition = ' 1 = 1 '
	--===============================================================================================

	--@OrderByCondition	
	--===============================================================================================	
	IF @SortField IS NULL OR @SortField = ''
		SET @SortField = ' [UpdatedDate] '	
	ELSE
		SET @SortField = '[' + @SortField + ']'

	SET @Sort = CASE UPPER(@Sort) WHEN 'ASC' THEN ' ASC' ELSE ' DESC' END
	
	SET @OrderByCondition = @SortField + @Sort
	--===============================================================================================
    
    --Execute Sql
	--===============================================================================================
	SET @SQL = ' SELECT @RecordCount = COUNT(1) FROM ' + @FromTables + ' WHERE ' + @WhereCondition
	    + ' IF @PageSize = 0 SET @PageSize = @RecordCount ' 
	    + ' SELECT *'
	    + ' FROM (SELECT ROW_NUMBER() OVER (ORDER BY ' + @OrderByCondition + ') AS RowNumber'
	    + ', T.* FROM (SELECT ' + @SelectColumns + ' FROM ' + @FromTables + ' WHERE ' + @WhereCondition + ') AS T) AS A'
	    + ' WHERE A.RowNumber BETWEEN @PageSize * (@PageIndex - 1) + 1 AND @PageSize * @PageIndex'	

	EXEC sp_executesql @SQL,
		N'@PageIndex INT,@PageSize INT,@RecordCount INT OUTPUT',		  
		  @PageIndex, @PageSize, @RecordCount OUTPUT
	--===============================================================================================

GO

--GRANT EXEC ON [dbo].[Usp_TYYP_Goods_Pagination] TO shafeUser

GO

