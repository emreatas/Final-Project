using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewInventory
{
    public class PlayerInventory : MonoBehaviour
    {
        public InventoryObject inventory;

        private void OnTriggerEnter(Collider other)
        {

            var item = other.GetComponent<Item>();
            if (item)
            {
                inventory.AddItem(item.item, 1);
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inventory.Save();
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                inventory.Load();
            }
        }
    }
}