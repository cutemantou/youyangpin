using System.Collections.Generic;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using YYP.Entities;

namespace YYP.Services
{
	public class WithdrawalServiceResult : ServiceResultBase
	{					
		public WithdrawalServiceResult() : this(new List<RuleViolation>())
        { 
        }

        public WithdrawalServiceResult(Withdrawal withdrawal)
            : this()
        {
            this.Withdrawal = withdrawal;
        }

        public WithdrawalServiceResult(IEnumerable<RuleViolation> ruleViolations)
            : base(ruleViolations)
        { 
        }

        public Withdrawal Withdrawal
        {
            get;
            set;
        }        
	}
}

