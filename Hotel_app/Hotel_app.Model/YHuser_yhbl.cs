﻿using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// YHuser_yhbl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YHuser_yhbl
	{
		public YHuser_yhbl()
		{}
		#region Model
		private int _id;
		private string _yydh="";
		private string _qymc="";
		private string _user_type="";
		private string _type_explain="";
		private string _yh="";
		private decimal _yhbl=1M;
		private bool _is_top= false;
		private bool _is_select= false;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yydh
		{
			set{ _yydh=value;}
			get{return _yydh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qymc
		{
			set{ _qymc=value;}
			get{return _qymc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_type
		{
			set{ _user_type=value;}
			get{return _user_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_explain
		{
			set{ _type_explain=value;}
			get{return _type_explain;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yh
		{
			set{ _yh=value;}
			get{return _yh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal yhbl
		{
			set{ _yhbl=value;}
			get{return _yhbl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_top
		{
			set{ _is_top=value;}
			get{return _is_top;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool is_select
		{
			set{ _is_select=value;}
			get{return _is_select;}
		}
		#endregion Model

	}
}

