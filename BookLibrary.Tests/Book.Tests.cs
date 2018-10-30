using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTests
    {
        [TestCase("A", ExpectedResult = "Lev Tolstoy")]
        [TestCase("TAP", ExpectedResult = "War and Peace, Lev Tolstoy, Bookinist")]
        [TestCase("TA", ExpectedResult = "War and Peace, Lev Tolstoy")]
        [TestCase("TM", ExpectedResult = "War and Peace, $40.00")]
        public string BookTests_Takestring_ReturnFormattedString(string format)
        {
            Book book = new Book("War and Peace", "Lev Tolstoy", 1846, "Bookinist", 1, 40, 1200);
            return book.ToString(format);
        }
    }
}
