using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class SkillSettings_Warrior_Primary : AbstractSkillSettings
    {
        public override void CastSkill()
        {
            Instantiate(prefab, m_Player.position, Quaternion.identity);
        }
    }
}

