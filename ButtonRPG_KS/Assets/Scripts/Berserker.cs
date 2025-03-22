using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int aggressionGain = 5;
    
    public override int Attack()
    {
        strength += aggressionGain;
        return strength / 10;
    }
}
