using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int strengthGain = 5;
    private int additionalStrength;
    
    public override void Awake()
    {
        health = maxHealth;
        additionalStrength = 0;
    }
    
    public override int Attack()
    {
        CombatLog.Instance.AddLog($"{charName} flexes and gains {strengthGain} strength!");
        additionalStrength += strengthGain;
        return ActiveWeapon.GetDamage() + strength + additionalStrength;
    }
}
