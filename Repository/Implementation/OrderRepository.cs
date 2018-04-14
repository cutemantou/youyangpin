using System.Collections.Generic;
using Infrastructure.Repository;
using YYP.Entities;

namespace YYP.Repository
{
	/// <summary>
	/// Summary description for OrderRepository.
	/// </summary>
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		public OrderRepository(IDatabaseFactory db) : base(db)
		{
            
		}
	}
}

