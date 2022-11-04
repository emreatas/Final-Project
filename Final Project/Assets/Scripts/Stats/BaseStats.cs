using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stat
{
    public class BaseStats : ScriptableObject
    {
        public float Vitality;
        public float Intelligence;
        public float Strength;
        public float Dexterity;

        public float HP;
        public float MP;
        public float Defense;
        public float PhysicalAttackDamage;
        public float MagicalAttackDamage;
        public float Speed;

        public StatUpgrade StatUpgrade;
        
        public void UpdateBaseStates()
        {
            HP += StatUpgrade.StrengthUpdate;
        }
    }

    public class StatUpgrade : ScriptableObject
    {
        public float StrengthUpdate;
    }
}