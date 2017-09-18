using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ragyaiddo.Ef.BulkInsertTests.DataModel
{
    public class EntityWithId<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
