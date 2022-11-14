using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skill/Indicator")]
    public class SkillIndicatorSettings : ScriptableObject
    {
        public bool HasRadius;
        public float radius;
        public Sprite radiusSprite;
        public Color radiusColor;

        public bool HasDirection;
        public float length;
        public Sprite directionSprite;
        public Color directionColor;
        
        public bool HasImpact;
        public float impactRadius;
        public Sprite impactSprite;
        public Color impactColor;
        
        public void InitializeIndicator(DecalProjector radiusDeccal, DecalProjector directionDecal, DecalProjector impactDecal,  Transform directionDecalParent)
        {
            InitializeRadiusIndicator(radiusDeccal);
            InitializeDirectionIndicator(directionDecal, directionDecalParent);
            InitializeImpactIndicator(impactDecal);
        }
        
        public void InitializeRadiusIndicator(DecalProjector radiusDecal)
        {
            if (HasRadius)
            {
                radiusDecal.material.color = radiusColor;
                
                radiusDecal.gameObject.transform.localScale = new Vector3(radius, radius, 1);
                radiusDecal.gameObject.SetActive(true);
            }
            else
            {
                radiusDecal.gameObject.SetActive(false);
            }
        }

        public void InitializeDirectionIndicator(DecalProjector directionDecal, Transform directionDecalParent)
        {
            if (HasDirection)
            {
                directionDecal.material.color = directionColor;

                directionDecalParent.localScale = new Vector3(length,1,length );
                directionDecal.gameObject.SetActive(true);
            }
            else
            {
                directionDecal.gameObject.SetActive(false);
            }
        }
        
        private void InitializeImpactIndicator(DecalProjector impactDecal)
        {
            if (HasImpact)
            {
                impactDecal.material.color = impactColor;

                impactDecal.gameObject.transform.localScale = new Vector3(impactRadius, impactRadius, 1);
                impactDecal.gameObject.SetActive(true);
            }
            else
            {
                impactDecal.gameObject.SetActive(false);
            }
        }
        
        public void UpdateIndicator(Transform playerTransform ,Transform indicatorTransform, Transform impactTransform, Vector3 direction)
        {
            if (HasDirection)
            {
                indicatorTransform.LookAt(indicatorTransform.position + direction);
            }

            if (HasImpact)
            {
                impactTransform.position = GetImpactPosition(playerTransform, direction);
            }
        }
        
        public Vector3 GetImpactPosition(Transform playerTransform, Vector3 direction)
        {
            Vector3 impactPos = playerTransform.position + (direction * radius / 2);
            return impactPos;
        }
    } 
}