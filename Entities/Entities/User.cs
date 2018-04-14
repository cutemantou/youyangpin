
using System;
using Infrastructure.DomainModel;

namespace YYP.Entities
{
	/// <summary>
	/// User object mapped to table 'T_Sys_User'.
	/// </summary>
	public class User : EntityBase
	{
        #region Constructors

        public  User() { }

		public  User( string gUID, string account, string pwd, byte userState, string userType, string trueName, string departmentGuid, string positionGuid, DateTime lastLoginTime, string lastLoginIP, int loginTimes, int loginErrorTimes, string createPerson, DateTime createTime, DateTime expirationDate, string qQ, bool isAdmin, string telPhone, string qQGroup, string returnInfo, string cityName, string provinceName, string email, string gender, string zFBAccount, DateTime updateTime )
		{
			this.GUID = gUID;
			this.Account = account;
			this.Pwd = pwd;
			this.UserState = userState;
			this.UserType = userType;
			this.TrueName = trueName;
			this.DepartmentGuid = departmentGuid;
			this.PositionGuid = positionGuid;
			this.LastLoginTime = lastLoginTime;
			this.LastLoginIP = lastLoginIP;
			this.LoginTimes = loginTimes;
			this.LoginErrorTimes = loginErrorTimes;
			this.CreatePerson = createPerson;
			this.CreateTime = createTime;
			this.ExpirationDate = expirationDate;
			this.QQ = qQ;
			this.IsAdmin = isAdmin;
			this.TelPhone = telPhone;
			this.QQGroup = qQGroup;
			this.ReturnInfo = returnInfo;
			this.CityName = cityName;
			this.ProvinceName = provinceName;
			this.Email = email;
			this.Gender = gender;
			this.ZFBAccount = zFBAccount;
			this.UpdateTime = updateTime;
		}
		
		#endregion

		#region Public Properties

		public string GUID { get; set; }
		public string Account { get; set; }
		public string Pwd { get; set; }
		public byte UserState { get; set; }
		public string UserType { get; set; }
		public string TrueName { get; set; }
		public string DepartmentGuid { get; set; }
		public string PositionGuid { get; set; }
		public DateTime? LastLoginTime { get; set; }
		public string LastLoginIP { get; set; }
		public int LoginTimes { get; set; }
		public int LoginErrorTimes { get; set; }
		public string CreatePerson { get; set; }
		public DateTime? CreateTime { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public string QQ { get; set; }
		public bool IsAdmin { get; set; }
		public string TelPhone { get; set; }
		public string QQGroup { get; set; }
		public string ReturnInfo { get; set; }
		public string CityName { get; set; }
		public string ProvinceName { get; set; }
		public string Email { get; set; }
		public string Gender { get; set; }
		public string ZFBAccount { get; set; }
		public DateTime? UpdateTime { get; set; }
        
		#endregion
	}
}