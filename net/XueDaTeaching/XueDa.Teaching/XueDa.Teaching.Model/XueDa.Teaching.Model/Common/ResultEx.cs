using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XueDa.Teaching.Model.Common
{
    public class ResultEx<T> :Result
    {
        T Data { get; set; }
    }
}
