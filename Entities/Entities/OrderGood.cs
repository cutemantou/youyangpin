using Infrastructure.DomainModel;

namespace YYP.Entities
{
    /// <summary>
    /// OrderGood object mapped to table 'TYYP_OrderGoods'.
    /// </summary>
    public class OrderGood : EntityBase
	{	
		#region Constructors

		public  OrderGood() { }

		public  OrderGood( string orderGoodsId, string orderId, string goodsId )
		{
			this.OrderGoodsId = orderGoodsId;
			this.OrderId = orderId;
			this.GoodsId = goodsId;
		}
		
		#endregion

		#region Public Properties

		public string OrderGoodsId { get; set; }
		public string OrderId { get; set; }
		public string GoodsId { get; set; }
        
		#endregion
	}
}