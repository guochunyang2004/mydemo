using gcy.WebmvcDemo.Dao.Question;
using gcy.WebmvcDemo.Entity.Common;
using gcy.WebmvcDemo.Entity.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcy.WebmvcDemo.Service
{
    public class QuestionService
    {
        QuestionDao questionDao = new QuestionDao();
       // ApiLogDao apiLogDao = new ApiLogDao();
        public QuestionEntity GetQuestion(long id)
        {
            return questionDao.GetQuestion(id);
        }

        /*public long Add(QuestionEntity info)
        {
            info.CreateTime = DateTime.Now;
            try
            {
                questionDao.BeginTran();
                apiLogDao.BeginTran();
                var ret = questionDao.Save(info);
                var apiLog = new ApiLog() { UserID = 100000, AppID = 10000, InterfaceName = "AddResource", CreateTime = DateTime.Now };
                apiLogDao.Save(apiLog);
                throw new Exception("测uow");
                questionDao.CommitTran();
                apiLogDao.CommitTran();
                return ret;
            }
            catch (Exception ex)
            {
                questionDao.RollbackTran();
                apiLogDao.RollbackTran();
                throw ex;

            }
        }*/

        public PageData<QuestionEntity> ListQuestion(int pageSize, int pageIndex, string questionContent)
        {
            return questionDao.ListQuestion(pageSize, pageIndex, questionContent);
        }
    }
}
