using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XueDa.Teaching.Model.Common;
using XueDa.Teaching.Model.Education.Resource;
using XueDa.Teaching.Service.Education;

namespace XueDa.Teaching.WebApi.Controllers
{
    //[RoutePrefix("web/Business")]
    public class ResourceController : ApiController
    {
        ResourceService resourceService = new ResourceService();

        // GET api/resource        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
      
        
        // [Route("GetData"), System.Web.Http.HttpGet]
        /// <summary>
        /// 获取资源信息
        /// </summary>
        /// <param name="id">资源id</param>
        /// <returns></returns>
        public Resource Get(long id)
        {
            return resourceService.GetResource(id);
            //return new Resource() { ID=1,Name="test",CreateTime=DateTime.Now};
        }

        /// <summary>
        /// 添加资源
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public long Add(Resource info)
        {
            return resourceService.Add(info);
        }

        /// <summary>
        /// 查询资源
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public PageData<Resource> ListResource(int pageSize, int pageIndex, string name)
        {
            return resourceService.ListResource(pageSize, pageIndex, name);
        }
        // POST api/resource
        public void Post([FromBody]string value)
        {

        }

        // PUT api/resource/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/resource/5
        public void Delete(int id)
        {
        }
    }
}
