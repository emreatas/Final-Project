using System;
using System.Collections.Generic;
using MEC;
using Skills;
using UnityEngine;

namespace Player
{
    public class PlayerSkillController : MonoBehaviour
    {
        [SerializeField] private PlayerInputSystem inputSystem;
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
            basicSkill.StartSkill();
        }

        public void PerformBasicSkill()
        {
            float dmg = playerStats.GetValue(basicSkill.damageStatType);
            float attackSpeed = playerStats.GetValue(basicSkill.attackSpeedStatType);
            basicSkill.SetAttributes(dmg, attackSpeed);
            
            basicSkill.SetPlayerTransform(transform);
            Vector3 targetPos = basicSkill.FindTargetPosition();
            movementController.LerpPlayerRotation(targetPos);
        }

        public void CastBasicSkill()
        {
            basicSkill.CastSkill();
        }

        public void CancelBasicSkill()
        {
            basicSkill.CancelSkill();
        }

        public void OnFinishedBasicSkill()
        {
            basicSkill.OnFinishedSkillAnimation();
        }
        
        public void StartPrimarySkill(Vector3 skillDirection)
        {
            skillIndicator.DisableSkillIndicator();
            primarySkill.ShootDirection = skillDirection;
            movementController.LerpPlayerRotation(transform.position + skillDirection);
        }

        public void PerformPrimarySkill(Vector3 skillVector)
        {
            primarySkill.ShowSkillIndicator(skillIndicator, skillVector);
            primarySkill.PerformSkill(skillVector);
        }
        
        public void CastPrimarySkill()
        {
            float dmg = playerStats.GetValue(primarySkill.damageStatType);
            float attackSpeed = playerStats.GetValue(primarySkill.attackSpeedStatType);
            primarySkill.SetAttributes(dmg, attackSpeed);
            
            primarySkill.SetPlayerTransform(transform);
            primarySkill.CastSkill();
        }
        
        public void OnFinishedPrimarySkill()
        {
            primarySkill.OnFinishedSkillAnimation();
        }

        public void StartSecondarySkill(Vector3 skillVector)
        {
            secondarySkill.StartSkill();
        }

        public void PerformSecondarySkill(Vector3 skillVector)
        {
            // secondarySkill.PerformSkill(transform);
        }

        public void CancelSecondarySkill(Vector3 skillVector)
        {
            secondarySkill.CancelSkill();
            // Timing.RunCoroutine(_CastSpells(secondarySkill.SkillDuration, secondarySkill.FinishedSkill));
        }
        
        
        private IEnumerator<float> _CastSpells(float duration, Action FinishedSkillFunc)
        {
            yield return Timing.WaitForSeconds(duration);

            FinishedSkillFunc();
        }
    }
}