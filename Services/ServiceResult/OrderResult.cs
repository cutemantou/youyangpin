using System.Collections.Generic;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using YYP.Entities;

namespace YYP.Services
{
	public class OrderServiceResult : ServiceResultBase
	{					
		public OrderServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public OrderServiceResult(Order order)
            : this()
        {
            this.Order = order;
        }

        public OrderServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public Order Order
        {
            get;
            set;
        }        
	}
}

