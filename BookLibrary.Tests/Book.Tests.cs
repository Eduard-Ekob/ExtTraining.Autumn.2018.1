using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        [TestCase("A", ExpectedResult = "Lev Tolstoy")]
        [TestCase("TAP", ExpectedResult = "War and Peace, Lev Tolstoy, Bookinist")]
        [TestCase("TA", ExpectedResult = "War and Peace, Lev Tolstoy")]
        [TestCase("TM", ExpectedResult = "War and Peace, $40.00")]
        public string BookTest_Takestring_ReturnFormattedString(string format)
        {
            Book book = new Book("War and Peace", "Lev Tolstoy", 1846, "Bookinist", 1, 40, 1200);
            return book.ToString(format, null);
        }

        [TestCase("TM", ExpectedResult = "War and Peace, 40,00р.")]
        public string BookTest_TakesWithurrencyString_ReturnStringWithRegionalCurrency(string format)
        {
            Book book = new Book("War and Peace", "Lev Tolstoy", 1846, "Bookinist", 1, 40, 1200);
            var provider = Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            return book.ToString(format, provider);
        }

        [Test]
        public void BookTest_WithWrongYear_ThrowsArgumentException()
        {
            Book book;
            Assert.That(() => book = new Book("War and Peace", "Lev Tolstoy", -1846, "Bookinist", 1, 40, 1200),
                Throws.ArgumentException);
        }

        [Test]
        public void BookTest_WithWrongEdition_ThrowsArgumentException()
        {
            Book book;
            Assert.That(() => book = new Book("War and Peace", "Lev Tolstoy", 1846, "Bookinist", -1, 40, 1200),
                Throws.ArgumentException);
        }

        [Test]
        public void BookTest_WithWrongPages_ThrowsArgumentException()
        {
            Book book;
            Assert.That(() => book = new Book("War and Peace", "Lev Tolstoy", 1846, "Bookinist", 1, 40, 0),
                Throws.ArgumentException);
        }

        [Test]
        public void BookTest_WithWrongAuthor_ThrowsArgumentException()
        {
            Book book;
            Assert.That(() => book = new Book("War and Peace", null, 1846, "Bookinist", 1, 40, 0),
                Throws.ArgumentException);
        }

        [Test]
        public void BookTest_WithWrongPublishingHouse_ThrowsArgumentException()
        {
            Book book;
            Assert.That(() => book = new Book("War and Peace", "Lev Tolstoy", 1846, null, 1, 40, 0),
                Throws.ArgumentException);
        }
    }
}
