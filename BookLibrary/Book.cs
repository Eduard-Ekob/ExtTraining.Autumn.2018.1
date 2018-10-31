using System;
using System.Globalization;
using System.Threading;

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
                throw new ArgumentException(nameof(edition));
            }
            if (year <= 0)
            {
                throw new ArgumentException(nameof(year));
            }
            if (price <= 0)
            {
                throw new ArgumentException(nameof(price));
            }

            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            PublishingHous = publishingHouse ?? throw new ArgumentNullException(nameof(publishingHouse));
            Year = year;
            Edition = edition;
            Price = price;
            Pages = pages;
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (provider == null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            }

            if (format.Length > 4)
            {
                throw new ArgumentException(nameof(format));
            }

            if (String.IsNullOrEmpty(format))
            {
                format = "T";
            }

            string resStr = string.Empty;

            switch (format)
            {
                case "T": return resStr += string.Format(provider, "{0:T}", Title);
                case "A": return resStr += string.Format(provider, "{0:A}", Author);
                case "TA": return resStr += string.Format(provider, "{0:T}, {1:A}", Title, Author);
                case "TAP":
                    return resStr += string.Format(provider, "{0:T}, {1:A}, {2:P}", Title, Author, PublishingHous);
                case "TM":
                    return resStr += string.Format(provider, "{0:T}, {1}", Title, Price.ToString("C"));                

                default:
                    throw new FormatException(String.Format("The {0} format string is wrong.", format));
            }
        }
    }
}
