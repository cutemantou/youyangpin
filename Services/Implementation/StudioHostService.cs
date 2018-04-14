using System.Collections.Generic;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class StudioHostService : ServiceBase<StudioHost>,IStudioHostService
	{
		private readonly ILogger _logger;
		private readonly IStudioHostRepository _studioHostRepository;
		
		public StudioHostService(IStudioHostRepository studioHostRepository, ILogger<StudioHostService> logger)
		{
			this._studioHostRepository = studioHostRepository;
			this._logger = logger;
		}
        
	}
}

