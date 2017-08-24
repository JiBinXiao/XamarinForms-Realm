using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopToolBar
{
    public class Bean : RealmObject
    {
        //主键
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //计数器
        public RealmInteger<int> Counter { get; set; }

    }
}
