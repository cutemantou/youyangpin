using System.Collections.Generic;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class MerchantService : ServiceBase<Merchant>,IMerchantService
	{
		private readonly ILogger _logger;
		private readonly IMerchantRepository _merchantRepository;
		
		public MerchantService(IMerchantRepository merchantRepository, ILogger<MerchantService> logger)
		{
			this._merchantRepository = merchantRepository;
			this._logger = logger;
		}
        
	}
}

