using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject interactButton;

    private void OnEnable()
    {
        CanvasManager.InteractableStart += CanvasManager_InteractableStart1;

    }

    private void CanvasManager_InteractableStart1(bool obj)
    {
        interactButton.SetActive(obj);

    }


    private void OnDisable()
    {
        CanvasManager.InteractableStart -= CanvasManager_InteractableStart1;

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
