using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public abstract class AbstractAttackSettings : AbstractSkillSettings
    {
        protected int m_ComboCount;

        public void SetCombo(int comboCount)
        {
            m_ComboCount = comboCount;
        }
    }
  
}
