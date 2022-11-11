using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

public class RandomLoot : AbstractSingelton<RandomLoot>
{
    [SerializeField] private ChestLoot loot;

    [SerializeField] private Chest chestPrefab;
    
    public void CreateLoot(Vector3 position)
    {
        var chestLoot = Instantiate(loot);
        var instansiated = Instantiate(chestPrefab, position,Quaternion.identity);
        instansiated.InitializeChest(chestLoot);
    }
}
