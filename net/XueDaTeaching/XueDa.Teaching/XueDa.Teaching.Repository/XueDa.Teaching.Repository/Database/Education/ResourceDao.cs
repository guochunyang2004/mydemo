using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XueDa.Teaching.Model.Common;
using XueDa.Teaching.Model.Education.Resource;

namespace XueDa.Teaching.Repository.Database.Education
{
    public class ResourceDao : BaseDao
    {
        public ResourceDao()
            : base(DataBaseEnum.EducationData)
        {

        }
        public long Save(Resource info)
        {
            if (info.ID > 0)
                return db.Updateable(info).ExecuteCommand();
            else
                return db.Insertable(info).ExecuteReturnBigIdentity();
        }
        public Resource GetResource(long id)
        {
            return db.Queryable<Resource>().Where(r => r.ID == id).First();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public PageData<Resource> ListResource(int pageSize, int pageIndex, string name)
        {
            int totalCount = 0;
            PageData<Resource> pageData = new PageData<Resource>();
            var data = db.Queryable<Resource>();
            if (!string.IsNullOrWhiteSpace(name))
                data.Where(r => SqlFunc.Contains(r.Name, name));//SqlFunc生成sql语句
            pageData.DataList = data.OrderBy(it => it.ID)//OrderBy生成sql
               .With(SqlWith.NoLock)//nolock
              .ToPageList(pageIndex, pageSize, ref totalCount);
            pageData.TotalCount = totalCount;
            return pageData;
        }
    }
}
