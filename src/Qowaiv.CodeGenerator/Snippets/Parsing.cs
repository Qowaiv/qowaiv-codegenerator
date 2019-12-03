namespace @Namespace
{
    using System;
    using System.Globalization;

    public partial struct @TSvo
    {
#if !NotCultureDependent
        /// <summary>Converts the <see cref="string"/> to <see cref="@TSvo"/>.</summary>
        /// <param name="s">
        /// A string containing the @FullName to convert.
        /// </param>
        /// <returns>
        /// The parsed @FullName.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="s"/> is not in the correct format.
        /// </exception>
        public static @TSvo Parse(string s) => Parse(s, CultureInfo.CurrentCulture);

        /// <summary>Converts the <see cref="string"/> to <see cref="@TSvo"/>.</summary>
        /// <param name="s">
        /// A string containing the @FullName to convert.
        /// </param>
        /// <param name="formatProvider">
        /// The specified format provider.
        /// </param>
        /// <returns>
        /// The parsed @FullName.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="s"/> is not in the correct format.
        /// </exception>
        public static @TSvo Parse(string s, IFormatProvider formatProvider)
        {
            return TryParse(s, formatProvider, out @TSvo val)
                ? val
                : throw new FormatException(@FormatExceptionMessage);
        }

        /// <summary>Converts the <see cref="string"/> to <see cref="@TSvo"/>.</summary>
        /// <param name="s">
        /// A string containing the @FullName to convert.
        /// </param>
        /// <returns>
        /// The @FullName if the string was converted successfully, otherwise default.
        /// </returns>
        public static @TSvo TryParse(string s)
        {
            return TryParse(s, CultureInfo.CurrentCulture, out @TSvo val) ? val : default;
        }

        /// <summary>Converts the <see cref="string"/> to <see cref="@TSvo"/>.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="s">
        /// A string containing the @FullName to convert.
        /// </param>
        /// <param name="result">
        /// The result of the parsing.
        /// </param>
        /// <returns>
        /// True if the string was converted successfully, otherwise false.
        /// </returns>
        public static bool TryParse(string s, out @TSvo result) => TryParse(s, CultureInfo.CurrentCulture, out result);
#else
        /// <summary>Converts the <see cref="string"/> to <see cref="@TSvo"/>.</summary>
        /// <param name="s">
        /// A string containing the @FullName to convert.
        /// </param>
        /// <returns>
        /// The parsed @FullName.
        /// </returns>
        /// <exception cref="FormatException">
        /// <paramref name="s"/> is not in the correct format.
        /// </exception>
        public static @TSvo Parse(string s)
        {
            return TryParse(s, out @TSvo val)
                ? val
                : throw new FormatException(@FormatExceptionMessage);
        }

        /// <summary>Converts the <see cref="string"/> to <see cref="@TSvo"/>.</summary>
        /// <param name="s">
        /// A string containing the @FullName to convert.
        /// </param>
        /// <returns>
        /// The @FullName if the string was converted successfully, otherwise default.
        /// </returns>
        public static @TSvo TryParse(string s)
        {
            return TryParse(s, out @TSvo val) ? val : default;
        }
#endif
    }
}
