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
        
        public void StartBasicSkill()
        {
            InitializeSkill(ref basicSkill);
            
            basicSkill.RotatePlayer(movementController.LerpPlayerRotation);
        }
        
        public void CastBasicSkill()
        {
            basicSkill.CastSkill();
        }
        
        public void OnFinishedBasicSkill()
        {
            basicSkill.OnFinishedSkillAnimation();
        }
        
        public void StartPrimarySkill(Vector3 skillDirection)
        {
            skillIndicator.DisableSkillIndicator();
            primarySkill.ShootDirection = skillDirection;
            InitializeSkill(ref primarySkill);
            primarySkill.RotatePlayer( movementController.LerpPlayerRotation);
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
        
        public void StartSecondarySkill(Vector3 skillDirection)
        {
            skillIndicator.DisableSkillIndicator();
            secondarySkill.ShootDirection = skillDirection;
            InitializeSkill(ref secondarySkill);
            secondarySkill.RotatePlayer( movementController.LerpPlayerRotation);
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
        
        private void InitializeSkill(ref AbstractSkill skill)
        {
            //float dmg = playerStats.GetValue(skill.damageStatType);
            //float attackSpeed = playerStats.GetValue(skill.attackSpeedStatType);
            // skill.SetAttributes(dmg, attackSpeed);
            skill.SetAttributes(playerStats.CharacterStats);
            
            skill.SetPlayerTransform(transform);
        }
        
        private void HandleOnSkillChanged(AbstractSkill newSkill)
        {
            if (newSkill.skillType == PlayerSkillType.Basic)
            {
                basicSkill = newSkill;
            }
            else if(newSkill.skillType == PlayerSkillType.Primary)
            {
                primarySkill = newSkill;    
            }
            else
            {
                secondarySkill = newSkill;
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