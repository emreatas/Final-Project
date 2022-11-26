using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PlayerTarget : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayerMask;
        [SerializeField] private SphereCollider collider;

        
        private List<Target> inRangeTargetList = new List<Target>();
        
        private Target m_CurrentTarget;
        private bool m_PlayerChooseTarget;

        private Camera mainCam;

        public bool HasTarget => m_CurrentTarget != null;
        
        
        public Vector3 GetTargetDirection()
        {
            if (HasTarget)
            {
                return (m_CurrentTarget.Position - transform.position);
            }

            return Vector3.zero;
        }

        public Target GetTarget()
        {
            return m_CurrentTarget;
        }
        
        private void Start()
        {
            mainCam = Camera.main;
        }

        private bool IsPointerOverUIObject()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }
        
        private void Update()
        {
            if (Input.touches.Length > 0)
            {
                var firstTouch = Input.GetTouch(0);

                if (!IsPointerOverUIObject())
                {
                    if (firstTouch.phase == TouchPhase.Began)
                    {
                        Ray ray = mainCam.ScreenPointToRay(firstTouch.position);
                        RaycastHit hit;
                        if (Physics.Raycast(ray,out hit, 100,enemyLayerMask))
                        {
                            if (hit.transform.TryGetComponent(out Target target))
                            {
 
                                m_PlayerChooseTarget = true;
                                SwitchTarget(target);
                            }
                        }
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Target target))
            {
                if (!inRangeTargetList.Contains(target))
                {
                    inRangeTargetList.Add(target);
                }
                
                if (m_CurrentTarget == null)
                {
                    SwitchTarget(target);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Target target))
            {
                if (inRangeTargetList.Contains(target))
                {
                    inRangeTargetList.Remove(target);
                }
                
                if (target == m_CurrentTarget)
                {
                    if (m_PlayerChooseTarget)
                    {
                        m_PlayerChooseTarget = false;
                    }
                    
                    Target newTarget = GetClosestTarget();
                    SwitchTarget(newTarget);
                }
            }
        }

        private Target GetClosestTarget()
        {
            if (inRangeTargetList.Count > 0)
            {
                Target closestTarget = inRangeTargetList[0];
                float targetDistance = (transform.position - inRangeTargetList[0].Position).sqrMagnitude;

                for (int i = 0; i < inRangeTargetList.Count; i++)
                {
                    float distance = (transform.position - inRangeTargetList[i].Position).sqrMagnitude;
                    if (distance < targetDistance)
                    {
                        closestTarget = inRangeTargetList[i];
                        targetDistance = (transform.position - inRangeTargetList[i].Position).sqrMagnitude;
                    }
                }

                return closestTarget;
            }

            return null;
        }
        
        private void SwitchTarget(Target newTarget)
        {
            DisableCurrentTarget();
            SetNewTarget(newTarget);
        }

        private void DisableCurrentTarget()
        {
            if (m_CurrentTarget != null)
            {
                m_CurrentTarget.DisableTargetIndicator();
                RemoveListeners();
                m_CurrentTarget = null;
            }
        }

        private void SetNewTarget(Target newTarget)
        {
            if (newTarget != null)
            {
                m_CurrentTarget = newTarget;
                AddListeners();
                m_CurrentTarget.EnableTargetIndicator();
            }
        }

        private void HandleOnPlayerDeath()
        {
            if (inRangeTargetList.Contains(m_CurrentTarget))
            {
                inRangeTargetList.Remove(m_CurrentTarget);
            }
            m_CurrentTarget = null;
        }

        private void AddListeners()
        {
            m_CurrentTarget.OnDestroyed.AddListener(HandleOnPlayerDeath);
        }

        private void RemoveListeners()
        {
            m_CurrentTarget.OnDestroyed.RemoveListener(HandleOnPlayerDeath);
        }
    }
}
