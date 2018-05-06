using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yikang.validcode.data.Model.co
{
	/// <summary>
	/// paymoney:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Table("T_PayMoney")]
	public partial class PayMoney
	{
		public PayMoney()
		{}
		#region Model
		private int _id;
		private string _uid;
		private int? _isenabled;
		private DateTime? _createtime;
		private int? _createuser;
		private DateTime? _updatetime;
		private int? _updateuser;
		private DateTime? _deletedtime;
		private int? _deleteuser;
		private string _userloginname;
		private int? _userid;
		private string _companyname;
		private decimal? _paytype;
		private decimal? _price;
		private string _note;
		private int? _statue;
		private string _orderno;
		private string _filename;
		private decimal? _currentmoney;
		private decimal? _overmoney;
        /// <summary>
        /// auto_increment
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UId
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsEnabled
		{
			set{ _isenabled=value;}
			get{return _isenabled;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UpdateUser
		{
			set{ _updateuser=value;}
			get{return _updateuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DeletedTime
		{
			set{ _deletedtime=value;}
			get{return _deletedtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DeleteUser
		{
			set{ _deleteuser=value;}
			get{return _deleteuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserLoginName
		{
			set{ _userloginname=value;}
			get{return _userloginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PayType
		{
			set{ _paytype=value;}
			get{return _paytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Statue
		{
			set{ _statue=value;}
			get{return _statue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CurrentMoney
		{
			set{ _currentmoney=value;}
			get{return _currentmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OverMoney
		{
			set{ _overmoney=value;}
			get{return _overmoney;}
		}
		#endregion Model

	}
}

