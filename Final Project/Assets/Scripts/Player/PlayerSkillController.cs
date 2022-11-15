using System;
using System.Collections.Generic;
using CanvasNS;
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

        [SerializeField] private AbstractSkill basicSkill;
        [SerializeField] private AbstractSkill primarySkill;
        [SerializeField] private AbstractSkill secondarySkill;
        
        public AbstractSkill BasicSkill => basicSkill;
        public AbstractSkill PrimarySkill => primarySkill;
        public AbstractSkill SecondarySkill => secondarySkill;

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
            basicSkill.StartSkill();
        }
        
        public void CastBasicSkill()
        {
            basicSkill.CastSkill();
        }
        
        public void OnFinishedBasicSkill()
        {
            basicSkill.OnFinishedSkillAnimation();
        }
        
        #endregion

        #region PrimarySkill
        public void StartPrimarySkill(Vector3 skillDirection)
        {
            skillIndicator.DisableSkillIndicator();
            primarySkill.SetShootDirection(skillDirection);
            primarySkill.StartSkill();
        }

        public void PerformPrimarySkill(Vector3 skillVector)
        {
            primarySkill.ShowSkillIndicator(skillIndicator, skillVector);
        }
        
        public void CastPrimarySkill()
        {
            primarySkill.CastSkill();
        }
        
        public void OnFinishedPrimarySkill()
        {
            primarySkill.OnFinishedSkillAnimation();
        }
        #endregion

        #region SecondarySkill
        public void StartSecondarySkill(Vector3 skillDirection)
        {
            skillIndicator.DisableSkillIndicator();
            secondarySkill.SetShootDirection(skillDirection);
            secondarySkill.StartSkill();
        }

        public void PerformSecondarySkill(Vector3 skillVector)
        {
            secondarySkill.ShowSkillIndicator(skillIndicator, skillVector);
        }
        
        public void CastSecondarySkill()
        {
            secondarySkill.CastSkill();
        }
        
        public void OnFinishedSecondarySkill()
        {
            secondarySkill.OnFinishedSkillAnimation();
        }
        #endregion

        private void InitializeSkills()
        {
            InitializeSkill(basicSkill);
            InitializeSkill(primarySkill);
            InitializeSkill(secondarySkill);
        }
        
        private void InitializeSkill(AbstractSkill skill)
        {
            if (skill != null)
            {
                skill.InitializeSkill(playerStats.CharacterStats, transform, movementController.LerpPlayerRotation);
            }
        }

        private void ResetSkill(AbstractSkill skill)
        {
            if (skill != null)
            {
                skill.ResetParams();
            }
        }
        
        private void HandleOnSkillChanged(AbstractSkill newSkill)
        {
            if (newSkill.skillType == PlayerSkillType.Basic)
            {
                ResetSkill(basicSkill);
                basicSkill = newSkill;
                InitializeSkill(basicSkill);
            }
            else if(newSkill.skillType == PlayerSkillType.Primary)
            {
                ResetSkill(primarySkill);
                primarySkill = newSkill;    
                InitializeSkill(basicSkill);
            }
            else
            {
                ResetSkill(secondarySkill);
                secondarySkill = newSkill;
                InitializeSkill(basicSkill);
            }
        }
        
        private void AddListeners()
        {
            CanvasScript.OnSkillChanged.AddListener(HandleOnSkillChanged);
        }

        private void RemoveListeners()
        {
            CanvasScript.OnSkillChanged.RemoveListener(HandleOnSkillChanged);
        }
    }
}