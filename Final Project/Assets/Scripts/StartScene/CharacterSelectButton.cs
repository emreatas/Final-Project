using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour
{
   [SerializeField] private Image characterIcon;
   [SerializeField] private TextMeshProUGUI levelText;
   [SerializeField] private TextMeshProUGUI nameText;

   public void InitButton(Sprite icon, int level, string name)
   {
      characterIcon.sprite = icon;
      levelText.text = $"LEVEL : {level}";
      nameText.text = name;
   }
}
