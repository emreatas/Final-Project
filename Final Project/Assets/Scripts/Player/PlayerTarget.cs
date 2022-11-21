using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerTarget : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayerMask;
        [SerializeField] private SphereCollider collider;
        [SerializeField] private float targetRadius;
        private List<ITarget> inRangeTargetList = new List<ITarget>();
        
        private ITarget m_CurrentTarget;
        private bool m_PlayerChooseTarget;

        private Camera mainCam;

        private void Start()
        {
            mainCam = Camera.main;
            targetRadius = collider.radius;
        }

        private void Update()
        {
            if (Input.touches.Length > 0)
            {
                var firstTouch = Input.GetTouch(0);

                if (firstTouch.phase == TouchPhase.Began)
                {
                    Debug.Log("Start Raycast");
                    Ray ray = mainCam.ScreenPointToRay(firstTouch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray,out hit, 100,enemyLayerMask))
                    {
                        Debug.Log("Raycast Hit " + hit.transform.name);
                        if (hit.transform.TryGetComponent(out ITarget target))
                        {
                       
                                Debug.Log("Raycast Hit Target");
                                m_PlayerChooseTarget = true;
                                SwitchTarget(target);
                           
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
            }
        }

        private void SetNewTarget(ITarget newTarget)
        {
            if (newTarget != null)
            {
                m_CurrentTarget = newTarget;
                m_CurrentTarget.EnableTargetIndicator();
            }
            else
            {
                m_CurrentTarget = null;
            }
        }
    }
}
