using System.Collections.Generic;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class WithdrawalService : ServiceBase<Withdrawal>,IWithdrawalService
	{
		private readonly ILogger _logger;
		private readonly IWithdrawalRepository _withdrawalRepository;
		
		public WithdrawalService(IWithdrawalRepository withdrawalRepository, ILogger<WithdrawalService> logger)
		{
			this._withdrawalRepository = withdrawalRepository;
			this._logger = logger;
		}
        
	}
}

