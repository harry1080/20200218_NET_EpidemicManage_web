using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
//using Maticsoft.DBUtility;//Please add references
namespace com.gxchuwei.DAL
{
	/// <summary>
	/// 数据访问类:PersonRecord
	/// </summary>
	public partial class PersonRecord
	{
		public PersonRecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "PersonRecord"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PersonRecord");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(com.gxchuwei.Model.PersonRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PersonRecord(");
			strSql.Append("PersonID,DeclarationTime,Temp,HealthState,Remark,LocationX,LocationY,Location)");
			strSql.Append(" values (");
			strSql.Append("@PersonID,@DeclarationTime,@Temp,@HealthState,@Remark,@LocationX,@LocationY,@Location)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PersonID", SqlDbType.Int,4),
					new SqlParameter("@DeclarationTime", SqlDbType.DateTime),
					new SqlParameter("@Temp", SqlDbType.Decimal,9),
					new SqlParameter("@HealthState", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@LocationX", SqlDbType.Decimal,9),
					new SqlParameter("@LocationY", SqlDbType.Decimal,9),
					new SqlParameter("@Location", SqlDbType.VarChar,200)};
			parameters[0].Value = model.PersonID;
			parameters[1].Value = model.DeclarationTime;
			parameters[2].Value = model.Temp;
			parameters[3].Value = model.HealthState;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.LocationX;
			parameters[6].Value = model.LocationY;
			parameters[7].Value = model.Location;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(com.gxchuwei.Model.PersonRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PersonRecord set ");
			strSql.Append("PersonID=@PersonID,");
			strSql.Append("DeclarationTime=@DeclarationTime,");
			strSql.Append("Temp=@Temp,");
			strSql.Append("HealthState=@HealthState,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("LocationX=@LocationX,");
			strSql.Append("LocationY=@LocationY,");
			strSql.Append("Location=@Location");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@PersonID", SqlDbType.Int,4),
					new SqlParameter("@DeclarationTime", SqlDbType.DateTime),
					new SqlParameter("@Temp", SqlDbType.Decimal,9),
					new SqlParameter("@HealthState", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@LocationX", SqlDbType.Decimal,9),
					new SqlParameter("@LocationY", SqlDbType.Decimal,9),
					new SqlParameter("@Location", SqlDbType.VarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.PersonID;
			parameters[1].Value = model.DeclarationTime;
			parameters[2].Value = model.Temp;
			parameters[3].Value = model.HealthState;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.LocationX;
			parameters[6].Value = model.LocationY;
			parameters[7].Value = model.Location;
			parameters[8].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonRecord ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonRecord ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public com.gxchuwei.Model.PersonRecord GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PersonID,DeclarationTime,Temp,HealthState,Remark,LocationX,LocationY,Location from PersonRecord ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			com.gxchuwei.Model.PersonRecord model=new com.gxchuwei.Model.PersonRecord();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public com.gxchuwei.Model.PersonRecord DataRowToModel(DataRow row)
		{
			com.gxchuwei.Model.PersonRecord model=new com.gxchuwei.Model.PersonRecord();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PersonID"]!=null && row["PersonID"].ToString()!="")
				{
					model.PersonID=int.Parse(row["PersonID"].ToString());
				}
				if(row["DeclarationTime"]!=null && row["DeclarationTime"].ToString()!="")
				{
					model.DeclarationTime=DateTime.Parse(row["DeclarationTime"].ToString());
				}
				if(row["Temp"]!=null && row["Temp"].ToString()!="")
				{
					model.Temp=decimal.Parse(row["Temp"].ToString());
				}
				if(row["HealthState"]!=null)
				{
					model.HealthState=row["HealthState"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["LocationX"]!=null && row["LocationX"].ToString()!="")
				{
					model.LocationX=decimal.Parse(row["LocationX"].ToString());
				}
				if(row["LocationY"]!=null && row["LocationY"].ToString()!="")
				{
					model.LocationY=decimal.Parse(row["LocationY"].ToString());
				}
				if(row["Location"]!=null)
				{
					model.Location=row["Location"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,PersonID,DeclarationTime,Temp,HealthState,Remark,LocationX,LocationY,Location ");
			strSql.Append(" FROM PersonRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,PersonID,DeclarationTime,Temp,HealthState,Remark,LocationX,LocationY,Location ");
			strSql.Append(" FROM PersonRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM PersonRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from PersonRecord T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "PersonRecord";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

