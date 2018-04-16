

IF OBJECT_ID(N'[dbo].[Usp_TYYP_Goods_Pagination]') IS NOT NULL
BEGIN
	PRINT 'Dropping Procedure [dbo].[Usp_TYYP_Goods_Pagination]'
	DROP PROCEDURE [dbo].[Usp_TYYP_Goods_Pagination]
END


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_Goods_Pagination]'

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_Goods_Pagination]
	@GoodsName NVARCHAR(100),
	@VerticalFieldCode NVARCHAR(5),
	@ActivityType NVARCHAR(10),
	@Sales INT,
	@LowDailyPrice Decimal(10,2),
	@HighDailyPrice Decimal(10,2),
	@CommissionRatio Decimal(5,2),
	@CheckStatus NVARCHAR(5),
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
	    '	G.[GoodsId],
	G.[UserId],
	G.[ShopId],
	G.[GoodsImgURL],
	G.[GoodsName],
	G.[GoodsURL],
	G.[ActivityType],
	G.[DailyPrice],
	G.[LivePrice],
	G.[CommissionRatio],
	G.[CommissionURL],
	G.[InventoryNum],
	G.[SupplyNum],
	G.[IsProvideMulticolor],
	G.[ColorNum],
	G.[Sales],
	G.[PreferentialWay],
	G.[NeedSendBack],
	G.[SellingPointDescribe],
	G.[CouponsURL],
	G.[ActivityBeginTime],
	G.[ActivityEndTime],
	G.[FansOrAverageDailyViews],
	G.[AverageDailyViewsHight],
	G.[AverageDailyViewsLow],
	G.[FansHight],
	G.[FansLow],
	G.[CheckStatus],
	G.[AddTime]
  '
	--===============================================================================================
		
	--@FromTables
	--===============================================================================================	
	SET @FromTables = 
	    ' [dbo].[TYYP_Goods] AS G INNER JOIN [dbo].[TYYP_Shop] AS S ON G.ShopId = S.ShopId'
	--===============================================================================================
	
	--@WhereCondition
	--===============================================================================================	
	SET @WhereCondition = ' G.[CheckStatus] = @CheckStatus '
	--===============================================================================================

	IF @GoodsName IS NOT NULL AND @GoodsName <> ''
	BEGIN
		SET @GoodsName=[dbo].[fn_Escape](@GoodsName)
		SET @WhereCondition=@WhereCondition+ ' AND G.[GoodsName] LIKE ''%'+@GoodsName+'%'''  
	END		
	IF @ActivityType IS NOT NULL AND @ActivityType <> ''
	BEGIN
		SET @WhereCondition=@WhereCondition+ ' AND G.[ActivityType] = @ActivityType'  
	END		

	IF @VerticalFieldCode IS NOT NULL AND @VerticalFieldCode <> ''
	BEGIN
		SET @WhereCondition=@WhereCondition+ ' AND S.[VerticalFieldCode] = @VerticalFieldCode'  
	END		

	IF @Sales IS NOT NULL
	BEGIN
		SET @WhereCondition=@WhereCondition+ ' AND G.[Sales] > @Sales'  
	END		

	IF @HighDailyPrice IS NOT NULL
	BEGIN
		SET @WhereCondition=@WhereCondition+ ' AND G.[DailyPrice] <= @HighDailyPrice'  
	END
	
	IF @LowDailyPrice IS NOT NULL
	BEGIN
		SET @WhereCondition=@WhereCondition+ ' AND G.[DailyPrice] >= @LowDailyPrice'  
	END

	IF @CommissionRatio IS NOT NULL
	BEGIN
		SET @WhereCondition=@WhereCondition+ ' AND G.[CommissionRatio] > @CommissionRatio'  
	END		

	--@OrderByCondition	
	--===============================================================================================	
	IF @SortField IS NULL OR @SortField = ''
		SET @SortField = '[AddTime]'
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
		PRINT @SQL
	EXEC sp_executesql @SQL,
		N'@VerticalFieldCode NVARCHAR(5),
			@ActivityType NVARCHAR(10),
			@Sales INT,
			@HighDailyPrice Decimal(10,2),
			@LowDailyPrice Decimal(10,2),
			@CommissionRatio Decimal(5,2),
			@CheckStatus NVARCHAR(5),@PageIndex INT,@PageSize INT,@RecordCount INT OUTPUT',		  
		  @VerticalFieldCode, @ActivityType, @Sales, @HighDailyPrice, @LowDailyPrice, @CommissionRatio, @CheckStatus, @PageIndex, @PageSize, @RecordCount OUTPUT
	--===============================================================================================

GO

--GRANT EXEC ON [dbo].[Usp_TYYP_Goods_Pagination] TO shafeUser

GO

