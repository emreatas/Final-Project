using Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using System;
using PInventory;
using ItemManager;
public class Data : MonoBehaviour
{
    [Header("Player")]
    public PlayerClass playerClass;
    public PlayerInventory inventory;

    [Header("Item Database")]
    [SerializeField] private List<ItemSettings> itemDataBase;
    [SerializeField] private List<Stat.StatType> statDataBase;

    [Header("Inventory")]
    public List<DataInventoryItem> dataInventoryItems = new List<DataInventoryItem>();
    public List<DataInventoryItem> savedInventory = new List<DataInventoryItem>();
    public List<InventoryItemData> flagInventory;
    public List<InventoryItemData> savedFlagInventory;

    [Header("Equipment")]
    public List<EquipmentSlotTypes> flagEquipmentKeys = new List<EquipmentSlotTypes>();
    public List<InventoryItemData> flagEquipmentValues = new List<InventoryItemData>();
    public Dictionary<EquipmentSlotTypes, InventoryItemData> flagEquipment = new Dictionary<EquipmentSlotTypes, InventoryItemData>();

    void Start()
    {
        StartCoroutine(test());        //EquipmentLoad();
    }

    private void OnApplicationPause(bool pause)
    {
        InventorySave();

    }

    private void OnApplicationQuit()
    {
        //InventorySave();
        //EquipmentSave();
    }

    private void OnDestroy()
    {
        //InventoryLoad();
    }



    private void InventorySave()
    {
        flagInventory = playerClass.PlayerSettings.Inventory.GetInventory;


        if (Time.time < 5)
        {
            return;
        }

        for (int i = 0; i < flagInventory.Count; i++)
        {
            DataInventoryItem datanew = new DataInventoryItem();

            if (flagInventory[i].Item.CanBeStacked)
            {
                datanew.stackCount = flagInventory[i].Count;
            }


            datanew.ItemID = flagInventory[i].Item.ID;
            datanew.ItemTier = (int)flagInventory[i].Item.ItemTier;
            datanew.StatCount = flagInventory[i].Item.Stats.Count;



            for (int j = 0; j < datanew.StatCount; j++)
            {
                if (flagInventory[i].Item.Stats[j] != null)
                {
                    datanew.statsAttributeModifiers[j] = flagInventory[i].Item.Stats[j].TargetStat.ID;
                    datanew.statsBaseValues[j] = flagInventory[i].Item.Stats[j].BaseValue;
                    datanew.statsAttributeType[j] = (int)flagInventory[i].Item.Stats[j].BaseAttributeType;

                }
            }

            dataInventoryItems.Add(datanew);
        }

        JSONSystem.JSONSaveSystem.SaveToJSON(dataInventoryItems, true, "IInventory");
    }
    private void InventoryLoad()
    {
        Debug.Log("-----------------a---------------");
        savedInventory = JSONSystem.JSONSaveSystem.ReadFromJson<DataInventoryItem>("IInventory");

        if (savedInventory.Count <= 0)
        {
            return;
        }
        Debug.Log(savedInventory[0].ItemID);
        Debug.Log("----------------b-------------");


        for (int i = 0; i < savedInventory.Count; i++)
        {
            for (int j = 0; j < itemDataBase.Count; j++)
            {
                if (savedInventory[i].ItemID == itemDataBase[j].ID)
                {
                    Item item = new Item(
                        itemDataBase[j].ID,
                        itemDataBase[j].ItemName,
                        itemDataBase[j].Icon,
                        itemDataBase[j].CanBeStacked,
                        itemDataBase[j].ItemTierSprite
                        );

                    InventoryItemData inventoryItem = new InventoryItemData(item, savedInventory[i].stackCount);

                    for (int k = 0; k < savedInventory[i].StatCount; k++)
                    {
                        for (int t = 0; t < statDataBase.Count; t++)
                        {
                            if (savedInventory[i].statsAttributeModifiers[k] == statDataBase[t].ID)
                            {

                                Stat.AttributeModifier attributeModifier = new Stat.AttributeModifier(
                                   savedInventory[i].statsBaseValues[k],
                                   statDataBase[t],
                                   (Stat.AttributeType)savedInventory[i].statsAttributeType[k]
                                   );

                                inventoryItem.Item.Stats.Add(attributeModifier);
                            }
                        }
                    }

                    inventoryItem.Item.ItemTier = (ItemTier)savedInventory[i].ItemTier;
                    inventoryItem.Item.ItemTierColor = ItemTierManager.GetTierColor(inventoryItem.Item.ItemTier);

                    savedFlagInventory.Add(inventoryItem);
                }
            }
        }
        //Debug.Log("orj" + playerClass.PlayerSettings.Inventory.GetInventory.Count);
        //Debug.Log("flag" + savedFlagInventory.Count);
        //playerClass.PlayerSettings.Inventory.GetInventory.AddRange(savedFlagInventory);
        //Debug.Log("endorj" + playerClass.PlayerSettings.Inventory.GetInventory.Count);

        for (int i = 0; i < savedFlagInventory.Count; i++)
        {
            inventory.AddItemToInventory(savedFlagInventory[i]);
        }

    }
    private void EquipmentSave()
    {
        flagEquipment = playerClass.PlayerSettings.Equipment.GetEquipment;
        flagEquipmentKeys = flagEquipment.Keys.ToList();
        flagEquipmentValues = flagEquipment.Values.ToList();



    }

    private void EquipmentLoad()
    {

    }


    IEnumerator test()
    {
        yield return new WaitForSeconds(1f);

        InventoryLoad();
    }

}



[System.Serializable]
public class DataInventoryItem
{
    public int ItemID;
    public int ItemTier;
    public int stackCount;
    public int StatCount;
    public int[] statsAttributeModifiers = new int[3];
    public float[] statsBaseValues = new float[3];
    public int[] statsAttributeType = new int[3];
}

[System.Serializable]
public class DataEquipmentItem
{
    public int EquipmentSlot;
    public int ItemID;
    public int ItemTier;
    public int stackCount;
    public int StatCount;
    public int[] statsAttributeModifiers = new int[3];
    public float[] statsBaseValues = new float[3];
    public int[] statsAttributeType = new int[3];
}