namespace @Namespace
{
    public partial struct @TSvo
    {
#if !NotField
        private @TSvo(@type value) => m_Value = value;

        /// <summary>The inner value of the @FullName.</summary>
        private @type m_Value;
#endif

#if !NotIsEmpty
        /// <summary>Returns true if the  @FullName is empty, otherwise false.</summary>
        public bool IsEmpty() => m_Value == default;
#endif
#if !NotIsUnknown
        /// <summary>Returns true if the  @FullName is unknown, otherwise false.</summary>
        public bool IsUnknown() => m_Value == Unknown.m_Value;
#endif
#if !NotIsEmptyOrUnknown
        /// <summary>Returns true if the  @FullName is empty or unknown, otherwise false.</summary>
        public bool IsEmptyOrUnknown() => IsEmpty() || IsUnknown();
#endif
    }
}