using System;
using Unity.VisualScripting;

namespace Stat
{
    [Serializable]
    public class ItemStat
    {
        public StatType statType;
        public AttributeType attributeType;
        public float minValue;
        public float maxValue;
    }
}