using System.Collections.Generic;
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
	}
}

