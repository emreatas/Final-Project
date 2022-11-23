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
        [SerializeField] private PlayerAnimationController animationController;
        [SerializeField] private PlayerLevel playerLevel;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerTarget _playerTarget;
        [SerializeField] private DecalSkillIndicator skillIndicator;

        [SerializeField] private AbstractNewSkillSettings basicSkillSettings;
        [SerializeField] private AbstractNewSkillSettings primarySkillSettings;
        [SerializeField] private AbstractNewSkillSettings secondarySkillSettings;

        public PlayerLevel PlayerLevel => playerLevel; 
        public PlayerStats PlayerStats => playerStats;
        public Vector3 ShootDirection => m_ShootDirection;
        
        public AbstractNewSkillSettings BasicSkillSettings => basicSkillSettings;
        public AbstractNewSkillSettings PrimarySkillSettings => primarySkillSettings;
        public AbstractNewSkillSettings SecondarySkillSettings => secondarySkillSettings;
        

        private AbstractNewSkillSettings m_ActiveSkill;

        private Vector3 m_ShootDirection;
        
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        #region Basic Attack 
        
        public void StartBasicSkill()
        {
            m_ActiveSkill = primarySkillSettings;
            basicSkillSettings.StartSkill(this);
        }
        
        #endregion

        #region PrimarySkill
        
        public void PerformPrimarySkill(Vector3 skillVector)
        {
            FindShootDirection(skillVector);
            ShowSkillIndicator(primarySkillSettings);
        }

        public void StartPrimarySkill(Vector3 skillDirection)
        {
            StartSkill(ref primarySkillSettings);
        }
        
        #endregion

        #region SecondarySkill
        
        public void PerformSecondarySkill(Vector3 skillVector)
        {
            FindShootDirection(skillVector);
            ShowSkillIndicator(secondarySkillSettings);
        }

        public void StartSecondarySkill(Vector3 skillDirection)
        {
            StartSkill(ref secondarySkillSettings);
        }
        
        #endregion

        private void StartSkill(ref AbstractNewSkillSettings skillSettings)
        {
            m_ActiveSkill = skillSettings;
            
            skillIndicator.DisableSkillIndicator();
    
            skillSettings.StartSkill(this);
        }
        
        public void CastActiveSkill()
        {
            m_ActiveSkill.ExecuteSkill(this);
        }
        
        private void ShowSkillIndicator(AbstractNewSkillSettings skillSettings)
        {
            skillIndicator.ShowSkillIndicator(skillSettings, m_ShootDirection);
        }
        
        private void FindShootDirection(Vector3 skillVector)
        {
            m_ShootDirection = transform.forward.normalized;
            
            if (skillVector == Vector3.zero)
            {
                if (_playerTarget.HasTarget)
                {
                    m_ShootDirection = _playerTarget.GetTargetDirection().normalized;
                }
            }
            else
            {
                m_ShootDirection = skillVector;
            } 
        }

        public void RotatePlayer()
        {
            Debug.Log("Shoot Dir " + m_ShootDirection);
            movementController.LerpPlayerRotation(m_ShootDirection);
        }
        
        private void HandleOnSkillChanged(AbstractNewSkillSettings newSkillSettings)
        {
            if(newSkillSettings.skillType == PlayerSkillType.Primary)
            {
                primarySkillSettings = newSkillSettings;
            }
            else
            {
                secondarySkillSettings = newSkillSettings;
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