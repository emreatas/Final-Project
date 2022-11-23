using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public interface IHealth
{
    public float Health { get; }
    public void TakeDamage(float damage, GameObject damageGiver);
}

