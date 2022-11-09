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
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private GameObject skillIndicator;
        
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
            float dmg = playerStats.GetValue(basicSkill.statType);
            Debug.Log(" Damageee " + dmg);
            basicSkill.SetDamage(dmg);
            Timing.RunCoroutine(basicSkill.PerformSkillCoroutine(transform));
            // StartCoroutine(basicSkill.PerformSkill(transform));
            // Timing.RunCoroutine(_CastSpells(basicSkill.SkillDuration, basicSkill.FinishedSkill));
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
        
        public void StartPrimarySkill()
        {
            primarySkill.StartSkill();
        }

        public void PerformPrimarySkill(Vector3 skillVector)
        {
            primarySkill.PerformSkill(skillVector);
        }

        public void CancelPrimarySkill(Vector3 skillVector)
        {
            primarySkill.CancelSkill();
            // Timing.RunCoroutine(_CastSpells(primarySkill.SkillDuration, primarySkill.FinishedSkill));
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