using System.Collections.Generic;
using System.Data;
using Dapper;
using Infrastructure.Repository;
using YYP.Entities;

namespace YYP.Repository
{
	/// <summary>
	/// Summary description for ShopRepository.
	/// </summary>
	public class ShopRepository : RepositoryBase<Shop>, IShopRepository
	{
		public ShopRepository(IDatabaseFactory db) : base(db)
		{

        }

        public override Shop GetById(string id)
        {
            return Database.QueryFirstOrDefault<Shop>("dbo.Usp_TYYP_Shop_Select", new { ShopId = id }, commandType: CommandType.StoredProcedure);
        }
    }
}

