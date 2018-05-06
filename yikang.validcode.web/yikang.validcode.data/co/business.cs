using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yikang.validcode.data.Model.co
{
	/// <summary>
	/// business:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Table("t_business")]
	public partial class Business
	{
		public Business()
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
		private string _userid;
		private string _telephoneid;
		private string _content;
		private string _sendport;
		private int? _projectid;
		private string _projectname;
		private int? _cardbusid;
		private decimal? _cardbusmoeny;
		private decimal? _userprice;
		private int? _busmode;
		private string _validcode;
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
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelephoneId
		{
			set{ _telephoneid=value;}
			get{return _telephoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendPort
		{
			set{ _sendport=value;}
			get{return _sendport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProjectId
		{
			set{ _projectid=value;}
			get{return _projectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CardBusId
		{
			set{ _cardbusid=value;}
			get{return _cardbusid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CardBusMoeny
		{
			set{ _cardbusmoeny=value;}
			get{return _cardbusmoeny;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UserPrice
		{
			set{ _userprice=value;}
			get{return _userprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BusMode
		{
			set{ _busmode=value;}
			get{return _busmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ValidCode
		{
			set{ _validcode=value;}
			get{return _validcode;}
		}
		#endregion Model

	}
}

