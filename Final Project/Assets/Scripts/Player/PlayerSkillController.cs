using System;
using System.Collections;
using System.Collections.Generic;
using MEC;
using Skills;
using UnityEngine;

namespace Player
{
    public class PlayerSkillController : MonoBehaviour
    {
        [SerializeField] private PlayerInputSystem inputSystem;

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
            basicSkill.PerformSkill();
            // Timing.RunCoroutine(_CastSpells(basicSkill.SkillDuration, basicSkill.FinishedSkill));
        }

        public void CancelBasicSkill()
        {
            basicSkill.CancelSkill();
        }
        
        public void StartPrimarySkill(Vector3 skillVector)
        {
            primarySkill.StartSkill();
        }

        public void PerformPrimarySkill(Vector3 skillVector)
        {
            primarySkill.PerformSkill();
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
            secondarySkill.PerformSkill();
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