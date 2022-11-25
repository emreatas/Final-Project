using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Skills;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class SkillEquipUI : MonoBehaviour
{
    [SerializeField] private Image primarySkillIcon;
    [SerializeField] private Image secondarySkillIcon;
    
    private AbstractNewSkillSettings m_SelectedSkill;

    public static GameEvent<AbstractNewSkillSettings> OnEquipSkill;

    private void Awake()
    {
        AddListeners();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    public void HandleOnSelectSkill(AbstractNewSkillSettings skillSettings)
    {
        if (skillSettings != null)
        {
            m_SelectedSkill = skillSettings;
        }
    }

    public void _EquipSkill()
    {
        if (m_SelectedSkill != null)
        {
            OnEquipSkill.Invoke(m_SelectedSkill);

            SwapSkillIcon();
        }
    }

    private void SwapSkillIcon()
    {
        if (m_SelectedSkill.skillType == PlayerSkillType.Primary)
        {
            primarySkillIcon.sprite = m_SelectedSkill.SkillIcon;
        }
        else
        {
            secondarySkillIcon.sprite = m_SelectedSkill.SkillIcon;
        }
    }

    private void AddListeners()
    {
        SkillUI.OnSelectSkill.AddListener(HandleOnSelectSkill);
    }

    private void RemoveListeners()
    {
        SkillUI.OnSelectSkill.RemoveListener(HandleOnSelectSkill);
    }
}
