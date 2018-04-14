using System.Collections.Generic;
using Infrastructure.Repository;
using YYP.Entities;

namespace YYP.Repository
{
	/// <summary>
	/// Summary description for MerchantRepository.
	/// </summary>
	public class MerchantRepository : RepositoryBase<Merchant>, IMerchantRepository
	{
		public MerchantRepository(IDatabaseFactory db) : base(db)
		{
            
		}
	}
}

