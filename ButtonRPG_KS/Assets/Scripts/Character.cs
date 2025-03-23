using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected string charName;
    public string CharName { get => charName; }
    [SerializeField] protected int maxHealth;
    protected int health;
    public int Health { get => health; }
    
    [SerializeField] protected int strength;
    public int Strength { get => strength; }
    
    [SerializeField] protected int armorClass;
    public int ArmorClass { get => armorClass; }
    
    [SerializeField] private Weapon currentWeapon;
    public Weapon ActiveWeapon { get { return currentWeapon; } }

    
    public virtual void Awake()
    {
        health = maxHealth;
    }
    
    public virtual int Attack()
    {
        return currentWeapon.GetDamage() + strength;
    }

    public virtual void GetHit(int damage, string hitCulprit = "Character")
    {
        CombatLog.Instance.AddLog($"{hitCulprit} tries to hit {charName}!");

        if (GameManager.RollD20(hitCulprit) >= armorClass) // roll for the attack hitting like it's DnD
        {
            health -= damage;
            CombatLog.Instance.AddLog($"{charName} got hit for {damage} damage!");
        }
        else
        {
            CombatLog.Instance.AddLog($"{hitCulprit}'s attack misses!");
        }
        
        
        if (health <= 0)
        {
            Die();
        }
    }
    
    public virtual void GetHit(int damage, Enemy hitCulprit)
    {
        CombatLog.Instance.AddLog($"{hitCulprit.charName} tries to hit {charName}!");

        if (GameManager.RollD20(hitCulprit.CharName) >= armorClass) // roll for the attack hitting like it's DnD
        {
            health -= damage;
            CombatLog.Instance.AddLog($"{charName} got hit for {damage} damage by {hitCulprit.CharName}'s {hitCulprit.ActiveWeapon.weaponName}!");
        }
        else
        {
            CombatLog.Instance.AddLog($"{hitCulprit}'s attack misses!");
        }
        
        
        if (health <= 0)
        {
            Die();
        }
    }
    
    protected abstract void Die();
}
