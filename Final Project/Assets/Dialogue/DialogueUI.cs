using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Dialogue;
using TMPro;

namespace RPG.UI
{
    public class DialogueUI : MonoBehaviour
    {
        PlayerConversation playerConversation;
        [SerializeField] TextMeshProUGUI AIText;

        // Start is called before the first frame update
        void Start()
        {
            playerConversation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversation>();
            AIText.text = playerConversation.GetText();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}