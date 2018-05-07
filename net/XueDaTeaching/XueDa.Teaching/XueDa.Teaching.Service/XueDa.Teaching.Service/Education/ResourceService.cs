using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XueDa.Teaching.Model.Common;
using XueDa.Teaching.Model.Education.Resource;
using XueDa.Teaching.Model.Log;
using XueDa.Teaching.Repository.Database.Education;
using XueDa.Teaching.Repository.Database.Log;

namespace XueDa.Teaching.Service.Education
{
    public class ResourceService
    {
        ResourceDao resourceDao = new ResourceDao();
        ApiLogDao apiLogDao = new ApiLogDao();
        public Resource GetResource(long id)
        {
            return resourceDao.GetResource(id);
        }

        public long Add(Resource info)        
        {
            info.CreateTime = DateTime.Now;
            try
            {
                resourceDao.BeginTran();
                apiLogDao.BeginTran();
                var ret = resourceDao.Save(info);
                var apiLog = new ApiLog() { UserID = 100000, AppID = 10000, InterfaceName = "AddResource",CreateTime = DateTime.Now };
                apiLogDao.Save(apiLog);
                throw new Exception("测uow");
                resourceDao.CommitTran();
                apiLogDao.CommitTran();
                return ret;
            }
            catch (Exception ex)
            {
                resourceDao.RollbackTran();
                apiLogDao.RollbackTran();
                throw ex;
             
            }
        }

        public PageData<Resource> ListResource(int pageSize, int pageIndex, string name)
        {
            return resourceDao.ListResource(pageSize, pageIndex, name);
        }
    }
}
