using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private PlayerLevelSettings levelSettings;
        
        public void AddExperience(float experienceAmount)
        {
            levelSettings.AddExperience(experienceAmount);
        }
    }
}