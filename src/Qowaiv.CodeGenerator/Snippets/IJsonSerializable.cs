namespace @Namespace
{
    using System;
    using Qowaiv.Json;

    public partial struct @TSvo : IJsonSerializable
    {
        /// <inheritdoc />
        [Obsolete("Use FromJson(object) instead.")]
        void IJsonSerializable.FromJson() => ((IJsonSerializable)this).FromJson(null);

        /// <inheritdoc />
        [Obsolete("Use FromJson(object) instead.")]
        void IJsonSerializable.FromJson(string jsonString) => ((IJsonSerializable)this).FromJson((object)jsonString);

        /// <inheritdoc />
        [Obsolete("Use FromJson(object) instead.")]
        void IJsonSerializable.FromJson(long jsonInteger) => ((IJsonSerializable)this).FromJson((object)jsonInteger);

        /// <inheritdoc />
        [Obsolete("Use FromJson(object) instead.")]
        void IJsonSerializable.FromJson(double jsonNumber) => ((IJsonSerializable)this).FromJson((object)jsonNumber);

        /// <inheritdoc />
        [Obsolete("Use FromJson(object) instead.")]
        void IJsonSerializable.FromJson(DateTime jsonDate) => ((IJsonSerializable)this).FromJson((object)jsonDate);

    }
}
