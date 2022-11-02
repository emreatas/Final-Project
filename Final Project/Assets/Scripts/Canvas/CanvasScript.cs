using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject interactButton;
    [SerializeField] private GameObject interactItemPanel;

    private void OnEnable()
    {
        CanvasManager.InteractableStart += CanvasManager_InteractableStart1;
        CanvasManager.ItemDropPanelStart += CanvasManagerOnItemDropPanelStart;

    }

    private void CanvasManagerOnItemDropPanelStart(bool obj)
    {
        interactItemPanel.SetActive(obj);
    }

    private void CanvasManager_InteractableStart1(bool obj)
    {
        interactButton.SetActive(obj);

    }


    private void OnDisable()
    {
        CanvasManager.InteractableStart -= CanvasManager_InteractableStart1;
        CanvasManager.ItemDropPanelStart -= CanvasManagerOnItemDropPanelStart;
    }

    public void Inventory(GameObject inventoryPanel)
    {
        inventoryPanel.SetActive(true);
    }
    public void CloseButton(GameObject panel)
    {
        panel.SetActive(false);
    }
}
