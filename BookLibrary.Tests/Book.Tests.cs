using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Tests
{
    public class Class1
    {
        [TestCase("A", ExpectedResult = "Lev Tolstoy")]
        [TestCase("TAP", ExpectedResult = "War and Peace, Lev Tolstoy, Bookinist")]
        [TestCase("TA", ExpectedResult = "War and Peace, Lev Tolstoy")]
        public string BookTests_Takestring_ReturnFormattedString(string format)
        {
            Book book = new Book("War and Peace", "Lev Tolstoy", "1846", "Bookinist", "1", "40$", "1200");
            return book.ToString(format);
        }
    }
}
