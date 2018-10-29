using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExtension
{
    public class BookFormatExtension
    {
        public string Title { get; set; }
        private string Author { get; set; }
        private string Year { get; set; }
        private string PublishingHous { get; set; }
        private string Edition { get; set; }
        private string Price { get; set; }
        private string Pages { get; set; }

        public BookExt(string title, string author, string year, string publishingHouse, string edition, string price, string pages)
        {
            Title = title;
            Author = author;
            Year = year;
            PublishingHous = publishingHouse;
            Edition = edition;
            Price = price;
            Pages = pages;
        }

        public string ToString(string format, IFormatProvider provider = null)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "T";
            }

            string resStr = string.Empty;
            provider = CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            if (format.Length > 4)
                throw new ArgumentException();


            switch (format.ToLowerInvariant())
            {
                case "t": return resStr += string.Format(provider, "{0:T}", Title);
                case "a": return resStr += string.Format(provider, "{0:A}", Author);
                case "ta": return resStr += string.Format(provider, "{0:T}, {1:A}", Title, Author);
                case "tap": return resStr += string.Format(provider, "{0:T}, {1:A}, {2:P}", Title, Author, PublishingHous);

                default:
                    throw new FormatException(String.Format("The {0} format string is wrong.", format));
            }

            return resStr;
        }
}
