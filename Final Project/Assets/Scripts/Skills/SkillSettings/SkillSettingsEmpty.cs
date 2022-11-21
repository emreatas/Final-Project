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
        var instansiated = Instantiate(prefab, m_Player);
        instansiated.FireProjectile();
    }
}
