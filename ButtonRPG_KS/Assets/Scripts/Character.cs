using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string charName;
    [SerializeField] private int health;

    public void Attack()
    {
        print("Attack!! from " + name);
    }
    
    public string CharName { get => charName; }
}
