using System;
using System.Collections.Generic;
using MEC;
using Skills;
using UnityEngine;

namespace Player
{
    public class PlayerSkillController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private SkillIndicator skillIndicator;
        
        [SerializeField] private AbstractSkill basicSkill;
        [SerializeField] private AbstractSkill primarySkill;
        [SerializeField] private AbstractSkill secondarySkill;

        public AbstractSkill BasicSkill => basicSkill;
        public AbstractSkill PrimarySkill => primarySkill;
        public AbstractSkill SecondarySkill => secondarySkill;
        
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
        
        private void InitializeSkill(ref AbstractSkill skill)
        {
            float dmg = playerStats.GetValue(skill.damageStatType);
            float attackSpeed = playerStats.GetValue(skill.attackSpeedStatType);
            skill.SetAttributes(dmg, attackSpeed);
            
            skill.SetPlayerTransform(transform);
        }

        public void StartSecondarySkill(Vector3 skillVector)
        {
   
        }

        public void PerformSecondarySkill(Vector3 skillVector)
        {
            // secondarySkill.PerformSkill(transform);
        }

        public void CancelSecondarySkill(Vector3 skillVector)
        {
         
        }
        
    }
}