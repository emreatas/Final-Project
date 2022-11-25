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
        [SerializeField] private WeaponSelector weaponSelector;
        
        
        [SerializeField] private AbstractNewSkillSettings basicSkillSettings;
        [SerializeField] private AbstractNewSkillSettings primarySkillSettings;
        [SerializeField] private AbstractNewSkillSettings secondarySkillSettings;

        public PlayerTarget PlayerTarget => _playerTarget;
        public WeaponSelector WeaponSelector => weaponSelector;
        public PlayerLevel PlayerLevel => playerLevel; 
        public PlayerStats PlayerStats => playerStats;
        public Vector3 ShootDirection => m_ShootDirection;
        public PlayerAnimationController PlayerAnimationController => animationController;

        public AbstractNewSkillSettings BasicSkillSettings
        {
            get => basicSkillSettings;
            set => basicSkillSettings = value;
        } 
        public AbstractNewSkillSettings PrimarySkillSettings 
        {
            get => primarySkillSettings;
            set => primarySkillSettings = value;
        }
        public AbstractNewSkillSettings SecondarySkillSettings   
        {
            get => secondarySkillSettings;
            set => secondarySkillSettings = value;
        }
        

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
            m_ActiveSkill = basicSkillSettings;
            FindShootDirection(Vector3.zero);
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
            Debug.Log("SHot Dir + " + m_ShootDirection);
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
        
            DisableSkillIndicator();

            skillSettings.StartSkill(this);
        }
        
        public void CastActiveSkill()
        {
            m_ActiveSkill.ExecuteSkill(this);
        }

        public void DisableSkillIndicator()
        {
            skillIndicator.DisableSkillIndicator();
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
                    m_ShootDirection = _playerTarget.GetTargetDirection();
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
            Debug.Log("On Changed SKill");
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
            SkillEquipUI.OnEquipSkill.AddListener(HandleOnSkillChanged);
        }

        private void RemoveListeners()
        {
            //CanvasScript.OnSkillChanged.RemoveListener(HandleOnSkillChanged);
            SkillEquipUI.OnEquipSkill.RemoveListener(HandleOnSkillChanged);
        }
    }
}