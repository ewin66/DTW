﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Ssyxfmx_kc_sh_temp
	/// </summary>
	public partial class Ssyxfmx_kc_sh_temp
	{
		private readonly Hotel_app.DAL.Ssyxfmx_kc_sh_temp dal=new Hotel_app.DAL.Ssyxfmx_kc_sh_temp();
		public Ssyxfmx_kc_sh_temp()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.Ssyxfmx_kc_sh_temp model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Ssyxfmx_kc_sh_temp model)
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
		public Hotel_app.Model.Ssyxfmx_kc_sh_temp GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Ssyxfmx_kc_sh_temp GetModelByCache(int id)
		{
			
			string CacheKey = "Ssyxfmx_kc_sh_tempModel-" + id;
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
			return (Hotel_app.Model.Ssyxfmx_kc_sh_temp)objModel;
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
		public List<Hotel_app.Model.Ssyxfmx_kc_sh_temp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Ssyxfmx_kc_sh_temp> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Ssyxfmx_kc_sh_temp> modelList = new List<Hotel_app.Model.Ssyxfmx_kc_sh_temp>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Ssyxfmx_kc_sh_temp model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Ssyxfmx_kc_sh_temp();
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
					if(dt.Rows[n]["id_app"]!=null && dt.Rows[n]["id_app"].ToString()!="")
					{
					model.id_app=dt.Rows[n]["id_app"].ToString();
					}
					if(dt.Rows[n]["ckeckTime"]!=null && dt.Rows[n]["ckeckTime"].ToString()!="")
					{
						model.ckeckTime=DateTime.Parse(dt.Rows[n]["ckeckTime"].ToString());
					}
					if(dt.Rows[n]["xfsj"]!=null && dt.Rows[n]["xfsj"].ToString()!="")
					{
						model.xfsj=DateTime.Parse(dt.Rows[n]["xfsj"].ToString());
					}
					if(dt.Rows[n]["mxbh"]!=null && dt.Rows[n]["mxbh"].ToString()!="")
					{
					model.mxbh=dt.Rows[n]["mxbh"].ToString();
					}
					if(dt.Rows[n]["xfsl"]!=null && dt.Rows[n]["xfsl"].ToString()!="")
					{
						model.xfsl=decimal.Parse(dt.Rows[n]["xfsl"].ToString());
					}
					if(dt.Rows[n]["xfje"]!=null && dt.Rows[n]["xfje"].ToString()!="")
					{
						model.xfje=decimal.Parse(dt.Rows[n]["xfje"].ToString());
					}
					if(dt.Rows[n]["xfxm"]!=null && dt.Rows[n]["xfxm"].ToString()!="")
					{
					model.xfxm=dt.Rows[n]["xfxm"].ToString();
					}
					if(dt.Rows[n]["ischecked"]!=null && dt.Rows[n]["ischecked"].ToString()!="")
					{
						if((dt.Rows[n]["ischecked"].ToString()=="1")||(dt.Rows[n]["ischecked"].ToString().ToLower()=="true"))
						{
						model.ischecked=true;
						}
						else
						{
							model.ischecked=false;
						}
					}
					if(dt.Rows[n]["xftm"]!=null && dt.Rows[n]["xftm"].ToString()!="")
					{
					model.xftm=dt.Rows[n]["xftm"].ToString();
					}
					if(dt.Rows[n]["tjrq"]!=null && dt.Rows[n]["tjrq"].ToString()!="")
					{
						model.tjrq=DateTime.Parse(dt.Rows[n]["tjrq"].ToString());
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

