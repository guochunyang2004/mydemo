using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gcy.WebmvcDemo.Entity.Common
{
    public class PageData<T>:Result
    {
        public PageData()
        {

        }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public List<T> DataList { get; set; }
    }
}
