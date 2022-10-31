using UnityEngine;

namespace Skills
{
    public abstract class AbstractSkill : ScriptableObject
    {
        public abstract void StartSkill();
        public abstract void PerformSkill();
        public abstract void CancelSkill();
    }
}