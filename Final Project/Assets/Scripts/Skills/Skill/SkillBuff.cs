using System;
using Stat;
using UnityEngine;

namespace Skills
{
    [Serializable]
    public class SkillBuff
    {
        public StatType buffType;
        public float buffMultiplicator;
    }
}