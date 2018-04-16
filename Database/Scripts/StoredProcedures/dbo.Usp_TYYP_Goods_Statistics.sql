

IF OBJECT_ID(N'[dbo].[Usp_TYYP_Goods_Statistics]') IS NOT NULL
    BEGIN
        PRINT 'Dropping Procedure [dbo].[Usp_TYYP_Goods_Statistics]';
        DROP PROCEDURE [dbo].[Usp_TYYP_Goods_Statistics];
    END;


GO

PRINT 'Create Procedure [dbo].[Usp_TYYP_Goods_Statistics]';

GO

CREATE PROCEDURE [dbo].[Usp_TYYP_Goods_Statistics]
    @CheckStatus NVARCHAR(5)
AS
    SELECT  S.VerticalFieldCode ,
            COUNT(G.GoodsId) Quantity
    FROM    dbo.TYYP_Shop AS S
            INNER JOIN dbo.TYYP_Goods AS G ON G.ShopId = S.ShopId
    GROUP BY S.VerticalFieldCode
	ORDER BY S.VerticalFieldCode DESC;
GO

