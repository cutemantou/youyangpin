using System.Collections.Generic;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class ShopService : ServiceBase<Shop>,IShopService
	{
		private readonly ILogger _logger;
		private readonly IShopRepository _shopRepository;
		
		public ShopService(IShopRepository shopRepository, ILogger<ShopService> logger)
		{
			this._shopRepository = shopRepository;
			this._logger = logger;
		}
        
	}
}

