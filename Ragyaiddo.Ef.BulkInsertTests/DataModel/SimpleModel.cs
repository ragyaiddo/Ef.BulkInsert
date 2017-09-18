using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ragyaiddo.Ef.BulkInsertTests.DataModel
{
    public class SimpleModel : EntityWithId<int>
    {
        public int SimplePropInt { get; set; }
        public string SimplePropStr { get; set; }
        public Guid SimplePropGuid { get; set; }
        public DateTime SimplePropDateTime { get; set; }

    }
}
