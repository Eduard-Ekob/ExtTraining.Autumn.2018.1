using System;

namespace StringExtension
{
    public static class Parser
    {
        const string allCase = "0123456789ABCDEF";

        public static int ToDecimal(this string source, int @base)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} string is empty");
            }

            source = source.ToUpperInvariant();

            if (@base < 2 || @base > 16)
            {
                throw new ArgumentOutOfRangeException($"{nameof(@base)} must by great of 2 and less 16");
            }

            int result = 0;
            int accumulate = 1;
            for (int i = source.Length - 1; i >= 0; i--)
            {
                int ind = allCase.IndexOf(source[i]);
                if (ind < 0 || ind >= @base)
                {
                    throw new ArgumentException($"{nameof(@base)}");
                }

                if (accumulate < 0)
                {
                    throw new OverflowException(nameof(accumulate));
                }

                checked
                {
                    result += accumulate * ind;

                }

                accumulate *= @base;
            }
            return result;
        }
    }
}