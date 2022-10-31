using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Player/Movement")]
    public class PlayerMovementSettings : ScriptableObject
    {
        public float MovementSpeed;
    }
}