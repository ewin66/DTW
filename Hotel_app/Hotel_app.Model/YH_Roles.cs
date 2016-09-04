﻿using System;
namespace Hotel_app.Model
{
	/// <summary>
	/// YH_Roles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class YH_Roles
	{
		public YH_Roles()
		{}
		#region Model
		private int _id;
		private string _yydh;
		private string _qymc;
		private string _r_lsbh;
		private string _r_rolesname;
		private string _r_bz;
		private int _r_ts=1;
		private bool _is_top= false;
		private bool _is_select= false;
		/// <summary>
		/// 
		/// </summary>
		public int ID
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
		public string R_lsbh
		{
			set{ _r_lsbh=value;}
			get{return _r_lsbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R_RolesName
		{
			set{ _r_rolesname=value;}
			get{return _r_rolesname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R_Bz
		{
			set{ _r_bz=value;}
			get{return _r_bz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int R_ts
		{
			set{ _r_ts=value;}
			get{return _r_ts;}
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

