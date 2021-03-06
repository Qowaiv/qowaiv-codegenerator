﻿using CodeGeneration.Roslyn;
using System;
using System.Diagnostics;

namespace Qowaiv.CodeGenerator
{
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
    [CodeGenerationAttribute(typeof(SvoCodeGenerator))]
    [Conditional(CodeGeneration)]
    public sealed class SingleValueObjectAttribute : Attribute
    {
        private const string CodeGeneration = nameof(CodeGeneration);

        public SingleValueObjectAttribute(
            Type underlyingType, 
            string fullName, 
            SvoFeatures features = SvoFeatures.Default)
        {
            UnderlyingType = underlyingType ?? typeof(string);
            FullName = fullName ?? UnderlyingType.Name;
            Features = features;
        }

        public Type UnderlyingType { get; }
        public string FullName { get; }
        public SvoFeatures Features { get; }
    }
}
