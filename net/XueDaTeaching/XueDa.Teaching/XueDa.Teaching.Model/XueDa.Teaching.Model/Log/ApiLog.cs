using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XueDa.Teaching.Model.Log
{
    [SqlSugar.SugarTable("APILOG")]
    public class ApiLog
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long ID { get; set; }
        public long UserID { get; set; }
        public long AppID { get; set; }
        public string InterfaceName { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
