namespace @Namespace
{
    using System;
    using System.Collections.Generic;

    public partial struct @TSvo : IConvertible
    {
        /// <inheritdoc/>
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => Convertable.ToType(conversionType, provider);

        /// <inheritdoc/>
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convertable.ToBoolean(provider);

        /// <inheritdoc/>
        byte IConvertible.ToByte(IFormatProvider provider) => Convertable.ToByte(provider);

        /// <inheritdoc/>
        char IConvertible.ToChar(IFormatProvider provider) => Convertable.ToChar(provider);

        /// <inheritdoc/>
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convertable.ToDateTime(provider);

        /// <inheritdoc/>
        decimal IConvertible.ToDecimal(IFormatProvider provider) => Convertable.ToDecimal(provider);

        /// <inheritdoc/>
        double IConvertible.ToDouble(IFormatProvider provider) => Convertable.ToDouble(provider);

        /// <inheritdoc/>
        short IConvertible.ToInt16(IFormatProvider provider) => Convertable.ToInt16(provider);

        /// <inheritdoc/>
        int IConvertible.ToInt32(IFormatProvider provider) => Convertable.ToInt32(provider);

        /// <inheritdoc/>
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
