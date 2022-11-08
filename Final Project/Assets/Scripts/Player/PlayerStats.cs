using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using Stat;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private CharacterStat characterStats;
        [SerializeField] private StatType targetStat;
        
        public float GetValue(StatType statType)
        {
            return characterStats.GetValue(statType);
        }
        
        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.K))
        //     {
        //         AttributeModifier att = new AttributeModifier(100,targetStat);
        //         characterStats.AddModifier(att);
        //     }
        //
        //     if (Input.GetKeyDown(KeyCode.B))
        //     {
        //         Debug.Log(characterStats.GetValue(targetStat));
        //     }
        // }
        
    }
}