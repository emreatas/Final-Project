using System.Collections;
using System.Collections.Generic;
using Skills;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Skills/Empty")]
public class SkillSettingsEmpty : AbstractSkillSettings
{
    [SerializeField] private ParticleSystem skill;
 
    public override void CastSkill()
    {
        Instantiate(skill, m_Player);
    }

    public override void OnFinishedSkillAnimation()
    {
        OnFinishedSkill.Invoke();
    }
}
