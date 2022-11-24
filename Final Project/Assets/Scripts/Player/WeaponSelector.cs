using UnityEngine;

namespace Player
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] private Weapon[] weaponsParent;

        public Transform GetActiveWeaponTransform()
        {
            for (int i = 0; i < weaponsParent.Length; i++)
            {
                if (weaponsParent[i].gameObject.activeSelf)
                {
                    return weaponsParent[i].GetWeaponSkillTransform();
                }
            }

            return null;
        }
    }
}