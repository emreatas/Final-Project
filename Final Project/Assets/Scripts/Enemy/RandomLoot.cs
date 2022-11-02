using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    [SerializeField] private ChestLoot loot;

    [SerializeField] private Chest chestPrefab;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CreateLoot();
        }
    }

    private void CreateLoot()
    {
        var chestLoot = Instantiate(loot);
        var instansiated = Instantiate(chestPrefab, new Vector3(0,0,0),Quaternion.identity);
        instansiated.InitializeChest(chestLoot);
    }
}
