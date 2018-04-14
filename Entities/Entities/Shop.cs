using Infrastructure.DomainModel;

namespace YYP.Entities
{
    /// <summary>
    /// Shop object mapped to table 'TYYP_Shop'.
    /// </summary>
    public class Shop : EntityBase
	{
		#region Constructors

		public  Shop() { }

		public  Shop( string shopId, string userId, string shopType, string shopName, string verticalFieldCode, string shopURL, string wangWangNo, string shopAddress, decimal descriptionMatch, decimal serviceAttitude, decimal logisticsService, string checkStatus, int deleteMark )
		{
			this.ShopId = shopId;
			this.UserId = userId;
			this.ShopType = shopType;
			this.ShopName = shopName;
			this.VerticalFieldCode = verticalFieldCode;
			this.ShopURL = shopURL;
			this.WangWangNo = wangWangNo;
			this.ShopAddress = shopAddress;
			this.DescriptionMatch = descriptionMatch;
			this.ServiceAttitude = serviceAttitude;
			this.LogisticsService = logisticsService;
			this.CheckStatus = checkStatus;
			this.DeleteMark = deleteMark;
		}
		
		#endregion

		#region Public Properties

		public string ShopId { get; set; }
		public string UserId { get; set; }
		public string ShopType { get; set; }
		public string ShopName { get; set; }
		public string VerticalFieldCode { get; set; }
		public string ShopURL { get; set; }
		public string WangWangNo { get; set; }
		public string ShopAddress { get; set; }
		public decimal DescriptionMatch { get; set; }
		public decimal ServiceAttitude { get; set; }
		public decimal LogisticsService { get; set; }
		public string CheckStatus { get; set; }
		public int DeleteMark { get; set; }
        
		#endregion
	}
}