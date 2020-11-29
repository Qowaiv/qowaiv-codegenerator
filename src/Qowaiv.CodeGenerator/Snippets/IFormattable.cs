namespace @Namespace
{
    using System;
    using System.Globalization;

    public partial struct @TSvo : IFormattable
    {
        /// <summary>Returns a <see cref="string"/> that represents the @FullName.</summary>
        public override string ToString() => ToString((IFormatProvider)null);

        /// <summary>Returns a formatted <see cref="string"/> that represents the @FullName.</summary>
        /// <param name="format">
        /// The format that describes the formatting.
        /// </param>
        public string ToString(string format) => ToString(format, null);

        /// <summary>Returns a formatted <see cref="string"/> that represents the @FullName.</summary>
        /// <param name="provider">
        /// The format provider.
        /// </param>
        public string ToString(IFormatProvider provider) => ToString(null, provider);
    }
}
