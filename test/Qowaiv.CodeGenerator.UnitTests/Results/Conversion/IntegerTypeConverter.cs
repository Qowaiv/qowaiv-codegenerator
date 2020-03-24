using System.Globalization;

namespace Qowaiv.Conversion
{
    public class IntegerTypeConverter : NumericTypeConverter<Integer, int>
    {
        protected override Integer FromRaw(int raw) => (Integer)raw;

        protected override Integer FromString(string str, CultureInfo culture) => Integer.Parse(str, culture);

        protected override int ToRaw(Integer svo) => (int)svo;
    }
}
