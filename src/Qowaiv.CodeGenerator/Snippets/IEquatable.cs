namespace @Namespace
{
    using System;

    public partial struct @TSvo : IEquatable<@TSvo>
    {
#if !NotEqualsSvo
        /// <summary>Returns true if this instance and the other @FullName are equal, otherwise false.</summary>
        /// <param name="other">The <see cref="@TSvo" /> to compare with.</param>
        public bool Equals(@TSvo other) => m_Value == other.m_Value;
#endif
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is @TSvo other && Equals(other);

#if !NotGetHashCodeStruct
        /// <inheritdoc />
        public override int GetHashCode() => m_Value.GetHashCode();
#endif
#if !NotGetHashCodeClass
        /// <inheritdoc />
        public override int GetHashCode() => m_Value is null ? 0 : m_Value.GetHashCode();
#endif
        /// <summary>Returns true if the left and right operand are equal, otherwise false.</summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand</param>
        public static bool operator !=(@TSvo left, @TSvo right) => !(left == right);

        /// <summary>Returns true if the left and right operand are not equal, otherwise false.</summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand</param>
        public static bool operator ==(@TSvo left, @TSvo right) => left.Equals(right);
    }
}
