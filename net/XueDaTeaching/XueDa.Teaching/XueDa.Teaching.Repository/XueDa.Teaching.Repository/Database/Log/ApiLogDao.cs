using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XueDa.Teaching.Model.Log;

namespace XueDa.Teaching.Repository.Database.Log
{
    public class ApiLogDao:BaseDao
    {
        public ApiLogDao():base( DataBaseEnum.LogData)          
        {
            
        }
        public long Save(ApiLog apiLog)
        {
            return this.db.Insertable<ApiLog>(apiLog).ExecuteReturnBigIdentity();
        }
    }
}
