using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gcy.WebmvcDemo.Entity.Common
{
    public class ResultEx<T> :Result
    {
        T Data { get; set; }
    }
}
