﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Sjzmx_gd_temp
	/// </summary>
	public partial class Sjzmx_gd_temp
	{
		private readonly Hotel_app.DAL.Sjzmx_gd_temp dal=new Hotel_app.DAL.Sjzmx_gd_temp();
		public Sjzmx_gd_temp()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.Sjzmx_gd_temp model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Sjzmx_gd_temp model)
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
		public Hotel_app.Model.Sjzmx_gd_temp GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Sjzmx_gd_temp GetModelByCache(int id)
		{
			
			string CacheKey = "Sjzmx_gd_tempModel-" + id;
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
			return (Hotel_app.Model.Sjzmx_gd_temp)objModel;
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
		public List<Hotel_app.Model.Sjzmx_gd_temp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Sjzmx_gd_temp> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Sjzmx_gd_temp> modelList = new List<Hotel_app.Model.Sjzmx_gd_temp>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Sjzmx_gd_temp model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Sjzmx_gd_temp();
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
					if(dt.Rows[n]["jzbh"]!=null && dt.Rows[n]["jzbh"].ToString()!="")
					{
					model.jzbh=dt.Rows[n]["jzbh"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["fjrb"]!=null && dt.Rows[n]["fjrb"].ToString()!="")
					{
					model.fjrb=dt.Rows[n]["fjrb"].ToString();
					}
					if(dt.Rows[n]["fjbh"]!=null && dt.Rows[n]["fjbh"].ToString()!="")
					{
					model.fjbh=dt.Rows[n]["fjbh"].ToString();
					}
					if(dt.Rows[n]["sktt"]!=null && dt.Rows[n]["sktt"].ToString()!="")
					{
					model.sktt=dt.Rows[n]["sktt"].ToString();
					}
					if(dt.Rows[n]["xfrq"]!=null && dt.Rows[n]["xfrq"].ToString()!="")
					{
						model.xfrq=DateTime.Parse(dt.Rows[n]["xfrq"].ToString());
					}
					if(dt.Rows[n]["xfsj"]!=null && dt.Rows[n]["xfsj"].ToString()!="")
					{
						model.xfsj=DateTime.Parse(dt.Rows[n]["xfsj"].ToString());
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["xfrb"]!=null && dt.Rows[n]["xfrb"].ToString()!="")
					{
					model.xfrb=dt.Rows[n]["xfrb"].ToString();
					}
					if(dt.Rows[n]["xfdr"]!=null && dt.Rows[n]["xfdr"].ToString()!="")
					{
					model.xfdr=dt.Rows[n]["xfdr"].ToString();
					}
					if(dt.Rows[n]["xfxm"]!=null && dt.Rows[n]["xfxm"].ToString()!="")
					{
					model.xfxm=dt.Rows[n]["xfxm"].ToString();
					}
					if(dt.Rows[n]["xfbz"]!=null && dt.Rows[n]["xfbz"].ToString()!="")
					{
					model.xfbz=dt.Rows[n]["xfbz"].ToString();
					}
					if(dt.Rows[n]["xfzy"]!=null && dt.Rows[n]["xfzy"].ToString()!="")
					{
					model.xfzy=dt.Rows[n]["xfzy"].ToString();
					}
					if(dt.Rows[n]["jjje"]!=null && dt.Rows[n]["jjje"].ToString()!="")
					{
						model.jjje=decimal.Parse(dt.Rows[n]["jjje"].ToString());
					}
					if(dt.Rows[n]["yh"]!=null && dt.Rows[n]["yh"].ToString()!="")
					{
					model.yh=dt.Rows[n]["yh"].ToString();
					}
					if(dt.Rows[n]["xfje"]!=null && dt.Rows[n]["xfje"].ToString()!="")
					{
						model.xfje=decimal.Parse(dt.Rows[n]["xfje"].ToString());
					}
					if(dt.Rows[n]["sjxfje"]!=null && dt.Rows[n]["sjxfje"].ToString()!="")
					{
						model.sjxfje=decimal.Parse(dt.Rows[n]["sjxfje"].ToString());
					}
					if(dt.Rows[n]["xfsl"]!=null && dt.Rows[n]["xfsl"].ToString()!="")
					{
						model.xfsl=decimal.Parse(dt.Rows[n]["xfsl"].ToString());
					}
					if(dt.Rows[n]["shsc"]!=null && dt.Rows[n]["shsc"].ToString()!="")
					{
						if((dt.Rows[n]["shsc"].ToString()=="1")||(dt.Rows[n]["shsc"].ToString().ToLower()=="true"))
						{
						model.shsc=true;
						}
						else
						{
							model.shsc=false;
						}
					}
					if(dt.Rows[n]["czzt"]!=null && dt.Rows[n]["czzt"].ToString()!="")
					{
					model.czzt=dt.Rows[n]["czzt"].ToString();
					}
					if(dt.Rows[n]["czy_bc"]!=null && dt.Rows[n]["czy_bc"].ToString()!="")
					{
					model.czy_bc=dt.Rows[n]["czy_bc"].ToString();
					}
					if(dt.Rows[n]["tfsj"]!=null && dt.Rows[n]["tfsj"].ToString()!="")
					{
						model.tfsj=DateTime.Parse(dt.Rows[n]["tfsj"].ToString());
					}
					if(dt.Rows[n]["czsj"]!=null && dt.Rows[n]["czsj"].ToString()!="")
					{
						model.czsj=DateTime.Parse(dt.Rows[n]["czsj"].ToString());
					}
					if(dt.Rows[n]["is_visible"]!=null && dt.Rows[n]["is_visible"].ToString()!="")
					{
						if((dt.Rows[n]["is_visible"].ToString()=="1")||(dt.Rows[n]["is_visible"].ToString().ToLower()=="true"))
						{
						model.is_visible=true;
						}
						else
						{
							model.is_visible=false;
						}
					}
					if(dt.Rows[n]["syzd"]!=null && dt.Rows[n]["syzd"].ToString()!="")
					{
					model.syzd=dt.Rows[n]["syzd"].ToString();
					}
					if(dt.Rows[n]["xyh"]!=null && dt.Rows[n]["xyh"].ToString()!="")
					{
					model.xyh=dt.Rows[n]["xyh"].ToString();
					}
					if(dt.Rows[n]["jzzt"]!=null && dt.Rows[n]["jzzt"].ToString()!="")
					{
					model.jzzt=dt.Rows[n]["jzzt"].ToString();
					}
					if(dt.Rows[n]["fkfs"]!=null && dt.Rows[n]["fkfs"].ToString()!="")
					{
					model.fkfs=dt.Rows[n]["fkfs"].ToString();
					}
					if(dt.Rows[n]["mxbh"]!=null && dt.Rows[n]["mxbh"].ToString()!="")
					{
					model.mxbh=dt.Rows[n]["mxbh"].ToString();
					}
					if(dt.Rows[n]["zd_fkje"]!=null && dt.Rows[n]["zd_fkje"].ToString()!="")
					{
						model.zd_fkje=decimal.Parse(dt.Rows[n]["zd_fkje"].ToString());
					}
					if(dt.Rows[n]["zd_xfje"]!=null && dt.Rows[n]["zd_xfje"].ToString()!="")
					{
						model.zd_xfje=decimal.Parse(dt.Rows[n]["zd_xfje"].ToString());
					}
					if(dt.Rows[n]["zd_ddsj"]!=null && dt.Rows[n]["zd_ddsj"].ToString()!="")
					{
						model.zd_ddsj=DateTime.Parse(dt.Rows[n]["zd_ddsj"].ToString());
					}
					if(dt.Rows[n]["zd_tfsj"]!=null && dt.Rows[n]["zd_tfsj"].ToString()!="")
					{
						model.zd_tfsj=DateTime.Parse(dt.Rows[n]["zd_tfsj"].ToString());
					}
					if(dt.Rows[n]["zd_fjbh"]!=null && dt.Rows[n]["zd_fjbh"].ToString()!="")
					{
					model.zd_fjbh=dt.Rows[n]["zd_fjbh"].ToString();
					}
					if(dt.Rows[n]["zd_krxm_lz"]!=null && dt.Rows[n]["zd_krxm_lz"].ToString()!="")
					{
					model.zd_krxm_lz=dt.Rows[n]["zd_krxm_lz"].ToString();
					}
					if(dt.Rows[n]["zd_fjbh_lz"]!=null && dt.Rows[n]["zd_fjbh_lz"].ToString()!="")
					{
					model.zd_fjbh_lz=dt.Rows[n]["zd_fjbh_lz"].ToString();
					}
					if(dt.Rows[n]["czy_temp"]!=null && dt.Rows[n]["czy_temp"].ToString()!="")
					{
					model.czy_temp=dt.Rows[n]["czy_temp"].ToString();
					}
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
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

