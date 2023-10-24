using System;
using static RPBUtilities.UConverter;

namespace RPBAttributes
{
    internal class Attributes<TEnum> where TEnum : unmanaged, Enum
    {
        private readonly AttributeValue[] _attributes;

        public Attributes(AttributeProfile<TEnum> profile)
        {
            _attributes = new AttributeValue[Enum.GetNames(typeof(TEnum)).Length];

            foreach (var attribute in profile.Attributes) _attributes[ToInt(attribute)] = new AttributeValue();
        }

        public AttributeValue this[TEnum attr] => _attributes[ToInt(attr)];

        public int this[TEnum attr, AttributeType type]
        {
            get => _attributes[ToInt(attr)][type];
            set => _attributes[ToInt(attr)][type] = value;
        }
    }

    public class AttributeStats<TEnum> where TEnum : unmanaged, Enum
    {
        private readonly AttributeValue[] _attributes;
    }

    public struct AttributeData<TEnum> where TEnum : unmanaged, Enum
    {
        public readonly TEnum Attribute;
        public readonly ValueType ValueType;
    }
}