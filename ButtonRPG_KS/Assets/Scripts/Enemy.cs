using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected int aggression = 10;

    public enum EnemyType
    {
        Goblin,
        Insect,
        Mutant,
        Dinosaur
    }

    [SerializeField] private EnemyType type;
}
