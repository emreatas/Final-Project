//using System.Collections;
//using System.Collections.Generic;
//using Skills;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif
//using UnityEngine;
//#if UNITY_EDITOR
//namespace MyCustomEditor
//{

//    [CustomEditor(typeof(SkillIndicatorSettings))]
//    public class SkillIndicatorSettings_Editor : Editor
//    {
//        public override void OnInspectorGUI()
//        {
//            DrawDefaultInspector();

//            SkillIndicatorSettings skillSettings = (SkillIndicatorSettings)target;

//            EditorGUILayout.LabelField("Radius");
//            skillSettings.HasRadius = EditorGUILayout.Toggle("Has Radius", skillSettings.HasRadius);
//            if (skillSettings.HasRadius)
//            {
//                skillSettings.radius = EditorGUILayout.FloatField("Radius", skillSettings.radius);
//                skillSettings.radiusColor = EditorGUILayout.ColorField("Radius Color", skillSettings.radiusColor);
//                skillSettings.radiusSprite = EditorGUILayout.ObjectField("Radius Sprite", skillSettings.radiusSprite, typeof(Sprite), true) as Sprite;



//                EditorGUILayout.Space();
//                EditorGUILayout.Space();
//                EditorGUILayout.LabelField("Impact");
//                skillSettings.HasImpact = EditorGUILayout.Toggle("Has Impact", skillSettings.HasImpact);
//                if (skillSettings.HasImpact)
//                {
//                    skillSettings.impactRadius = EditorGUILayout.FloatField("Impact Radius", skillSettings.impactRadius);
//                    skillSettings.impactColor = EditorGUILayout.ColorField("Impact Color", skillSettings.impactColor);
//                    skillSettings.impactSprite = EditorGUILayout.ObjectField("Impact Sprite", skillSettings.impactSprite, typeof(Sprite), true) as Sprite;

//                }
//            }
//            EditorGUILayout.Space();
//            EditorGUILayout.Space();
//            EditorGUILayout.LabelField("Direction");
//            skillSettings.HasDirection = EditorGUILayout.Toggle("Has Direction", skillSettings.HasDirection);
//            if (skillSettings.HasDirection)
//            {
//                skillSettings.length = EditorGUILayout.FloatField("Direction Length", skillSettings.length);
//                skillSettings.directionColor = EditorGUILayout.ColorField("Direction Color", skillSettings.directionColor);
//                skillSettings.directionSprite = EditorGUILayout.ObjectField("Direction Sprite", skillSettings.directionSprite, typeof(Sprite), true) as Sprite;

//            }

//        }
//    }

//}
//#endif