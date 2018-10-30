using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BookLibrary;
using BookExtension;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        [TestCase("a", ExpectedResult = "Lev Tolstoy")]
        [TestCase("tap", ExpectedResult = "War and Peace, Lev Tolstoy, Bookinist")]
        public string BookTestsExtend_Takestring_ReturnFormattedString(string format)
        {
            Book book = new Book("War and Peace", "Lev Tolstoy", 1846, "Bookinist", 1, 40, 1200);
            return book.BookExt(format);
        }
    }
}
