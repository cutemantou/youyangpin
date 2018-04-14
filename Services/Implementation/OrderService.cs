using System.Collections.Generic;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class OrderService : ServiceBase<Order>,IOrderService
	{
		private readonly ILogger _logger;
		private readonly IOrderRepository _orderRepository;
		
		public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
		{
			this._orderRepository = orderRepository;
			this._logger = logger;
		}
        
	}
}

