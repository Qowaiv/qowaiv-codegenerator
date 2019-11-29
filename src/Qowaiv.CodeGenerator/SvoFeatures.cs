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
        IFormattable = /*       */ 0x0200,
        IComparable = /*        */ 0x0400,
        ComparisonOperators = /**/ 0x0800,
        Parsing = /*            */ 0x1000,
        CultureDependent = /*   */ 0x2000,
        All = /*                 */0x3FFF,
        Continuous = All ^ IsEmpty ^ IsUnknown,
        AllExcludingCulture = All ^ CultureDependent,
    }
}
