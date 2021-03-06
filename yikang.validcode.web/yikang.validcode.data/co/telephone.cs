﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yikang.validcode.data.Model.co
{
	/// <summary>
	/// telephone:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    [Table("t_telephone")]
    public partial class Telephone
    {
		public Telephone()
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
		private string _phone;
		private int? _status;
		private string _areaname;
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
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		#endregion Model

	}
}

