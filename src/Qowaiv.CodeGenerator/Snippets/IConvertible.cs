namespace @Namespace
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public partial struct @TSvo : IConvertible
    {
        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => Convertable.ToType(conversionType, provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convertable.ToBoolean(provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        byte IConvertible.ToByte(IFormatProvider provider) => Convertable.ToByte(provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        char IConvertible.ToChar(IFormatProvider provider) => Convertable.ToChar(provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convertable.ToDateTime(provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        decimal IConvertible.ToDecimal(IFormatProvider provider) => Convertable.ToDecimal(provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        double IConvertible.ToDouble(IFormatProvider provider) => Convertable.ToDouble(provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        short IConvertible.ToInt16(IFormatProvider provider) => Convertable.ToInt16(provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        int IConvertible.ToInt32(IFormatProvider provider) => Convertable.ToInt32(provider);

        /// <inheritdoc/>
        [ExcludeFromCodeCoverage]
        long IConvertible.ToInt64(IFormatProvider provider) => Convertable.ToInt64(provider);

        /// <inheritdoc/>
        sbyte IConvertible.ToSByte(IFormatProvider provider) => Convertable.ToSByte(provider);

        /// <inheritdoc/>
        float IConvertible.ToSingle(IFormatProvider provider) => Convertable.ToSingle(provider);

        /// <inheritdoc/>
        ushort IConvertible.ToUInt16(IFormatProvider provider) => Convertable.ToUInt16(provider);

        /// <inheritdoc/>
        uint IConvertible.ToUInt32(IFormatProvider provider) => Convertable.ToUInt32(provider);

        /// <inheritdoc/>
        ulong IConvertible.ToUInt64(IFormatProvider provider) => Convertable.ToUInt64(provider);
    }
}
