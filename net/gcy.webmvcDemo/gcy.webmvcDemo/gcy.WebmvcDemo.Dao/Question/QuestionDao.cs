using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gcy.WebmvcDemo.Entity.Question;
using SqlSugar;
using gcy.WebmvcDemo.Entity.Common;

namespace gcy.WebmvcDemo.Dao.Question
{
    public class QuestionDao  :BaseDao
    {
        public QuestionDao() : base(DataBaseEnum.QuestionData)
        {

        }

        public long Save(QuestionEntity info)
        {
            if (info.Id > 0)
                return db.Updateable(info).ExecuteCommand();
            else
                return db.Insertable(info).ExecuteReturnBigIdentity();
        }
        public QuestionEntity GetQuestion(long id)
        {
            return db.Queryable<QuestionEntity>().Where(r => r.Id == id).First();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public PageData<QuestionEntity> ListQuestion(int pageSize, int pageIndex, string questionContent)
        {
            int totalCount = 0;
            PageData<QuestionEntity> pageData = new PageData<QuestionEntity>();
            var data = db.Queryable<QuestionEntity>();
            if (!string.IsNullOrWhiteSpace(questionContent))
                data.Where(r => SqlFunc.Contains(r.QuestionContent, questionContent));//SqlFunc生成sql语句
            pageData.DataList = data.OrderBy(it => it.Id)//OrderBy生成sql
               .With(SqlWith.NoLock)//nolock
              .ToPageList(pageIndex, pageSize, ref totalCount);
            pageData.TotalCount = totalCount;
            return pageData;
        }
    }
}
