using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private int aggression = 5;

    public enum EnemyType
    {
        Goblin,
        Insect,
        Mutant,
        Dinosaur
    }

    [SerializeField] private EnemyType type;
}
