using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Dialogue;
using TMPro;
using UnityEngine.UI;


namespace RPG.UI
{
    public class DialogueUI : MonoBehaviour
    {
        PlayerConversation playerConversation;
        [SerializeField] TextMeshProUGUI AIText;
        [SerializeField] Button nextButton;
        public GameObject closePanel;

        // Start is called before the first frame update
        private void Start()
        {
            playerConversation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversation>();
            nextButton.onClick.AddListener(Next);
        }

        private void Next()
        {
            playerConversation.Next();
            UpdateUI();
        }

        // Update is called once per frame
        private void UpdateUI()
        {
            AIText.text = playerConversation.GetText();
            nextButton.gameObject.SetActive(playerConversation.HasNext());
        }

        public void closingPanel()
        {
            closePanel.gameObject.SetActive(false);
        }
    }
}