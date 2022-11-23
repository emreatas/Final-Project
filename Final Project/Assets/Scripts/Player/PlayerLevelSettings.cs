using UnityEngine;

namespace Player
{
    public class PlayerLevelSettings : ScriptableObject
    {
        [SerializeField] private int level;
        [SerializeField] private float currentExperience;

        [SerializeField][Range(0,1)] private float nextLevelExperienceMuliplicator = 0.25f;
        
        public int Level => level;
        public float Experienxe => currentExperience;

        private float levelUpXP;
        private bool HasPlayerLeveledUp => currentExperience > levelUpXP;
        
        
        
        public void AddExperience(float experienceAmount)
        {
            currentExperience += experienceAmount;

            if (HasPlayerLeveledUp)
            {
                var overflowedXP = currentExperience - levelUpXP;

                while (overflowedXP >= 0)
                {
                    level++;
                    if (overflowedXP == 0)
                    {
                        break;
                    }
                    
                    currentExperience = overflowedXP;
                    levelUpXP *= nextLevelExperienceMuliplicator;
                    
                    overflowedXP = currentExperience - levelUpXP;
                }
            }
        }
    }
}