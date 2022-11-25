using System.Collections;
using System.Collections.Generic;
using Stat;
using UnityEngine;

public class StartScreenCharacter : MonoBehaviour
{
    [SerializeField] private CharacterTypes _characterTypes;

    public CharacterTypes CharacterType => _characterTypes;
}
