﻿///*************************************************************************/
///*
///* 文件名    ：IWriteSQLConfigValue.cs                                      
///* 程序说明  : 用于扩展Tag标记的自定义对象
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Common
{
    /// <summary>
    /// 系统支持３种登录授权策略
    /// </summary>
    public enum LoginAuthType
    {
        /// <summary>
        /// 系统内部用户授权
        /// </summary>
        LocalSystemAuth = 1,

        /// <summary>
        /// Novell网用户授权
        /// </summary>
        NovellUserAuth = 2,

        /// <summary>
        /// Windows域用户授权
        /// </summary>
        WindowsDomainAuth = 3
    }

    /// <summary>
    /// 当前登录的用户信息
    /// </summary>
    [Serializable]
    public class Loginer
    {
        private string _Account = "";
        private string _AccountName = "";
        private string _Email = "";
        private DateTime _LoginTime;
        private LoginAuthType _LoginAuthType = LoginAuthType.LocalSystemAuth;
        private string _FlagAdmin = "N";
        private string _DataSetID;
        private string _DataSetName;
        private string _DBName;
        private string _MDBName;
        private string _DbType;
        private string _MDbType;
        private string _MachineName;
        private string _IpAddress;
        private string _ID;
        private string _CardNo;

        /// <summary>
        /// 用户帐号，登录帐号
        /// </summary>
        public string Account { get { return _Account; } set { _Account = value; } }

        /// <summary>
        /// 用户名
        /// </summary>
        public string AccountName { get { return _AccountName; } set { _AccountName = value; } }

        /// <summary>
        /// 用户的邮件地址
        /// </summary>
        public string Email { get { return _Email; } set { _Email = value; } }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get { return _LoginTime; } set { _LoginTime = value; } }

        /// <summary>
        /// 登录授权策略
        /// </summary>
        public LoginAuthType LoginAuthType
        {
            get { return _LoginAuthType; }
            set { _LoginAuthType = value; }
        }

        /// <summary>
        /// ADMIN标记
        /// </summary>
        public string FlagAdmin { get { return _FlagAdmin; } set { _FlagAdmin = value; } }

        /// <summary>
        /// 帐套编号
        /// </summary>
        public string DataSetID { get { return _DataSetID; } set { _DataSetID = value; } }

        /// <summary>
        /// 帐套名称
        /// </summary>
        public string DataSetName { get { return _DataSetName; } set { _DataSetName = value; } }

        /// <summary>
        /// 数据库名（FNumber）
        /// </summary>
        public string DBName { get { return _DBName; } set { _DBName = value; } }
        /// <summary>
        /// 数据库名（当系统需要访问其他数据库时，将该属性替换成帐套中的多连接中的FNumber，
        /// 那么系统将访问其他数据库，但是访问完成以后需要马上恢复，只要将主数据库名恢复过来即可）
        /// </summary>
        public string MDBName { get { return _MDBName; } set { _MDBName = value; } }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DbType { get { return _DbType; } set { _DbType = value; } }
        /// <summary>
        /// 主链接数据类型
        /// </summary>
        public string MDbType { get { return _MDbType; } set { _MDbType = value; } }
        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get { return _MachineName; } set { _MachineName = value; } }
        /// <summary>
        /// IP
        /// </summary>
        public string IPAddress { get { return _IpAddress; } set { _IpAddress = value; } }
        /// <summary>
        /// ID
        /// </summary>
        public string Fid { get { return _ID; } set { _ID = value; } }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get { return _CardNo; } set { _CardNo = value; } }

        /// <summary>
        /// 是否ADMIN
        /// </summary>
        /// <returns></returns>
        public bool IsAdmin()
        {
            return _FlagAdmin == "1";
        }
        /// <summary>
        /// 将主数据库复原，当数据库链接到其他数据库时，使用完毕需要立即复原成主数据库
        /// </summary>
        public void RestorMasterDB()
        {
            _DBName = _MDBName;
            _DbType = _MDbType;
        }

        private static Loginer _User = null;

        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public static Loginer CurrentUser
        {
            get
            {
                if (_User == null) _User = new Loginer(); //空对象
                return _User;
            }
            set
            {
                _User = value;
            }
        }
    }

    /// <summary>
    /// 用于登录及修改密码的实体类
    /// </summary>
    [Serializable]
    public class LoginUser
    {
        private string _Account;
        private string _Password;
        private string _DataSetID;
        private string _DataSetDBName;
        private string _DbType;
        private string _MachineName;
        private string _IpAddress;
        private string _ID;
        private string _DBName;
        private string _MDBName;
        private string _MDbType;
        private string _CardNo;
        public LoginUser() { }

        public LoginUser(string account, string password, string dataSetID, string dataSetDBName)
        {
            _Account = account;
            _Password = password;
            _DataSetID = dataSetID;
            _DataSetDBName = dataSetDBName;
        }
        public LoginUser(string account, string password, string dataSetID, string dataSetDBName,string sDBName,string sDbType)
        {
            _Account = account;
            _Password = password;
            _DataSetID = dataSetID;
            _DataSetDBName = dataSetDBName;
            _DBName = sDBName;
            _DbType = sDbType;
            _MDBName = sDBName;
            _MDbType = sDbType;
        }

        public LoginUser(string account, string password, string dataSetID, string dataSetDBName, string sDbType, string sMachineName,string sIp,string sID)
        {
            _Account = account;
            _Password = password;
            _DataSetID = dataSetID;
            _DataSetDBName = dataSetDBName;
            _DbType = sDbType;
            _MDbType = sDbType;
            _MachineName = sMachineName;
            _IpAddress = sIp;
            _ID = sID;
        }

        public LoginUser(string cardNo, string dataSetID, string dataSetDBName)
        {
            _CardNo = cardNo;
            _DataSetID = dataSetID;
            _DataSetDBName = dataSetDBName;
        }
        /// <summary>
        /// 用户帐号，登录帐号
        /// </summary>
        public string Account { get { return _Account; } set { _Account = value; } }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get { return _Password; } set { _Password = value; } }

        /// <summary>
        /// 当前登录的帐套
        /// </summary>
        public string DataSetID { get { return _DataSetID; } set { _DataSetID = value; } }

        /// <summary>
        /// 帐套的数据库名
        /// </summary>
        public string DataSetDBName { get { return _DataSetDBName; } set { _DataSetDBName = value; } }
        /// <summary>
        /// 数据库名（当系统需要访问其他数据库时，将该属性替换成帐套中的多连接中的FNumber，
        /// 那么系统将访问其他数据库，但是访问完成以后需要马上恢复，只要将主数据库名恢复过来即可）
        /// </summary>
        public string DBName { get { return _DBName; } set { _DBName = value; } }
        /// <summary>
        /// 主数据库名
        /// </summary>
        public string MDBName { get { return _MDBName; } set { _MDBName = value; } }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DbType { get { return _DbType; } set { _DbType = value; } }
        /// <summary>
        /// 主数据类型
        /// </summary>
        public string MDbType { get { return _MDbType; } set { _MDbType = value; } }
        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get { return _MachineName; } set { _MachineName = value; } }
        /// <summary>
        /// IP
        /// </summary>
        public string IPAddress { get { return _IpAddress; } set { _IpAddress = value; } }
        /// <summary>
        /// ID
        /// </summary>
        public string Fid { get { return _ID; } set { _ID = value; } }
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get { return _CardNo; } set { _CardNo = value; } }
    }

}

