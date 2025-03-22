using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected string charName;
    public string CharName { get => charName; }
    [SerializeField] protected int maxHealth;
    protected int health;
    public int Health { get => health; }
    
    [SerializeField] protected TMP_Text strengthText;
    [SerializeField] protected int strength;
    [SerializeField] protected TMP_Text armorValueText;
    [SerializeField] protected int baseArmorValue;
    
    [SerializeField] private Weapon currentWeapon;
    public Weapon ActiveWeapon { get { return currentWeapon; } }

    
    private void Start()
    {
        health = maxHealth;
    }
    
    public virtual int Attack()
    {
        print(name + " is attacking!");
        return currentWeapon.GetDamage() + strength;
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

    protected virtual void UpdateCharacterText()
    {
        strengthText.text = $"Strength: {strength}";
        armorValueText.text = $"Armor value: {armorValueText}";
    }
    
    protected abstract void Die();
}
