using Infrastructure.DomainModel;

namespace YYP.Entities
{
    /// <summary>
    /// Merchant object mapped to table 'TYYP_Merchant'.
    /// </summary>
    public class Merchant : EntityBase
	{
		
		#region Constructors

		public  Merchant() { }

		public  Merchant( string userId, string linkmanName, string linkmanPhone, string weChat, string qQ, string email, decimal accountBalance, int deleteMark )
		{
			this.UserId = userId;
			this.LinkmanName = linkmanName;
			this.LinkmanPhone = linkmanPhone;
			this.WeChat = weChat;
			this.QQ = qQ;
			this.Email = email;
			this.AccountBalance = accountBalance;
			this.DeleteMark = deleteMark;
		}
		
		#endregion

		#region Public Properties

		public string UserId { get; set; }
		public string LinkmanName { get; set; }
		public string LinkmanPhone { get; set; }
		public string WeChat { get; set; }
		public string QQ { get; set; }
		public string Email { get; set; }
		public decimal AccountBalance { get; set; }
		public int DeleteMark { get; set; }
        
		#endregion
	}
}