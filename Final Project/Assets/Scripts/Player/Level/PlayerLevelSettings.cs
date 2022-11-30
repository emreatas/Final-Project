using UnityEngine;
using Utils;

namespace Player
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Level")]
    [System.Serializable]
    public class PlayerLevelSettings : ScriptableObject
    {
        public int level;
        public float currentExperience;
        [Range(0, 1)] public float nextLevelExperienceMuliplicator = 0.25f;
        public float levelUpXP = 100;

        private bool HasPlayerLeveledUp => currentExperience > levelUpXP;

        public GameEvent OnPlayerLeveldUp;

        public float GetExperienceInPercent()
        {
            return currentExperience / levelUpXP;
        }

        public void AddExperience(float experienceAmount)
        {
            currentExperience += experienceAmount;

            if (HasPlayerLeveledUp)
            {
                var overflowedXP = currentExperience - levelUpXP;

                while (overflowedXP >= 0)
                {
                    level++;
                    currentExperience = overflowedXP;

                    levelUpXP = levelUpXP + (levelUpXP * nextLevelExperienceMuliplicator);

                    OnPlayerLeveldUp.Invoke();

                    overflowedXP = currentExperience - levelUpXP;

                    if (overflowedXP <= 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}