using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Player/Rotation")]
    public class PlayerRotationSettings : ScriptableObject
    {
        public float RotationSpeed;
    }
}