using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    private int startArmorClass;
    
    public override void Awake()
    {
        health = maxHealth;
        startArmorClass = armorClass;
    }
    
    public override int Attack()
    {
        CombatLog.Instance.AddLog($"{charName}'s rocky armor crumbles.");
        armorClass--;
        return base.Attack();
    }

    protected override void Die()
    {
        armorClass = startArmorClass;
        base.Die();
    }
}
