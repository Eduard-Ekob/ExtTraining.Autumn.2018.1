using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExtension.Tests
{
    public class BookFormatExtensionTests
    {
        [TestCase("T", ExpectedResult = "Lev Tolstoy")]
        [TestCase("TAP", ExpectedResult = "War and Peace, Lev Tolstoy, Bookinist")]
        public string BookTestsExtend_Takestring_ReturnFormattedString(string format)
        {
            BookExt bookExt = new BookExt("War and Peace", "Lev Tolstoy", "1846", "Bookinist", "1", "40$", "1200");
            return bookExt.ToString(format);
        }
    }
}
