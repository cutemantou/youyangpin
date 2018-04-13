using System.Collections.Generic;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using WebAPI.Entities;
using WebAPI.Repository;

namespace WebAPI.Services
{
	public class GoodService : ServiceBase<Good>,IGoodService
	{
		private readonly ILogger _logger;
		private readonly IGoodRepository _goodRepository;
		
		public GoodService(IGoodRepository goodRepository, ILogger<GoodService> logger)
		    : base(logger)
        {
			this._goodRepository = goodRepository;
			this._logger = logger;
		}
        
        public IEnumerable<Good> GetPagedGood(int? pageIndex
                                    , int itemsPerPage
                                    , string sortField
                                    , string sort
                                    , out int recordCount)
		{
			return _goodRepository.GetPagedGood(
				pageIndex, itemsPerPage, sortField, sort, out recordCount);
		}
        
	}
}

