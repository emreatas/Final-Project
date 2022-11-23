using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace ObjectPooling
{
    public class SkillPool : AbstractSingelton<SkillPool>
    {
        [SerializeField] private AbstractNewSkill[] skillList;

        private Dictionary<AbstractNewSkill, ObjectPool<AbstractNewSkill>> m_SkillDictionary =
            new Dictionary<AbstractNewSkill, ObjectPool<AbstractNewSkill>>();

        private void Start()
        {
            for (int i = 0; i < skillList.Length; i++)
            {
                m_SkillDictionary.Add(skillList[i], new ObjectPool<AbstractNewSkill>());
            }
        }
        
        public AbstractNewSkill PoolSkill(AbstractNewSkill skill)
        {
            return PoolSkill(skill, null);
        }

        public AbstractNewSkill PoolSkill(AbstractNewSkill skill, Transform parent)
        {
            if (m_SkillDictionary.ContainsKey(skill))
            {
                return m_SkillDictionary[skill].GetObject(skill, parent);
            }

            return null;
        }
    }
}

