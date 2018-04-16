using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Infrastructure.Repository;
using YYP.ComLib;
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

        public override string Add(StudioHost entity)
        {
            entity.AddTime = DateTime.Now;
            Database.Execute("dbo.Usp_TYYP_StudioHost_Insert",
                new
                {
                    entity.UserId,
                    entity.StudioHostName,
                    entity.AddTime,
                    CheckStatus = CheckStatus.Waiting
                }, commandType: CommandType.StoredProcedure);
            return entity.UserId;
        }

        public override StudioHost GetById(string id)
        {
            return Database.QueryFirstOrDefault<StudioHost>("dbo.Usp_TYYP_StudioHost_Select", new { UserId = id }, commandType: CommandType.StoredProcedure);
        }
    }
}

