using System;
using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private CharacterStat characterStats;
        [SerializeField] private StatType targetStat;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                AttributeModifier att = new AttributeModifier(100,targetStat);
                characterStats.AddModifier(att);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log(characterStats.GetValue(targetStat));
            }
        }
    }
}