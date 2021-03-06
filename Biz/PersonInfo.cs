﻿using System;
using System.Data;
using System.Collections.Generic;
//using Maticsoft.Common;
using com.gxchuwei.Model;
namespace com.gxchuwei.BLL
{
	/// <summary>
	/// PersonInfo
	/// </summary>
	public partial class PersonInfo
	{
		private readonly com.gxchuwei.DAL.PersonInfo dal=new com.gxchuwei.DAL.PersonInfo();
		public PersonInfo()
		{}
		#region  BasicMethod

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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(com.gxchuwei.Model.PersonInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(com.gxchuwei.Model.PersonInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		//public bool DeleteList(string IDlist )
		//{
		//	return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(IDlist,0) );
		//}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public com.gxchuwei.Model.PersonInfo GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public com.gxchuwei.Model.PersonInfo GetModelByCache(int ID)
		//{
			
		//	string CacheKey = "PersonInfoModel-" + ID;
		//	object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(ID);
		//			if (objModel != null)
		//			{
		//				int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
		//				Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (com.gxchuwei.Model.PersonInfo)objModel;
		//}

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
		public List<com.gxchuwei.Model.PersonInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获取管控人员列表（包含同住人员)
        /// </summary>
        public List<com.gxchuwei.Model.PersonInfo> GetChargeManList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<com.gxchuwei.Model.PersonInfo> list = DataTableToList(ds.Tables[0]);
            List<com.gxchuwei.Model.PersonInfo> newList = new List<Model.PersonInfo>();
            foreach (var item in list)
            {
                item.TogetherPerson = new List<Model.PersonInfo>();
                if (item.PID != 0)//那这个节点一定有爸爸
                {
                    com.gxchuwei.Model.PersonInfo dadNode = list.Find(x => x.ID == item.PID); //找出爸爸
                    item.TogetherPerson.Add(dadNode); //将爸爸节点添加到同行人员
                  
                }
                else //找儿子
                {
                    List<com.gxchuwei.Model.PersonInfo> sonList = list.FindAll(x => x.PID == item.ID);
                    if (sonList.Count > 0)
                    {
                        foreach (var son in sonList)
                        {
                            com.gxchuwei.Model.PersonInfo newSon = new Model.PersonInfo();
                            newSon.PersonName = son.PersonName;
                            item.TogetherPerson.Add(newSon);
                        }
                    }
                }
                newList.Add(item);
            }


            

            return newList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<com.gxchuwei.Model.PersonInfo> DataTableToList(DataTable dt)
		{
			List<com.gxchuwei.Model.PersonInfo> modelList = new List<com.gxchuwei.Model.PersonInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				com.gxchuwei.Model.PersonInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

