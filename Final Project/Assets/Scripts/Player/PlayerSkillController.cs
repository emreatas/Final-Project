using System;
using System.Collections;
using System.Collections.Generic;
using Skills;
using UnityEngine;

namespace Player
{
    public class PlayerSkillController : MonoBehaviour
    {
        [SerializeField] private PlayerInputSystem inputSystem;

        [SerializeField] private AbstractSkill primarySkill;
        [SerializeField] private AbstractSkill secondarySkill;

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            
            RemoveListeners();
        }
        
        private void HandleOnPrimarySkillStarted(Vector3 skillVector)
        {
            primarySkill.StartSkill();
        }

        private void HandleOnPrimarySkillPerformed(Vector3 skillVector)
        {
            primarySkill.PerformSkill();
        }

        private void HandleOnPrimarySkillCanceled(Vector3 skillVector)
        {
            primarySkill.CancelSkill();
        }
        
        private void HandleOnSecondarySkillStarted(Vector3 skillVector)
        {
            secondarySkill.StartSkill();
        }

        private void HandleOnSecondarySkillPerformed(Vector3 skillVector)
        {
            secondarySkill.PerformSkill();
        }

        private void HandleOnSecondarySkillCanceled(Vector3 skillVector)
        {
            secondarySkill.CancelSkill();
        }
        
        private void AddListeners()
        {
            inputSystem.OnPrimarySkillStarted.AddListener(HandleOnPrimarySkillStarted);
            inputSystem.OnPrimarySkillPerfomed.AddListener(HandleOnPrimarySkillPerformed);
            inputSystem.OnPrimarySkillCanceled.AddListener(HandleOnPrimarySkillCanceled);
            
            inputSystem.OnSecondarySkillStarted.AddListener(HandleOnSecondarySkillStarted);
            inputSystem.OnSecondarySkillPerfomed.AddListener(HandleOnSecondarySkillPerformed);
            inputSystem.OnSecondarySkillCanceled.AddListener(HandleOnSecondarySkillCanceled);
        }

        private void RemoveListeners()
        {
            inputSystem.OnPrimarySkillStarted.RemoveListener(HandleOnPrimarySkillStarted);
            inputSystem.OnPrimarySkillPerfomed.RemoveListener(HandleOnPrimarySkillPerformed);
            inputSystem.OnPrimarySkillCanceled.RemoveListener(HandleOnPrimarySkillCanceled);
            
            inputSystem.OnSecondarySkillStarted.RemoveListener(HandleOnSecondarySkillStarted);
            inputSystem.OnSecondarySkillPerfomed.RemoveListener(HandleOnSecondarySkillPerformed);
            inputSystem.OnSecondarySkillCanceled.RemoveListener(HandleOnSecondarySkillCanceled);
        }
    }
}