using System;

namespace Qowaiv.CodeGenerator
{
    [Flags]
    public enum SvoFeatures
    {
        Field = /*              */ 0x0001,
        GetHashCode = /*        */ 0x0002,
        IsEmpty = /*            */ 0x0004,
        IsUnknown = /*          */ 0x0008,
        IEquatable = /*         */ 0x0010,
        EqualsSvo =  /*         */ 0x0020,
        ISerializable = /*      */ 0x0080,
        IXmlSerializable = /*   */ 0x0100,
        IJsonSerializable = /*  */ 0x0200,
        IFormattable = /*       */ 0x0400,
        IComparable = /*        */ 0x0800,
        ComparisonOperators = /**/ 0x1000,
        Parsing = /*            */ 0x2000,
        CultureDependent = /*   */ 0x4000,
        Validation  = /*        */ 0x8000,
        All = /*                 */0xFFFF,
        Default = All ^ ComparisonOperators,
        Continuous = All ^ IsEmpty ^ IsUnknown,
        AllExcludingCulture = Default ^ CultureDependent,
    }
}
