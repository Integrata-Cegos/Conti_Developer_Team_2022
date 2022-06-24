using Conti.Tom.Publishing.Store;

namespace Conti.Tom.Publishing.Store.Test
{
    [TestFixture(Author = "Conti Tom")]
    public class GetStockTests
    {

        private StoreService _storeService;

        [SetUp]
        public void SetUp()
        {
            _storeService = new StoreService();
            _storeService.SetStock("Test", new(), 10);
        }

        [Test]
        public void IsStoreGetStockEmpty()
        {
            var result = _storeService.GetStock("empty", new object());
            if (result == 0) { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void StoreGetStockCategoryNull()
        {
            try
            {
                _storeService.GetStock(null, new object());
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void StoreGetStockObjectNull()
        {
            try
            {
                _storeService.GetStock("", null);
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void GetStockWithCategoryBooksAndItemIsbn1RetrievesStockGreaterThanNull()
        {
            int stock = _storeService.GetStock("Books", "Isbn1");
            Assert.GreaterOrEqual(0, stock);
        }
        [Test]
        public void GetStockWithNullCategoryThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _storeService.GetStock(null, "item"));
        }

        [Test]
        public void GetStockWithNullItemThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _storeService.GetStock("null", null));
        }


    }

}