using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string charName;
    [SerializeField] private int health;
    
    [SerializeField] private Weapon currentWeapon;
    
    public Weapon ActiveWeapon { get { return currentWeapon; } }
    
    public string CharName { get => charName; }
    
    public int Health { get => health; }

    public virtual int Attack()
    {
        print(name + " is attacking!");
        return currentWeapon.GetDamage();
    }

    public void GetHit(int damage)
    {
        health -= damage;
        print(name + " got hit for " + damage + " damage! Current health = " + health);
    }
    
    public void GetHit(Weapon weapon)
    {
        health -= weapon.GetDamage();
        print(name + " got hit by" + weapon.name + "! Current health = " + health);
    }
}
