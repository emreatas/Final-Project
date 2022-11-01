using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public void Inventory(GameObject inventoryPanel)
    {
        inventoryPanel.SetActive(true);
    }
    public void CloseButton(GameObject panel)
    {
        panel.SetActive(false);
    }
}
