using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;


namespace BookExtension
{
    public static class BookFormatExtension
    {
        public static string BookExt (this Book bookExt, string format)
        {
            if (bookExt == null)
            {
                throw new ArgumentNullException(nameof(bookExt));
            }

            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            format = format.ToUpperInvariant();
            IFormatProvider provider = CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            return bookExt.ToString(format, provider);            
        }
    }
}
