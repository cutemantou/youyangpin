using System.Collections.Generic;
using Infrastructure.Repository;
using YYP.Entities;

namespace YYP.Repository
{
	/// <summary>
	/// Summary description for WithdrawalRepository.
	/// </summary>
	public class WithdrawalRepository : RepositoryBase<Withdrawal>, IWithdrawalRepository
	{
		public WithdrawalRepository(IDatabaseFactory db) : base(db)
		{
            
		}
	}
}

