using Ploeh.AutoFixture;
using Ragyaiddo.Ef.BulkInsertTests.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ragyaiddo.Ef.BulkInsertTests.TestDataGenerator
{
    public class BulkInsertTestDataGenerator
    {
        public static IEnumerable<SimpleModel> CreateSimpleModels(int count)
        {
            Fixture fixture = new Fixture();
            for (int i = 0; i < count; ++i)
                yield return new SimpleModel()
                {
                    SimplePropInt = fixture.Create<int>(),
                    SimplePropStr = fixture.Create<string>(),
                    SimplePropGuid = fixture.Create<Guid>(),
                    SimplePropDateTime = fixture.Create<DateTime>()
                };
        }
    }
}
