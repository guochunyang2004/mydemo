using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace XueDa.Teaching.Repository.Database
{
    public class BaseDao
    {
        private static Dictionary<DataBaseEnum, string> connections = null;
        public DataBaseEnum DataBaseEnum;
        /// <summary>
        /// 静态初始
        /// </summary>
        static BaseDao()
        {
            connections = new Dictionary<DataBaseEnum, string>(3);
            connections.Add(DataBaseEnum.QuestionData,"QuestionConnectionString");
            connections.Add(DataBaseEnum.EducationData, "EducationConnectionString");
            connections.Add(DataBaseEnum.LogData, "LogConnectionString");
        
        }
        public BaseDao(DataBaseEnum databaseEnum)
        {
            DataBaseEnum = databaseEnum;
        }     
 
        public SqlSugar.SqlSugarClient db { get { return GetInstance(); } }
        public void BeginTran()
        {
            db.Ado.BeginTran();
        }
        public void CommitTran()
        {
            db.Ado.CommitTran();
        }
        public void RollbackTran()
        {
            db.Ado.RollbackTran();
        }
        public SqlSugarClient GetInstance()
        {
            if (this.DataBaseEnum == Database.DataBaseEnum.None) return null;
            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = GetConnectionString(connections[this.DataBaseEnum]),
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    IsShardSameThread = true /*Shard Same Thread 跨方法事务*/
                });

            return db;
        }

        /// <summary>
        /// 获取数据库链接配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ToString();
        }
    }

    public enum DataBaseEnum
    {
        None, QuestionData,EducationData,LogData
    }
}
