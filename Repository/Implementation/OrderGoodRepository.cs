using System.Collections.Generic;
using Infrastructure.Repository;
using YYP.Entities;

namespace YYP.Repository
{
	/// <summary>
	/// Summary description for OrderGoodRepository.
	/// </summary>
	public class OrderGoodRepository : RepositoryBase<OrderGood>, IOrderGoodRepository
	{
		public OrderGoodRepository(IDatabaseFactory db) : base(db)
		{
            
		}
	}
}

