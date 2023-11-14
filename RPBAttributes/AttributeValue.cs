using static RPBUtilities.UConverter;

namespace RPBAttributes
{
    internal class AttributeValue
    {
        private readonly int[] _values = new int[ToInt(AttributeType.ATTRIBUTE_TYPE_MAX)];

        public int this[AttributeType type]
        {
            get => _values[ToInt(type)];
            set => _values[ToInt(type)] = value;
        }

        public void Update()
        {
            _updateAbsolute();
            _updateRatio();

            _updateTotal();
        }

        private void _updateTotal()
        {
            _values[ToInt(AttributeType.CALC_TOTAL)] = _values[ToInt(AttributeType.CALC_ABS)] *
                                                       ((AttributeConst.ATTR_CALC_RATIO_PER_PERCENT +
                                                         _values[ToInt(AttributeType.CALC_RATIO)]) /
                                                        AttributeConst.ATTR_CALC_RATIO_PER_PERCENT);
        }

        private void _updateAbsolute()
        {
            _values[ToInt(AttributeType.CALC_ABS)] = _values[ToInt(AttributeType.BASE)] +
                                                     _values[ToInt(AttributeType.ITEM)] +
                                                     _values[ToInt(AttributeType.SKILL)];
        }

        private void _updateRatio()
        {
            _values[ToInt(AttributeType.CALC_RATIO)] =
                _values[ToInt(AttributeType.ITEM_RATIO)] + _values[ToInt(AttributeType.SKILL_RATIO)];
        }
    }
}