using Javacream.Store.Impl;

namespace Javacream.Store.Test
{
    public class SetStock
    {
        private StoreService _storeService;

        [SetUp]
        public void SetUp()
        {
            _storeService = new StoreService();
        }

        [Test]
        public void SetStockCorrect()
        {
            object storeentry = new();
            try
            {
                _storeService.SetStock("Test", storeentry, 10);
                var result = _storeService.GetStock("Test", storeentry);
                Assert.IsNotNull(result);
                return;
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
            Assert.Fail();
        }

        [Test]
        public void SetStockCategoryNull()
        {
            object storeentry = new();
            try
            {
                _storeService.SetStock(null, storeentry, 10);
                Assert.Fail();
                return;
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
        [Test]
        public void SetStockEntryNull()
        {
            object storeentry = new();
            try
            {
                _storeService.SetStock("", null, 10);
                Assert.Fail();
                return;
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void SetStockStockInvalid()
        {
            object storeentry = new();
            try
            {
                _storeService.SetStock("", storeentry, -1);
                Assert.Fail();
                return;
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}