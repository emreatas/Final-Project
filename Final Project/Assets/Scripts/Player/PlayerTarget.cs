using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PlayerTarget : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayerMask;
        [SerializeField] private SphereCollider collider;

        
        private List<ITarget> inRangeTargetList = new List<ITarget>();
        
        private ITarget m_CurrentTarget;
        private bool m_PlayerChooseTarget;

        private Camera mainCam;

        public bool HasTarget => m_CurrentTarget != null;
        
        
        public Vector3 GetTargetDirection()
        {
            Debug.Log("Direction" + (m_CurrentTarget.Position - transform.position));
            return (m_CurrentTarget.Position - transform.position);
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
                            if (hit.transform.TryGetComponent(out ITarget target))
                            {
 
                                m_PlayerChooseTarget = true;
                                SwitchTarget(target);
                            }
                        }
                        else
                        {
                            m_PlayerChooseTarget = false;
                            DisableCurrentTarget();
                        }
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ITarget target))
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
            if (other.TryGetComponent(out ITarget target))
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
                    
                    ITarget newTarget = GetClosestTarget();
                    SwitchTarget(newTarget);
                }
            }
        }

        private ITarget GetClosestTarget()
        {
            if (inRangeTargetList.Count > 0)
            {
                ITarget closestTarget = inRangeTargetList[0];
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
        
        private void SwitchTarget(ITarget newTarget)
        {
            DisableCurrentTarget();
            SetNewTarget(newTarget);
        }

        private void DisableCurrentTarget()
        {
            if (m_CurrentTarget != null)
            {
                m_CurrentTarget.DisableTargetIndicator();
                m_CurrentTarget = null;
            }
        }

        private void SetNewTarget(ITarget newTarget)
        {
            if (newTarget != null)
            {
                m_CurrentTarget = newTarget;
                m_CurrentTarget.EnableTargetIndicator();
            }
        }
    }
}
