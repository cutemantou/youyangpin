using System.Collections.Generic;
using System.Data;
using Dapper;
using Infrastructure.Repository;
using YYP.ComLib;
using YYP.Dto;
using YYP.Entities;

namespace YYP.Repository
{
    /// <summary>
    /// Summary description for GoodRepository.
    /// </summary>
    public class GoodRepository : RepositoryBase<Good>, IGoodRepository
	{
	    public GoodRepository(IDatabaseFactory db) : base(db)
        {
        }

        public IEnumerable<GoodStatistic> GetStatistics(string checkStatus)
        {
            return Database.Query<GoodStatistic>("[dbo].[Usp_TYYP_Goods_Statistics]", new { CheckStatus = checkStatus }, commandType: CommandType.StoredProcedure);
        }

        public override Good GetById(string id)
        {
            return Database.QueryFirstOrDefault<Good>("[dbo].[Usp_TYYP_Good_Select]", new { GoodsId = id }, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int? sales, decimal? lowDailyPrice, decimal? highDailyPrice, decimal? commissionRatio, string checkStatus
                                       , int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@GoodsName", goodsName);
            parameters.Add("@VerticalFieldCode", verticalFieldCode);
            parameters.Add("@ActivityType", activityType);
            parameters.Add("@Sales", sales);
            parameters.Add("@LowDailyPrice", lowDailyPrice);
            parameters.Add("@HighDailyPrice", highDailyPrice);
            parameters.Add("@CommissionRatio", commissionRatio);
            parameters.Add("@CheckStatus", CheckStatus.Pass);
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@PageSize", itemsPerPage);
            parameters.Add("@SortField", sortField);
            parameters.Add("@Sort", sort);
            parameters.Add("@RecordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var goods = Database.Query<Good>("[dbo].[Usp_TYYP_Goods_Pagination]", parameters, commandType: CommandType.StoredProcedure);
            recordCount = parameters.Get<int>("@RecordCount");
            return goods;
        }

        public IEnumerable<Good> GetRelatedGoods(string shopId, string activityType)
        {
            return Database.Query<Good>("[dbo].[Usp_TYYP_Goods_SelectRelated]", new { ShopId = shopId, ActivityType = activityType, CheckStatus = CheckStatus.Pass }, commandType: CommandType.StoredProcedure);
        }

        public int GetRequestQuantity(string goodsId)
        {
            return Database.QueryFirstOrDefault<int>(@"SELECT  COUNT(*)
                                            FROM    dbo.TYYP_Order AS O
                                                    INNER JOIN dbo.TYYP_OrderGoods AS OG ON OG.OrderId = O.OrderId
                                            WHERE   OG.GoodsId = @GoodsId;"
                , new { GoodsId = goodsId });
        }
    }
}

