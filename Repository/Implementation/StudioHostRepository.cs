using System.Collections.Generic;
using Infrastructure.Repository;
using YYP.Entities;

namespace YYP.Repository
{
	/// <summary>
	/// Summary description for StudioHostRepository.
	/// </summary>
	public class StudioHostRepository : RepositoryBase<StudioHost>, IStudioHostRepository
	{
		public StudioHostRepository(IDatabaseFactory db) : base(db)
		{
            
		}
	}
}

