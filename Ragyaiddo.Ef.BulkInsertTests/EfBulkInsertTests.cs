using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ragyaiddo.Ef.BulkInsertTests.DataModel;
using Ragyaiddo.Ef.BulkInsertTests.EfContext;
using Ragyaiddo.Ef.BulkInsert;
using System.Data.SqlClient;
using Ragyaiddo.Ef.BulkInsertTests.TestDataGenerator;
using System.Data.Common;
using System.Data.Entity;
using System.Data;

namespace Ragyaiddo.Ef.BulkInsertTests
{
    /// <summary>
    /// Summary description for EfBulkInsertTests
    /// </summary>
    [TestClass]
    public class EfBulkInsertTests
    {
        public EfBulkInsertTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void BulkInsert_SimpleModel()
        {
            IEnumerable<SimpleModel> testSimpleModels = BulkInsertTestDataGenerator.CreateSimpleModels(10);
            using (BulkInsertTestContext insertTestContext = new BulkInsertTestContext())
            {
                var options = new BulkCopyOptions()
                {
                    BatchSize = 100,
                    SqlBulkCopyOptions = SqlBulkCopyOptions.Default,
                    TimeOut = 180
                };

                IBulkInsertProvider bulkInsertProvider = new BulkInsertProvider(options);

                bulkInsertProvider.BulkInsert(insertTestContext.Database.Connection,
                    insertTestContext.Database.CurrentTransaction?.UnderlyingTransaction,
                    () => new SimpleEntityDataReader<SimpleModel>(testSimpleModels));
            }
        }
    }
}
