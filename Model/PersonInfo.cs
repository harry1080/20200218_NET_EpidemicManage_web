using System;
using System.Collections.Generic;

namespace com.gxchuwei.Model
{
	/// <summary>
	/// PersonInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PersonInfo
	{
		public PersonInfo()
		{}

        //zdh 20200218添加同行人员
        private List<PersonInfo> _togetherPerson;
        public List<PersonInfo> TogetherPerson
        {
            get
            {
                return _togetherPerson;
            }

            set
            {
                _togetherPerson = value;
            }
        }

        #region Model
        private int _id;
		private string _persontype;
		private string _personname;
        private string _area;
        private string _sex;
		private string _idcardno;
		private string _phoneno;
		private string _native;
		private DateTime? _arrivetime;
		private string _arrivepurpose;
		private string _traffic;
		private string _physicalstate;
		private decimal? _lasttemp;
        private DateTime? _lasttempdate;
        private string _nowaddress;
		private string _disposetype;
		private string _manageman;
		private string _managemanphone;
		private decimal? _locationx;
		private decimal? _locationy;
		private string _location;
		private string _byeondwarning;
		private int? _usertype;
		private string _loginname;
		private string _loginpassword;
		private string _isadmin;
		private DateTime? _recordlasttime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 人员类别
		/// </summary>
		public string PersonType
		{
			set{ _persontype=value;}
			get{return _persontype;}
		}
        /// <summary>
		/// 人员类别
		/// </summary>
		public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonName
		{
			set{ _personname=value;}
			get{return _personname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDCardNo
		{
			set{ _idcardno=value;}
			get{return _idcardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhoneNo
		{
			set{ _phoneno=value;}
			get{return _phoneno;}
		}
		/// <summary>
		/// 户籍
		/// </summary>
		public string Native
		{
			set{ _native=value;}
			get{return _native;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ArriveTime
		{
			set{ _arrivetime=value;}
			get{return _arrivetime;}
		}
        public string ArriveTimeStr
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ArrivePurpose
		{
			set{ _arrivepurpose=value;}
			get{return _arrivepurpose;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Traffic
		{
			set{ _traffic=value;}
			get{return _traffic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhysicalState
		{
			set{ _physicalstate=value;}
			get{return _physicalstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LastTemp
		{
			set{ _lasttemp=value;}
			get{return _lasttemp;}
		}

        public DateTime? LastTempDate
        {
            set { _lasttempdate = value; }
            get { return _lasttempdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NowAddress
		{
			set{ _nowaddress=value;}
			get{return _nowaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisposeType
		{
			set{ _disposetype=value;}
			get{return _disposetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManageMan
		{
			set{ _manageman=value;}
			get{return _manageman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManageManPhone
		{
			set{ _managemanphone=value;}
			get{return _managemanphone;}
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
		/// <summary>
		/// 越界预警
		/// </summary>
		public string ByeondWarning
		{
			set{ _byeondwarning=value;}
			get{return _byeondwarning;}
		}
		/// <summary>
		/// 用户类型2：普通用户 1: 管理员 0：超级管理员
		/// </summary>
		public int? UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginPassword
		{
			set{ _loginpassword=value;}
			get{return _loginpassword;}
		}
		/// <summary>
		/// 1 是管理员 0 不是管理员
		/// </summary>
		public string IsAdmin
		{
			set{ _isadmin=value;}
			get{return _isadmin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RecordLastTime
		{
			set{ _recordlasttime=value;}
			get{return _recordlasttime;}
		}

        public string LastTempStr { get; set; }


        #endregion Model

    }
}

