﻿using UnityEngine;
using UnityEngine.UIElements;

namespace Stat
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Stats/Type")]
    public class StatType : ScriptableObject
    {
        public string name;
        [TextArea(10,100)]
        public string description;
    }
}