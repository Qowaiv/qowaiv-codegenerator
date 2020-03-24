using System;

namespace Qowaiv.CodeGenerator
{
    [Flags]
    public enum SvoFeatures
    {
        Field = /*              */ 0x00001,
        GetHashCode = /*        */ 0x00002,
        IsEmpty = /*            */ 0x00004,
        IsUnknown = /*          */ 0x00008,
        IEquatable = /*         */ 0x00010,
        EqualsSvo =  /*         */ 0x00020,
        ISerializable = /*      */ 0x00080,
        IXmlSerializable = /*   */ 0x00100,
        IJsonSerializable = /*  */ 0x00200,
        IFormattable = /*       */ 0x00400,
        IComparable = /*        */ 0x00800,
        IConvertible = /*       */ 0x01000,
        ComparisonOperators = /**/ 0x02000,
        Parsing = /*            */ 0x04000,
        CultureDependent = /*   */ 0x08000,
        Validation  = /*        */ 0x10000,
        All = /*                 */0x1FFFF,
        Default = All ^ ComparisonOperators,
        Continuous = All ^ IsEmpty ^ IsUnknown,
        AllExcludingCulture = Default ^ CultureDependent,
    }
}
