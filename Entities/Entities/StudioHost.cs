
using System;
using Infrastructure.DomainModel;

namespace YYP.Entities
{

    /// <summary>
    /// StudioHost object mapped to table 'TYYP_StudioHost'.
    /// </summary>
    public class StudioHost : EntityBase
    {

        #region Constructors

        public StudioHost() { }

        public StudioHost(string userId, string studioHostName, string tKName, int height, int weight, int shoeSize, string clothesSize, string address, string linkmanName, string linkmanPhone, string weChat, string qQ, string email, int fansNum, int averageDailyViews, string verticalFieldCode, string mainPopActivityType, decimal perCustomerTransactionHight, decimal perCustomerTransactionLow, string alipayAccount, decimal accountBalance, decimal margin, string checkStatus, string remark, DateTime dailyBeginTime, DateTime dailyEndTime, DateTime addTime, DateTime updateTime)
        {
            this.UserId = userId;
            this.StudioHostName = studioHostName;
            this.TKName = tKName;
            this.Height = height;
            this.Weight = weight;
            this.ShoeSize = shoeSize;
            this.ClothesSize = clothesSize;
            this.Address = address;
            this.LinkmanName = linkmanName;
            this.LinkmanPhone = linkmanPhone;
            this.WeChat = weChat;
            this.QQ = qQ;
            this.Email = email;
            this.FansNum = fansNum;
            this.AverageDailyViews = averageDailyViews;
            this.VerticalFieldCode = verticalFieldCode;
            this.MainPopActivityType = mainPopActivityType;
            this.PerCustomerTransactionHight = perCustomerTransactionHight;
            this.PerCustomerTransactionLow = perCustomerTransactionLow;
            this.AlipayAccount = alipayAccount;
            this.AccountBalance = accountBalance;
            this.Margin = margin;
            this.CheckStatus = checkStatus;
            this.Remark = remark;
            this.DailyBeginTime = dailyBeginTime;
            this.DailyEndTime = dailyEndTime;
            this.AddTime = addTime;
            this.UpdateTime = updateTime;
        }

        #endregion

        #region Public Properties

        public string UserId { get; set; }
        public string StudioHostName { get; set; }
        public string TKName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int ShoeSize { get; set; }
        public string ClothesSize { get; set; }
        public string Address { get; set; }
        public string LinkmanName { get; set; }
        public string LinkmanPhone { get; set; }
        public string WeChat { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public int FansNum { get; set; }
        public int AverageDailyViews { get; set; }
        public string VerticalFieldCode { get; set; }
        public string MainPopActivityType { get; set; }
        public decimal PerCustomerTransactionHight { get; set; }
        public decimal PerCustomerTransactionLow { get; set; }
        public string AlipayAccount { get; set; }
        public decimal AccountBalance { get; set; }
        public decimal Margin { get; set; }
        public string CheckStatus { get; set; }
        public string Remark { get; set; }
        public DateTime DailyBeginTime { get; set; }
        public DateTime DailyEndTime { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }

        #endregion
    }
}