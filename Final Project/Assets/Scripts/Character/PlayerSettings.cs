using System;
using PInventory;
using Stat;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerSettings")]
    [Serializable]
    public class PlayerSettings : ScriptableObject
    {
        public int CharacterID;
        public Inventory Inventory;
        public Equipment Equipment;
        public CharacterStat CharacterStat;
        public PlayerLevelSettings LevelSettings;
        public CharacterTypes characterType;
    }

}