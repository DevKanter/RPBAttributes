using System;

namespace RPBAttributes
{
    public abstract class AttributeProfile<TEnum> where TEnum : unmanaged, Enum

    {
        public TEnum[] Attributes { get; protected set; } = Array.Empty<TEnum>();
    }
}


