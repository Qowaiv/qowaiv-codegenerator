namespace @Namespace
{
    using System;
    using System.Globalization;

    public partial struct @TSvo
    {
#if !NotCultureDependent

        /// <summary>Returns true if the value represents a valid @FullName.</summary>
        /// <param name="val">
        /// The <see cref="string"/> to validate.
        /// </param>
        public static bool IsValid(string val) => IsValid(val, (IFormatProvider)null);

        /// <summary>Returns true if the value represents a valid @FullName.</summary>
        /// <param name="val">
        /// The <see cref="string"/> to validate.
        /// </param>
        /// <param name="formatProvider">
        /// The <see cref="IFormatProvider"/> to interpret the <see cref="string"/> value with.
        /// </param>
        public static bool IsValid(string val, IFormatProvider formatProvider)
            => !string.IsNullOrWhiteSpace(val)
            && TryParse(val, formatProvider, out _);
#else
        /// <summary>Returns true if the value represents a valid @FullName.</summary>
        /// <param name="val">
        /// The <see cref="string"/> to validate.
        /// </param>
        public static bool IsValid(string val)
            => !string.IsNullOrWhiteSpace(val)
            && TryParse(val, out _);
#endif
    }
}
