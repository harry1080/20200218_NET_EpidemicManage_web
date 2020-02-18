using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using DBUtility;

namespace com.gxchuwei.DAL
{
	/// <summary>
	/// 数据访问类:PersonInfo
	/// </summary>
	public partial class PersonInfo
	{
		public PersonInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "PersonInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PersonInfo");
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
		public int Add(com.gxchuwei.Model.PersonInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PersonInfo(");
			strSql.Append("PersonType,PersonName,Sex,IDCardNo,PhoneNo,Native,ArriveTime,ArrivePurpose,Traffic,PhysicalState,LastTemp,NowAddress,DisposeType,ManageMan,ManageManPhone,LocationX,LocationY,Location,ByeondWarning,UserType,LoginName,LoginPassword,IsAdmin,RecordLastTime,Area)");
			strSql.Append(" values (");
			strSql.Append("@PersonType,@PersonName,@Sex,@IDCardNo,@PhoneNo,@Native,@ArriveTime,@ArrivePurpose,@Traffic,@PhysicalState,@LastTemp,@NowAddress,@DisposeType,@ManageMan,@ManageManPhone,@LocationX,@LocationY,@Location,@ByeondWarning,@UserType,@LoginName,@LoginPassword,@IsAdmin,@RecordLastTime,@Area)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PersonType", SqlDbType.VarChar,50),
					new SqlParameter("@PersonName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@IDCardNo", SqlDbType.VarChar,50),
					new SqlParameter("@PhoneNo", SqlDbType.VarChar,50),
					new SqlParameter("@Native", SqlDbType.VarChar,200),
					new SqlParameter("@ArriveTime", SqlDbType.DateTime),
					new SqlParameter("@ArrivePurpose", SqlDbType.VarChar,200),
					new SqlParameter("@Traffic", SqlDbType.VarChar,50),
					new SqlParameter("@PhysicalState", SqlDbType.VarChar,50),
					new SqlParameter("@LastTemp", SqlDbType.Decimal,9),
					new SqlParameter("@NowAddress", SqlDbType.VarChar,200),
					new SqlParameter("@DisposeType", SqlDbType.VarChar,50),
					new SqlParameter("@ManageMan", SqlDbType.VarChar,50),
					new SqlParameter("@ManageManPhone", SqlDbType.VarChar,20),
					new SqlParameter("@LocationX", SqlDbType.Decimal,9),
					new SqlParameter("@LocationY", SqlDbType.Decimal,9),
					new SqlParameter("@Location", SqlDbType.VarChar,200),
					new SqlParameter("@ByeondWarning", SqlDbType.VarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@LoginPassword", SqlDbType.VarChar,50),
					new SqlParameter("@IsAdmin", SqlDbType.VarChar,10),
					new SqlParameter("@RecordLastTime", SqlDbType.DateTime),
                    new SqlParameter("@Area", SqlDbType.VarChar, 10)};
            parameters[0].Value = model.PersonType;
			parameters[1].Value = model.PersonName;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.IDCardNo;
			parameters[4].Value = model.PhoneNo;
			parameters[5].Value = model.Native;
			parameters[6].Value = model.ArriveTime;
			parameters[7].Value = model.ArrivePurpose;
			parameters[8].Value = model.Traffic;
			parameters[9].Value = model.PhysicalState;
			parameters[10].Value = model.LastTemp;
			parameters[11].Value = model.NowAddress;
			parameters[12].Value = model.DisposeType;
			parameters[13].Value = model.ManageMan;
			parameters[14].Value = model.ManageManPhone;
			parameters[15].Value = model.LocationX;
			parameters[16].Value = model.LocationY;
			parameters[17].Value = model.Location;
			parameters[18].Value = model.ByeondWarning;
			parameters[19].Value = model.UserType;
			parameters[20].Value = model.LoginName;
			parameters[21].Value = model.LoginPassword;
			parameters[22].Value = model.IsAdmin;
			parameters[23].Value = model.RecordLastTime;
            parameters[24].Value = model.Area;
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
		public bool Update(com.gxchuwei.Model.PersonInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PersonInfo set ");
			strSql.Append("PersonType=@PersonType,");
			strSql.Append("PersonName=@PersonName,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("IDCardNo=@IDCardNo,");
			strSql.Append("PhoneNo=@PhoneNo,");
			strSql.Append("Native=@Native,");
			strSql.Append("ArriveTime=@ArriveTime,");
			strSql.Append("ArrivePurpose=@ArrivePurpose,");
			strSql.Append("Traffic=@Traffic,");
			strSql.Append("PhysicalState=@PhysicalState,");
			strSql.Append("LastTemp=@LastTemp,");
			strSql.Append("NowAddress=@NowAddress,");
			strSql.Append("DisposeType=@DisposeType,");
			strSql.Append("ManageMan=@ManageMan,");
			strSql.Append("ManageManPhone=@ManageManPhone,");
			strSql.Append("LocationX=@LocationX,");
			strSql.Append("LocationY=@LocationY,");
			strSql.Append("Location=@Location,");
			strSql.Append("ByeondWarning=@ByeondWarning,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("LoginName=@LoginName,");
			strSql.Append("LoginPassword=@LoginPassword,");
			strSql.Append("IsAdmin=@IsAdmin,");
			strSql.Append("RecordLastTime=@RecordLastTime,");
            strSql.Append("Area=@Area");
            strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@PersonType", SqlDbType.VarChar,50),
					new SqlParameter("@PersonName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@IDCardNo", SqlDbType.VarChar,50),
					new SqlParameter("@PhoneNo", SqlDbType.VarChar,50),
					new SqlParameter("@Native", SqlDbType.VarChar,200),
					new SqlParameter("@ArriveTime", SqlDbType.DateTime),
					new SqlParameter("@ArrivePurpose", SqlDbType.VarChar,200),
					new SqlParameter("@Traffic", SqlDbType.VarChar,50),
					new SqlParameter("@PhysicalState", SqlDbType.VarChar,50),
					new SqlParameter("@LastTemp", SqlDbType.Decimal,9),
					new SqlParameter("@NowAddress", SqlDbType.VarChar,200),
					new SqlParameter("@DisposeType", SqlDbType.VarChar,50),
					new SqlParameter("@ManageMan", SqlDbType.VarChar,50),
					new SqlParameter("@ManageManPhone", SqlDbType.VarChar,20),
					new SqlParameter("@LocationX", SqlDbType.Decimal,9),
					new SqlParameter("@LocationY", SqlDbType.Decimal,9),
					new SqlParameter("@Location", SqlDbType.VarChar,200),
					new SqlParameter("@ByeondWarning", SqlDbType.VarChar,50),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@LoginPassword", SqlDbType.VarChar,50),
					new SqlParameter("@IsAdmin", SqlDbType.VarChar,10),
					new SqlParameter("@RecordLastTime", SqlDbType.DateTime),
                    new SqlParameter("@Area", SqlDbType.VarChar,10),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.PersonType;
			parameters[1].Value = model.PersonName;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.IDCardNo;
			parameters[4].Value = model.PhoneNo;
			parameters[5].Value = model.Native;
			parameters[6].Value = model.ArriveTime;
			parameters[7].Value = model.ArrivePurpose;
			parameters[8].Value = model.Traffic;
			parameters[9].Value = model.PhysicalState;
			parameters[10].Value = model.LastTemp;
			parameters[11].Value = model.NowAddress;
			parameters[12].Value = model.DisposeType;
			parameters[13].Value = model.ManageMan;
			parameters[14].Value = model.ManageManPhone;
			parameters[15].Value = model.LocationX;
			parameters[16].Value = model.LocationY;
			parameters[17].Value = model.Location;
			parameters[18].Value = model.ByeondWarning;
			parameters[19].Value = model.UserType;
			parameters[20].Value = model.LoginName;
			parameters[21].Value = model.LoginPassword;
			parameters[22].Value = model.IsAdmin;
			parameters[23].Value = model.RecordLastTime;
            parameters[24].Value = model.Area;
            parameters[25].Value = model.ID;

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
			strSql.Append("delete from PersonInfo ");
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
			strSql.Append("delete from PersonInfo ");
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
		public com.gxchuwei.Model.PersonInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PersonType,PersonName,Sex,IDCardNo,PhoneNo,Native,ArriveTime,ArrivePurpose,Traffic,PhysicalState,LastTemp,LastTempDate,NowAddress,DisposeType,ManageMan,ManageManPhone,LocationX,LocationY,Location,ByeondWarning,UserType,LoginName,LoginPassword,IsAdmin,RecordLastTime,Area from PersonInfo ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			com.gxchuwei.Model.PersonInfo model=new com.gxchuwei.Model.PersonInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count>0)
			{
                com.gxchuwei.Model.PersonInfo p = DataRowToModel(ds.Tables[0].Rows[0]);
                p.TogetherPerson = new System.Collections.Generic.List<Model.PersonInfo>();
                //zdh 20200218添加同行人员
                string sql1 = " select * from  PersonInfo where PID = " + ID + "";
                string sql2 = "select * from personinfo where id in (select pid from personinfo where id = "+ID+")";

                DataSet ds1 = DbHelperSQL.Query(sql1);
                foreach (DataRow item in ds1.Tables[0].Rows)
                {
                    com.gxchuwei.Model.PersonInfo p1 = DataRowToModel(item);
                    p.TogetherPerson.Add(p1);
                }
                DataSet ds2 = DbHelperSQL.Query(sql2);
                foreach (DataRow item2 in ds2.Tables[0].Rows)
                {
                    com.gxchuwei.Model.PersonInfo p2 = DataRowToModel(item2);
                    p.TogetherPerson.Add(p2);
                }
                return p;
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public com.gxchuwei.Model.PersonInfo DataRowToModel(DataRow row)
		{
			com.gxchuwei.Model.PersonInfo model=new com.gxchuwei.Model.PersonInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PersonType"]!=null)
				{
					model.PersonType=row["PersonType"].ToString();
				}
				if(row["PersonName"]!=null)
				{
					model.PersonName=row["PersonName"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["IDCardNo"]!=null)
				{
					model.IDCardNo=row["IDCardNo"].ToString();
				}
				if(row["PhoneNo"]!=null)
				{
					model.PhoneNo=row["PhoneNo"].ToString();
				}
				if(row["Native"]!=null)
				{
					model.Native=row["Native"].ToString();
				}
				if(row["ArriveTime"]!=null && row["ArriveTime"].ToString()!="")
				{
					model.ArriveTime=DateTime.Parse(row["ArriveTime"].ToString());
				}
				if(row["ArrivePurpose"]!=null)
				{
					model.ArrivePurpose=row["ArrivePurpose"].ToString();
				}
				if(row["Traffic"]!=null)
				{
					model.Traffic=row["Traffic"].ToString();
				}
				if(row["PhysicalState"]!=null)
				{
					model.PhysicalState=row["PhysicalState"].ToString();
				}
				if(row["LastTemp"]!=null && row["LastTemp"].ToString()!="")
				{
					model.LastTemp=decimal.Parse(row["LastTemp"].ToString());
				}
				if(row["NowAddress"]!=null)
				{
					model.NowAddress=row["NowAddress"].ToString();
				}
				if(row["DisposeType"]!=null)
				{
					model.DisposeType=row["DisposeType"].ToString();
				}
				if(row["ManageMan"]!=null)
				{
					model.ManageMan=row["ManageMan"].ToString();
				}
				if(row["ManageManPhone"]!=null)
				{
					model.ManageManPhone=row["ManageManPhone"].ToString();
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
				if(row["ByeondWarning"]!=null)
				{
					model.ByeondWarning=row["ByeondWarning"].ToString();
				}
				if(row["UserType"]!=null && row["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(row["UserType"].ToString());
				}
				if(row["LoginName"]!=null)
				{
					model.LoginName=row["LoginName"].ToString();
				}
				if(row["LoginPassword"]!=null)
				{
					model.LoginPassword=row["LoginPassword"].ToString();
				}
				if(row["IsAdmin"]!=null)
				{
					model.IsAdmin=row["IsAdmin"].ToString();
				}
				if(row["RecordLastTime"]!=null && row["RecordLastTime"].ToString()!="")
				{
					model.RecordLastTime=DateTime.Parse(row["RecordLastTime"].ToString());
				}
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["LastTempDate"] != null && row["LastTempDate"].ToString() != "")
                {
                    model.LastTempDate = DateTime.Parse(row["LastTempDate"].ToString());
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
			strSql.Append("select ID,PersonType,PersonName,Sex,IDCardNo,PhoneNo,Native,ArriveTime,ArrivePurpose,Traffic,Area,PhysicalState,LastTemp,LastTempDate,NowAddress,DisposeType,ManageMan,ManageManPhone,LocationX,LocationY,Location,ByeondWarning,UserType,LoginName,LoginPassword,IsAdmin,RecordLastTime ");
			strSql.Append(" FROM PersonInfo ");
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
			strSql.Append(" ID,PersonType,PersonName,Sex,IDCardNo,PhoneNo,Native,ArriveTime,ArrivePurpose,Traffic,PhysicalState,LastTemp,NowAddress,DisposeType,ManageMan,ManageManPhone,LocationX,LocationY,Location,ByeondWarning,UserType,LoginName,LoginPassword,IsAdmin,RecordLastTime ");
			strSql.Append(" FROM PersonInfo ");
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
			strSql.Append("select count(1) FROM PersonInfo ");
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
			strSql.Append(")AS Row, T.*  from PersonInfo T ");
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
			parameters[0].Value = "PersonInfo";
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

