using System.Collections.Generic;
using Infrastructure.Repository;
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

        public IEnumerable<Good> GetPagedGood(int? pageIndex
                                       , int itemsPerPage
                                       , string sortField
                                       , string sort
                                       , out int recordCount)
        {
            recordCount = 0;
            //ListDictionary outValues;
            //var dt = Database.StoredProcedure("[dbo].[Usp_TYYP_Good_Pagination]")
            //    .AddInputParameter("@PageIndex", DbType.Int32, pageIndex.HasValue ? pageIndex.Value : 1)
            //    .AddInputParameter("@PageSize", DbType.Int32, itemsPerPage)
            //    .AddInputParameter("@SortField", DbType.String, sortField)
            //    .AddInputParameter("@Sort", DbType.String, sort)
            //    .AddOutputParameter("@RecordCount", DbType.Int32, recordCount)
            //    .ToDataTable(out outValues);

            //var myGood = new List<Good>();
            //Converter<,>.DataTableToEntityCollection(dt, myGood);
            //recordCount = (int)outValues["RecordCount"];
            //return myGood;
            return null;
        }
	}
}

