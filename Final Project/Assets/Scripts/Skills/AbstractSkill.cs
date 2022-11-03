using UnityEngine;
using Utils;

namespace Skills
{
    public abstract class AbstractSkill : ScriptableObject
    {
        public string AnimationName;

        public GameEvent OnFinishedSkill;

        public float SkillDuration;
        
        
        public abstract void StartSkill();
        public abstract void PerformSkill();
        public abstract void CancelSkill();
        public abstract void FinishedSkill();
    }
}