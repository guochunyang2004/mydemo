using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XueDa.Teaching.Model.Education.Resource
{
    //[DataContract]
    [SugarTable("Resources")]
    public class Resource
    {
        //[DataMember]
        // JsonProperty(Order = 0) 
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int FileSize { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
