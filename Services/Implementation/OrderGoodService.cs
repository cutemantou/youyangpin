using System.Collections.Generic;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class OrderGoodService : ServiceBase<OrderGood>,IOrderGoodService
	{
		private readonly ILogger _logger;
		private readonly IOrderGoodRepository _orderGoodRepository;
		
		public OrderGoodService(IOrderGoodRepository orderGoodRepository, ILogger<OrderGoodService> logger)
		{
			this._orderGoodRepository = orderGoodRepository;
			this._logger = logger;
		}
        
	}
}

