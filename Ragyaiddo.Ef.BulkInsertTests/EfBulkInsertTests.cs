using System.Collections.Generic;
using Ragyaiddo.Ef.BulkInsertTests.DataModel;
using Ragyaiddo.Ef.BulkInsertTests.EfContext;
using Ragyaiddo.Ef.BulkInsert;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Ragyaiddo.Ef.BulkInsertTests.TestDataGenerator;
using Ragyaiddo.Ef.BulkInsert.DataReader;
using Xunit;
using Xunit.Abstractions;

namespace Ragyaiddo.Ef.BulkInsertTests
{
    public class EfBulkInsertTests
    {
        private readonly ITestOutputHelper _output;
        
        public EfBulkInsertTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(5000)]
        [InlineData(10000)]
        [InlineData(20000)]
        [InlineData(50000)]
        [InlineData(100000)]
        public void BulkInsert_SimpleModel(int dataSize)
        {
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                var options = new BulkCopyOptions()
                {
                    BatchSize = 1000,
                    SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                    TimeOut = 180
                };

                sw.Start();
                IBulkInsertProvider bulkInsertProvider = new BulkInsertProvider(options);
                bulkInsertProvider.BulkInsert(insertTestContext.Database.Connection,
                    insertTestContext.Database.CurrentTransaction?.UnderlyingTransaction,
                    () => new SimpleEntityDataReader<SimpleModel>(testSimpleModels));
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Theory]
        [InlineData(1000)]
        [InlineData(5000)]
        [InlineData(10000)]
        [InlineData(20000)]
        [InlineData(50000)]
        [InlineData(100000)]
        public void ContextAddRangeInsert_SimpleModel(int dataSize)
        {
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                sw.Start();
                insertTestContext.SimpleModels.AddRange(testSimpleModels);
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void BulkInsert_SimpleModel_1000()
        {
            int dataSize = 1000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                var options = new BulkCopyOptions()
                {
                    BatchSize = 1000,
                    SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                    TimeOut = 180
                };

                sw.Start();
                IBulkInsertProvider bulkInsertProvider = new BulkInsertProvider(options);
                bulkInsertProvider.BulkInsert(insertTestContext.Database.Connection,
                    insertTestContext.Database.CurrentTransaction?.UnderlyingTransaction,
                    () => new SimpleEntityDataReader<SimpleModel>(testSimpleModels));
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void BulkInsert_SimpleModel_5000()
        {
            int dataSize = 5000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                var options = new BulkCopyOptions()
                {
                    BatchSize = 1000,
                    SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                    TimeOut = 180
                };

                sw.Start();
                IBulkInsertProvider bulkInsertProvider = new BulkInsertProvider(options);
                bulkInsertProvider.BulkInsert(insertTestContext.Database.Connection,
                    insertTestContext.Database.CurrentTransaction?.UnderlyingTransaction,
                    () => new SimpleEntityDataReader<SimpleModel>(testSimpleModels));
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }


        [Fact]
        public void BulkInsert_SimpleModel_10000()
        {
            int dataSize = 10000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                var options = new BulkCopyOptions()
                {
                    BatchSize = 1000,
                    SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                    TimeOut = 180
                };

                sw.Start();
                IBulkInsertProvider bulkInsertProvider = new BulkInsertProvider(options);
                bulkInsertProvider.BulkInsert(insertTestContext.Database.Connection,
                    insertTestContext.Database.CurrentTransaction?.UnderlyingTransaction,
                    () => new SimpleEntityDataReader<SimpleModel>(testSimpleModels));
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void BulkInsert_SimpleModel_20000()
        {
            int dataSize = 20000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                var options = new BulkCopyOptions()
                {
                    BatchSize = 1000,
                    SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                    TimeOut = 180
                };

                sw.Start();
                IBulkInsertProvider bulkInsertProvider = new BulkInsertProvider(options);
                bulkInsertProvider.BulkInsert(insertTestContext.Database.Connection,
                    insertTestContext.Database.CurrentTransaction?.UnderlyingTransaction,
                    () => new SimpleEntityDataReader<SimpleModel>(testSimpleModels));
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void BulkInsert_SimpleModel_50000()
        {
            int dataSize = 50000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                var options = new BulkCopyOptions()
                {
                    BatchSize = 1000,
                    SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                    TimeOut = 180
                };

                sw.Start();
                IBulkInsertProvider bulkInsertProvider = new BulkInsertProvider(options);
                bulkInsertProvider.BulkInsert(insertTestContext.Database.Connection,
                    insertTestContext.Database.CurrentTransaction?.UnderlyingTransaction,
                    () => new SimpleEntityDataReader<SimpleModel>(testSimpleModels));
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void BulkInsert_SimpleModel_100000()
        {
            int dataSize = 100000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                var options = new BulkCopyOptions()
                {
                    BatchSize = 1000,
                    SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                    TimeOut = 180
                };

                sw.Start();
                IBulkInsertProvider bulkInsertProvider = new BulkInsertProvider(options);
                bulkInsertProvider.BulkInsert(insertTestContext.Database.Connection,
                    insertTestContext.Database.CurrentTransaction?.UnderlyingTransaction,
                    () => new SimpleEntityDataReader<SimpleModel>(testSimpleModels));
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void ContextAddRangeInsert_SimpleModel_1000()
        {
            int dataSize = 1000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                sw.Start();
                insertTestContext.SimpleModels.AddRange(testSimpleModels);
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void ContextAddRangeInsert_SimpleModel_5000()
        {
            int dataSize = 5000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                sw.Start();
                insertTestContext.SimpleModels.AddRange(testSimpleModels);
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void ContextAddRangeInsert_SimpleModel_10000()
        {
            int dataSize = 10000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                sw.Start();
                insertTestContext.SimpleModels.AddRange(testSimpleModels);
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void ContextAddRangeInsert_SimpleModel_20000()
        {
            int dataSize = 20000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                sw.Start();
                insertTestContext.SimpleModels.AddRange(testSimpleModels);
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void ContextAddRangeInsert_SimpleModel_50000()
        {
            int dataSize = 50000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                sw.Start();
                insertTestContext.SimpleModels.AddRange(testSimpleModels);
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

        [Fact]
        public void ContextAddRangeInsert_SimpleModel_100000()
        {
            int dataSize = 100000;
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(dataSize);
            _output.WriteLine($"Data generated: {testSimpleModels.Count()}");
            var sw = new Stopwatch();
            _output.WriteLine($"Start elapsed time: {sw.ElapsedMilliseconds} ms");
            using (var insertTestContext = new BulkInsertTestContext())
            {
                sw.Start();
                insertTestContext.SimpleModels.AddRange(testSimpleModels);
                sw.Stop();
            }

            _output.WriteLine($@"Data size: {dataSize}, elapsed time: {sw.ElapsedMilliseconds} ms");

        }

    }
}
