﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// F_ftfx_7days_zy
	/// </summary>
	public partial class F_ftfx_7days_zy
	{
		private readonly Hotel_app.DAL.F_ftfx_7days_zy dal=new Hotel_app.DAL.F_ftfx_7days_zy();
		public F_ftfx_7days_zy()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.F_ftfx_7days_zy model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.F_ftfx_7days_zy model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.F_ftfx_7days_zy GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.F_ftfx_7days_zy GetModelByCache(int id)
		{
			
			string CacheKey = "F_ftfx_7days_zyModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hotel_app.Model.F_ftfx_7days_zy)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.F_ftfx_7days_zy> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.F_ftfx_7days_zy> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.F_ftfx_7days_zy> modelList = new List<Hotel_app.Model.F_ftfx_7days_zy>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.F_ftfx_7days_zy model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.F_ftfx_7days_zy();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["zyzt"]!=null && dt.Rows[n]["zyzt"].ToString()!="")
					{
					model.zyzt=dt.Rows[n]["zyzt"].ToString();
					}
					if(dt.Rows[n]["frhj"]!=null && dt.Rows[n]["frhj"].ToString()!="")
					{
					model.frhj=dt.Rows[n]["frhj"].ToString();
					}
					if(dt.Rows[n]["fx_value_yd_1"]!=null && dt.Rows[n]["fx_value_yd_1"].ToString()!="")
					{
					model.fx_value_yd_1=dt.Rows[n]["fx_value_yd_1"].ToString();
					}
					if(dt.Rows[n]["fx_value_1"]!=null && dt.Rows[n]["fx_value_1"].ToString()!="")
					{
					model.fx_value_1=dt.Rows[n]["fx_value_1"].ToString();
					}
					if(dt.Rows[n]["fx_value_yd_2"]!=null && dt.Rows[n]["fx_value_yd_2"].ToString()!="")
					{
					model.fx_value_yd_2=dt.Rows[n]["fx_value_yd_2"].ToString();
					}
					if(dt.Rows[n]["fx_value_2"]!=null && dt.Rows[n]["fx_value_2"].ToString()!="")
					{
					model.fx_value_2=dt.Rows[n]["fx_value_2"].ToString();
					}
					if(dt.Rows[n]["fx_value_yd_3"]!=null && dt.Rows[n]["fx_value_yd_3"].ToString()!="")
					{
					model.fx_value_yd_3=dt.Rows[n]["fx_value_yd_3"].ToString();
					}
					if(dt.Rows[n]["fx_value_3"]!=null && dt.Rows[n]["fx_value_3"].ToString()!="")
					{
					model.fx_value_3=dt.Rows[n]["fx_value_3"].ToString();
					}
					if(dt.Rows[n]["fx_value_yd_4"]!=null && dt.Rows[n]["fx_value_yd_4"].ToString()!="")
					{
					model.fx_value_yd_4=dt.Rows[n]["fx_value_yd_4"].ToString();
					}
					if(dt.Rows[n]["fx_value_4"]!=null && dt.Rows[n]["fx_value_4"].ToString()!="")
					{
					model.fx_value_4=dt.Rows[n]["fx_value_4"].ToString();
					}
					if(dt.Rows[n]["fx_value_yd_5"]!=null && dt.Rows[n]["fx_value_yd_5"].ToString()!="")
					{
					model.fx_value_yd_5=dt.Rows[n]["fx_value_yd_5"].ToString();
					}
					if(dt.Rows[n]["fx_value_5"]!=null && dt.Rows[n]["fx_value_5"].ToString()!="")
					{
					model.fx_value_5=dt.Rows[n]["fx_value_5"].ToString();
					}
					if(dt.Rows[n]["fx_value_yd_6"]!=null && dt.Rows[n]["fx_value_yd_6"].ToString()!="")
					{
					model.fx_value_yd_6=dt.Rows[n]["fx_value_yd_6"].ToString();
					}
					if(dt.Rows[n]["fx_value_6"]!=null && dt.Rows[n]["fx_value_6"].ToString()!="")
					{
					model.fx_value_6=dt.Rows[n]["fx_value_6"].ToString();
					}
					if(dt.Rows[n]["fx_value_yd_7"]!=null && dt.Rows[n]["fx_value_yd_7"].ToString()!="")
					{
					model.fx_value_yd_7=dt.Rows[n]["fx_value_yd_7"].ToString();
					}
					if(dt.Rows[n]["fx_value_7"]!=null && dt.Rows[n]["fx_value_7"].ToString()!="")
					{
					model.fx_value_7=dt.Rows[n]["fx_value_7"].ToString();
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["is_top"]!=null && dt.Rows[n]["is_top"].ToString()!="")
					{
						if((dt.Rows[n]["is_top"].ToString()=="1")||(dt.Rows[n]["is_top"].ToString().ToLower()=="true"))
						{
						model.is_top=true;
						}
						else
						{
							model.is_top=false;
						}
					}
					if(dt.Rows[n]["is_select"]!=null && dt.Rows[n]["is_select"].ToString()!="")
					{
						if((dt.Rows[n]["is_select"].ToString()=="1")||(dt.Rows[n]["is_select"].ToString().ToLower()=="true"))
						{
						model.is_select=true;
						}
						else
						{
							model.is_select=false;
						}
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

