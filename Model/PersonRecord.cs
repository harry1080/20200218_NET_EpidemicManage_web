using System;
namespace com.gxchuwei.Model
{
	/// <summary>
	/// PersonRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PersonRecord
	{
		public PersonRecord()
		{}
		#region Model
		private int _id;
		private int? _personid;
		private DateTime? _declarationtime;
		private decimal? _temp;
		private string _healthstate;
		private string _remark;
		private decimal? _locationx;
		private decimal? _locationy;
		private string _location;
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
		public int? PersonID
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DeclarationTime
		{
			set{ _declarationtime=value;}
			get{return _declarationtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Temp
		{
			set{ _temp=value;}
			get{return _temp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HealthState
		{
			set{ _healthstate=value;}
			get{return _healthstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LocationX
		{
			set{ _locationx=value;}
			get{return _locationx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LocationY
		{
			set{ _locationy=value;}
			get{return _locationy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Location
		{
			set{ _location=value;}
			get{return _location;}
		}
		#endregion Model

	}
}

