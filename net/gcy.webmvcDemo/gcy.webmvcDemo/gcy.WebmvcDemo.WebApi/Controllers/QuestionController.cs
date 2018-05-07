using gcy.WebmvcDemo.Entity.Common;
using gcy.WebmvcDemo.Entity.Question;
using gcy.WebmvcDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace gcy.WebmvcDemo.WebApi.Controllers
{
    public class QuestionController : ApiController
    {
        QuestionService questionService = new QuestionService();
        /// <summary>
        /// 获取试题信息
        /// </summary>
        /// <param name="id">试题id</param>
        /// <returns></returns>
        //[Route("GetData"), System.Web.Http.HttpGet]
        [HttpGet]
        public QuestionEntity Get(long id)
        {
            return questionService.GetQuestion(id);            
        }
        /// <summary>
        /// 查询试题
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public PageData<QuestionEntity> ListQuestion(int pageSize, int pageIndex, string name)
        {
            return questionService.ListQuestion(pageSize, pageIndex, name);
        }
    }
}