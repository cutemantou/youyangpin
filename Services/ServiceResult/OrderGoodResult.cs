using System.Collections.Generic;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using YYP.Entities;

namespace YYP.Services
{
	public class OrderGoodServiceResult : ServiceResultBase
	{					
		public OrderGoodServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public OrderGoodServiceResult(OrderGood orderGood)
            : this()
        {
            this.OrderGood = orderGood;
        }

        public OrderGoodServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public OrderGood OrderGood
        {
            get;
            set;
        }        
	}
}

