using System.Collections.Generic;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using YYP.Entities;

namespace YYP.Services
{
	public class StudioHostServiceResult : ServiceResultBase
	{					
		public StudioHostServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public StudioHostServiceResult(StudioHost studioHost)
            : this()
        {
            this.StudioHost = studioHost;
        }

        public StudioHostServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public StudioHost StudioHost
        {
            get;
            set;
        }        
	}
}

