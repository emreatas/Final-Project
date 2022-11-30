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
        [SerializeField] GameObject AIResponse;
        [SerializeField] Button nextButton;
        [SerializeField] Transform choiceRoot;
        [SerializeField] GameObject choicePrefab;

        public GameObject closePanel;

        // Start is called before the first frame update
        private void Start()
        {
            playerConversation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversation>();
            nextButton.onClick.AddListener(Next);

            UpdateUI();
        }

        private void Next()
        {
            playerConversation.Next();
            UpdateUI();
        }

        // Update is called once per frame
        private void UpdateUI()
        {
            AIResponse.SetActive(!playerConversation.IsChoosing());
            choiceRoot.gameObject.SetActive(playerConversation.IsChoosing());

            if (playerConversation.IsChoosing())
            {
                BuildChoiceList();
            }
            else
            {
                AIText.text = playerConversation.GetText();
                nextButton.gameObject.SetActive(playerConversation.HasNext());
            }
        }
        private void BuildChoiceList()
        {
            foreach (Transform item in choiceRoot)
            {
                Destroy(item.gameObject);
            }

            foreach (DialogueNode choice in playerConversation.GetChoices())
            {
                GameObject choiceInstance = Instantiate(choicePrefab, choiceRoot);
                var textComp = choiceInstance.GetComponentInChildren<TextMeshProUGUI>();
                textComp.text = choice.GetText();
                Button button = choiceInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(() =>
                {
                    playerConversation.SelectChoice(choice);
                    UpdateUI();
                });
            }
        }
        public void closingPanel()
        {
            closePanel.gameObject.SetActive(false);
        }
    }
}