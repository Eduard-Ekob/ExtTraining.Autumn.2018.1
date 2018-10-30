using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        private string Title { get; set; }
        private string Author { get; set; }
        private int Year { get; set; }
        private string PublishingHous { get; set; }
        private int Edition { get; set; }
        private decimal Price { get; set; }
        private int Pages { get; set; }
        public Book(string title, string author, int year, string publishingHouse, int edition, decimal price,
            int pages)
        {
            if (pages <= 0)
            {
                throw new ArgumentException(nameof(pages));
            }

            if (edition <= 0)
            {
                throw new ArgumentException(nameof(pages));
            }           
            if (year <= 0)
            {
                throw new ArgumentException(nameof(pages));
            }
           
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));            
            PublishingHous = publishingHouse ?? throw new ArgumentNullException(nameof(publishingHouse));
            Year = year;
            Edition = edition;
            Price = price;
            Pages = pages;
        }

        public string ToString(string format, IFormatProvider provider = null)
        {

            if (format.Length > 4)
            {
                throw new ArgumentException();
            }
            if (String.IsNullOrEmpty(format))
            {
                format = "T";
            }

            string resStr = string.Empty;
            provider = CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            NumberFormatInfo nf = new NumberFormatInfo();
            nf.CurrencySymbol = "$";

            switch (format)
            {
                case "T": return resStr += string.Format(provider, "{0:T}", Title);
                case "A": return resStr += string.Format(provider, "{0:A}", Author);
                case "TA": return resStr += string.Format(provider, "{0:T}, {1:A}", Title, Author);
                case "TAP":
                    return resStr += string.Format(provider, "{0:T}, {1:A}, {2:P}", Title, Author, PublishingHous);
                case "TM":
                    return resStr += string.Format(provider, "{0:T}, {1}", Title, Price.ToString("C",nf));

                default:
                    throw new FormatException(String.Format("The {0} format string is wrong.", format));
            }
        }
    }
}
