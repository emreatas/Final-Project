using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Skills
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Skill/Indicator")]
    public class SkillIndicatorSettings : ScriptableObject
    {
        [HideInInspector] 
        public bool HasRadius;
        [HideInInspector]
        public float radius;
        [HideInInspector]
        public Sprite radiusSprite;
        [HideInInspector]
        public Color radiusColor;
        
        [HideInInspector]
        public bool HasDirection;
        [HideInInspector]
        public float length;
        [HideInInspector]
        public Sprite directionSprite;
        [HideInInspector]
        public Color directionColor;

        [HideInInspector]       
        public bool HasImpact;
        [HideInInspector]
        public float impactRadius;
        [HideInInspector]
        public Sprite impactSprite;
        [HideInInspector]
        public Color impactColor;
        

        public void InitializeIndicator(Transform radiusTransform, Image radiusImage, Transform directionTransform, Image directionImage, Transform impactTransform, Image impactImage)
        {
            InitializeRadiusIndicator(radiusTransform, radiusImage);
            InitializeDirectionIndicator(directionTransform, directionImage);
            InitializeImpactIndicator(impactTransform, impactImage);
        }
        
        public void InitializeRadiusIndicator(Transform radiusTransform, Image radiusImage)
        {
            if (HasRadius)
            {
                radiusImage.sprite = radiusSprite;
                radiusImage.color = radiusColor;
                
                radiusTransform.localScale = new Vector3(radius, radius, 1);
                radiusTransform.gameObject.SetActive(true);
            }
            else
            {
                radiusTransform.gameObject.SetActive(false);
            }
        }

        public void InitializeDirectionIndicator(Transform directionTransform, Image directionImage)
        {
            if (HasDirection)
            {
                directionImage.sprite = directionSprite;
                directionImage.color = directionColor;
                
                directionTransform.localScale = new Vector3(1, 1, length);
                directionTransform.gameObject.SetActive(true);
            }
            else
            {
                directionTransform.gameObject.SetActive(false);
            }
        }
        
        private void InitializeImpactIndicator(Transform impactTransform, Image impactImage)
        {
            if (HasImpact)
            {
                impactImage.sprite = impactSprite;
                impactImage.color = impactColor;

                impactTransform.localScale = new Vector3(impactRadius, impactRadius, 1);
                impactTransform.gameObject.SetActive(true);
            }
            else
            {
                impactTransform.gameObject.SetActive(false);
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