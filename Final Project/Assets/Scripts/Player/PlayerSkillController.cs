using System;
using System.Collections.Generic;
//using CanvasNS;
using MEC;
using Skills;
using UnityEngine;

namespace Player
{
    public enum PlayerSkillType
    {
        Basic,
        Primary,
        Secondary
    }
    
    public class PlayerSkillController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private DecalSkillIndicator skillIndicator;

        [SerializeField] private AbstractSkillSettings basicSkillSettings;
        [SerializeField] private AbstractSkillSettings primarySkillSettings;
        [SerializeField] private AbstractSkillSettings secondarySkillSettings;
        
        public AbstractSkillSettings BasicSkillSettings => basicSkillSettings;
        public AbstractSkillSettings PrimarySkillSettings => primarySkillSettings;
        public AbstractSkillSettings SecondarySkillSettings => secondarySkillSettings;

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void Start()
        {
            InitializeSkills();
        }
        
        #region Basic Attack 
        
        public void StartBasicSkill()
        {
            basicSkillSettings.StartSkill();
        }
        
        public void CastBasicSkill()
        {
            basicSkillSettings.CastSkill();
        }
        
        public void OnFinishedBasicSkill()
        {
            basicSkillSettings.OnFinishedSkillAnimation();
        }
        
        #endregion

        #region PrimarySkill
        public void StartPrimarySkill(Vector3 skillDirection)
        {
            skillIndicator.DisableSkillIndicator();
            primarySkillSettings.SetShootDirection(skillDirection);
            primarySkillSettings.StartSkill();
        }

        public void PerformPrimarySkill(Vector3 skillVector)
        {
            primarySkillSettings.ShowSkillIndicator(skillIndicator, skillVector);
        }
        
        public void CastPrimarySkill()
        {
            primarySkillSettings.CastSkill();
        }
        
        public void OnFinishedPrimarySkill()
        {
            primarySkillSettings.OnFinishedSkillAnimation();
        }
        #endregion

        #region SecondarySkill
        public void StartSecondarySkill(Vector3 skillDirection)
        {
            skillIndicator.DisableSkillIndicator();
            secondarySkillSettings.SetShootDirection(skillDirection);
            secondarySkillSettings.StartSkill();
        }

        public void PerformSecondarySkill(Vector3 skillVector)
        {
            secondarySkillSettings.ShowSkillIndicator(skillIndicator, skillVector);
        }
        
        public void CastSecondarySkill()
        {
            secondarySkillSettings.CastSkill();
        }
        
        public void OnFinishedSecondarySkill()
        {
            secondarySkillSettings.OnFinishedSkillAnimation();
        }
        #endregion

        private void InitializeSkills()
        {
            InitializeSkill(basicSkillSettings);
            InitializeSkill(primarySkillSettings);
            InitializeSkill(secondarySkillSettings);
        }
        
        private void InitializeSkill(AbstractSkillSettings skillSettings)
        {
            if (skillSettings != null)
            {
                skillSettings.InitializeSkill(playerStats.CharacterStats, transform, movementController.LerpPlayerRotation);
            }
        }

        private void ResetSkill(AbstractSkillSettings skillSettings)
        {
            if (skillSettings != null)
            {
                skillSettings.ResetParams();
            }
        }
        
        private void HandleOnSkillChanged(AbstractSkillSettings newSkillSettings)
        {
            if (newSkillSettings.skillType == PlayerSkillType.Basic)
            {
                ResetSkill(basicSkillSettings);
                basicSkillSettings = newSkillSettings;
                InitializeSkill(basicSkillSettings);
            }
            else if(newSkillSettings.skillType == PlayerSkillType.Primary)
            {
                ResetSkill(primarySkillSettings);
                primarySkillSettings = newSkillSettings;    
                InitializeSkill(basicSkillSettings);
            }
            else
            {
                ResetSkill(secondarySkillSettings);
                secondarySkillSettings = newSkillSettings;
                InitializeSkill(basicSkillSettings);
            }
        }
        
        private void AddListeners()
        {
            //CanvasScript.OnSkillChanged.AddListener(HandleOnSkillChanged);
        }

        private void RemoveListeners()
        {
            //CanvasScript.OnSkillChanged.RemoveListener(HandleOnSkillChanged);
        }
    }
}