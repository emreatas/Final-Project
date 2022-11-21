using System.Collections;
using System.Collections.Generic;
using Skills;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Skills/Empty")]
public class SkillSettingsEmpty : AbstractSkillSettings
{
    public override void CastSkill()
    {
      
    }

    public override void OnFinishedSkillAnimation()
    {
        OnFinishedSkill.Invoke();
    }
}
