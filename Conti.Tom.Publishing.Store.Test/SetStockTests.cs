namespace Conti.Tom.Publishing.Store.Test
{
    [TestFixture (Author = "Conti Tom")]
    public class SetStockTests
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

        [Test]
        public void SetStockWithCategoryBooksAndItemIsbn1AndStock42IsOk([Values("Books")] string book, [Values("isbn1")] string isbn, [Values(42)] int stock)
        {
            _storeService.SetStock(book, isbn, stock);
        }
        [Test]
        public void SetStockWithNegativeStockThrowsArgumentException([Values("Book1", "Book2")] string book, [Values("isbn1", "isbn2")] string isbn, [Random(-100, -1, 20)] int stock)
        {
            Assert.Throws<ArgumentException>(() => _storeService.SetStock(book, isbn, stock));
        }
        [Test]
        public void SetStockWithNullCategoryThrowsArgumentException([Values(null)] string book, [Values("isbn1", "isbn2")] string isbn, [Values(1, 2)] int stock)
        {
            Assert.Throws<ArgumentException>(() => _storeService.SetStock(book, isbn, stock));
        }
        [Test]
        public void SetStockWithNullItemThrowsArgumentException([Values("Book1", "Book2")] string book, [Values(null)] string isbn, [Values(1, 2)] int stock)
        {
            Assert.Throws<ArgumentException>(() => _storeService.SetStock(book, isbn, stock));
        }
        [Test]
        public void SetStockWithCategoryBooksAndItemIsbn1AndStock42CreatesEntryJC()
        {
            _storeService.SetStockJC("Books", "Isbn1", 42);
            Assert.That(_storeService.GetStock("Books", "Isbn1"), Is.EqualTo(42));
        }
        [Test]
        public void SetStockWithCategoryBooksAndItemIsbn1AndStock42CreatesEntry()
        {
            _storeService.SetStock("Books", "Isbn1", 42);
            Assert.That(_storeService.GetStock("Books", "Isbn1"), Is.EqualTo(42));
        }
        [Test]
        public void SetStockCreatesEntry([Values("Book1", "Book2")] string book, [Values("isbn1", "isbn2")] string isbn, [Values(1, 2)] int stock)
        {
            _storeService.SetStock(book, isbn, stock);
            Assert.That(_storeService.GetStock(book, isbn), Is.EqualTo(stock));
        }
    }
}