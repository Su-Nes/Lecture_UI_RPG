using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int aggressionGain = 5;
    
    public override int Attack()
    {
        aggression += aggressionGain;
        return aggression / 10;
    }
}
