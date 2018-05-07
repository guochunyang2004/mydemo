using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace gcy.WebmvcDemo.Entity.Question
{
    [SugarTable("Questions")]
    public class QuestionEntity
    {
        //[DataMember]
        //[JsonProperty(Order = 0) ]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        public int SubjectId { get; set; }
        public string QuestionContent { get; set; }
        public string Answer { get; set; }
    }
}
