namespace Qowaiv.CodeGenerator.Examples
{
    [SingleValueObject(underlyingType: typeof(string), fullName: "example structure")]
    public partial struct ExampleStruct
    {
        public override string ToString() => "Test";
    }
}
