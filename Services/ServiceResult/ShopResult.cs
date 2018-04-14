using System.Collections.Generic;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using YYP.Entities;

namespace YYP.Services
{
	public class ShopServiceResult : ServiceResultBase
	{					
		public ShopServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public ShopServiceResult(Shop shop)
            : this()
        {
            this.Shop = shop;
        }

        public ShopServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public Shop Shop
        {
            get;
            set;
        }        
	}
}

