using System;

namespace Qowaiv.CodeGenerator
{
    public class SvoArguments
    {
        public SvoFeatures Features { get; set; } = SvoFeatures.Default;
        public Type Underlying { get; set; } = typeof(string);
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Namespace { get; set; } = "Qowaiv";
        public string Type => SimpleType.ToString(Underlying);
        public string FormatExceptionMessage { get; set; }

        public bool HasFeature(SvoFeatures feature) => Features.HasFlag(feature);
        public bool LacksFeature(SvoFeatures feature) => !HasFeature(feature);

       
    }
}
