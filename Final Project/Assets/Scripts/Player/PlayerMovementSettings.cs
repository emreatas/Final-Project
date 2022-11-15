using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Player/Movement")]
    public class PlayerMovementSettings : ScriptableObject
    {
        public StatType movementStatType;

        public float MovementSpeed;
        public float RotationSpeed;
    }
}