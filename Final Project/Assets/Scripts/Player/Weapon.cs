using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform weaponSkillSpawnPoint;


        public Transform GetWeaponSkillTransform()
        {
            return weaponSkillSpawnPoint;
        }
    }
}